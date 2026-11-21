namespace SampleChatApp
{
    partial class Start
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
            loginformbtn = new Button();
            regisformbtn = new Button();
            loginform = new GroupBox();
            forpasslink = new LinkLabel();
            loginbtn = new Button();
            label8 = new Label();
            label7 = new Label();
            emailtxtbox = new TextBox();
            passtxtbox = new TextBox();
            regisform = new GroupBox();
            nametag_regis_txt = new TextBox();
            username_regis_txt = new TextBox();
            label6 = new Label();
            label5 = new Label();
            name_regis_txt = new TextBox();
            label4 = new Label();
            confirmpasstxt = new TextBox();
            label3 = new Label();
            regisbtn = new Button();
            pass_regis_txt = new TextBox();
            email_regis_txt = new TextBox();
            label1 = new Label();
            label2 = new Label();
            loginform.SuspendLayout();
            regisform.SuspendLayout();
            SuspendLayout();
            // 
            // loginformbtn
            // 
            loginformbtn.Anchor = AnchorStyles.None;
            loginformbtn.BackColor = Color.Gray;
            loginformbtn.FlatStyle = FlatStyle.Flat;
            loginformbtn.Font = new Font("Times New Roman", 18F, FontStyle.Bold);
            loginformbtn.ForeColor = Color.White;
            loginformbtn.Location = new Point(11, 26);
            loginformbtn.Margin = new Padding(0);
            loginformbtn.Name = "loginformbtn";
            loginformbtn.Size = new Size(241, 42);
            loginformbtn.TabIndex = 0;
            loginformbtn.Text = "Login";
            loginformbtn.UseVisualStyleBackColor = false;
            loginformbtn.Click += loginformbtn_Click;
            // 
            // regisformbtn
            // 
            regisformbtn.Anchor = AnchorStyles.None;
            regisformbtn.BackColor = Color.Gray;
            regisformbtn.FlatStyle = FlatStyle.Flat;
            regisformbtn.Font = new Font("Times New Roman", 18F, FontStyle.Bold);
            regisformbtn.ForeColor = Color.White;
            regisformbtn.Location = new Point(268, 26);
            regisformbtn.Margin = new Padding(0);
            regisformbtn.Name = "regisformbtn";
            regisformbtn.Size = new Size(241, 42);
            regisformbtn.TabIndex = 1;
            regisformbtn.Text = "Register";
            regisformbtn.UseVisualStyleBackColor = false;
            regisformbtn.Click += regisformbtn_Click;
            // 
            // loginform
            // 
            loginform.Anchor = AnchorStyles.None;
            loginform.Controls.Add(forpasslink);
            loginform.Controls.Add(loginbtn);
            loginform.Controls.Add(label8);
            loginform.Controls.Add(label7);
            loginform.Controls.Add(emailtxtbox);
            loginform.Controls.Add(passtxtbox);
            loginform.Font = new Font("Times New Roman", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            loginform.ForeColor = SystemColors.ControlLightLight;
            loginform.Location = new Point(12, 81);
            loginform.Name = "loginform";
            loginform.Size = new Size(500, 407);
            loginform.TabIndex = 2;
            loginform.TabStop = false;
            loginform.Text = "Login Form";
            // 
            // forpasslink
            // 
            forpasslink.Anchor = AnchorStyles.None;
            forpasslink.AutoSize = true;
            forpasslink.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            forpasslink.LinkColor = Color.MediumTurquoise;
            forpasslink.Location = new Point(66, 205);
            forpasslink.Name = "forpasslink";
            forpasslink.Size = new Size(120, 19);
            forpasslink.TabIndex = 13;
            forpasslink.TabStop = true;
            forpasslink.Text = "Forgot password?";
            // 
            // loginbtn
            // 
            loginbtn.Anchor = AnchorStyles.None;
            loginbtn.BackColor = Color.Green;
            loginbtn.FlatStyle = FlatStyle.Flat;
            loginbtn.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            loginbtn.ForeColor = Color.White;
            loginbtn.Location = new Point(75, 246);
            loginbtn.Margin = new Padding(0);
            loginbtn.Name = "loginbtn";
            loginbtn.Size = new Size(347, 34);
            loginbtn.TabIndex = 12;
            loginbtn.Text = "Login";
            loginbtn.UseVisualStyleBackColor = false;
            loginbtn.Click += loginbtn_Click;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.None;
            label8.AutoSize = true;
            label8.Font = new Font("Times New Roman", 15.75F);
            label8.Location = new Point(29, 156);
            label8.Name = "label8";
            label8.Size = new Size(101, 23);
            label8.TabIndex = 11;
            label8.Text = "Password: ";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.None;
            label7.AutoSize = true;
            label7.Font = new Font("Times New Roman", 15.75F);
            label7.Location = new Point(48, 100);
            label7.Name = "label7";
            label7.Size = new Size(71, 23);
            label7.TabIndex = 10;
            label7.Text = "Email: ";
            // 
            // emailtxtbox
            // 
            emailtxtbox.Anchor = AnchorStyles.None;
            emailtxtbox.BorderStyle = BorderStyle.FixedSingle;
            emailtxtbox.Font = new Font("Times New Roman", 15F);
            emailtxtbox.ForeColor = SystemColors.InfoText;
            emailtxtbox.Location = new Point(135, 99);
            emailtxtbox.Name = "emailtxtbox";
            emailtxtbox.Size = new Size(348, 30);
            emailtxtbox.TabIndex = 5;
            // 
            // passtxtbox
            // 
            passtxtbox.Anchor = AnchorStyles.None;
            passtxtbox.BorderStyle = BorderStyle.FixedSingle;
            passtxtbox.Font = new Font("Times New Roman", 15F);
            passtxtbox.ForeColor = SystemColors.InfoText;
            passtxtbox.Location = new Point(135, 149);
            passtxtbox.Name = "passtxtbox";
            passtxtbox.Size = new Size(348, 30);
            passtxtbox.TabIndex = 6;
            // 
            // regisform
            // 
            regisform.Anchor = AnchorStyles.None;
            regisform.Controls.Add(nametag_regis_txt);
            regisform.Controls.Add(username_regis_txt);
            regisform.Controls.Add(label6);
            regisform.Controls.Add(label5);
            regisform.Controls.Add(name_regis_txt);
            regisform.Controls.Add(label4);
            regisform.Controls.Add(confirmpasstxt);
            regisform.Controls.Add(label3);
            regisform.Controls.Add(regisbtn);
            regisform.Controls.Add(pass_regis_txt);
            regisform.Controls.Add(email_regis_txt);
            regisform.Controls.Add(label1);
            regisform.Controls.Add(label2);
            regisform.Font = new Font("Times New Roman", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            regisform.ForeColor = SystemColors.ControlLightLight;
            regisform.Location = new Point(12, 81);
            regisform.Name = "regisform";
            regisform.Size = new Size(500, 407);
            regisform.TabIndex = 8;
            regisform.TabStop = false;
            regisform.Text = "Register Form";
            // 
            // nametag_regis_txt
            // 
            nametag_regis_txt.Anchor = AnchorStyles.None;
            nametag_regis_txt.BorderStyle = BorderStyle.FixedSingle;
            nametag_regis_txt.Font = new Font("Times New Roman", 15F);
            nametag_regis_txt.ForeColor = SystemColors.InfoText;
            nametag_regis_txt.Location = new Point(390, 123);
            nametag_regis_txt.Name = "nametag_regis_txt";
            nametag_regis_txt.Size = new Size(92, 30);
            nametag_regis_txt.TabIndex = 10;
            // 
            // username_regis_txt
            // 
            username_regis_txt.Anchor = AnchorStyles.None;
            username_regis_txt.BorderStyle = BorderStyle.FixedSingle;
            username_regis_txt.Font = new Font("Times New Roman", 15F);
            username_regis_txt.ForeColor = SystemColors.InfoText;
            username_regis_txt.Location = new Point(118, 123);
            username_regis_txt.Name = "username_regis_txt";
            username_regis_txt.Size = new Size(181, 30);
            username_regis_txt.TabIndex = 10;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(305, 130);
            label6.Name = "label6";
            label6.Size = new Size(79, 21);
            label6.TabIndex = 9;
            label6.Text = "Nametag:";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 15.75F);
            label5.Location = new Point(19, 130);
            label5.Name = "label5";
            label5.Size = new Size(104, 23);
            label5.TabIndex = 9;
            label5.Text = "Username: ";
            // 
            // name_regis_txt
            // 
            name_regis_txt.Anchor = AnchorStyles.None;
            name_regis_txt.BorderStyle = BorderStyle.FixedSingle;
            name_regis_txt.Font = new Font("Times New Roman", 15F);
            name_regis_txt.ForeColor = SystemColors.InfoText;
            name_regis_txt.Location = new Point(200, 73);
            name_regis_txt.Name = "name_regis_txt";
            name_regis_txt.Size = new Size(282, 30);
            name_regis_txt.TabIndex = 10;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 15.75F);
            label4.Location = new Point(19, 74);
            label4.Name = "label4";
            label4.Size = new Size(101, 23);
            label4.TabIndex = 9;
            label4.Text = "Họ và tên: ";
            // 
            // confirmpasstxt
            // 
            confirmpasstxt.Anchor = AnchorStyles.None;
            confirmpasstxt.BorderStyle = BorderStyle.FixedSingle;
            confirmpasstxt.Font = new Font("Times New Roman", 15F);
            confirmpasstxt.ForeColor = SystemColors.InfoText;
            confirmpasstxt.Location = new Point(200, 264);
            confirmpasstxt.Name = "confirmpasstxt";
            confirmpasstxt.Size = new Size(282, 30);
            confirmpasstxt.TabIndex = 8;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 15.75F);
            label3.Location = new Point(19, 265);
            label3.Name = "label3";
            label3.Size = new Size(175, 23);
            label3.TabIndex = 7;
            label3.Text = "Confirm password: ";
            // 
            // regisbtn
            // 
            regisbtn.Anchor = AnchorStyles.None;
            regisbtn.BackColor = Color.Green;
            regisbtn.FlatStyle = FlatStyle.Flat;
            regisbtn.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            regisbtn.ForeColor = Color.White;
            regisbtn.Location = new Point(118, 341);
            regisbtn.Margin = new Padding(0);
            regisbtn.Name = "regisbtn";
            regisbtn.Size = new Size(282, 36);
            regisbtn.TabIndex = 3;
            regisbtn.Text = "Register";
            regisbtn.UseVisualStyleBackColor = false;
            regisbtn.Click += regisbtn_Click;
            // 
            // pass_regis_txt
            // 
            pass_regis_txt.Anchor = AnchorStyles.None;
            pass_regis_txt.BorderStyle = BorderStyle.FixedSingle;
            pass_regis_txt.Font = new Font("Times New Roman", 15F);
            pass_regis_txt.ForeColor = SystemColors.InfoText;
            pass_regis_txt.Location = new Point(200, 219);
            pass_regis_txt.Name = "pass_regis_txt";
            pass_regis_txt.Size = new Size(282, 30);
            pass_regis_txt.TabIndex = 6;
            // 
            // email_regis_txt
            // 
            email_regis_txt.Anchor = AnchorStyles.None;
            email_regis_txt.BorderStyle = BorderStyle.FixedSingle;
            email_regis_txt.Font = new Font("Times New Roman", 15F);
            email_regis_txt.ForeColor = SystemColors.InfoText;
            email_regis_txt.Location = new Point(200, 174);
            email_regis_txt.Name = "email_regis_txt";
            email_regis_txt.Size = new Size(282, 30);
            email_regis_txt.TabIndex = 5;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 15.75F);
            label1.Location = new Point(19, 226);
            label1.Name = "label1";
            label1.Size = new Size(101, 23);
            label1.TabIndex = 4;
            label1.Text = "Password: ";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 15.75F);
            label2.Location = new Point(19, 181);
            label2.Name = "label2";
            label2.Size = new Size(71, 23);
            label2.TabIndex = 3;
            label2.Text = "Email: ";
            // 
            // Start
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSlateGray;
            ClientSize = new Size(518, 500);
            Controls.Add(regisformbtn);
            Controls.Add(loginformbtn);
            Controls.Add(loginform);
            Controls.Add(regisform);
            Name = "Start";
            Text = "Start menu";
            Load += Start_Load;
            loginform.ResumeLayout(false);
            loginform.PerformLayout();
            regisform.ResumeLayout(false);
            regisform.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button loginformbtn;
        private Button regisformbtn;
        private GroupBox loginform;
        private TextBox passtxtbox;
        private TextBox emailtxtbox;
        private GroupBox regisform;
        private TextBox name_regis_txt;
        private Label label4;
        private TextBox confirmpasstxt;
        private Label label3;
        private Button regisbtn;
        private TextBox pass_regis_txt;
        private TextBox email_regis_txt;
        private Label label1;
        private Label label2;
        private TextBox nametag_regis_txt;
        private TextBox username_regis_txt;
        private Label label6;
        private Label label5;
        private Label label8;
        private Label label7;
        private LinkLabel forpasslink;
        private Button loginbtn;
    }
}
