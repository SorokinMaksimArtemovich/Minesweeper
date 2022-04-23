using System;
using System.Collections.Generic;
using System.Text;

namespace Minesweeper
{
    public class Square
    {
        public short Value;
        public short CurrentValue;
        public bool IsOpened;
        public bool IsMarked;
        public bool IsHightlighted;
        public Square(short Value, short CurrentValue, bool IsOpened, bool IsMarked, bool IsHightlighted)
        {
            this.Value = Value;
            this.CurrentValue = CurrentValue;
            this.IsOpened = IsOpened;
            this.IsMarked = IsMarked;
            this.IsHightlighted = IsHightlighted;
        }
        public short Open()
        {
            if (!IsOpened && !IsMarked)
            {
                if (Value == -1)
                {
                    return -1;
                }
                else return CurrentValue;
            }
            else
            {
                return CurrentValue;
            }
        }

    }
}
