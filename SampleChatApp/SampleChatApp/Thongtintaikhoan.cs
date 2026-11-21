using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace SampleChatApp
{
    public partial class Thongtintaikhoan : Form
    {
        private readonly string email_login;
        private readonly string connectstring =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SampleDatabase;Integrated Security=True";

        public Thongtintaikhoan(string email_login)
        {
            InitializeComponent();
            this.email_login = email_login;
        }

        private void Thongtintaikhoan_Load(object sender, EventArgs e)
        {
            const string sql = """
                SELECT hovaten, username, email, nametag
                FROM TaiKhoan
                WHERE email = @email;
                """;

            try
            {
                using var con = new SqlConnection(connectstring);
                using var cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@email", SqlDbType.NVarChar, 320).Value = email_login;

                con.Open();
                using var reader = cmd.ExecuteReader();

                if (!reader.Read())
                {
                    MessageBox.Show("Không tìm thấy thông tin tài khoản.");
                    return;
                }

                tennguoidung.Text = reader.IsDBNull(0) ? "" : reader.GetString(0).Trim();
                usernamethongtin.Text = reader.IsDBNull(1) ? "" : reader.GetString(1).Trim();
                emailthongtin.Text = reader.IsDBNull(2) ? "" : reader.GetString(2).Trim();
                tagnamethongtin.Text = reader.IsDBNull(3) ? "" : reader.GetString(3).Trim();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Không tải được thông tin tài khoản: " + ex.Message,
                    "Lỗi database",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void tagnamethongtin_Click(object sender, EventArgs e)
        {

        }
    }
}

