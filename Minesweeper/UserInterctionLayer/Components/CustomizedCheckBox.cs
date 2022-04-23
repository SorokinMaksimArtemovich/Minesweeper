using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper.UserInterctionLayer.Components
{
    internal class CustomizedCheckBox : CheckBox
    {
        [Description("Цвет заполнения кнопки")]
        public Color FillColor { get; set; } = Color.Tomato;

        public bool IsChecked = false;

        public StringFormat stringFormat = new StringFormat();
        public CustomizedCheckBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            DoubleBuffered = true;
            stringFormat.Alignment = StringAlignment.Near;
            stringFormat.LineAlignment = StringAlignment.Center;
            AutoSize = false;
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (IsChecked)
            {
                IsChecked = false;
            }
            else
            {
                IsChecked = true;
            }
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            graphics.Clear(Parent.BackColor);

            Rectangle CheckBoxRectangle = new Rectangle(1, 1, Height - 2, Height - 2);
            Rectangle TextRectangle = new Rectangle(Height + 1, 0, Width - Height, Height);

            Rectangle CheckedSymbolRectangle = new Rectangle(CheckBoxRectangle.X + 3, CheckBoxRectangle.Y + 3, CheckBoxRectangle.Width - 6, CheckBoxRectangle.Height - 6);

            graphics.DrawRectangle(new Pen(FillColor), CheckBoxRectangle);

            if (IsChecked)
            {
                graphics.DrawLine(
                new Pen(FillColor, 2),
                CheckedSymbolRectangle.X,
                CheckedSymbolRectangle.Y + CheckedSymbolRectangle.Height / 2,
                CheckedSymbolRectangle.X + CheckedSymbolRectangle.Width / 2,
                CheckedSymbolRectangle.Y + CheckedSymbolRectangle.Height);

                graphics.DrawLine(
                new Pen(FillColor, 2),
                CheckedSymbolRectangle.X + CheckedSymbolRectangle.Width / 2,
                CheckedSymbolRectangle.Y + CheckedSymbolRectangle.Height,
                CheckedSymbolRectangle.X + CheckedSymbolRectangle.Width,
                CheckedSymbolRectangle.Y);
            }


            graphics.DrawString(Text, Font, new SolidBrush(ForeColor), TextRectangle, stringFormat);
        }
    }
}
