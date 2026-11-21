namespace SampleChatApp
{
    partial class Thongtintaikhoan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tennguoidung = new Label();
            panelthongtin = new Panel();
            tagnamethongtin = new Label();
            usernamethongtin = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            emailthongtin = new Label();
            panelthongtin.SuspendLayout();
            SuspendLayout();
            // 
            // tennguoidung
            // 
            tennguoidung.AutoSize = true;
            tennguoidung.Dock = DockStyle.Top;
            tennguoidung.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tennguoidung.Location = new Point(0, 0);
            tennguoidung.Name = "tennguoidung";
            tennguoidung.Size = new Size(210, 37);
            tennguoidung.TabIndex = 0;
            tennguoidung.Text = "Ten Nguoi Dung";
            // 
            // panelthongtin
            // 
            panelthongtin.BorderStyle = BorderStyle.Fixed3D;
            panelthongtin.Controls.Add(tagnamethongtin);
            panelthongtin.Controls.Add(usernamethongtin);
            panelthongtin.Controls.Add(label3);
            panelthongtin.Controls.Add(label2);
            panelthongtin.Controls.Add(label1);
            panelthongtin.Controls.Add(emailthongtin);
            panelthongtin.Dock = DockStyle.Fill;
            panelthongtin.Location = new Point(0, 37);
            panelthongtin.Name = "panelthongtin";
            panelthongtin.Size = new Size(402, 212);
            panelthongtin.TabIndex = 1;
            // 
            // tagnamethongtin
            // 
            tagnamethongtin.AutoSize = true;
            tagnamethongtin.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tagnamethongtin.Location = new Point(129, 95);
            tagnamethongtin.Name = "tagnamethongtin";
            tagnamethongtin.Size = new Size(86, 25);
            tagnamethongtin.TabIndex = 0;
            tagnamethongtin.Text = "nametag";
            tagnamethongtin.Click += tagnamethongtin_Click;
            // 
            // usernamethongtin
            // 
            usernamethongtin.AutoSize = true;
            usernamethongtin.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            usernamethongtin.Location = new Point(129, 41);
            usernamethongtin.Name = "usernamethongtin";
            usernamethongtin.Size = new Size(95, 25);
            usernamethongtin.TabIndex = 0;
            usernamethongtin.Text = "username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(10, 95);
            label3.Name = "label3";
            label3.Size = new Size(98, 25);
            label3.TabIndex = 0;
            label3.Text = "Nametag: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(10, 41);
            label2.Name = "label2";
            label2.Size = new Size(106, 25);
            label2.TabIndex = 0;
            label2.Text = "Username: ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(10, 147);
            label1.Name = "label1";
            label1.Size = new Size(67, 25);
            label1.TabIndex = 0;
            label1.Text = "Email: ";
            // 
            // emailthongtin
            // 
            emailthongtin.AutoSize = true;
            emailthongtin.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            emailthongtin.Location = new Point(129, 147);
            emailthongtin.Name = "emailthongtin";
            emailthongtin.Size = new Size(58, 25);
            emailthongtin.TabIndex = 0;
            emailthongtin.Text = "email";
            // 
            // Thongtintaikhoan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(402, 249);
            Controls.Add(panelthongtin);
            Controls.Add(tennguoidung);
            Name = "Thongtintaikhoan";
            Text = "Thông tin tài khoản";
            Load += Thongtintaikhoan_Load;
            panelthongtin.ResumeLayout(false);
            panelthongtin.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label tennguoidung;
        private Panel panelthongtin;
        private Label emailthongtin;
        private Label tagnamethongtin;
        private Label usernamethongtin;
        private Label label1;
        private Label label3;
        private Label label2;
    }
}