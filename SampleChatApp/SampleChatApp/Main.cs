using System;
using System.Data;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace SampleChatApp
{
    public partial class Main : Form
    {
        private readonly Start startmenu;
        private readonly string email_login;
        private readonly string connectstring =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SampleDatabase;Integrated Security=True";
        private readonly ListBox contactListBox = new();
        private readonly List<ContactItem> allContacts = new();
        private readonly Label contactHeader = new();
        private readonly object sendLock = new();

        private Socket? chatSocket;
        private StreamReader? chatReader;
        private StreamWriter? chatWriter;
        private volatile bool closing;
        private int? currentConversationId;

        // Khởi tạo form và cấu hình các sự kiện giao diện.
        public Main(Start startmenu, string email_login)
        {
            InitializeComponent();
            ApplyDiscordTheme();
            this.startmenu = startmenu;
            this.email_login = email_login;
            clienttxtbox.KeyDown += clienttxtbox_KeyDown;
            // Tìm kiếm bằng nút kính lúp hoặc phím Enter.
            timkiemicon.Click += timkiemicon_Click;
            timkiemtxtbox.KeyDown += timkiemtxtbox_KeyDown;
            timkiemtxtbox.PlaceholderText = "Tìm theo username...";
            FormClosed += Main_FormClosed;
            chatview.View = View.List;
            InitializeContactList();
        }

        // Áp dụng bảng màu tối và kiểu nút lấy cảm hứng từ Discord.
        private void ApplyDiscordTheme()
        {

            Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);

            navi_panel.BorderStyle = BorderStyle.None;

            tenlienhe.Text = "Chọn cuộc trò chuyện";
            tenlienhe.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);

            clienttxtbox.BorderStyle = BorderStyle.FixedSingle;
            clienttxtbox.Font = new Font("Segoe UI", 11F);
            clienttxtbox.PlaceholderText = "Nhắn tin...";
            clienttxtbox.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;

            foreach (Control control in navi_panel.Controls)
            {
                if (control is PictureBox picture)
                {
                    picture.BorderStyle = BorderStyle.None;
                }
            }
        }

        // Vẽ từng liên hệ và làm nổi bật liên hệ đang chọn.
        private void contactListBox_DrawItem(object? sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= contactListBox.Items.Count)
                return;

            bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            Color rowColor = selected
                ? Color.FromArgb(64, 66, 72)
                : Color.FromArgb(43, 45, 49);
            Color textColor = selected
                ? Color.FromArgb(255, 255, 255)
                : Color.FromArgb(219, 222, 225);

            using (var brush = new SolidBrush(rowColor))
                e.Graphics.FillRectangle(brush, e.Bounds);

            string text = contactListBox.Items[e.Index]?.ToString() ?? "";
            Rectangle textBounds = Rectangle.Inflate(e.Bounds, -14, 0);
            TextRenderer.DrawText(
                e.Graphics, text, e.Font ?? contactListBox.Font, textBounds, textColor,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);

            if ((e.State & DrawItemState.Focus) == DrawItemState.Focus)
                e.DrawFocusRectangle();
        }
        // Tạo danh sách liên hệ trong panel.
        private void InitializeContactList()
        {
            contactHeader.Text = "TIN NHẮN TRỰC TIẾP";
            contactHeader.Dock = DockStyle.Top;
            contactHeader.Height = 42;
            contactHeader.Padding = new Padding(14, 0, 0, 0);
            contactHeader.TextAlign = ContentAlignment.MiddleLeft;
            contactHeader.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);

            contactListBox.Dock = DockStyle.Fill;
            contactListBox.BorderStyle = BorderStyle.None;
            contactListBox.IntegralHeight = false;
            contactListBox.Font = new Font("Segoe UI", 10F);
            contactListBox.DrawMode = DrawMode.OwnerDrawFixed;
            contactListBox.ItemHeight = 40;
            contactListBox.DrawItem += contactListBox_DrawItem;
            contactListBox.SelectedIndexChanged += contactListBox_SelectedIndexChanged;

            danhsachlienhe.Controls.Add(contactListBox);
            danhsachlienhe.Controls.Add(contactHeader);
        }

        // Chuẩn bị database, tải liên hệ và kết nối server.
        private void Main_Load(object sender, EventArgs e)
        {
            EnsureChatTables();

            using (var con = new SqlConnection(connectstring))
            using (var cmd = new SqlCommand(
                "SELECT email FROM TaiKhoan WHERE email = @email", con))
            {
                cmd.Parameters.Add("@email", SqlDbType.NVarChar, 320).Value = email_login;
                con.Open();
                if (cmd.ExecuteScalar() == null)
                {
                    MessageBox.Show("Không tìm thấy tài khoản đang đăng nhập trong database.");
                    return;
                }
            }

            LoadContacts();
            ConnectToChatServer();
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
            using var con = new SqlConnection(connectstring);
            using var cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
        }

        // Tải username và email một lần để tìm kiếm trên danh sách liên hệ.
        private void LoadContacts()
        {
            allContacts.Clear();
            const string sql =
                "SELECT username, email FROM TaiKhoan WHERE email <> @email ORDER BY username, email";

            using var con = new SqlConnection(connectstring);
            using var cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@email", SqlDbType.NVarChar, 320).Value = email_login;
            con.Open();

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string username = reader.IsDBNull(0) ? "" : reader.GetString(0).Trim();
                string email = reader.IsDBNull(1) ? "" : reader.GetString(1).Trim();

                if (email.Length > 0)
                {
                    // Nếu thiếu username thì vẫn hiện liên hệ bằng email.
                    string displayName = string.IsNullOrWhiteSpace(username) ? email : username;
                    allContacts.Add(new ContactItem(username, displayName, email));
                }
            }

            RefreshContactList("");
        }

        // Hiển thị tất cả liên hệ hoặc chỉ username khớp từ khóa.
        private void RefreshContactList(string usernameFilter)
        {
            contactListBox.BeginUpdate();
            contactListBox.Items.Clear();
            contactListBox.Enabled = true;

            foreach (ContactItem contact in allContacts)
            {
                // So sánh không phân biệt chữ hoa và chữ thường.
                if (string.IsNullOrWhiteSpace(usernameFilter) ||
                    contact.Username.Contains(usernameFilter, StringComparison.OrdinalIgnoreCase))
                {
                    contactListBox.Items.Add(contact);
                }
            }

            if (contactListBox.Items.Count == 0)
            {
                contactListBox.Items.Add(allContacts.Count == 0
                    ? "Chưa có tài khoản khác."
                    : "Không tìm thấy username phù hợp.");
                contactListBox.Enabled = allContacts.Count > 0;
            }

            contactListBox.EndUpdate();
        }

        // Thực hiện tìm kiếm khi người dùng bấm biểu tượng kính lúp.
        private void timkiemicon_Click(object? sender, EventArgs e)
        {
            RefreshContactList(timkiemtxtbox.Text.Trim());
        }

        // Cho phép nhấn Enter để tìm mà không cần bấm biểu tượng.
        private void timkiemtxtbox_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                RefreshContactList(timkiemtxtbox.Text.Trim());
            }
        }
        // Mở hoặc tạo cuộc trò chuyện với user được chọn.
        private void contactListBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (contactListBox.SelectedItem is not ContactItem contact ||
                string.Equals(contact.Email, email_login, StringComparison.OrdinalIgnoreCase))
                return;

            try
            {
                currentConversationId = GetOrCreateConversation(email_login, contact.Email);
                tenlienhe.Text = contact.DisplayName;
                LoadConversationMessages(currentConversationId.Value);
                SendServerCommand($"JOIN|{currentConversationId.Value}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không mở được cuộc trò chuyện: " + ex.Message,
                    "Lỗi database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tìm conversation của hai email hoặc tạo mới.
        private int GetOrCreateConversation(string firstEmail, string secondEmail)
        {
            // Dùng email làm ID vì code hiện chưa cho thấy khóa ID riêng trong TaiKhoan.
            string user1 = string.Compare(firstEmail, secondEmail,
                StringComparison.OrdinalIgnoreCase) <= 0 ? firstEmail : secondEmail;
            string user2 = string.Equals(user1, firstEmail,
                StringComparison.OrdinalIgnoreCase) ? secondEmail : firstEmail;

            const string sql = """
                DECLARE @id INT;
                SELECT @id = conversation_id FROM dbo.Conversations
                WHERE id_user1 = @user1 AND id_user2 = @user2;
                IF @id IS NULL
                BEGIN
                    INSERT INTO dbo.Conversations
                        (id_user1, id_user2, gmail_user1, gmail_user2, messages)
                    VALUES (@user1, @user2, @user1, @user2, NULL);
                    SET @id = CONVERT(INT, SCOPE_IDENTITY());
                END;
                SELECT @id;
                """;
            using var con = new SqlConnection(connectstring);
            using var cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@user1", SqlDbType.NVarChar, 320).Value = user1;
            cmd.Parameters.Add("@user2", SqlDbType.NVarChar, 320).Value = user2;
            con.Open();
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        // Tải lịch sử tin nhắn của conversation.
        private void LoadConversationMessages(int conversationId)
        {
            chatview.Items.Clear();
            const string sql = """
                SELECT sender_email, message_text
                FROM dbo.ConversationMessages
                WHERE conversation_id = @id ORDER BY message_id;
                """;
            using var con = new SqlConnection(connectstring);
            using var cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = conversationId;
            con.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                AddMessage($"{reader.GetString(0)}: {reader.GetString(1)}");
        }

        // Kết nối client tới server chat.
        private void ConnectToChatServer()
        {
            try
            {
                var socket = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(new IPEndPoint(IPAddress.Loopback, 9999));
                chatSocket = socket;
                var stream = new NetworkStream(socket, ownsSocket: false);
                chatReader = new StreamReader(stream, Encoding.UTF8, false, 1024, leaveOpen: true);
                chatWriter = new StreamWriter(stream, new UTF8Encoding(false)) { AutoFlush = true };
                SendServerCommand($"AUTH|{email_login}");
                new Thread(ReceiveMessages) { IsBackground = true }.Start();
            }
            catch
            {
                MessageBox.Show("Không kết nối được đến server chat. Hãy mở server trước.",
                    "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Gửi một lệnh dạng dòng cho server.
        private void SendServerCommand(string command)
        {
            lock (sendLock) chatWriter?.WriteLine(command);
        }

        // Gửi tin khi người dùng bấm nút.
        private void sendbtn_Click(object? sender, EventArgs e) => SendMessage();

        // Gửi tin khi nhấn Enter trong ô nhập.
        private void clienttxtbox_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SendMessage();
            }
        }

        // Kiểm tra và gửi tin trong conversation đang mở.
        private void SendMessage()
        {
            string message = clienttxtbox.Text.Trim();
            if (message.Length == 0) return;
            if (currentConversationId == null)
            {
                MessageBox.Show("Hãy chọn một tài khoản trước khi gửi tin.");
                return;
            }
            if (chatWriter == null || chatSocket?.Connected != true)
            {
                MessageBox.Show("Chưa kết nối được đến server.");
                return;
            }
            try
            {
                SendServerCommand($"MSG|{message}");
                clienttxtbox.Clear();
            }
            catch
            {
                AddMessage("Mất kết nối với server.");
            }
        }

        // Nhận tin server gửi về và cập nhật giao diện.
        private void ReceiveMessages()
        {
            try
            {
                while (!closing && chatReader != null)
                {
                    string? line = chatReader.ReadLine();
                    if (line == null) break;
                    string[] parts = line.Split('|', 3);
                    if (parts.Length == 3 && parts[0] == "MSG")
                    {
                        string display = $"{parts[1]}: {parts[2]}";
                        if (!IsDisposed && IsHandleCreated)
                            BeginInvoke(new Action(() => AddMessage(display)));
                    }
                    else if (line == "DENIED")
                    {
                        if (!IsDisposed && IsHandleCreated)
                            BeginInvoke(new Action(() =>
                                MessageBox.Show("Server từ chối tài khoản hoặc conversation này.")));
                        break;
                    }
                }
            }
            catch { /* Kết nối có thể bị đóng */ }
        }

        // Thêm một tin nhắn vào khung chat.
        private void AddMessage(string message)
        {
            if (IsDisposed) return;
            chatview.Items.Add(new ListViewItem(message));
            if (chatview.Items.Count > 0)
                chatview.EnsureVisible(chatview.Items.Count - 1);
        }

        // Đóng kết nối khi cửa sổ chat đóng.
        private void Main_FormClosed(object? sender, FormClosedEventArgs e)
        {
            closing = true;
            try { chatSocket?.Shutdown(SocketShutdown.Both); } catch { }
            try { chatReader?.Dispose(); } catch { }
            try { chatWriter?.Dispose(); } catch { }
            try { chatSocket?.Close(); } catch { }
            chatSocket = null;
        }

        // Đóng cửa sổ chat và quay lại màn hình đăng nhập.
        private void logout()
        {
            Close();
            startmenu.Show();
        }

        // Xử lý khi bấm biểu tượng đăng xuất.
        private void logoutpic_Click(object sender, EventArgs e) => logout();

        // Mở cửa sổ thông tin tài khoản.
        private void avatarpic_Click(object sender, EventArgs e)
        {
            using var thongtin = new Thongtintaikhoan(email_login);
            thongtin.ShowDialog();
        }

        // Giữ tên hiển thị và email riêng để giao diện hiện tên nhưng chat dùng email.
        private sealed class ContactItem
        {
            public string Username { get; }
            public string DisplayName { get; }
            public string Email { get; }

            public ContactItem(string username, string displayName, string email)
            {
                Username = username;
                DisplayName = displayName;
                Email = email;
            }

            public override string ToString() => DisplayName;
        }

        // Xử lý sự kiện vẽ panel chat.
        private void chatpanel_Paint(object sender, PaintEventArgs e) { }
        // Xử lý sự kiện tải UserControl.
        private void userControl11_Load(object sender, EventArgs e) { }
    }
}



