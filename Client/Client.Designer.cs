namespace SampleMultichat
{
    partial class Client
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
            listView1 = new ListView();
            clienttxtbox = new TextBox();
            sendbtn = new Button();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listView1.Location = new Point(12, 12);
            listView1.Name = "listView1";
            listView1.Size = new Size(582, 396);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.List;
            // 
            // clienttxtbox
            // 
            clienttxtbox.Font = new Font("Times New Roman", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            clienttxtbox.Location = new Point(12, 419);
            clienttxtbox.Name = "clienttxtbox";
            clienttxtbox.Size = new Size(472, 35);
            clienttxtbox.TabIndex = 1;
            // 
            // sendbtn
            // 
            sendbtn.Location = new Point(490, 419);
            sendbtn.Name = "sendbtn";
            sendbtn.Size = new Size(104, 39);
            sendbtn.TabIndex = 2;
            sendbtn.Text = "Send";
            sendbtn.UseVisualStyleBackColor = true;
            sendbtn.Click += sendbtn_Click;
            // 
            // Client
            // 
            AcceptButton = sendbtn;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(606, 470);
            Controls.Add(sendbtn);
            Controls.Add(clienttxtbox);
            Controls.Add(listView1);
            Name = "Client";
            Text = "Client";
            FormClosed += Client_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView1;
        private TextBox clienttxtbox;
        private Button sendbtn;
    }
}
