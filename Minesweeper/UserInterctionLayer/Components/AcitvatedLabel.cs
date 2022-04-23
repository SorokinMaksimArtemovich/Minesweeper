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
    internal class AcitvatedLabel : Label
    {
        [Description("Перевести надпись в аткивное/неактивное состояние")]
        public bool IsActive { get; set; } = false;

        public AcitvatedLabel()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            DoubleBuffered = true;

            Font = new Font("Verdana", 8.25F, FontStyle.Regular);

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

            graphics.DrawString(Text, Font, new SolidBrush(IsActive ? ForeColor : Color.FromArgb(150, ForeColor)), rectangle);
        }
    }
}
