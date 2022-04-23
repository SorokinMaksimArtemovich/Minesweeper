using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using yt_DesignUI;

namespace Minesweeper
{
    public class InterectiveList : Control
    {

        [Description("Возвращает или задает цвет границы (обводки)")]
        public Color BorderColor { get; set; } = Color.Tomato;

        [Description("Возвращает или задает цвет строки списка")]
        public Color ItemColor { get; set; } = Color.Azure;

        [Description("Возвращает или задает цвет границы элемента списка")]
        public Color ItemBorderColor { get; set; } = Color.RoyalBlue;

        [Description("Возвращает или задает шрифт текста строки списка")]
        public Font ItemTextFont { get; set; } = new Font("Verdana", 8.25F, FontStyle.Regular);

        [Description("Возвращает или задает цвет текста строки списка")]
        public Color ItemTextColor { get; set; } = Color.RoyalBlue;

        [Description("Возвращает или задает формит текста строки списка")]
        public StringFormat ItemSF { get; set; } = new StringFormat();

        private int CurentItemPosition = 1;

        private List<ListItem> Items = new List<ListItem>();

        private bool MousePressed = false;

        private int ItemHeight = 30;

        private MouseButtons LastClickedMouseButton = new MouseButtons();

        public string ClickedItem { get; private set; } = null;
        private class ListItem
        {
            public string Name { get; private set; }
            public Rectangle Rectangle { get;  set; }
            public bool IsHovered { get; set; } = false;

            public ListItem(string name, Rectangle rectangle)
            {
                Name = name;
                Rectangle = rectangle;
            }
        }

        public InterectiveList()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            DoubleBuffered = true;

            Size = new Size(400, 200);

            Font = new Font("Verdana", 8.25F, FontStyle.Regular);

            Cursor = Cursors.Hand;

            ItemSF.Alignment = StringAlignment.Center;
            ItemSF.LineAlignment = StringAlignment.Center;

