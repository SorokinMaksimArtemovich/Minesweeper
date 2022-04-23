using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using yt_DesignUI;

namespace Minesweeper.UserInterctionLayer.Components
{
    internal class BorderedTextBox : Control
    {

        [Description("Цвет обводки (границы) кнопки")]
        public Color BorderColor { get; set; } = Color.Tomato;

        public bool IsActive = false;
        public bool IsFocused = false;
        private bool IsVisible = false;

        public StringFormat stringFormat = new StringFormat();

        private Timer timer = new Timer();

        public bool UseSystemPasswordChar {get; set;}

        void timer_Tick(object sender, EventArgs e)
        {
            IsVisible = !IsVisible;
            Invalidate();
        }

        public BorderedTextBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            DoubleBuffered = true;

            stringFormat.Alignment = StringAlignment.Near;
            stringFormat.LineAlignment = StringAlignment.Center;

            timer.Interval = 700;
            timer.Tick += new EventHandler(timer_Tick);

            IsFocused = false;
        }


        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);

        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
        }
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            IsFocused = false;
            timer.Stop();
            Invalidate();
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            IsFocused = false;
            timer.Stop();
            Invalidate();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            IsFocused = true;
            timer.Start();
            IsVisible = true;
            Invalidate();
        }


        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            Focus();
            IsFocused = true; 
            timer.Start();
            IsVisible = true;
            Invalidate();
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar == 8)
            {
                if (Text.Length != 0)
                {
                    Text = Text.Substring(0, Text.Length - 1);
                }
            }
            else
            {
                Text += e.KeyChar;
            }
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.HighQuality;

            graphics.Clear(Parent.BackColor);

            Rectangle rectangle = new Rectangle(0, 0, Width - 1, Height - 1);
            Rectangle textRectangle = new Rectangle(3, 0, Width - 7, Height - 1);

            if (IsActive)
            {
                graphics.DrawRectangle(new Pen(BorderColor), rectangle);
                graphics.FillRectangle(new SolidBrush(BackColor), rectangle);
                if (Focused)
                {
                    if (IsVisible)
                    {
                        graphics.DrawString(Text + '|', Font, new SolidBrush(ForeColor), textRectangle, stringFormat);
                    }
                    else
                    {
                        graphics.DrawString(Text, Font, new SolidBrush(ForeColor), textRectangle, stringFormat);
                    }
                }
                else
                {
                    graphics.DrawString(Text, Font, new SolidBrush(ForeColor), textRectangle, stringFormat);
                }
            }
            else
            {
                graphics.DrawRectangle(new Pen(Color.FromArgb(90, BorderColor)), rectangle);
                graphics.FillRectangle(new SolidBrush(Color.FromArgb(90, BackColor)), rectangle);
                graphics.DrawString(Text, Font, new SolidBrush(Color.FromArgb(90, ForeColor)), textRectangle, stringFormat);
            }
        }
    }
}
