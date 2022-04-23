using System;
using System.Collections.Generic;
using System.Text;

namespace Minesweeper
{
    public class Game
    {
        public int ID { get; } = -1;
        public string UserName { get; }
        public float Time { get; set; }
        public int Bombs { get; set; }
        public int Empty { get; set; }
        public Field CurrentField { get; }
        public Game(int ID, string UserName, float Time, int Bombs, int Empty, Field CurrentFied)
        {
            this.ID = ID;
            this.UserName = UserName;
            this.Time = Time;
            this.Bombs = Bombs;
            this.Empty = Empty;
            this.CurrentField = CurrentField;
        }
        public Game(string UserName, float Time, int Bombs, int Empty, Field CurrentFied)
        {
            this.UserName = UserName;
            this.Time = Time;
            this.Bombs = Bombs;
            this.Empty = Empty;
            this.CurrentField = CurrentField;
        }
    }
}
