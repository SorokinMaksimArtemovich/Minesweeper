using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using yt_DesignUI;

namespace Minesweeper.UserInterctionLayer.Components
{
    internal class LableWithIcon : Control
    {
        public Image Icon;

        public float roundingPercent = 0;
        public Color BorderColor { get; set; } = Color.Tomato;

        public StringFormat stringFormat = new StringFormat();

        public bool UseSystemPasswordChar { get; set; }

        public LableWithIcon()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            DoubleBuffered = true;

            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.HighQuality;

            graphics.Clear(Parent.BackColor);

            Rectangle internalRectangle = new Rectangle(2, 2, Width - 5, Height - 5);
            Rectangle externalRectangle = new Rectangle(0, 0, Width - 1, Height - 1);

            // Закругление
            float roundingValue = 0.1F;
            if (roundingPercent > 0)
            {
                roundingValue = Height / 100F * roundingPercent;
            }
            GraphicsPath roundedExternalRectangle = Drawer.RoundedRectangle(externalRectangle, roundingValue);
            GraphicsPath roundedInternalRectangle = Drawer.RoundedRectangle(internalRectangle, roundingValue);

            Rectangle imageRectangle = new Rectangle(8, 4, Height - 9, Height - 9);
            Rectangle textRectangle = new Rectangle(Height - 9, 2, Width - Height + 1, Height - 1);
            graphics.DrawPath(new Pen(BorderColor), roundedExternalRectangle);
            graphics.FillPath(new SolidBrush(BorderColor), roundedExternalRectangle);
            graphics.SetClip(roundedExternalRectangle);
            graphics.DrawPath(new Pen(BackColor), roundedInternalRectangle);
            graphics.FillPath(new SolidBrush(BackColor), roundedInternalRectangle);
            graphics.SetClip(roundedInternalRectangle);
            graphics.DrawImage(Icon, imageRectangle);
            graphics.DrawString(Text, Font, new SolidBrush(ForeColor), textRectangle, stringFormat);


        }
    }
}