            BackColor = Color.Azure;
            BorderColor = Color.DarkCyan;
            ForeColor = Color.RoyalBlue;
        }


        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            // Hovering
            foreach (var i in Items) {
                // New Game Menu Item Hovering
                if (i.Rectangle.Contains(e.Location))
                {
                    if (i.IsHovered == false)
                    {
                        i.IsHovered = true;

                        Invalidate();
                    }

                    Invalidate();
                }
                else
                {
                    if (i.IsHovered == true)
                    {
                        i.IsHovered = false;
                        Invalidate();
                    }
                }
            }
        }


        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            foreach (var i in Items)
            {
                if (i.IsHovered == true)
                {
                    i.IsHovered = false;
                }
            }
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            MousePressed = false;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            MousePressed = true;
            foreach (var i in Items)
            {
                if (e.Location.Y <= Height
                    && i.Rectangle.Contains(e.Location))
                {
                    ClickedItem = i.Name;
                }

                LastClickedMouseButton = e.Button;
            }
            Invalidate();
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            CurentItemPosition = 1;
            ItemHeight = (int)(0.12 * Height);
            foreach (var i in Items)
            {
                i.Rectangle = new Rectangle(1, CurentItemPosition, Width - 3, ItemHeight);
                CurentItemPosition += ItemHeight;
            }
        }
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (Items[Items.Count - 1].Rectangle.Bottom > Height && e.Delta < 0)
            {
                if (Items[Items.Count - 1].Rectangle.Bottom + e.Delta / 4 > Height)
                {
                    foreach (var i in Items)
                    {
                        i.Rectangle = new Rectangle(i.Rectangle.X, i.Rectangle.Y + e.Delta / 4, i.Rectangle.Width, i.Rectangle.Height);
                    }
                }
                else
                {
                    int specialDelta = Height - Items[Items.Count - 1].Rectangle.Bottom - 2;
                    foreach (var i in Items)
                    {
                        i.Rectangle = new Rectangle(i.Rectangle.X, i.Rectangle.Y + specialDelta, i.Rectangle.Width, i.Rectangle.Height);
                    }
                }
            }
            else if (Items[0].Rectangle.Y < 1 && e.Delta > 0)
            {
                if (Items[0].Rectangle.Y + e.Delta / 4 < 1)
                {
                    foreach (var i in Items)
                    {
                        i.Rectangle = new Rectangle(i.Rectangle.X, i.Rectangle.Y + e.Delta / 4, i.Rectangle.Width, i.Rectangle.Height);
                    }
                }
                else
                {
                    int specialDelta = 1 - Items[0].Rectangle.Y;
                    foreach (var i in Items)
                    {
                        i.Rectangle = new Rectangle(i.Rectangle.X, i.Rectangle.Y + specialDelta, i.Rectangle.Width, i.Rectangle.Height);
                    }
                }
            }
            Invalidate();
        }

        public void AddItem(string Item)
        {
            ItemHeight = (int)(0.12 * Height);
            Items.Add(new ListItem(Item, new Rectangle(1, CurentItemPosition, Width - 3, ItemHeight)));
            CurentItemPosition += ItemHeight;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            graphics.Clear(Parent.BackColor);

            Rectangle rectangle = new Rectangle(0, 0, Width - 1, Height - 1);

            graphics.FillRectangle(new SolidBrush(BackColor), rectangle);

            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].Rectangle.Top > 0 && Items[i].Rectangle.Bottom < Height - 1)
                {
                    graphics.DrawRectangle(new Pen(ItemBorderColor), Items[i].Rectangle);
                    graphics.FillRectangle(new SolidBrush(ItemColor), Items[i].Rectangle);
                    graphics.DrawString(Items[i].Name, ItemTextFont, new SolidBrush(ItemTextColor), Items[i].Rectangle, ItemSF);

                    if (Items[i].IsHovered)
                    {
                        graphics.DrawRectangle(new Pen(Color.FromArgb(30, Color.Blue)), Items[i].Rectangle);
                        graphics.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.Blue)), Items[i].Rectangle);
                        if (MousePressed && LastClickedMouseButton == MouseButtons.Left)
                        {
                            graphics.DrawRectangle(new Pen(Color.FromArgb(30, Color.RoyalBlue)), Items[i].Rectangle);
                            graphics.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.RoyalBlue)), Items[i].Rectangle);
                        }
                    }
                }
                else if (Items[i].Rectangle.Top > 0 && Items[i].Rectangle.Top < Height - 1)
                {
                    graphics.DrawRectangle(new Pen(ItemBorderColor), new Rectangle(1, Items[i].Rectangle.Top, Width - 3, Height -2));
                    graphics.FillRectangle(new SolidBrush(ItemColor), new Rectangle(1, Items[i].Rectangle.Top, Width - 3, Height - 2));
                    graphics.DrawString(Items[i].Name, ItemTextFont, new SolidBrush(ItemTextColor), Items[i].Rectangle, ItemSF);

                    if (Items[i].IsHovered)
                    {
                        graphics.DrawRectangle(new Pen(Color.FromArgb(30, Color.Blue)), new Rectangle(1, Items[i].Rectangle.Top, Width - 3, Height - 2));
                        graphics.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.Blue)), new Rectangle(1, Items[i].Rectangle.Top, Width - 3, Height - 2));
                        if (MousePressed && LastClickedMouseButton == MouseButtons.Left)
                        {
                            graphics.DrawRectangle(new Pen(Color.FromArgb(60, Color.RoyalBlue)), new Rectangle(1, Items[i].Rectangle.Top, Width - 3, Height - 2));
                            graphics.FillRectangle(new SolidBrush(Color.FromArgb(60, Color.RoyalBlue)), new Rectangle(1, Items[i].Rectangle.Top, Width - 3, Height - 2));
                        }
                    }
                }
                else if (Items[i].Rectangle.Bottom < Height - 1 && Items[i].Rectangle.Bottom > 0)
                {
                    graphics.DrawRectangle(new Pen(ItemBorderColor), new Rectangle(1, 1, Width - 3, Items[i].Rectangle.Bottom));
                    graphics.FillRectangle(new SolidBrush(ItemColor), new Rectangle(1, 1, Width - 3, Items[i].Rectangle.Bottom));
                    graphics.DrawString(Items[i].Name, ItemTextFont, new SolidBrush(ItemTextColor), Items[i].Rectangle, ItemSF);

                    if (Items[i].IsHovered)
                    {
                        graphics.DrawRectangle(new Pen(Color.FromArgb(30, Color.Blue)), new Rectangle(1, 1, Width - 3, Items[i].Rectangle.Bottom));
                        graphics.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.Blue)), new Rectangle(1, 1, Width - 3, Items[i].Rectangle.Bottom));
                        if (MousePressed && LastClickedMouseButton == MouseButtons.Left)
                        {
                            graphics.DrawRectangle(new Pen(Color.FromArgb(60, Color.RoyalBlue)), new Rectangle(1, 1, Width - 3, Items[i].Rectangle.Bottom));
                            graphics.FillRectangle(new SolidBrush(Color.FromArgb(60, Color.RoyalBlue)), new Rectangle(1, 1, Width - 3, Items[i].Rectangle.Bottom));
                        }
                    }
                }
            }
            graphics.DrawRectangle(new Pen(BorderColor), rectangle);
        }

    }
}
