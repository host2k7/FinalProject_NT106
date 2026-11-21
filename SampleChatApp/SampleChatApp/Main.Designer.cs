namespace SampleChatApp
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            navi_panel = new Panel();
            grouppic = new PictureBox();
            dmpic = new PictureBox();
            avatarpic = new PictureBox();
            logoutpic = new PictureBox();
            settingpic = new PictureBox();
            chatpanel = new Panel();
            doanchatpanel = new Panel();
            chatview = new ListView();
            textpanel = new Panel();
            clienttxtbox = new TextBox();
            sendbtn = new Button();
            tenlienhevachucnangpanel = new Panel();
            tenlienhe = new Label();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            filespic = new PictureBox();
            danhsachvatk = new Panel();
            danhsachlienhe = new Panel();
            timkiem = new Panel();
            timkiemicon = new PictureBox();
            pictureBox4 = new PictureBox();
            timkiemtxtbox = new TextBox();
            navi_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grouppic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dmpic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)avatarpic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)logoutpic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)settingpic).BeginInit();
            chatpanel.SuspendLayout();
            doanchatpanel.SuspendLayout();
            textpanel.SuspendLayout();
            tenlienhevachucnangpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)filespic).BeginInit();
            danhsachvatk.SuspendLayout();
            timkiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)timkiemicon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // navi_panel
            // 
            navi_panel.Anchor = AnchorStyles.None;
            navi_panel.BackColor = Color.DodgerBlue;
            navi_panel.BorderStyle = BorderStyle.FixedSingle;
            navi_panel.Controls.Add(grouppic);
            navi_panel.Controls.Add(dmpic);
            navi_panel.Controls.Add(avatarpic);
            navi_panel.Controls.Add(logoutpic);
            navi_panel.Controls.Add(settingpic);
            navi_panel.Location = new Point(0, 0);
            navi_panel.Name = "navi_panel";
            navi_panel.Size = new Size(52, 597);
            navi_panel.TabIndex = 0;
            // 
            // grouppic
            // 
            grouppic.Anchor = AnchorStyles.None;
            grouppic.BackColor = Color.Ivory;
            grouppic.BorderStyle = BorderStyle.FixedSingle;
            grouppic.Image = (Image)resources.GetObject("grouppic.Image");
            grouppic.Location = new Point(3, 124);
            grouppic.Name = "grouppic";
            grouppic.Size = new Size(42, 40);
            grouppic.SizeMode = PictureBoxSizeMode.StretchImage;
            grouppic.TabIndex = 2;
            grouppic.TabStop = false;
            // 
            // dmpic
            // 
            dmpic.Anchor = AnchorStyles.None;
            dmpic.BackColor = Color.Ivory;
            dmpic.BorderStyle = BorderStyle.FixedSingle;
            dmpic.Image = (Image)resources.GetObject("dmpic.Image");
            dmpic.Location = new Point(3, 68);
            dmpic.Name = "dmpic";
            dmpic.Size = new Size(42, 40);
            dmpic.SizeMode = PictureBoxSizeMode.StretchImage;
            dmpic.TabIndex = 2;
            dmpic.TabStop = false;
            // 
            // avatarpic
            // 
            avatarpic.Anchor = AnchorStyles.None;
            avatarpic.BackColor = Color.Ivory;
            avatarpic.BorderStyle = BorderStyle.FixedSingle;
            avatarpic.Image = (Image)resources.GetObject("avatarpic.Image");
            avatarpic.Location = new Point(3, 11);
            avatarpic.Name = "avatarpic";
            avatarpic.Size = new Size(42, 40);
            avatarpic.SizeMode = PictureBoxSizeMode.StretchImage;
            avatarpic.TabIndex = 2;
            avatarpic.TabStop = false;
            avatarpic.Click += avatarpic_Click;
            // 
            // logoutpic
            // 
            logoutpic.Anchor = AnchorStyles.None;
            logoutpic.BackColor = Color.Ivory;
            logoutpic.BorderStyle = BorderStyle.FixedSingle;
            logoutpic.Image = (Image)resources.GetObject("logoutpic.Image");
            logoutpic.Location = new Point(3, 528);
            logoutpic.Name = "logoutpic";
            logoutpic.Size = new Size(42, 40);
            logoutpic.SizeMode = PictureBoxSizeMode.StretchImage;
            logoutpic.TabIndex = 1;
            logoutpic.TabStop = false;
            logoutpic.Click += logoutpic_Click;
            // 
            // settingpic
            // 
            settingpic.Anchor = AnchorStyles.None;
            settingpic.BackColor = Color.Ivory;
            settingpic.BorderStyle = BorderStyle.FixedSingle;
            settingpic.Image = (Image)resources.GetObject("settingpic.Image");
            settingpic.Location = new Point(3, 470);
            settingpic.Name = "settingpic";
            settingpic.Size = new Size(42, 40);
            settingpic.SizeMode = PictureBoxSizeMode.StretchImage;
            settingpic.TabIndex = 1;
            settingpic.TabStop = false;
            // 
            // chatpanel
            // 
            chatpanel.Anchor = AnchorStyles.None;
            chatpanel.BackColor = Color.LightSteelBlue;
            chatpanel.Controls.Add(doanchatpanel);
            chatpanel.Controls.Add(textpanel);
            chatpanel.Controls.Add(tenlienhevachucnangpanel);
            chatpanel.Location = new Point(355, 0);
            chatpanel.Name = "chatpanel";
            chatpanel.Size = new Size(678, 597);
            chatpanel.TabIndex = 2;
            // 
            // doanchatpanel
            // 
            doanchatpanel.Anchor = AnchorStyles.None;
            doanchatpanel.BackColor = Color.White;
            doanchatpanel.Controls.Add(chatview);
            doanchatpanel.Location = new Point(0, 65);
            doanchatpanel.Name = "doanchatpanel";
            doanchatpanel.Size = new Size(678, 454);
            doanchatpanel.TabIndex = 2;
            // 
            // chatview
            // 
            chatview.Anchor = AnchorStyles.None;
            chatview.Location = new Point(0, 0);
            chatview.Name = "chatview";
            chatview.Size = new Size(678, 454);
            chatview.TabIndex = 0;
            chatview.UseCompatibleStateImageBehavior = false;
            // 
            // textpanel
            // 
            textpanel.Anchor = AnchorStyles.None;
            textpanel.BackColor = Color.SteelBlue;
            textpanel.Controls.Add(clienttxtbox);
            textpanel.Controls.Add(sendbtn);
            textpanel.Location = new Point(0, 519);
            textpanel.Name = "textpanel";
            textpanel.Size = new Size(678, 78);
            textpanel.TabIndex = 1;
            // 
            // clienttxtbox
            // 
            clienttxtbox.Anchor = AnchorStyles.None;
            clienttxtbox.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            clienttxtbox.Location = new Point(64, 20);
            clienttxtbox.Name = "clienttxtbox";
            clienttxtbox.Size = new Size(556, 32);
            clienttxtbox.TabIndex = 3;
            // 
            // sendbtn
            // 
            sendbtn.Anchor = AnchorStyles.None;
            sendbtn.BackColor = Color.Azure;
            sendbtn.BackgroundImage = (Image)resources.GetObject("sendbtn.BackgroundImage");
            sendbtn.BackgroundImageLayout = ImageLayout.Stretch;
            sendbtn.ForeColor = SystemColors.ActiveCaptionText;
            sendbtn.Location = new Point(626, 15);
            sendbtn.Name = "sendbtn";
            sendbtn.Size = new Size(40, 40);
            sendbtn.TabIndex = 2;
            sendbtn.UseVisualStyleBackColor = false;
            sendbtn.Click += sendbtn_Click;
            // 
            // tenlienhevachucnangpanel
            // 
            tenlienhevachucnangpanel.Anchor = AnchorStyles.None;
            tenlienhevachucnangpanel.BackColor = Color.DeepSkyBlue;
            tenlienhevachucnangpanel.Controls.Add(tenlienhe);
            tenlienhevachucnangpanel.Controls.Add(pictureBox2);
            tenlienhevachucnangpanel.Controls.Add(pictureBox1);
            tenlienhevachucnangpanel.Controls.Add(filespic);
            tenlienhevachucnangpanel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tenlienhevachucnangpanel.Location = new Point(0, 0);
            tenlienhevachucnangpanel.Name = "tenlienhevachucnangpanel";
            tenlienhevachucnangpanel.Size = new Size(678, 65);
            tenlienhevachucnangpanel.TabIndex = 0;
            // 
            // tenlienhe
            // 
            tenlienhe.Anchor = AnchorStyles.None;
            tenlienhe.AutoSize = true;
            tenlienhe.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tenlienhe.Location = new Point(6, 17);
            tenlienhe.Name = "tenlienhe";
            tenlienhe.Size = new Size(300, 32);
            tenlienhe.TabIndex = 4;
            tenlienhe.Text = "Chọn một cuộc trò chuyện";
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.None;
            pictureBox2.BackColor = Color.Ivory;
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(519, 18);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(37, 34);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.BackColor = Color.Ivory;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(576, 18);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(37, 34);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // filespic
            // 
            filespic.Anchor = AnchorStyles.None;
            filespic.BackColor = Color.Ivory;
            filespic.BorderStyle = BorderStyle.FixedSingle;
            filespic.Image = (Image)resources.GetObject("filespic.Image");
            filespic.Location = new Point(629, 18);
            filespic.Name = "filespic";
            filespic.Size = new Size(37, 34);
            filespic.SizeMode = PictureBoxSizeMode.StretchImage;
            filespic.TabIndex = 3;
            filespic.TabStop = false;
            // 
            // danhsachvatk
            // 
            danhsachvatk.Anchor = AnchorStyles.None;
            danhsachvatk.BackColor = Color.LightSteelBlue;
            danhsachvatk.BorderStyle = BorderStyle.FixedSingle;
            danhsachvatk.Controls.Add(danhsachlienhe);
            danhsachvatk.Controls.Add(timkiem);
            danhsachvatk.Location = new Point(52, 0);
            danhsachvatk.Name = "danhsachvatk";
            danhsachvatk.Size = new Size(303, 597);
            danhsachvatk.TabIndex = 2;
            // 
            // danhsachlienhe
            // 
            danhsachlienhe.Anchor = AnchorStyles.None;
            danhsachlienhe.BackColor = Color.MediumSpringGreen;
            danhsachlienhe.Location = new Point(0, 64);
            danhsachlienhe.Name = "danhsachlienhe";
            danhsachlienhe.Size = new Size(301, 531);
            danhsachlienhe.TabIndex = 1;
            // 
            // timkiem
            // 
            timkiem.Anchor = AnchorStyles.None;
            timkiem.BackColor = Color.SteelBlue;
            timkiem.Controls.Add(timkiemicon);
            timkiem.Controls.Add(pictureBox4);
            timkiem.Controls.Add(timkiemtxtbox);
            timkiem.Location = new Point(0, 0);
            timkiem.Name = "timkiem";
            timkiem.Size = new Size(301, 64);
            timkiem.TabIndex = 0;
            // 
            // timkiemicon
            // 
            timkiemicon.Anchor = AnchorStyles.None;
            timkiemicon.BackColor = Color.Ivory;
            timkiemicon.BorderStyle = BorderStyle.FixedSingle;
            timkiemicon.Image = (Image)resources.GetObject("timkiemicon.Image");
            timkiemicon.Location = new Point(17, 16);
            timkiemicon.Name = "timkiemicon";
            timkiemicon.Size = new Size(27, 29);
            timkiemicon.SizeMode = PictureBoxSizeMode.StretchImage;
            timkiemicon.TabIndex = 4;
            timkiemicon.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Anchor = AnchorStyles.None;
            pictureBox4.BackColor = Color.Ivory;
            pictureBox4.BorderStyle = BorderStyle.FixedSingle;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(256, 16);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(27, 29);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 6;
            pictureBox4.TabStop = false;
            // 
            // timkiemtxtbox
            // 
            timkiemtxtbox.Anchor = AnchorStyles.None;
            timkiemtxtbox.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            timkiemtxtbox.Location = new Point(50, 16);
            timkiemtxtbox.Name = "timkiemtxtbox";
            timkiemtxtbox.Size = new Size(200, 29);
            timkiemtxtbox.TabIndex = 0;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSlateGray;
            ClientSize = new Size(1033, 597);
            Controls.Add(chatpanel);
            Controls.Add(danhsachvatk);
            Controls.Add(navi_panel);
            Name = "Main";
            StartPosition = FormStartPosition.Manual;
            Text = "Discord Clone";
            Load += Main_Load;
            navi_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grouppic).EndInit();
            ((System.ComponentModel.ISupportInitialize)dmpic).EndInit();
            ((System.ComponentModel.ISupportInitialize)avatarpic).EndInit();
            ((System.ComponentModel.ISupportInitialize)logoutpic).EndInit();
            ((System.ComponentModel.ISupportInitialize)settingpic).EndInit();
            chatpanel.ResumeLayout(false);
            doanchatpanel.ResumeLayout(false);
            textpanel.ResumeLayout(false);
            textpanel.PerformLayout();
            tenlienhevachucnangpanel.ResumeLayout(false);
            tenlienhevachucnangpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)filespic).EndInit();
            danhsachvatk.ResumeLayout(false);
            timkiem.ResumeLayout(false);
            timkiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)timkiemicon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel navi_panel;
        private PictureBox logoutpic;
        private PictureBox settingpic;
        private PictureBox grouppic;
        private PictureBox dmpic;
        private PictureBox avatarpic;
        private Panel chatpanel;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private PictureBox filespic;
        private Panel tenlienhevachucnangpanel;
        private Panel danhsachvatk;
        private Panel timkiem;
        private PictureBox timkiemicon;
        private PictureBox pictureBox4;
        private TextBox timkiemtxtbox;
        private Panel textpanel;
        private Button sendbtn;
        private TextBox clienttxtbox;
        private Panel doanchatpanel;
        private ListView chatview;
        private Panel danhsachlienhe;
        private Label tenlienhe;
    }
}