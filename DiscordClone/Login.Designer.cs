namespace DiscordClone
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            backgroundpic = new PictureBox();
            panellogin = new Panel();
            forgotpasslink = new LinkLabel();
            registerlink = new LinkLabel();
            registertext = new Label();
            loginbutton = new Button();
            passbox = new TextBox();
            emailbox = new TextBox();
            getpassword = new Label();
            getemail = new Label();
            greeting = new Label();
            ((System.ComponentModel.ISupportInitialize)backgroundpic).BeginInit();
            panellogin.SuspendLayout();
            SuspendLayout();
            // 
            // backgroundpic
            // 
            backgroundpic.BackgroundImage = (Image)resources.GetObject("backgroundpic.BackgroundImage");
            backgroundpic.BackgroundImageLayout = ImageLayout.Stretch;
            backgroundpic.Dock = DockStyle.Fill;
            backgroundpic.Location = new Point(0, 0);
            backgroundpic.Name = "backgroundpic";
            backgroundpic.Size = new Size(697, 421);
            backgroundpic.SizeMode = PictureBoxSizeMode.Zoom;
            backgroundpic.TabIndex = 0;
            backgroundpic.TabStop = false;
            backgroundpic.Click += backgroundpic_Click;
            // 
            // panellogin
            // 
            panellogin.AutoSize = true;
            panellogin.BackColor = SystemColors.ButtonFace;
            panellogin.Controls.Add(forgotpasslink);
            panellogin.Controls.Add(registerlink);
            panellogin.Controls.Add(registertext);
            panellogin.Controls.Add(loginbutton);
            panellogin.Controls.Add(passbox);
            panellogin.Controls.Add(emailbox);
            panellogin.Controls.Add(getpassword);
            panellogin.Controls.Add(getemail);
            panellogin.Controls.Add(greeting);
            panellogin.Location = new Point(167, 118);
            panellogin.Name = "panellogin";
            panellogin.Size = new Size(413, 206);
            panellogin.TabIndex = 1;
            // 
            // forgotpasslink
            // 
            forgotpasslink.AutoSize = true;
            forgotpasslink.Location = new Point(77, 126);
            forgotpasslink.Name = "forgotpasslink";
            forgotpasslink.Size = new Size(94, 15);
            forgotpasslink.TabIndex = 8;
            forgotpasslink.TabStop = true;
            forgotpasslink.Text = "Quên mật khẩu?";
            // 
            // registerlink
            // 
            registerlink.AutoSize = true;
            registerlink.Location = new Point(156, 178);
            registerlink.Name = "registerlink";
            registerlink.Size = new Size(50, 15);
            registerlink.TabIndex = 7;
            registerlink.TabStop = true;
            registerlink.Text = "Đăng ký";
            registerlink.LinkClicked += registerlink_LinkClicked;
            // 
            // registertext
            // 
            registertext.AutoSize = true;
            registertext.Location = new Point(43, 178);
            registertext.Name = "registertext";
            registertext.Size = new Size(108, 15);
            registertext.TabIndex = 6;
            registertext.Text = "Chưa có tài khoản?";
            // 
            // loginbutton
            // 
            loginbutton.Anchor = AnchorStyles.None;
            loginbutton.Font = new Font("Segoe UI", 10F);
            loginbutton.Location = new Point(116, 144);
            loginbutton.Name = "loginbutton";
            loginbutton.Size = new Size(187, 29);
            loginbutton.TabIndex = 5;
            loginbutton.Text = "Đăng nhập";
            loginbutton.UseVisualStyleBackColor = true;
            loginbutton.Click += loginbutton_Click;
            // 
            // passbox
            // 
            passbox.Anchor = AnchorStyles.None;
            passbox.Location = new Point(77, 98);
            passbox.Name = "passbox";
            passbox.Size = new Size(277, 23);
            passbox.TabIndex = 4;
            // 
            // emailbox
            // 
            emailbox.Anchor = AnchorStyles.None;
            emailbox.Location = new Point(77, 50);
            emailbox.Name = "emailbox";
            emailbox.Size = new Size(277, 23);
            emailbox.TabIndex = 3;
            // 
            // getpassword
            // 
            getpassword.Anchor = AnchorStyles.None;
            getpassword.AutoSize = true;
            getpassword.Location = new Point(43, 80);
            getpassword.Name = "getpassword";
            getpassword.Size = new Size(57, 15);
            getpassword.TabIndex = 2;
            getpassword.Text = "Password";
            // 
            // getemail
            // 
            getemail.Anchor = AnchorStyles.None;
            getemail.AutoSize = true;
            getemail.Location = new Point(43, 32);
            getemail.Name = "getemail";
            getemail.Size = new Size(69, 15);
            getemail.TabIndex = 1;
            getemail.Text = "Login Email";
            getemail.Click += getemail_Click;
            // 
            // greeting
            // 
            greeting.Anchor = AnchorStyles.None;
            greeting.AutoSize = true;
            greeting.Font = new Font("Tw Cen MT", 12F, FontStyle.Bold);
            greeting.Location = new Point(156, 9);
            greeting.Name = "greeting";
            greeting.Size = new Size(108, 19);
            greeting.TabIndex = 0;
            greeting.Text = "Welcome back!";
            greeting.TextAlign = ContentAlignment.TopCenter;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(697, 421);
            Controls.Add(panellogin);
            Controls.Add(backgroundpic);
            Name = "Login";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)backgroundpic).EndInit();
            panellogin.ResumeLayout(false);
            panellogin.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox backgroundpic;
        private Panel panellogin;
        private Label getpassword;
        private Label getemail;
        private Label greeting;
        private TextBox emailbox;
        private TextBox passbox;
        private Button loginbutton;
        private LinkLabel registerlink;
        private Label registertext;
        private LinkLabel forgotpasslink;
    }
}
