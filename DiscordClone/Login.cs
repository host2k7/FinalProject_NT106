using Microsoft.Data.SqlClient;
using System.Collections.Specialized;
using System.Drawing;
using System.Text.RegularExpressions;

namespace DiscordClone
{
    public partial class Login : Form
    {
        private void Form1_Center()
        {
            panellogin.Location = new Point(
                (this.ClientSize.Width - panellogin.Width) / 2,
                (this.ClientSize.Height - panellogin.Height) / 2);
        }

        public Login()
        {
            InitializeComponent();

            Form1_Center();

            this.Resize += (s, e) => Form1_Center();
        }

        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=QuanLyTaiKhoan;Integrated Security=True;Trust Server Certificate=True";

        private void backgroundpic_Click(object sender, EventArgs e)
        {

        }


        //Check email
        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            // Chuỗi Regex chuẩn để kiểm tra cấu trúc Email cơ bản
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            return Regex.IsMatch(email, pattern);
        }

        private void getemail_Click(object sender, EventArgs e)
        {

        }

        private void registerlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register registerForm = new Register(this);
            this.Hide();
            registerForm.FormClosed += (s, args) => this.Show();

            registerForm.Show();
        }

        private void loginbutton_Click(object sender, EventArgs e)
        {
            string email_login = emailbox.Text.Trim();
            string pass_login = passbox.Text.Trim();

            if (IsValidEmail(email_login))
            {
                SqlConnection con = new SqlConnection(connectionString);
                string q = "select PasswordHash from TaiKhoan where Email = @Email";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("Email", email_login);

                try
                {
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string pass = reader["PasswordHash"].ToString();
                            if (pass == pass_login)
                            {
                                MessageBox.Show("Đăng nhập thành công");
                                Main manhinhchinh = new Main();
                                this.Hide();
                                manhinhchinh.Show();
                            }

                            else
                            {
                                MessageBox.Show("Sai mật khẩu :(");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Email chưa được đăng ký");
                        }
                    }
                }

                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Email không hợp lệ");
            }
        }
    }
}
