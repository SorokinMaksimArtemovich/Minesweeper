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
    internal class GameField : Control
    {
        public int closedCells { get; private set; } = 0;
        public int markedMines { get; private set; } = 0;
        public bool IsGameLost { get; private set; } = false;

        private int heightCount = 1, widthCount = 1;

        private int CellSize;

        private bool isFieldChanged = true;

        private Bitmap bitmap;

        private Rectangle fieldRectangle;

        private Cell[,] Field;

        Image EmptyImage = Image.FromFile(@"Images\EmptyCell.bmp");
        Image OneImage = Image.FromFile(@"Images\OneCell.bmp");
        Image TwoImage = Image.FromFile(@"Images\TwoCell.bmp");
        Image ThreeImage = Image.FromFile(@"Images\ThreeCell.bmp");
        Image FourImage = Image.FromFile(@"Images\FourCell.bmp");
        Image FiveImage = Image.FromFile(@"Images\FiveCell.bmp");
        Image SixImage = Image.FromFile(@"Images\SixCell.bmp");
        Image SevenImage = Image.FromFile(@"Images\SevenCell.bmp");
        Image EightImage = Image.FromFile(@"Images\EightCell.bmp");
        Image MineImage = Image.FromFile(@"Images\MineCell.bmp");
        Image ExplodedMineImage = Image.FromFile(@"Images\ExplodedMineCell.bmp");
        Image ClosedImage = Image.FromFile(@"Images\ClocedCell.bmp");
        Image MarkedImage = Image.FromFile(@"Images\MarkedCell.bmp");
        Image HightlightedImage = Image.FromFile(@"Images\HighlightedCell.bmp");

        private enum cellStyles // Набор стилей
        {
            Closed,

            Empty,

            One,

            Two,

            Three,

            Four,

            Five,

            Six,

            Seven,

            Eight,

            Mine,

            ExplodedMine,

            Marked,

            Highlighted
        }

        private class Cell
        {
            public cellStyles style;
            public short value;
            public short curentValue;
            public Rectangle rectangle;
            public bool isHovered;
            public bool isChanged;
            public bool isCrosshaired;

            public Cell(short Value, short CurentValue, bool IsOpened, bool IsMarked, bool IsHighlighted)
            {
                value = Value;
                curentValue = CurentValue;
                isHovered = false;
                isChanged = true;
                isCrosshaired = false;
                if (IsOpened)
                {
                    if (Value == 0)
                    {
                        style = cellStyles.Empty;
                    }
                    if (Value == 1)
                    {
                        style = cellStyles.One;
                    }
                    if (Value == 2)
                    {
                        style = cellStyles.Two;
                    }
                    if (Value == 3)
                    {
                        style = cellStyles.Three;
                    }
                    if (Value == 4)
                    {
                        style = cellStyles.Four;
                    }
                    if (Value == 5)
                    {
                        style = cellStyles.Five;
                    }
                    if (Value == 6)
                    {
                        style = cellStyles.Six;
                    }
                    if (Value == 7)
                    {
                        style = cellStyles.Seven;
                    }
                    if (Value == 8)
                    {
                        style = cellStyles.Eight;
                    }
                }
                else if (IsMarked)
                {
                    style = cellStyles.Marked;
                }
                else if (IsHighlighted)
                {
                    style = cellStyles.Highlighted;
                }
                else
                {
                    style = cellStyles.Closed;
                }
            }

            public void Open()
            {
                if (value == 0)
                {
                    style = cellStyles.Empty;
                    isChanged = true;
                }
                if (value == 1)
                {
                    style = cellStyles.One;
                    isChanged = true;
                }
                if (value == 2)
                {
                    style = cellStyles.Two;
                    isChanged = true;
                }
                if (value == 3)
                {
                    style = cellStyles.Three;
                    isChanged = true;
                }
                if (value == 4)
                {
                    style = cellStyles.Four;
                    isChanged = true;
                }
                if (value == 5)
                {
                    style = cellStyles.Five;
                    isChanged = true;
                }
                if (value == 6)
                {
                    style = cellStyles.Six;
                    isChanged = true;
                }
                if (value == 7)
                {
                    style = cellStyles.Seven;
                    isChanged = true;
                }
                if (value == 8)
                {
                    style = cellStyles.Eight;
                    isChanged = true;
                }
                if (value == -1)
                {
                    style = cellStyles.ExplodedMine;
                    isChanged = true;
                }
            }
        }

        public GameField()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            DoubleBuffered = true;
            Size = new Size(300, 400);
        }

        public void SetData(int HeightCount, int WidthCount, int MinesCount, int ClosedCells, int MarkedMines)
        {
            Field = new Cell[HeightCount, WidthCount];
            heightCount = HeightCount;
            widthCount = WidthCount;
            closedCells = ClosedCells;
            markedMines = MarkedMines;
            IsGameLost = false;
        }

        public List<List<Tuple<short, bool, bool, bool>>> GetField()
        {
            List<List<Tuple<short, bool, bool, bool>>> result = new List<List<Tuple<short, bool, bool, bool>>>();
            List<Tuple<short, bool, bool, bool>> row;
            Tuple<short, bool, bool, bool> cell;
            bool isOpened, isMarked, isHighlighted;
            for (int i = 0; i < heightCount; i++)
            {
                row = new List<Tuple<short, bool, bool, bool>>();
                for (int j = 0; j < widthCount; j++)
                {
                    isMarked = Field[i, j].style == cellStyles.Marked;
                    isHighlighted = Field[i, j].style == cellStyles.Highlighted;
                    isOpened = !(Field[i, j].style == cellStyles.Closed || isHighlighted || isMarked);
                    cell = new Tuple<short, bool, bool, bool>(Field[i, j].curentValue, isOpened, isMarked, isHighlighted);
                    row.Add(cell);
                }
                result.Add(row);
            }
            return result;
        }

        public void Add(int PositionX, int PositionY, short Value, short CurentValue, bool IsOpend, bool IsMarked, bool IsHightlighted)
        {
            Field[PositionX, PositionY] = new Cell(Value, CurentValue, IsOpend, IsMarked, IsHightlighted);
        }

        private void Explosion(int PositionX, int PositionY)
        {
            for (int i = 0; i < heightCount; i++)
            {
                for (int j = 0; j < widthCount; j++)
                {
                    if (Field[i, j].value == -1)
                    {
                        Field[i, j].style = cellStyles.Mine;
                        Field[i, j].isChanged = true;
                    }
                }
            }
            Field[PositionX, PositionY].style = cellStyles.ExplodedMine;
            Field[PositionX, PositionY].isChanged = true;
            IsGameLost = true;
        }

        private void OpenAll(int PositionX, int PositionY)
        {
            List<Tuple<int, int>> cells = new List<Tuple<int, int>>();
            cells.Add(new Tuple<int, int>(PositionX, PositionY));
            int i = 0;
            while (i < cells.Count)
            {
                if (cells[i].Item1 > 0 && cells[i].Item2 > 0 && (Field[cells[i].Item1 - 1, cells[i].Item2 - 1].style == cellStyles.Closed || Field[cells[i].Item1 - 1, cells[i].Item2 - 1].style == cellStyles.Highlighted))
                {
                    if (Field[cells[i].Item1 - 1, cells[i].Item2 - 1].curentValue == 0)
                    {
                        Field[cells[i].Item1 - 1, cells[i].Item2 - 1].Open();
                        closedCells--;
                        if (Field[cells[i].Item1 - 1, cells[i].Item2 - 1].style == cellStyles.ExplodedMine)
                        {
                            Explosion(cells[i].Item1 - 1, cells[i].Item2 - 1);
                        }
                        cells.Add(new Tuple<int, int>(cells[i].Item1 - 1, cells[i].Item2 - 1));
                    }
                    else
                    {
                        Field[cells[i].Item1 - 1, cells[i].Item2 - 1].Open();
                        closedCells--;
                        if (Field[cells[i].Item1 - 1, cells[i].Item2 - 1].style == cellStyles.ExplodedMine)
                        {
                            Explosion(cells[i].Item1 - 1, cells[i].Item2 - 1);
                        }
                    }
                }
                if (cells[i].Item1 > 0 && (Field[cells[i].Item1 - 1, cells[i].Item2].style == cellStyles.Closed || Field[cells[i].Item1 - 1, cells[i].Item2].style == cellStyles.Highlighted))
                {
                    if (Field[cells[i].Item1 - 1, cells[i].Item2].curentValue == 0)
                    {
                        Field[cells[i].Item1 - 1, cells[i].Item2].Open();
                        closedCells--;
                        if (Field[cells[i].Item1 - 1, cells[i].Item2].style == cellStyles.ExplodedMine)
                        {
                            Explosion(cells[i].Item1 - 1, cells[i].Item2);
                        }
                        cells.Add(new Tuple<int, int>(cells[i].Item1 - 1, cells[i].Item2));
                    }
                    else
                    {
                        Field[cells[i].Item1 - 1, cells[i].Item2].Open();
                        closedCells--;
                        if (Field[cells[i].Item1 - 1, cells[i].Item2].style == cellStyles.ExplodedMine)
                        {
                            Explosion(cells[i].Item1 - 1, cells[i].Item2);
                        }
                    }
                }
                if (cells[i].Item1 > 0 && cells[i].Item2 < widthCount - 1 && (Field[cells[i].Item1 - 1, cells[i].Item2 + 1].style == cellStyles.Closed || Field[cells[i].Item1 - 1, cells[i].Item2 + 1].style == cellStyles.Highlighted))
                {
                    if (Field[cells[i].Item1 - 1, cells[i].Item2 + 1].curentValue == 0)
                    {
                        Field[cells[i].Item1 - 1, cells[i].Item2 + 1].Open();
                        closedCells--;
                        if (Field[cells[i].Item1 - 1, cells[i].Item2 + 1].style == cellStyles.ExplodedMine)
                        {
                            Explosion(cells[i].Item1 - 1, cells[i].Item2 + 1);
                        }
                        cells.Add(new Tuple<int, int>(cells[i].Item1 - 1, cells[i].Item2 + 1));
                    }
                    else
                    {
                        Field[cells[i].Item1 - 1, cells[i].Item2 + 1].Open();
                        closedCells--;
                        if (Field[cells[i].Item1 - 1, cells[i].Item2 + 1].style == cellStyles.ExplodedMine)
                        {
                            Explosion(cells[i].Item1 - 1, cells[i].Item2 + 1);
                        }
                    }
                }
                if (cells[i].Item2 > 0 && (Field[cells[i].Item1, cells[i].Item2 - 1].style == cellStyles.Closed || Field[cells[i].Item1, cells[i].Item2 - 1].style == cellStyles.Highlighted))
                {
                    if (Field[cells[i].Item1, cells[i].Item2 - 1].curentValue == 0)
                    {
                        Field[cells[i].Item1, cells[i].Item2 - 1].Open();
                        closedCells--;
                        if (Field[cells[i].Item1, cells[i].Item2 - 1].style == cellStyles.ExplodedMine)
                        {
                            Explosion(cells[i].Item1, cells[i].Item2 - 1);
                        }
                        cells.Add(new Tuple<int, int>(cells[i].Item1, cells[i].Item2 - 1));
                    }
                    else
                    {
                        Field[cells[i].Item1, cells[i].Item2 - 1].Open();
                        closedCells--;
                        if (Field[cells[i].Item1, cells[i].Item2 - 1].style == cellStyles.ExplodedMine)
                        {
                            Explosion(cells[i].Item1, cells[i].Item2 - 1);
                        }
                    }
                }
                if (cells[i].Item2 < widthCount - 1 && (Field[cells[i].Item1, cells[i].Item2 + 1].style == cellStyles.Closed || Field[cells[i].Item1, cells[i].Item2 + 1].style == cellStyles.Highlighted))
                {
                    if (Field[cells[i].Item1, cells[i].Item2 + 1].curentValue == 0)
                    {
                        Field[cells[i].Item1, cells[i].Item2 + 1].Open();
                        closedCells--;
                        if (Field[cells[i].Item1, cells[i].Item2 + 1].style == cellStyles.ExplodedMine)
                        {
                            Explosion(cells[i].Item1, cells[i].Item2 + 1);
                        }
                        cells.Add(new Tuple<int, int>(cells[i].Item1, cells[i].Item2 + 1));
                    }
                    else
                    {
                        Field[cells[i].Item1, cells[i].Item2 + 1].Open();
                        closedCells--;
                        if (Field[cells[i].Item1, cells[i].Item2 + 1].style == cellStyles.ExplodedMine)
                        {
                            Explosion(cells[i].Item1, cells[i].Item2 + 1);
                        }
                    }
                }
                if (cells[i].Item1 < heightCount - 1 && cells[i].Item2 > 0 && (Field[cells[i].Item1 + 1, cells[i].Item2 - 1].style == cellStyles.Closed || Field[cells[i].Item1 + 1, cells[i].Item2 - 1].style == cellStyles.Highlighted))
                {
                    if (Field[cells[i].Item1 + 1, cells[i].Item2 - 1].curentValue == 0)
                    {
                        Field[cells[i].Item1 + 1, cells[i].Item2 - 1].Open();
                        closedCells--;
                        if (Field[cells[i].Item1 + 1, cells[i].Item2 - 1].style == cellStyles.ExplodedMine)
                        {
                            Explosion(cells[i].Item1 + 1, cells[i].Item2 - 1);
                        }
                        cells.Add(new Tuple<int, int>(cells[i].Item1 + 1, cells[i].Item2 - 1));
                    }
                    else
                    {
                        Field[cells[i].Item1 + 1, cells[i].Item2 - 1].Open();
                        closedCells--;
                        if (Field[cells[i].Item1 + 1, cells[i].Item2 - 1].style == cellStyles.ExplodedMine)
                        {
                            Explosion(cells[i].Item1 + 1, cells[i].Item2 - 1);
                        }
                    }
                }
                if (cells[i].Item1 < heightCount - 1 && (Field[cells[i].Item1 + 1, cells[i].Item2].style == cellStyles.Closed || Field[cells[i].Item1 + 1, cells[i].Item2].style == cellStyles.Highlighted))
                {
                    if (Field[cells[i].Item1 + 1, cells[i].Item2].curentValue == 0)
                    {
                        Field[cells[i].Item1 + 1, cells[i].Item2].Open();
                        closedCells--;
                        if (Field[cells[i].Item1 + 1, cells[i].Item2].style == cellStyles.ExplodedMine)
                        {
                            Explosion(cells[i].Item1 + 1, cells[i].Item2);
                        }
                        cells.Add(new Tuple<int, int>(cells[i].Item1 + 1, cells[i].Item2));
                    }
                    else
                    {
                        Field[cells[i].Item1 + 1, cells[i].Item2].Open();
                        closedCells--;
                        if (Field[cells[i].Item1 + 1, cells[i].Item2].style == cellStyles.ExplodedMine)
                        {
                            Explosion(cells[i].Item1 + 1, cells[i].Item2);
                        }
                    }
                }
                if (cells[i].Item1 < heightCount - 1 && cells[i].Item2 < widthCount - 1 && (Field[cells[i].Item1 + 1, cells[i].Item2 + 1].style == cellStyles.Closed || Field[cells[i].Item1 + 1, cells[i].Item2 + 1].style == cellStyles.Highlighted))
                {
                    if (Field[cells[i].Item1 + 1, cells[i].Item2 + 1].curentValue == 0)
                    {
                        Field[cells[i].Item1 + 1, cells[i].Item2 + 1].Open();
                        closedCells--;
                        if (Field[cells[i].Item1 + 1, cells[i].Item2 + 1].style == cellStyles.ExplodedMine)
                        {
                            Explosion(cells[i].Item1 + 1, cells[i].Item2 + 1);
                        }
                        cells.Add(new Tuple<int, int>(cells[i].Item1 + 1, cells[i].Item2 + 1));
                    }
                    else
                    {
                        Field[cells[i].Item1 + 1, cells[i].Item2 + 1].Open();
                        closedCells--;
                        if (Field[cells[i].Item1 + 1, cells[i].Item2 + 1].style == cellStyles.ExplodedMine)
                        {
                            Explosion(cells[i].Item1 + 1, cells[i].Item2 + 1);
                        }
                    }
                }
                i++;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                for (int i = 0; i < heightCount; i++)
                {
                    for (int j = 0; j < widthCount; j++)
                    {
                        if (Field[i, j].rectangle.Contains(e.Location))
                        {
                            if (Field[i, j].style == cellStyles.Closed | Field[i, j].style == cellStyles.Highlighted)
                            {
                                if (Field[i, j].value == -1)
                                {
                                    Explosion(i, j);
                                    Refresh();
                                }
                                else
                                {
                                    Field[i, j].Open();
                                    closedCells--;
                                    if (Field[i, j].curentValue == 0)
                                    {
                                        OpenAll(i, j);
                                    }
                                    Refresh();
                                }
                            }
                        }
                    }
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < heightCount; i++)
                {
                    for (int j = 0; j < widthCount; j++)
                    {
                        if (Field[i, j].rectangle.Contains(e.Location))
                        {
                            if (Field[i, j].style == cellStyles.Closed)
                            {
                                markedMines++;
                                Field[i, j].style = cellStyles.Marked;
                                Field[i, j].isChanged = true;


                                if (i > 0 && j > 0 && Field[i - 1, j - 1].value != -1)
                                {
                                    Field[i - 1, j - 1].curentValue--;
                                }
                                if (i > 0 && Field[i - 1, j].value != -1)
                                {
                                    Field[i - 1, j].curentValue--;
                                }
                                if (i > 0 && j < widthCount - 1 && Field[i - 1, j + 1].value != -1)
                                {
                                    Field[i - 1, j + 1].curentValue--;
                                }
                                if (j > 0 && Field[i, j - 1].value != -1)
                                {
                                    Field[i, j - 1].curentValue--;
                                }
                                if (j < widthCount - 1 && Field[i, j + 1].value != -1)
                                {
                                    Field[i, j + 1].curentValue--;
                                }
                                if (i < heightCount - 1 && j > 0 && Field[i + 1, j - 1].value != -1)
                                {
                                    Field[i + 1, j - 1].curentValue--;
                                }
                                if (i < heightCount - 1 && Field[i + 1, j].value != -1)
                                {
                                    Field[i + 1, j].curentValue--;
                                }
                                if (i < heightCount - 1 && j < widthCount - 1 && Field[i + 1, j + 1].value != -1)
                                {
                                    Field[i + 1, j + 1].curentValue--;
                                }

                                Refresh();
                            }
                            else if (Field[i, j].style == cellStyles.Marked)
                            {
                                markedMines--;
                                Field[i, j].style = cellStyles.Highlighted;
                                Field[i, j].isChanged = true;


                                if (i > 0 && j > 0 && Field[i - 1, j - 1].value != -1)
                                {
                                    Field[i - 1, j - 1].curentValue++;
                                }
                                if (i > 0 && Field[i - 1, j].value != -1)
                                {
                                    Field[i - 1, j].curentValue++;
                                }
                                if (i > 0 && j < widthCount - 1 && Field[i - 1, j + 1].value != -1)
                                {
                                    Field[i - 1, j + 1].curentValue++;
                                }
                                if (j > 0 && Field[i, j - 1].value != -1)
                                {
                                    Field[i, j - 1].curentValue++;
                                }
                                if (j < widthCount - 1 && Field[i, j + 1].value != -1)
                                {
                                    Field[i, j + 1].curentValue++;
                                }
                                if (i < heightCount - 1 && j > 0 && Field[i + 1, j - 1].value != -1)
                                {
                                    Field[i + 1, j - 1].curentValue++;
                                }
                                if (i < heightCount - 1 && Field[i + 1, j].value != -1)
                                {
                                    Field[i + 1, j].curentValue++;
                                }
                                if (i < heightCount - 1 && j < widthCount - 1 && Field[i + 1, j + 1].value != -1)
                                {
                                    Field[i + 1, j + 1].curentValue++;
                                }

                                Refresh();
                            }
                            else if (Field[i, j].style == cellStyles.Highlighted)
                            {
                                Field[i, j].style = cellStyles.Closed;
                                Field[i, j].isChanged = true;
                                Refresh();
                            }
                        }
                    }
                }
            }
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);
            if (e.Button == MouseButtons.Left)
            {
                for (int i = 0; i < heightCount; i++)
                {
                    for (int j = 0; j < widthCount; j++) {

                        if (Field[i, j].rectangle.Contains(e.Location) && (Field[i, j].style != cellStyles.Closed || Field[i, j].style != cellStyles.Marked || Field[i, j].style != cellStyles.Highlighted))
                        {
                            if (Field[i, j].curentValue == 0)
                            {
                                OpenAll(i, j);
                                Refresh();
                            }
                            else
                            {
                                Field[i, j].isCrosshaired = true;
                                Refresh();
                                Field[i, j].isCrosshaired = false;
                                Refresh();
                                Field[i, j].isCrosshaired = true;
                                Refresh();
                                Field[i, j].isCrosshaired = false;
                                Refresh();
                            }
                        }
                    }
                } }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            bitmap = new Bitmap(Width, Height);
            isFieldChanged = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            foreach (var i in Field)
            {
                if (i.isHovered)
                {
                    i.isHovered = false;
                    Refresh();
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            foreach (var i in Field)
            {
                if (i.rectangle.Contains(e.Location))
                {
                    i.isHovered = true;
                    Refresh();
                }
                else
                {
                    if (i.isHovered)
                    {
                        i.isHovered = false;
                        Refresh();
                    }
                }
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);
            if (isFieldChanged)
            {
                CellSize = (Height - 3) / heightCount;

                fieldRectangle = new Rectangle(0, 0, Width - 1, Height - 1);

                for (int i = 0; i < heightCount; i++)
                {
                    for (int j = 0; j < widthCount; j++)
                    {
                        Field[i, j].rectangle = new Rectangle(1 + j * CellSize, 1 + i * CellSize, CellSize, CellSize);
                    }
                }

                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.DrawRectangle(new Pen(BackColor), fieldRectangle);
                    graphics.FillRectangle(new SolidBrush(BackColor), fieldRectangle);
                    foreach (var i in Field)
                    {
                        if (i.style == cellStyles.Empty)
                        {
                            graphics.DrawImage(EmptyImage, i.rectangle);
                            i.isChanged = false;
                        }
                        else if (i.style == cellStyles.One)
                        {
                            graphics.DrawImage(OneImage, i.rectangle);
                            i.isChanged = false;
                        }
                        else if (i.style == cellStyles.Two)
                        {
                            graphics.DrawImage(TwoImage, i.rectangle);
                            i.isChanged = false;
                        }
                        else if (i.style == cellStyles.Three)
                        {
                            graphics.DrawImage(ThreeImage, i.rectangle);
                            i.isChanged = false;
                        }
                        else if (i.style == cellStyles.Four)
                        {
                            graphics.DrawImage(FourImage, i.rectangle);
                            i.isChanged = false;
                        }
                        else if (i.style == cellStyles.Five)
                        {
                            graphics.DrawImage(FiveImage, i.rectangle);
                            i.isChanged = false;
                        }
                        else if (i.style == cellStyles.Six)
                        {
                            graphics.DrawImage(SixImage, i.rectangle);
                            i.isChanged = false;
                        }
                        else if (i.style == cellStyles.Seven)
                        {
                            graphics.DrawImage(SevenImage, i.rectangle);
                            i.isChanged = false;
                        }
                        else if (i.style == cellStyles.Eight)
                        {
                            graphics.DrawImage(EightImage, i.rectangle);
                            i.isChanged = false;
                        }
                        else if (i.style == cellStyles.Mine)
                        {
                            graphics.DrawImage(MineImage, i.rectangle);
                            i.isChanged = false;
                        }
                        else if (i.style == cellStyles.ExplodedMine)
                        {
                            graphics.DrawImage(ExplodedMineImage, i.rectangle);
                            i.isChanged = false;
                        }
                        else if (i.style == cellStyles.Closed)
                        {
                            graphics.DrawImage(ClosedImage, i.rectangle);
                            i.isChanged = false;
                        }
                        else if (i.style == cellStyles.Marked)
                        {
                            graphics.DrawImage(MarkedImage, i.rectangle);
                            i.isChanged = false;

                        }
                        else if (i.style == cellStyles.Highlighted)
                        {
                            graphics.DrawImage(HightlightedImage, i.rectangle);
                            i.isChanged = false;

                        }
                    }
                    isFieldChanged = false;
                }
            }

            pevent.Graphics.DrawImage(bitmap, fieldRectangle);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;           

            for (int i = 0; i < heightCount; i++)
            {
                for (int j = 0; j < widthCount; j++)
                {
                    if (Field[i, j].style == cellStyles.Empty & Field[i, j].isChanged)
                    {
                        e.Graphics.DrawImage(EmptyImage, Field[i, j].rectangle);
                    }
                    else if (Field[i, j].style == cellStyles.One & Field[i, j].isChanged)
                    {
                        e.Graphics.DrawImage(OneImage, Field[i, j].rectangle);
                    }
                    else if (Field[i, j].style == cellStyles.Two & Field[i, j].isChanged)
                    {
                        e.Graphics.DrawImage(TwoImage, Field[i, j].rectangle);
                    }
                    else if (Field[i, j].style == cellStyles.Three & Field[i, j].isChanged)
                    {
                        e.Graphics.DrawImage(ThreeImage, Field[i, j].rectangle);
                    }
                    else if (Field[i, j].style == cellStyles.Four & Field[i, j].isChanged)
                    {
                        e.Graphics.DrawImage(FourImage, Field[i, j].rectangle);
                    }
                    else if (Field[i, j].style == cellStyles.Five & Field[i, j].isChanged)
                    {
                        e.Graphics.DrawImage(FiveImage, Field[i, j].rectangle);
                    }
                    else if (Field[i, j].style == cellStyles.Six & Field[i, j].isChanged)
                    {
                        e.Graphics.DrawImage(SixImage, Field[i, j].rectangle);
                    }
                    else if (Field[i, j].style == cellStyles.Seven & Field[i, j].isChanged)
                    {
                        e.Graphics.DrawImage(SevenImage, Field[i, j].rectangle);
                    }
                    else if (Field[i, j].style == cellStyles.Eight & Field[i, j].isChanged)
                    {
                        e.Graphics.DrawImage(EightImage, Field[i, j].rectangle);
                    }
                    else if (Field[i, j].style == cellStyles.Mine & Field[i, j].isChanged)
                    {
                        e.Graphics.DrawImage(MineImage, Field[i, j].rectangle);
                    }
                    else if (Field[i, j].style == cellStyles.ExplodedMine & Field[i, j].isChanged)
                    {
                        e.Graphics.DrawImage(ExplodedMineImage, Field[i, j].rectangle);
                    }
                    else if (Field[i, j].style == cellStyles.Closed & Field[i, j].isChanged)
                    {
                        e.Graphics.DrawImage(ClosedImage, Field[i, j].rectangle);
                    }
                    else if (Field[i, j].style == cellStyles.Marked & Field[i, j].isChanged)
                    {
                        e.Graphics.DrawImage(MarkedImage, Field[i, j].rectangle);

                    }
                    else if (Field[i, j].style == cellStyles.Highlighted & Field[i, j].isChanged)
                    {
                        e.Graphics.DrawImage(HightlightedImage, Field[i, j].rectangle);

                    }
                }
            }
            foreach (var i in Field)
            {
                if ((i.style == cellStyles.Closed
                            | i.style == cellStyles.Marked
                            | i.style == cellStyles.Highlighted)
                            & i.isHovered)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(120, Color.White)), i.rectangle);
                }
            }
            foreach (var i in Field)
            {
                if (i.isCrosshaired)
                {
                    e.Graphics.DrawLine(new Pen(Color.Red, 5), i.rectangle.Left, i.rectangle.Top, i.rectangle.Right, i.rectangle.Bottom);
                    e.Graphics.DrawLine(new Pen(Color.Red, 5), i.rectangle.Left, i.rectangle.Bottom, i.rectangle.Right, i.rectangle.Top);
                }
            }
        }
    }
}
