using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace SampleChatApp
{
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
        }

        private string _title;

        [Category("Appearance")]
        [Description("Sets the title text of the control.")]
        [DefaultValue("")]
        public string Title
        {
            get { return _title; }
            set { _title = value; label1.Text = value; }
        }

        void AddHeightText()
        {
            UserControl2 user = new UserControl2();
            user.BringToFront();
            panel1.Height = Uilist.GetTextHeight(label1) + 10;
            user.Height = panel1.Top + panel1.Height;
            this.Height = user.Bottom + 10;
        }

        private void UserControl2_Load(object sender, EventArgs e)
        {
            AddHeightText();
        }
    }
}
