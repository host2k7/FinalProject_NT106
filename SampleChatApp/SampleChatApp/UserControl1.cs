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
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
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
            set { _title = value; label1.Text = value; AddHeightText(); }
        }

        void AddHeightText()
        {
            // Tính toán chiều cao của panel1 dựa vào label1
            panel1.Height = Uilist.GetTextHeight(label1) + 10;

            // Cập nhật chiều cao của toàn bộ UserControl hiện tại
            // panel1.Bottom chính là bằng panel1.Top + panel1.Height
            this.Height = panel1.Bottom + 10;

            // Nếu muốn đẩy UserControl hiện tại lên trên cùng
            this.BringToFront();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            AddHeightText();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Mỗi khi bạn thay đổi nội dung của Label từ Form chính, hãy gọi hàm
        public void UpdateControlSize()
        {
            // 1. Ép Label tính toán lại kích thước dựa theo Text mới
            label1.Refresh();

            // 2. Tính toán kích thước mới cho UserControl dựa vào vị trí và kích thước của Panel/Label
            // Cộng thêm khoảng cách (Padding/Margin) nếu cần để giao diện đẹp hơn
            this.Width = panel1.Width + panel1.Left * 2;
            this.Height = panel1.Bottom + 10; // Thay 10 bằng khoảng cách lề dưới bạn muốn
        }
    }
}
