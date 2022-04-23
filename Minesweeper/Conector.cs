using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Timers;

namespace Minesweeper
{
    public static class Conector
    {
        public static int CurentUserID = -1;
        public static string CurentDificultyLevel { get; private set; } = "Новичек" ;
        public static string BufferUserName = "";
        public static int Time;

        public static int markedMinesCount { get; set; }
        public static int closedSquaresCount { get; set; }
        public static int height { get; private set; }
        public static int width { get; private set; }
        public static int minesCount { get; private set; }
        public static bool IsFinished { get; private set; }

        private static int first, second;

        private static short[,] Values;

        private static short[,] CurentValues;

        private static bool[,] isOpened;

        private static bool[,] isMarked;

        private static bool[,] isHighlighted;

        static Random rnd = new Random();
                
        public static bool GetSqlConection()
        {
            return DBAccesser.GetDBConnection();
        }

        public static List<string> GetUsers()
        {
            return DBAccesser.GetUsersNames();
        }
        public static string GetUserName(int UserID)
        {
            return DBAccesser.GetUserName(UserID);
        }
        public static void SetUser(string UserName)
        {
            CurentUserID = DBAccesser.GetUserID(UserName);
            CurentDificultyLevel = DBAccesser.GetParameters(CurentUserID).Item3;
            LoadGame();
        }
        public static void AddUser(string UserName)
        {
            DBAccesser.AddUser(UserName);
            CurentUserID = DBAccesser.GetUserID(UserName);
        }
        public static void SetUserParameters(bool AlwaysSaveGame, bool AlwaysLoadGame)
        {
            DBAccesser.SetParameters(CurentUserID, AlwaysSaveGame, AlwaysLoadGame, CurentDificultyLevel);
        }
        public static bool IsAlwaysSaveGame()
        {
            return DBAccesser.GetParameters(CurentUserID).Item1;
        }
        public static bool IsAlwaysLoadGame()
        {
            return DBAccesser.GetParameters(CurentUserID).Item2;
        }
        public static List<string> GetCurentUserStatistics()
        {
            return GetUserStatistics(CurentUserID, CurentDificultyLevel);
        }
        public static List<string> GetUserStatistics(int UserID, string DificultyLevel)
        {
            List<string> UserStatistics = new List<string>();
            Tuple<int, int, int, int> UsersData;
            UserStatistics = new List<string>();
            UsersData = DBAccesser.GetStatistics(UserID, DificultyLevel);
            if (UsersData != null)
            {
                UserStatistics.AddRange(new string[] { (Time / 60).ToString() + ':' + (Time % 60).ToString(), (UsersData.Item2 / 60).ToString() + ':' + (UsersData.Item2 % 60).ToString(), UsersData.Item3.ToString(), UsersData.Item4.ToString(), UsersData.Item3 == 0 ? "0" : (UsersData.Item4 / UsersData.Item3 * 100).ToString() });
                return UserStatistics;
            }
            return null;
        }
        public static List<List<string>> GetStatistics(string DificultyLevel)
        {
            List<List<string>> Statistics = new List<List<string>>();
            List<string> UserStatistics = new List<string>();
            Tuple<int, int, int, int> UsersData;
            foreach(var i in DBAccesser.GetUsersID())
            {
                UserStatistics = new List<string>();
                UserStatistics.Add(DBAccesser.GetUserName(i));
                UsersData = DBAccesser.GetStatistics(i, DificultyLevel);
                UserStatistics.AddRange(new string[] { (UsersData.Item2 / 60).ToString() + ':' + (UsersData.Item2 % 60).ToString(), UsersData.Item3.ToString(), UsersData.Item4.ToString(), UsersData.Item3 == 0 ? "0" : (UsersData.Item4 / UsersData.Item3 * 100).ToString() });
                Statistics.Add(UserStatistics);
            }
            return Statistics;
        }
        public static int GetLastGameID()
        {
            return DBAccesser.GetGame(CurentUserID, CurentDificultyLevel);
        }


