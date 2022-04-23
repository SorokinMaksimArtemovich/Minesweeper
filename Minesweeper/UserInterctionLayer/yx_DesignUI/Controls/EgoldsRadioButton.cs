using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using EgoldsUI;

namespace yt_DesignUI
{
    public class EgoldsRadioButton : RadioButton
    {
        #region -- Переменные --

        StringFormat SF = new StringFormat();

        [Description("Цвет обводки (границы) кнопки")]
        public Color BorderColor { get; set; } = Color.Tomato;

        [Description("Цвет заполнения кнопки")]
        public Color FillColor { get; set; } = Color.Tomato;

        public bool IsChecked { get; set; } = false;

        #endregion

        #region -- Свойства --

        #endregion

        public EgoldsRadioButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            DoubleBuffered = true;

            Size = new Size(150, 15);

            Font = new Font("Verdana", 9F, FontStyle.Regular);
            BackColor = Color.White;

            SF.LineAlignment = StringAlignment.Center;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graph = e.Graphics;
            graph.SmoothingMode = SmoothingMode.HighQuality;
            graph.Clear(Parent.BackColor);

            //SizeF textSize = graph.MeasureString(Text, Font);
            //Width = (int)textSize.Width + Height + 3;

            Pen RBPen = new Pen(BorderColor, 3);

            Rectangle RBrect = new Rectangle(1, 3, Height - 7, Height - 7);
            Rectangle RBrectText = new Rectangle(Height + 1, 0, Width - Height, Height);

            Rectangle RBrectChecked = new Rectangle(RBrect.X + 3, RBrect.Y + 3, RBrect.Width - 6, RBrect.Height - 6);

            graph.DrawEllipse(RBPen, RBrect);
            graph.FillEllipse(new SolidBrush(BackColor), RBrect);

            if (IsChecked)
            {
                //graph.DrawEllipse(RBPen, RBrectChecked);
                graph.FillEllipse(new SolidBrush(FillColor), RBrectChecked);
            }

            graph.DrawString(Text, Font, new SolidBrush(ForeColor), RBrectText, SF);
        }

        protected override void OnCheckedChanged(EventArgs e)
        {
            base.OnCheckedChanged(e);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);

            if (!IsChecked)
            {
                IsChecked = true;
            }

            Invalidate();

        }
    }
}