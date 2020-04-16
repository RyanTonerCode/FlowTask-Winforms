﻿using System.Drawing;
using System.Windows.Forms;

namespace FlowTask_WinForms_Frontent
{
    public partial class ViewTask
    {
        public class SizableCheckBox : CheckBox
        {
            public override bool AutoSize
            {
                get => base.AutoSize;
                set => base.AutoSize = false;
            }

            public SizableCheckBox()
            {
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                int h = this.ClientSize.Height - 2;
                var rc = new System.Drawing.Rectangle(new Point(-1, this.Height / 2 - h / 2), new Size(h, h));
                if (FlatStyle == FlatStyle.Flat)
                    ControlPaint.DrawCheckBox(e.Graphics, rc, Checked ? ButtonState.Flat | ButtonState.Checked : ButtonState.Flat | ButtonState.Normal);
                else
                    ControlPaint.DrawCheckBox(e.Graphics, rc, Checked ? ButtonState.Checked : ButtonState.Normal);
            }
        }

    }
}