        public static void SetDificultyLevel(string Level)
        {            
            if (Level == "Новичек")
            {
                CurentDificultyLevel = Level;
                height = 9;
                width = 9;
                minesCount = 10;
                if (!LoadGame())
                {
                    FillMines();
                }
            }
            if (Level == "Любитель")
            {
                CurentDificultyLevel = Level;
                height = 16;
                width = 16;
                minesCount = 40; 
                if (!LoadGame())
                {
                    FillMines();
                }
            }
            if (Level == "Профессионал")
            {
                CurentDificultyLevel = Level;
                height = 16;
                width = 30;
                minesCount = 99;
                if (!LoadGame())
                {
                    FillMines();
                }
            }
        }
        public static void SetDificultyLevel(string Level, int Height, int Width, int MinesCount)
        {
            CurentDificultyLevel = Level;
            if (Level == "Пользовательский")
            {
                CurentDificultyLevel = Level;
                if (!LoadGame() || height != Height || width != Width || minesCount != MinesCount)
                {
                    height = Height;
                    width = Width;
                    minesCount = MinesCount;
                    FillMines();
                }
            }

        }
        public static void FillMines()
        {
            Values = new short[height, width];
            isHighlighted = new bool[height, width];
            isMarked = new bool[height, width];
            isOpened = new bool[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Values[i, j] = 0;
                    isHighlighted[i, j] = false;
                    isMarked[i, j] = false;
                    isOpened[i, j] = false;
                }
            }            
            for (int i = 0; i < minesCount; i++)
            {
                first = rnd.Next(0, height);
                second = rnd.Next(0, width);
                while (Values[first, second] == -1)
                {
                    first = rnd.Next(0, height);
                    second = rnd.Next(0, width);
                }
                Values[first, second] = -1;
            }
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if  (Values[i, j] == -1)
                    {
                        if (i > 0 && j > 0 && Values[i - 1, j - 1] != -1)
                        {
                            Values[i - 1, j - 1]++;
                        }
                        if (i > 0 && Values[i - 1, j] != -1)
                        {
                            Values[i - 1, j]++;
                        }
                        if (i > 0 && j < width - 1 && Values[i - 1, j + 1] != -1)
                        {
                            Values[i - 1, j + 1]++;
                        }
                        if (j > 0 && Values[i, j - 1] != -1)
                        {
                            Values[i, j - 1]++;
                        }
                        if (j < width - 1 && Values[i, j + 1] != -1)
                        {
                            Values[i, j + 1]++;
                        }
                        if (i < height - 1 && j > 0 && Values[i + 1, j - 1] != -1)
                        {
                            Values[i + 1, j - 1]++;
                        }
                        if (i < height - 1 && Values[i + 1, j] != -1)
                        {
                            Values[i + 1, j]++;
                        }
                        if (i < height - 1 && j < width - 1 && Values[i + 1, j + 1] != -1)
                        {
                            Values[i + 1, j + 1]++;
                        }
                    }
                }
            }
            CurentValues = Values;
            closedSquaresCount = height * width;
            markedMinesCount = 0;
            IsFinished = false;
            Time = 0;
        }        
        public static List<List<Tuple<short, short, bool, bool, bool>>> GetField()
        {
            if (IsFinished)
            {
                FillMines();
            }
            List<List<Tuple<short, short, bool, bool, bool>>> result = new List<List<Tuple<short, short, bool, bool, bool>>>();
            List<Tuple<short, short, bool, bool, bool>> line = new List<Tuple<short, short, bool, bool, bool>>();
            Tuple<short, short, bool, bool, bool> cell;
            for (int i = 0; i < height; i++)
            {
                line = new List<Tuple<short, short, bool, bool, bool>>();
                for (int j = 0; j < width; j++)
                {
                    cell = new Tuple<short, short, bool, bool, bool>(Values[i, j], CurentValues[i, j], isOpened[i, j], isMarked[i, j], isHighlighted[i, j]);
                    line.Add(cell);
                }
                result.Add(line);
            }
            return result;
        }

        public static void SetField(List<List<Tuple<short, bool, bool, bool>>> field)
        {
            for (int i = 0; i < field.Count; i++)
            {
                for(int j = 0; j < field[i].Count; j++)
                {
                    CurentValues[i, j] = field[i][j].Item1;
                    isOpened[i, j] = field[i][j].Item2;
                    isMarked[i, j] = field[i][j].Item3;
                    isHighlighted[i, j] = field[i][j].Item4;
                }
            }
        }

        public static bool SaveGame()
        {
            int GameID = DBAccesser.GetGame(CurentUserID, CurentDificultyLevel);
            GameID = DBAccesser.SaveGame(GameID, Time, minesCount, closedSquaresCount, height, width, IsFinished);
            if (DBAccesser.SetGame(CurentUserID, CurentDificultyLevel, GameID))
            {
                List<Tuple<int, byte, byte, short, short, bool, bool, Tuple<bool>>> field = new List<Tuple<int, byte, byte, short, short, bool, bool, Tuple<bool>>>();
                Tuple<int, byte, byte, short, short, bool, bool, Tuple<bool>> Buffer;
                for (byte i = 0; i < height; i++)
                {
                    for (byte j = 0; j < width; j++)
                    {
                        Buffer = new Tuple<int, byte, byte, short, short, bool, bool, Tuple<bool>>(GameID, j, i, Values[i, j], CurentValues[i, j], isOpened[i, j], isMarked[i, j], new Tuple<bool>(isHighlighted[i, j]));
                        field.Add(Buffer);
                    }
                }
                return DBAccesser.SaveFied(field);
            }
            return false;
        }
        public static bool LoadGame()
        {
            int GameID = DBAccesser.GetGame(CurentUserID, CurentDificultyLevel);
            if (GameID != -1)
            {
                Tuple<int, int, int, int, int, bool> game = DBAccesser.LoadGame(GameID);
                List<Tuple<byte, byte, short, short, bool, bool, bool>> field = DBAccesser.LoadField(GameID);
                if (game != null)
                {
                    Time = game.Item1;
                    minesCount = game.Item2;
                    closedSquaresCount = game.Item3;
                    height = game.Item4;
                    width = game.Item5;
                    IsFinished = game.Item6;
                    if (field.Count > 0)
                    {
                        Values = new short[height, width];
                        CurentValues = new short[height, width];
                        isOpened = new bool[height, width];
                        isMarked = new bool[height, width];
                        isHighlighted = new bool[height, width];
                        foreach (var i in field)
                        {
                            Values[i.Item2, i.Item1] = i.Item3;
                            CurentValues[i.Item2, i.Item1] = i.Item4;
                            isOpened[i.Item2, i.Item1] = i.Item5;
                            isMarked[i.Item2, i.Item1] = i.Item6;
                            isHighlighted[i.Item2, i.Item1] = i.Item7;
                        }
                        return true;
                    }
                }
            }
            return false;
        }
        public static void LoseGame()
        {
            IsFinished = true;
            DBAccesser.ChangeLoosersStatistics(CurentUserID, CurentDificultyLevel, Time, minesCount, closedSquaresCount, height, width);
        }
        public static void WinGame()
        {
            IsFinished = true;
            DBAccesser.ChangeWinersStatistics(CurentUserID, CurentDificultyLevel, Time, minesCount, closedSquaresCount, height, width);
        }
    }
}
