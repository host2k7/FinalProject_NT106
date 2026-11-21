using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;

namespace DiscordClone
{
    public partial class Register : Form
    {
        private void CenterPanel()
        {
            panelregis.Location = new Point(
                (this.ClientSize.Width - panelregis.Width) / 2,
                (this.ClientSize.Height - panelregis.Height) / 2);
        }

        private Login loginform;
        public Register(Login loginform)
        {
            InitializeComponent();
            this.loginform = loginform;

            CenterPanel();

            this.Resize += (s, e) => CenterPanel();
        }

        string connectstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=QuanLyTaiKhoan;Integrated Security=True;Trust Server Certificate=True";

        private void rickroll_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(
                new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "https://www.youtube.com/watch?v=dQw4w9WgXcQ",
                    UseShellExecute = true
                });
        }

        private void returnlogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            loginform.Show();

            this.Close();
        }

        void nhapdulieu(SqlConnection con ,SqlCommand cmd, string username, string nametag, string email, string password, string hovaten)
        {
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Nametag", nametag);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@PasswordHash", password);
            cmd.Parameters.AddWithValue("@Hovaten", hovaten);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }

            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show("Tên người dùng và Nametag đã có người sử dụng, yêu cầu đổi một trong 2 để có thể đăng ký");
                }
                else
                {
                    // Bắt các lỗi SQL khác (ví dụ: mất mạng, sai tên bảng, v.v.)
                    MessageBox.Show("Lỗi cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Bắt các lỗi chung chung của C# (không phải lỗi SQL)
                MessageBox.Show("Đã xảy ra lỗi không xác định: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
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

        void DangKy(bool check)
        {
            SqlConnection con = new SqlConnection(connectstring);
            string q = "insert into TaiKhoan(Username, Nametag, Email, PasswordHash, Hovaten)values(@Username, @Nametag, @Email, @PasswordHash, @Hovaten)";
            SqlCommand cmd = new SqlCommand(q, con);
            MemoryStream me = new MemoryStream();

            string name_su = getnameregis.Text.Trim();
            string username_su = getusernameregis.Text.Trim();
            string email_su = getemailregis.Text.Trim();
            string password_su = getpassregis.Text.Trim();
            string nametag_su = getnametag.Text.Trim();
            string confirmpass_su = getpass2regis.Text.Trim();

            if (confirmpass_su != password_su)
            {
                MessageBox.Show("Mật khẩu không giống nhau, vui lòng nhập lại");
            }
            else
            {
                // con cmd username nametag email pass hovaten
                string check_email_query = "select * from TaiKhoan where Email = @Email";
                SqlCommand check_email = new SqlCommand(check_email_query, con);
                check_email.Parameters.AddWithValue("@Email", email_su);
                con.Open();

                using (SqlDataReader reader = check_email.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        MessageBox.Show("Email đã tồn tại!");
                    }
                    else
                    {
                        con.Close();
                        nhapdulieu(con, cmd, username_su, nametag_su, email_su, password_su, name_su);
                        check = true;
                    }
                }
            }
        }

        private void buttonregis_Click(object sender, EventArgs e)
        {
            string email = getemailregis.Text.Trim();
            if (IsValidEmail(email))
            {
                bool check = false;
                DangKy(check);
                if (check)
                    MessageBox.Show("Đăng ký thành công");
            }
            else
            {
                MessageBox.Show("Email không hợp lệ");
            }
        }

        private void greetinglabel_Click(object sender, EventArgs e)
        {

        }
    }
}
