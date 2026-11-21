using Microsoft.Data.SqlClient;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;

namespace SampleChatApp
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        //Conect database
        string connectstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SampleDatabase;Integrated Security=True";

        private void loginformbtn_Click(object sender, EventArgs e)
        {
            loginform.Show();
            loginform.BringToFront();
        }

        private void regisformbtn_Click(object sender, EventArgs e)
        {
            regisform.Show();
            regisform.BringToFront();
        }

        // Check password
        public bool Checkpass(string password, string confirmpassword)
        {
            if (password.IsWhiteSpace()) return false;
            if (password != confirmpassword) return false;
            return true;
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

        // Check email da ton tai hay chua
        public bool UsedEmail(SqlConnection con, string email)
        {
            string check_email_query = "select * from TaiKhoan where Email = @Email";
            SqlCommand checkemail = new SqlCommand(check_email_query, con);
            checkemail.Parameters.AddWithValue("@Email", email);
            con.Open();

            using (SqlDataReader reader = checkemail.ExecuteReader())
            {
                if (reader.Read())
                {
                    con.Close();
                    return true;
                }
            }

            con.Close();
            return false;
        }

        private void AllClear()
        {
            name_regis_txt.Clear();
            email_regis_txt.Clear();
            pass_regis_txt.Clear();
            nametag_regis_txt.Clear();
            confirmpasstxt.Clear();
            username_regis_txt.Clear();
            emailtxtbox.Clear();
            passtxtbox.Clear();
        }

        public void LoginCheck(SqlConnection con, string email, string pass_login)
        {
            string q = "select password from TaiKhoan where email = @email";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("email", email);

            try
            {
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string pass = reader["password"].ToString();
                        if (pass == pass_login)
                        {
                            AllClear();
                            MessageBox.Show("Login Successfully!");
                            Main mainmenu = new Main(this, email);
                            this.Hide();
                            mainmenu.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Incorrect Password");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Email isnt registered yet");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cant connect to Database server, please retry in a few minutes");
            }
        }

        private void regisbtn_Click(object sender, EventArgs e)
        {
            // hovaten email password username nametag
            SqlConnection con = new SqlConnection(connectstring);
            string q = "insert into TaiKhoan(hovaten,email,password,username,nametag)values(@hovaten,@email,@password,@username,@nametag)";
            SqlCommand cmd = new SqlCommand(q, con);

            string hovaten_regis = name_regis_txt.Text.Trim();
            string email_regis = email_regis_txt.Text.Trim();
            string password_regis = pass_regis_txt.Text.Trim();
            string username_regis = username_regis_txt.Text.Trim();
            string nametag_regis = nametag_regis_txt.Text.Trim();
            string confirm_pass_regis = confirmpasstxt.Text.Trim();

            if (IsValidEmail(email_regis) && Checkpass(password_regis, confirm_pass_regis))
            {
                bool check_email = UsedEmail(con, email_regis);

                if (!check_email)
                {
                    cmd.Parameters.AddWithValue("hovaten", hovaten_regis);
                    cmd.Parameters.AddWithValue("email", email_regis);
                    cmd.Parameters.AddWithValue("password", password_regis);
                    cmd.Parameters.AddWithValue("username", username_regis);
                    cmd.Parameters.AddWithValue("nametag", nametag_regis);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        AllClear();
                        MessageBox.Show("Registration Successfully");
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
                else
                {
                    MessageBox.Show("Used Email, please Login");
                }
            }
            else
            {
                MessageBox.Show("Invalid Email or Invalid Password");
            }

        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            string email_login = emailtxtbox.Text.Trim();
            string pass_login = passtxtbox.Text.Trim();
            if (IsValidEmail(email_login) || email_login == "admin")
            {
                SqlConnection con = new SqlConnection(connectstring);
                LoginCheck(con, email_login, pass_login);
            }
            else
            {
                MessageBox.Show("Invalid Email!");
            }
        }

        private void Start_Load(object sender, EventArgs e)
        {

        }
    }
}
