using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace SampleMultichat
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;

            Connect();
        }

        private void sendbtn_Click(object sender, EventArgs e)
        {
            Send();
            AddMessage(clienttxtbox.Text.Trim());
        }


        // Cần
        /*
         * Socket
         * IP
         */

        IPEndPoint ip;
        Socket client;

        // Ket noi toi server
        void Connect()
        {
            // IP: dia chi cua server
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            try
            {
                client.Connect(ip);
            }
            catch
            {
                MessageBox.Show("Không kết nối được đến server", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            

            Thread listen = new Thread(Receive);
            listen.IsBackground = true;
            listen.Start();
        }

        // Dong ket noi hien tai
        void Close()
        {
            client.Close();
        }

        // Nhan tin
        void Receive()
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];

                    int bytesRead = client.Receive(data);
                    string message = (string)Deserialize(data, bytesRead);

                    AddMessage(message);
                }
            }
            catch
            {
                Close();
            }
        }

        // Add message vao khung chat
        void AddMessage(string s)
        {
            listView1.Items.Add(new ListViewItem() { Text = s });
            clienttxtbox.Clear();
        }

        // Gui tin
        void Send()
        {
            if (clienttxtbox.Text != string.Empty)
            {
                client.Send(Serialize(clienttxtbox.Text.Trim()));
            }
            
        }


        // Phan manh
        byte[] Serialize(string message)
        {
            return Encoding.UTF8.GetBytes(message);
        }

        // Gom manh
        string Deserialize(byte[] data, int receivedBytes)
        {
            return Encoding.UTF8.GetString(data, 0, receivedBytes);
        }


        // Dong ket noi khi dong form
        private void Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }
    }


}
