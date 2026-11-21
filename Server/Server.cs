using Microsoft.Data.SqlClient;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    public partial class Server : Form
    {
        private const string DbConnectionString =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SampleDatabase;Integrated Security=True";
        private readonly object sessionsLock = new();
        private readonly List<ChatSession> sessions = new();
        private readonly Dictionary<int, ActiveRoom> activeRooms = new();
        private Socket? server;
        private volatile bool closing;

        // Khởi tạo server và bắt đầu lắng nghe client.
        public Server()
        {
            InitializeComponent();
            Connect();
        }

        // Mở socket server và bắt đầu nhận kết nối.
        private void Connect()
        {
            try
            {
                EnsureChatTables();
                server = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);
                server.Bind(new IPEndPoint(IPAddress.Any, 9999));
                server.Listen(100);
                new Thread(ListenForClients) { IsBackground = true }.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không khởi động được server: " + ex.Message,
                    "Lỗi server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Chấp nhận client mới và tạo luồng xử lý.
        private void ListenForClients()
        {
            while (!closing && server != null)
            {
                try
                {
                    Socket client = server.Accept();
                    new Thread(() => HandleClient(client)) { IsBackground = true }.Start();
                }
                catch
                {
                    if (!closing) AddMessage("Lỗi khi nhận kết nối client.");
                    break;
                }
            }
        }

        // Xác thực client và xử lý các lệnh chat.
        private void HandleClient(Socket client)
        {
            ChatSession? session = null;
            try
            {
                var stream = new NetworkStream(client, ownsSocket: false);
                using var reader = new StreamReader(stream, Encoding.UTF8, false, 1024, leaveOpen: true);
                using var writer = new StreamWriter(stream, new UTF8Encoding(false)) { AutoFlush = true };

                string[] auth = (reader.ReadLine() ?? "").Split('|', 2);
                if (auth.Length != 2 || auth[0] != "AUTH" || !AccountExists(auth[1]))
                {
                    writer.WriteLine("DENIED");
                    return;
                }

                session = new ChatSession(client, auth[1], writer);
                lock (sessionsLock) sessions.Add(session);
                session.Send("OK|AUTH");
                AddMessage($"{session.Email} đã kết nối.");

                string? line;
                while (!closing && (line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith("JOIN|", StringComparison.Ordinal) &&
                        int.TryParse(line.AsSpan(5), out int conversationId))
                    {
                        if (TryGetConversationParticipants(
                            conversationId, session.Email, out string user1, out string user2))
                        {
                            bool created = false;
                            lock (sessionsLock)
                            {
                                if (!activeRooms.ContainsKey(conversationId))
                                {
                                    activeRooms[conversationId] = new ActiveRoom(user1, user2);
                                    created = true;
                                }
                                session.ConversationId = conversationId;
                            }

                            if (created)
                                AddMessage($"Conversation {conversationId}: phòng chat được mở.");
                            session.Send("OK|JOIN");
                        }
                        else session.Send("DENIED");
                    }
                    else if (line.StartsWith("MSG|", StringComparison.Ordinal))
                    {
                        int? currentConversationId;
                        lock (sessionsLock) currentConversationId = session.ConversationId;
                        if (currentConversationId == null ||
                            !CanJoinConversation(currentConversationId.Value, session.Email))
                        {
                            session.Send("DENIED");
                            continue;
                        }

                        string message = line[4..];
                        if (string.IsNullOrWhiteSpace(message)) continue;
                        SaveMessage(currentConversationId.Value, session.Email, message);
                        AddMessage($"{session.Email}: {message}");
                        BroadcastToConversation(currentConversationId.Value,
                            $"MSG|{session.Email}|{message}");
                    }
                }
            }
            catch { /* Client có thể ngắt kết nối */ }
            finally
            {
                if (session != null)
                {
                    List<int> removedRooms;
                    lock (sessionsLock)
                    {
                        sessions.Remove(session);
                        removedRooms = RemoveInactiveRoomsLocked();
                    }

                    AddMessage($"{session.Email} đã ngắt kết nối.");
                    foreach (int roomId in removedRooms)
                        AddMessage($"Conversation {roomId}: phòng chat đã đóng vì cả hai user đều thoát app.");
                }
                try { client.Close(); } catch { }
            }
        }

        // Tạo các bảng chat nếu chúng chưa tồn tại.
        private void EnsureChatTables()
        {
            const string sql = """
                IF OBJECT_ID(N'dbo.Conversations', N'U') IS NULL
                BEGIN
                    CREATE TABLE dbo.Conversations
                    (
                        conversation_id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
                        id_user1 NVARCHAR(320) NOT NULL,
                        id_user2 NVARCHAR(320) NOT NULL,
                        gmail_user1 NVARCHAR(320) NOT NULL,
                        gmail_user2 NVARCHAR(320) NOT NULL,
                        messages NVARCHAR(MAX) NULL,
                        CONSTRAINT UQ_Conversations_UserPair UNIQUE (id_user1, id_user2)
                    );
                END;
                IF OBJECT_ID(N'dbo.ConversationMessages', N'U') IS NULL
                BEGIN
                    CREATE TABLE dbo.ConversationMessages
                    (
                        message_id BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
                        conversation_id INT NOT NULL,
                        sender_email NVARCHAR(320) NOT NULL,
                        message_text NVARCHAR(MAX) NOT NULL,
                        sent_at DATETIME2 NOT NULL
                            CONSTRAINT DF_ConversationMessages_SentAt DEFAULT SYSUTCDATETIME(),
                        CONSTRAINT FK_ConversationMessages_Conversations
                            FOREIGN KEY (conversation_id)
                            REFERENCES dbo.Conversations(conversation_id)
                    );
                END;
                """;
            using var con = new SqlConnection(DbConnectionString);
            using var cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
        }

        // Kiểm tra email có trong bảng tài khoản.
        private bool AccountExists(string email)
        {
            using var con = new SqlConnection(DbConnectionString);
            using var cmd = new SqlCommand(
                "SELECT COUNT(1) FROM dbo.TaiKhoan WHERE email = @email", con);
            cmd.Parameters.Add("@email", SqlDbType.NVarChar, 320).Value = email;
            con.Open();
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        // Lấy hai thành viên và kiểm tra quyền tham gia.
        private bool TryGetConversationParticipants(
            int id, string email, out string user1, out string user2)
        {
            const string sql = """
                SELECT gmail_user1, gmail_user2
                FROM dbo.Conversations
                WHERE conversation_id = @id;
                """;

            using var con = new SqlConnection(DbConnectionString);
            using var cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            con.Open();

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                user1 = reader.GetString(0);
                user2 = reader.GetString(1);
                return string.Equals(user1, email, StringComparison.OrdinalIgnoreCase) ||
                       string.Equals(user2, email, StringComparison.OrdinalIgnoreCase);
            }

            user1 = "";
            user2 = "";
            return false;
        }

        // Chạy khi đã giữ sessionsLock. Phòng chỉ hết hạn khi không còn app
        // nào đang kết nối dưới danh tính của cả hai người tham gia.
        // Xóa phòng khi cả hai user đều offline.
        private List<int> RemoveInactiveRoomsLocked()
        {
            var removed = new List<int>();
            foreach (var pair in activeRooms.ToArray())
            {
                bool user1Online = sessions.Any(s =>
                    string.Equals(s.Email, pair.Value.User1, StringComparison.OrdinalIgnoreCase));
                bool user2Online = sessions.Any(s =>
                    string.Equals(s.Email, pair.Value.User2, StringComparison.OrdinalIgnoreCase));

                if (!user1Online && !user2Online)
                {
                    activeRooms.Remove(pair.Key);
                    removed.Add(pair.Key);
                }
            }
            return removed;
        }
        // Kiểm tra user có thuộc conversation hay không.
        private bool CanJoinConversation(int id, string email)
        {
            const string sql = """
                SELECT COUNT(1) FROM dbo.Conversations
                WHERE conversation_id = @id
                  AND (gmail_user1 = @email OR gmail_user2 = @email);
                """;
            using var con = new SqlConnection(DbConnectionString);
            using var cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@email", SqlDbType.NVarChar, 320).Value = email;
            con.Open();
            return Convert.ToInt32(cmd.ExecuteScalar()) == 1;
        }

        // Lưu tin nhắn vào database.
        private void SaveMessage(int id, string email, string message)
        {
            using var con = new SqlConnection(DbConnectionString);
            con.Open();
            using var tx = con.BeginTransaction();

            using (var insert = new SqlCommand("""
                INSERT INTO dbo.ConversationMessages
                    (conversation_id, sender_email, message_text)
                VALUES (@id, @email, @message);
                """, con, tx))
            {
                insert.Parameters.Add("@id", SqlDbType.Int).Value = id;
                insert.Parameters.Add("@email", SqlDbType.NVarChar, 320).Value = email;
                insert.Parameters.Add("@message", SqlDbType.NVarChar).Value = message;
                insert.ExecuteNonQuery();
            }

            using (var update = new SqlCommand("""
                UPDATE dbo.Conversations SET messages = @message
                WHERE conversation_id = @id;
                """, con, tx))
            {
                update.Parameters.Add("@id", SqlDbType.Int).Value = id;
                update.Parameters.Add("@message", SqlDbType.NVarChar).Value = message;
                update.ExecuteNonQuery();
            }

            tx.Commit();
        }

        // Chuyển tin tới client đang ở cùng phòng.
        private void BroadcastToConversation(int id, string line)
        {
            List<ChatSession> recipients;

            lock (sessionsLock)
            {
                if (!activeRooms.TryGetValue(id, out ActiveRoom? room))
                    return;

                recipients = sessions
                    .Where(s => s.ConversationId == id && room.HasParticipant(s.Email))
                    .ToList();
            }

            foreach (var recipient in recipients)
                recipient.Send(line);
        }

        // Hiển thị trạng thái hoặc tin nhắn trên giao diện server.
        private void AddMessage(string text)
        {
            if (IsDisposed || !IsHandleCreated) return;
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => AddMessage(text)));
                return;
            }
            listView1.Items.Add(new ListViewItem(text));
        }

        // Xử lý nút gửi trên giao diện server.
        private void sendbtn_Click(object sender, EventArgs e)
        {
            // Không phát thông báo toàn phòng trong chế độ conversation riêng.
            clienttxtbox.Clear();
        }

        // Dọn socket và các phòng khi server đóng.
        private void Server_FormClosed(object? sender, FormClosedEventArgs e)
        {
            closing = true;
            try { server?.Close(); } catch { }
            List<ChatSession> active;
            lock (sessionsLock)
            {
                active = sessions.ToList();
                sessions.Clear();
                activeRooms.Clear();
            }
            foreach (var session in active)
                try { session.Socket.Close(); } catch { }
        }

        private sealed class ActiveRoom
        {
            public string User1 { get; }
            public string User2 { get; }

            // Lưu email của hai thành viên trong phòng.
            public ActiveRoom(string user1, string user2)
            {
                User1 = user1;
                User2 = user2;
            }

            // Kiểm tra email có thuộc phòng này.
            public bool HasParticipant(string email)
            {
                return string.Equals(User1, email, StringComparison.OrdinalIgnoreCase) ||
                       string.Equals(User2, email, StringComparison.OrdinalIgnoreCase);
            }
        }
        private sealed class ChatSession
        {
            private readonly object writeLock = new();
            public Socket Socket { get; }
            public string Email { get; }
            public StreamWriter Writer { get; }
            public int? ConversationId { get; set; }

            // Lưu socket, email và luồng gửi của client.
            public ChatSession(Socket socket, string email, StreamWriter writer)
            {
                Socket = socket;
                Email = email;
                Writer = writer;
            }

            // Gửi một dòng dữ liệu tới client.
            public void Send(string line)
            {
                try
                {
                    lock (writeLock) Writer.WriteLine(line);
                }
                catch { try { Socket.Close(); } catch { } }
            }
        }
    }
}





