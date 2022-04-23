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
    internal class BorderedPanel : Control
    {
        [Description("Цвет обводки (границы) кнопки")]
        public Color BorderColor { get; set; } = Color.Tomato;

        private List<int> RadioButtons = new List<int>();
        public BorderedPanel()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            DoubleBuffered = true;

            Size = new Size(100, 30);

            Font = new Font("Verdana", 8.25F, FontStyle.Regular);

            BackColor = Color.Tomato;
            BorderColor = BackColor;
            ForeColor = Color.White;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            graphics.Clear(Parent.BackColor);

            Rectangle rectangle = new Rectangle(0, 0, Width - 1, Height - 1);

            graphics.DrawRectangle(new Pen(BorderColor), rectangle);
            graphics.FillRectangle(new SolidBrush(BackColor), rectangle);
        }
    }
}
