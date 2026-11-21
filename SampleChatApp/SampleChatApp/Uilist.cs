using System;
using System.Collections.Generic;
using System.Text;

namespace SampleChatApp
{
    internal class Uilist
    {
        public static int GetTextHeight(Label lbl)
        {
            using (Graphics g = lbl.CreateGraphics())
            {
                SizeF size = g.MeasureString(lbl.Text, lbl.Font, 495);
                return (int)Math.Ceiling(size.Height);
            }
        }
    }
}
