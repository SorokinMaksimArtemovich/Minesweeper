using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper.UserInterctionLayer.Components
{
    internal class CustomizedComboBox : Control
    {
        private Size baceSize;
        public Size BaceSize
        {
            private get { return baceSize; }
            set
            {
                baceSize = value;
                Size = value;
                OnBaceSizeChanged(baceSize);
            }
        }
        public Color BorderColor = Color.RoyalBlue;
        private StringFormat stringFormat = new StringFormat();
        private int BaceHeight = 20;
        private int ItemHeight = 15;
        private bool IsSignHovered = false;
        private bool IsItemsContains = false;
        private bool ShowItems = false;
        private Point ClickLocation = new Point();

        private Rectangle ExternalRectangle = new Rectangle();
        private Rectangle TextRectangle = new Rectangle();
        private Rectangle SignRectangle = new Rectangle();

        public List<string> Items { get; private set; } = new List<string>();
        private List<Rectangle> ItemPositions = new List<Rectangle>();

        public void AddItems(string[] Elements)
        {
            Items = new List<string>(); 
            ItemPositions = new List<Rectangle>();
            Items.AddRange(Elements);
            for (int i = 0; i < Elements.Length; i++)
            {
                ItemPositions.Add(new Rectangle(2, BaceHeight + i * ItemHeight + 1, Width - 5, ItemHeight));
            }
        }

        public CustomizedComboBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            DoubleBuffered = true;

            Size = new Size(100, 200);
            BorderColor = Color.RoyalBlue;
            stringFormat.Alignment = StringAlignment.Near;
            stringFormat.LineAlignment = StringAlignment.Center;

        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (SignRectangle.Contains(e.Location))
            {
                IsSignHovered = true;
            }
            else
            {
                IsSignHovered = false;
            }
            if (ShowItems)
            {
                IsItemsContains = false;
                foreach (var ItemPosition in ItemPositions)
                {
                    if (ItemPosition.Contains(e.Location))
                    {
                        IsItemsContains = true;
                        ClickLocation = e.Location;
                    }
                }
            }
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            IsSignHovered = false;
            IsItemsContains = false;
            Invalidate();
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (e.Button == MouseButtons.Left)
            {
                if (ClientRectangle.Contains(e.Location))
                {
                    if (ShowItems)
                    {
                        ShowItems = false;
                    }
                    else
                    {
                        ShowItems = true;
                    }
                    Invalidate();
                }
                for (int i = 0; i < ItemPositions.Count; i++)
                {
                    if (ItemPositions[i].Contains(e.Location))
                    {
                        Text = Items[i];

                        Invalidate();
                    }
                }
            }
        }
        protected void OnBaceSizeChanged(Size NewSize)
        {
            BaceHeight = NewSize.Height;
            ItemHeight = (int)(0.85 * NewSize.Height);
            Width = NewSize.Width;
            for (int i = 0; i < ItemPositions.Count; i++)
            {
                ItemPositions[i] = new Rectangle(2, BaceHeight + i * ItemHeight + 1, Width - 5, ItemHeight);
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            ExternalRectangle = new Rectangle(0, 0, Width - 1, BaceHeight - 1);
            TextRectangle = new Rectangle((int)(0.015 * Width), 0, Width - BaceHeight - 3, BaceHeight - 1);
            SignRectangle = new Rectangle(Width - BaceHeight, 1, BaceHeight - 2, BaceHeight - 3);

            graphics.Clear(Parent.BackColor);
            graphics.FillRectangle(new SolidBrush(BackColor), ExternalRectangle);
            graphics.DrawRectangle(new Pen(BorderColor, 2), ExternalRectangle);
            graphics.DrawLine(new Pen(BorderColor, 2), Width - BaceHeight, 0, Width - BaceHeight, BaceHeight - 1);
            graphics.DrawRectangle(new Pen(Color.FromArgb(40, Color.White)), SignRectangle);
            graphics.DrawLine(new Pen(BorderColor, 2), Width - 3 * BaceHeight / 4 - 1, 3 * BaceHeight / 8, Width - BaceHeight / 2, 5 * BaceHeight / 8);
            graphics.DrawLine(new Pen(BorderColor, 2), Width - BaceHeight / 2 - 2, 5 * BaceHeight / 8, Width - BaceHeight / 4 - 1, 3 * BaceHeight / 8);
            if (IsSignHovered)
            {
                graphics.FillRectangle(new SolidBrush(Color.FromArgb(80, BorderColor)), SignRectangle);
            }
            if (ShowItems)
            {
                Height = BaceHeight + ItemHeight * Items.Count + 4;
                graphics.DrawRectangle(new Pen(BorderColor, 2), new Rectangle(0, 0, Width - 1, Height - 1));
                for (int i = 0; i < Items.Count; i++)
                {
                    graphics.FillRectangle(new SolidBrush(BackColor), ItemPositions[i]);
                    graphics.DrawString(Items[i], Font, new SolidBrush(ForeColor), ItemPositions[i], stringFormat);
                    if (ItemPositions[i].Contains(ClickLocation) && IsItemsContains)
                    {
                        graphics.FillRectangle(new SolidBrush(Color.FromArgb(60, BorderColor)), ItemPositions[i]);
                    }
                }
            }
            else
            {
                Height = BaceHeight;
            }
            graphics.DrawString(Text, Font, new SolidBrush(BorderColor), TextRectangle, stringFormat);
        }
    }
}
