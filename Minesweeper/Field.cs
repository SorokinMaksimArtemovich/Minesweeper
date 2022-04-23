using System;
using System.Collections.Generic;
using System.Text;

namespace Minesweeper
{
    public class Field
    {        
        public int GameID;
        public byte FieldHeight;
        public byte FieldWidth;
        public List<List<Square>> Squares;
        public Field(int GameID, byte FieldHeight, byte FieldWidth)
        {
            this.GameID = GameID;
            this.FieldHeight = FieldHeight;
            this.FieldWidth = FieldWidth;
            this.Squares = new List<List<Square>>();
            List<Square> Buffer;
            for (byte i = 0; i < FieldHeight; i++)
            {
                Buffer = new List<Square>(FieldWidth);
                this.Squares.Add(Buffer);
            }
        }
    }
}
