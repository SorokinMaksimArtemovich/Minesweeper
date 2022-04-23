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
    internal class CustomizedTable : Control
    {
        private int RowCount = 0;
        private int RowHeight = 20;
        public Color BorderColor = Color.RoyalBlue;
        private int ColumnWidth = 40;
        public int HeaderHeight = 35;
        private bool TableHasRows = false;

        private StringFormat stringFormat = new StringFormat();

        private static Dictionary<cellStyles, TableCellStyle> StaylesDictionary = new Dictionary<cellStyles, TableCellStyle>();

        public CustomizedTable()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            DoubleBuffered = true;

            Size = new Size(150, 100);
            BackColor = Color.White;
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            StaylesDictionary = new Dictionary<cellStyles, TableCellStyle>();
            InitializeStyles();
        }

        public enum cellStyles // Набор стилей
        {
            Bace,

            StrongHighlighted,

            WeakHighlighted,

            Selected,

            Header,

            SelectedHeader,

            HighlightedHeader
        }

        private class TableCellStyle
        {
            public Color borderColor { get; private set; } = Color.Blue;
            public Color backColor { get; private set; } = Color.White;
            public Color foreColor { get; private set; } = Color.Blue;
            public Font font { get; private set; } = new Font("Segoe UI", 9.75F, FontStyle.Regular);

            public TableCellStyle(Color BackColor, Color BorderColor, Color ForeColor, Font Font)
            {
                backColor = BackColor;
                borderColor = BorderColor;
                foreColor = ForeColor;
                font = Font;
            }
        }

        private void InitializeStyles()
        {
            // Bace Style
            StaylesDictionary.Add
                (
                cellStyles.Bace,
                new TableCellStyle
                    (
                    Color.White,
                    Color.RoyalBlue,
                    Color.RoyalBlue,
                    new Font("Segoe UI", (float)(0.0382 * Height), FontStyle.Regular)
                    )
                );
            // WeakHighlidhted Style
            StaylesDictionary.Add
                (
                cellStyles.WeakHighlighted,
                new TableCellStyle
                    (
                    Color.Azure,
                    Color.RoyalBlue,
                    Color.RoyalBlue,
                    new Font("Segoe UI", (float)(0.0382 * Height), FontStyle.Regular)
                    )
                );
            // StrongHighlidhted Style
            StaylesDictionary.Add
                (
                cellStyles.StrongHighlighted,
                new TableCellStyle
                    (
                    Color.LightCyan,
                    Color.RoyalBlue,
                    Color.RoyalBlue,
                    new Font("Segoe UI", (float)(0.0382 * Height), FontStyle.Regular)
                    )
                );
            // Selected Style
            StaylesDictionary.Add
                (
                cellStyles.Selected,
                new TableCellStyle
                    (
                    Color.LightBlue,
                    Color.DarkBlue,
                    Color.RoyalBlue,
                    new Font("Segoe UI", (float)(0.0402 * Height), FontStyle.Regular)
                    )
                );
            // Header Style
            StaylesDictionary.Add
                (
                cellStyles.Header,
                new TableCellStyle
                    (
                    Color.White,
                    Color.Blue,
                    Color.Blue,
                    new Font("Segoe UI", (float)(0.0402 * Height), FontStyle.Regular)
                    )
                );
            // HighlidhtedHeader Style
            StaylesDictionary.Add
                (
                cellStyles.HighlightedHeader,
                new TableCellStyle
                    (
                    Color.Azure,
                    Color.Blue,
                    Color.Blue,
                    new Font("Segoe UI", (float)(0.0402 * Height), FontStyle.Regular)
                    )
                );
            // SelectedHeader Style
            StaylesDictionary.Add
                (
                cellStyles.SelectedHeader,
                new TableCellStyle
                    (
                    Color.LightBlue,
                    Color.DarkBlue,
                    Color.Blue,
                    new Font("Segoe UI", (float)(0.0422 * Height), FontStyle.Regular)
                    )
                );
        }

        private class Cell
        {
            public string value { get; private set; }
            public int position { get; set; }
            public cellStyles style { get; private set; }

            public Cell(string Value, int Position)
            {
                value = Value;
                position = Position;
                SetStyle(cellStyles.Bace);
            }

            public void SetStyle(cellStyles cellStyle)
            {
                style = cellStyle;
            }
        }

        private class Column
        {
            public int position { get; set; }
            public Cell Header { get; set; }
            public List<Cell> cells { get; private set; }
            public bool IsSorted { get; set; } = false;
            public bool IsIncreasing { get; set; } = true;
            public bool IsNumber { get; private set; }
            public Column(string Name, bool isNumber)
            {
                Header = new Cell(Name, 1);
                IsNumber = isNumber;
                Header.SetStyle(cellStyles.Header);
                cells = new List<Cell>();
            }
            public Column(Column column)
            {
                Header = column.Header;
                IsNumber = column.IsNumber;
                IsSorted = column.IsSorted;
                IsIncreasing = column.IsIncreasing;
                position = column.position;
                cells = new List<Cell>();
            }
            public void AddCell(Cell cell)
            {
                cells.Add(cell);
            }
            public void RemoveCells()
            {
                cells = new List<Cell>();
            }
        }

        private List<Column> columns = new List<Column>();

        public void AddColumn(string Name, bool isNumber)
        {
            if (!TableHasRows)
            {
                columns.Add(new Column(Name, isNumber));
                ColumnWidth = (Width - 3) / columns.Count;
            }
        }

        public bool AddRow(List<string> Row)
        {
            if (Row.Count == columns.Count)
            {
                for (int i = 0; i < Row.Count; i++)
                {
                    columns[i].AddCell(new Cell(Row[i], RowCount * RowHeight + HeaderHeight + 2));
                }
                RowCount++;
                if (!TableHasRows)
                {
                    TableHasRows = true;
                    for (int i = 0; i < Row.Count; i++)
                    {
                        columns[i].position = i * ColumnWidth + 1;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveRows()
        {
            RowCount = 0;
            foreach (var i in columns)
            {
                i.RemoveCells();
            }
        }

        private int[] CountingSort(List<string> Strings, int position, int[] stringPosititons, bool IsIncreasing)
        {
            List<char> symbols = new List<char>();
            List<int> symbolPosittion = new List<int>();
            symbolPosittion.Add(0);
            symbolPosittion.Add(0);
            int[] result = new int[Strings.Count];
            foreach (var i in Strings)
            {
                if (!symbols.Contains(i[position]))
                {
                    symbols.Add(i[position]);
                    symbolPosittion.Add(0);
                }
            }
            if (IsIncreasing)
            {
                symbols.Sort(delegate (char x, char y)
                {
                    if (char.ToUpper(x) > char.ToUpper(y))
                        return 1;
                    else if (char.ToUpper(x) == char.ToUpper(y))
                    {
                        if (x < y)
                        {
                            return 1;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                    else
                        return -1;
                });
            }
            else
            {
                symbols.Sort(delegate (char x, char y)
                {
                    if (char.ToUpper(x) < char.ToUpper(y))
                        return 1;
                    else if (char.ToUpper(x) == char.ToUpper(y))
                    {
                        if (x < y)
                        {
                            return 1;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                    else
                        return -1;
                });
            }
            for (int i = 0; i < stringPosititons.Length; i++)
            {
                for (int j = 0; j < symbols.Count; j++)
                {
                    if (Strings[stringPosititons[i]][position] == symbols[j])
                    {
                        symbolPosittion[j + 2]++;
                    }
                }
            }
            for (int j = 1; j < symbolPosittion.Count - 2; j++)
            {
                symbolPosittion[j] = symbolPosittion[j - 1] + symbolPosittion[j + 1];
            }
            for (int i = 0; i < stringPosititons.Length; i++)
            {
                for (int j = 0; j < symbols.Count; j++)
                {
                    if (Strings[stringPosititons[i]][position] == symbols[j])
                    {
                        result[symbolPosittion[j]] = stringPosititons[i];
                        symbolPosittion[j]++;
                    }
                }
            }
            return result;
        }

        private int[] LSDSort(List<string> Strings, int Length, bool IsIncreasing)
        {
            int position = Length - 1, curentArray = 1;
            List<char> symbols = new List<char>();
            List<int> symbolsPosititons = new List<int>();
            int[] firstArray = new int[Strings.Count], secondArray = new int[Strings.Count];
            for (int i = 0; i < Strings.Count; i++)
            {
                firstArray[i] = i;
            }
            while (position != -1)
            {
                if (curentArray == 1)
                {
                    secondArray = CountingSort(Strings, position, firstArray, IsIncreasing);
                    curentArray = 2;
                }
                else
                {
                    firstArray = CountingSort(Strings, position, secondArray, IsIncreasing);
                    curentArray = 1;
                }
                position--;
            }
            if (curentArray == 1)
            {
                return firstArray;
            }
            else
            {
                return secondArray;
            }
        }


        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (columns[0].cells[columns[0].cells.Count - 1].position + RowHeight > Height && e.Delta < 0)
            {
                if (columns[0].cells[columns[0].cells.Count - 1].position + RowHeight + e.Delta / 4 > Height )
                {
                    foreach (var column in columns)
                    {
                        foreach (var cell in column.cells)
                        {
                            cell.position += e.Delta / 4;
                        }
                    }
                }
                else
                {
                    int specialDelta = Height - columns[0].cells[columns[0].cells.Count - 1].position - RowHeight - 2;
                    foreach (var column in columns)
                    {
                        foreach (var cell in column.cells)
                        {
                            cell.position += specialDelta;
                        }
                    }
                }
            }
            else if (columns[0].cells[0].position < HeaderHeight + 2 && e.Delta > 0)
            {
                if (columns[0].cells[0].position + e.Delta / 4 < HeaderHeight + 2)
                {
                    foreach (var column in columns)
                    {
                        foreach (var cell in column.cells)
                        {
                            cell.position += e.Delta / 4;
                        }
                    }
                }
                else
                {
                    int specialDelta = HeaderHeight + 2 - columns[0].cells[0].position;
                    foreach (var column in columns)
                    {
                        foreach (var cell in column.cells)
                        {
                            cell.position += specialDelta;
                        }
                    }
                }
            }
            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            // Hovering
            foreach (var column in columns)
            {
                column.Header.SetStyle(cellStyles.Header);
                foreach (var cell in column.cells)
                {
                    cell.SetStyle(cellStyles.Bace);
                }
            }
            foreach (var column in columns)
            {
                if (column.position < e.X && column.position + ColumnWidth > e.X)
                {
                    if (e.Y < HeaderHeight + 1)
                    {
                        column.Header.SetStyle(cellStyles.SelectedHeader);
                        foreach (var cell in column.cells)
                        {
                            cell.SetStyle(cellStyles.StrongHighlighted);
                        }

                    }
                    else
                    {
                        column.Header.SetStyle(cellStyles.HighlightedHeader);
                        for (int i = 0; i < column.cells.Count; i++)
                        {
                            if (column.cells[i].position < e.Y && column.cells[i].position + RowHeight > e.Y)
                            {
                                foreach (var col in columns)
                                {
                                    col.cells[i].SetStyle(cellStyles.StrongHighlighted);
                                }
                                column.cells[i].SetStyle(cellStyles.Selected);
                            }
                            else
                            {
                                column.cells[i].SetStyle(cellStyles.WeakHighlighted);
                            }
                        }
                    }
                }
            }
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            foreach (var column in columns)
            {
                column.Header.SetStyle(cellStyles.Header);
                foreach (var cell in column.cells)
                {
                    cell.SetStyle(cellStyles.Bace);
                }
            }
            Invalidate();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            for (int i = 0; i < columns.Count; i++)
            {
                if (columns[i].position < e.X && columns[i].position + ColumnWidth > e.X && HeaderHeight > e.Y)
                {
                    if (columns[i].IsSorted)
                    {
                        if (columns[i].IsIncreasing)
                        {
                            columns[i].IsIncreasing = false;
                        }
                        else
                        {
                            columns[i].IsIncreasing = true;
                        }
                    }
                    else
                    {
                        columns[i].IsSorted = true;
                        columns[i].IsIncreasing = true;
                    }
                    Column column1;
                    int maxLength = -1;
                    List<string> columnValues = new List<string>();
                    string buffer = "";
                    for (int j = 0; j < columns[i].cells.Count; j++)
                    {
                        if (maxLength == -1 || maxLength < columns[i].cells[j].value.Length)
                        {
                            maxLength = columns[i].cells[j].value.Length;
                        }
                    }
                    if (columns[i].IsNumber)
                    {
                        foreach (var j in columns[i].cells)
                        {
                            buffer = j.value;
                            while (buffer.Length != maxLength)
                            {
                                buffer = '\n' + buffer;
                            }
                            columnValues.Add(buffer);
                        }
                    }
                    else
                    {
                        foreach (var j in columns[i].cells)
                        {
                            buffer = j.value;
                            while (buffer.Length != maxLength)
                            {
                                buffer += '\n';
                            }
                            columnValues.Add(buffer);
                        }
                    }
                    int[] newPositions = LSDSort(columnValues, maxLength, columns[i].IsIncreasing);
                    for (int column = 0; column < columns.Count; column++)
                    {
                        column1 = new Column(columns[column]);
                        int curentPosition = columns[column].cells[0].position;
                        foreach (var j in newPositions)
                        {
                            column1.AddCell(columns[column].cells[j]);
                        }
                        foreach (var j in column1.cells)
                        {
                            j.position = curentPosition;
                            curentPosition += RowHeight;
                        }
                        columns[column] = column1;
                    }
                }
                else
                {
                    columns[i].IsSorted = false;
                    columns[i].IsIncreasing = true;
                }
            }
            Invalidate();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (columns.Count != 0)
            {
                ColumnWidth = (Width - 3) / columns.Count;
                RowHeight = (int)(0.0784 * Height);
                HeaderHeight = (int)(0.13725 * Height);
                for (int i = 0; i < columns.Count; i++)
                {
                    columns[i].position = ColumnWidth * i + 1;
                    for (int j = 0; j < columns[i].cells.Count; j++)
                    {
                        columns[i].cells[j].position = RowHeight * j + HeaderHeight + 2;
                    }
                }
            }
            StaylesDictionary = new Dictionary<cellStyles, TableCellStyle>();
            InitializeStyles();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            graphics.Clear(Parent.BackColor);

            Rectangle TableRectangle = new Rectangle(0, 0, ColumnWidth * columns.Count + 2, Height - 1);
            Rectangle CellRectangle;

            graphics.FillRectangle(new SolidBrush(BackColor), TableRectangle);

            foreach (var column in columns)
            {                
                foreach (var cell in column.cells)
                {
                    if (cell.position > HeaderHeight + 1 && cell.position + RowHeight < Height - 1)
                    {
                        CellRectangle = new Rectangle(column.position, cell.position, ColumnWidth, RowHeight);
                        graphics.DrawRectangle(new Pen(StaylesDictionary[cell.style].borderColor), CellRectangle);
                        graphics.FillRectangle(new SolidBrush(StaylesDictionary[cell.style].backColor), CellRectangle);
                        graphics.DrawString(cell.value, StaylesDictionary[cell.style].font, new SolidBrush(StaylesDictionary[cell.style].foreColor), CellRectangle, stringFormat);
                    }
                    else if (cell.position > HeaderHeight + 1 && cell.position < Height - 1)
                    {
                        CellRectangle = new Rectangle(column.position, cell.position, ColumnWidth, Height - 2);
                        graphics.DrawRectangle(new Pen(StaylesDictionary[cell.style].borderColor), CellRectangle);
                        graphics.FillRectangle(new SolidBrush(StaylesDictionary[cell.style].backColor), CellRectangle);
                        graphics.DrawString(cell.value, StaylesDictionary[cell.style].font, new SolidBrush(StaylesDictionary[cell.style].foreColor), new Rectangle(column.position, cell.position, ColumnWidth, RowHeight), stringFormat);
                    }
                    else if (cell.position + RowHeight > HeaderHeight + 1 && cell.position + RowHeight < Height - 1)
                    {
                        CellRectangle = new Rectangle(column.position, HeaderHeight + 2, ColumnWidth, RowHeight);
                        graphics.DrawRectangle(new Pen(StaylesDictionary[cell.style].borderColor), CellRectangle);
                        graphics.FillRectangle(new SolidBrush(StaylesDictionary[cell.style].backColor), CellRectangle);
                        graphics.DrawString(cell.value, StaylesDictionary[cell.style].font, new SolidBrush(StaylesDictionary[cell.style].foreColor), new Rectangle(column.position, cell.position, ColumnWidth, RowHeight), stringFormat);
                    }
                }
                CellRectangle = new Rectangle(column.position, column.Header.position, ColumnWidth, HeaderHeight);
                graphics.DrawRectangle(new Pen(StaylesDictionary[column.Header.style].borderColor), CellRectangle);
                graphics.FillRectangle(new SolidBrush(StaylesDictionary[column.Header.style].backColor), CellRectangle);                
                if (column.IsSorted)
                {
                    if (column.IsIncreasing)
                    {
                        graphics.DrawString(column.Header.value + '\u25BC', StaylesDictionary[column.Header.style].font, new SolidBrush(StaylesDictionary[column.Header.style].foreColor), CellRectangle, stringFormat);
                    }
                    else
                    {
                        graphics.DrawString(column.Header.value + '\u25B2', StaylesDictionary[column.Header.style].font, new SolidBrush(StaylesDictionary[column.Header.style].foreColor), CellRectangle, stringFormat);
                    }
                }
                else
                {
                    graphics.DrawString(column.Header.value, StaylesDictionary[column.Header.style].font, new SolidBrush(StaylesDictionary[column.Header.style].foreColor), CellRectangle, stringFormat);
                }
                graphics.DrawLine(new Pen(StaylesDictionary[column.Header.style].borderColor), CellRectangle.Left, CellRectangle.Bottom + 1, CellRectangle.Right, CellRectangle.Bottom + 1);
            }
            graphics.DrawRectangle(new Pen(BorderColor), TableRectangle);
        }
    }
}
