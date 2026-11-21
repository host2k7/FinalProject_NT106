namespace DiscordClone
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
            navpanel = new Panel();
            panel1 = new Panel();
            chatspanel = new Panel();
            textpanel = new Panel();
            tendoanchat = new Panel();
            chatlist = new Panel();
            findands = new Panel();
            panel1.SuspendLayout();
            chatlist.SuspendLayout();
            SuspendLayout();
            // 
            // navpanel
            // 
            navpanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            navpanel.BackColor = SystemColors.ActiveCaptionText;
            navpanel.Dock = DockStyle.Left;
            navpanel.Location = new Point(0, 0);
            navpanel.Name = "navpanel";
            navpanel.Size = new Size(60, 541);
            navpanel.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Controls.Add(chatspanel);
            panel1.Controls.Add(textpanel);
            panel1.Controls.Add(tendoanchat);
            panel1.Controls.Add(chatlist);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(947, 541);
            panel1.TabIndex = 4;
            panel1.Paint += panel1_Paint;
            // 
            // chatspanel
            // 
            chatspanel.AutoScroll = true;
            chatspanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            chatspanel.BackColor = SystemColors.ActiveCaption;
            chatspanel.Dock = DockStyle.Fill;
            chatspanel.Location = new Point(350, 67);
            chatspanel.Name = "chatspanel";
            chatspanel.Size = new Size(597, 394);
            chatspanel.TabIndex = 6;
            // 
            // textpanel
            // 
            textpanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            textpanel.BackColor = SystemColors.HotTrack;
            textpanel.Dock = DockStyle.Bottom;
            textpanel.Location = new Point(350, 461);
            textpanel.Name = "textpanel";
            textpanel.Size = new Size(597, 80);
            textpanel.TabIndex = 5;
            // 
            // tendoanchat
            // 
            tendoanchat.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tendoanchat.BackColor = SystemColors.HotTrack;
            tendoanchat.Dock = DockStyle.Top;
            tendoanchat.Location = new Point(350, 0);
            tendoanchat.Name = "tendoanchat";
            tendoanchat.Size = new Size(597, 67);
            tendoanchat.TabIndex = 4;
            // 
            // chatlist
            // 
            chatlist.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            chatlist.BackColor = SystemColors.ButtonFace;
            chatlist.Controls.Add(findands);
            chatlist.Dock = DockStyle.Left;
            chatlist.Location = new Point(0, 0);
            chatlist.Name = "chatlist";
            chatlist.Size = new Size(350, 541);
            chatlist.TabIndex = 3;
            // 
            // findands
            // 
            findands.BackColor = SystemColors.ActiveCaption;
            findands.Dock = DockStyle.Top;
            findands.Location = new Point(0, 0);
            findands.Name = "findands";
            findands.Size = new Size(350, 38);
            findands.TabIndex = 0;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(947, 541);
            Controls.Add(navpanel);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main";
            panel1.ResumeLayout(false);
            chatlist.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel navpanel;
        private Panel panel1;
        private Panel chatlist;
        private Panel tendoanchat;
        private Panel findands;
        private Panel textpanel;
        private Panel chatspanel;
    }
}