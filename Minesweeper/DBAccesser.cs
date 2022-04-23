using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Minesweeper
{
    public static class DBAccesser
    {
        private static SqlConnection conn;
        public static bool GetDBConnection()
        {
            try
            {
                string datasource = @"(LocalDB)\MSSQLLocalDB";
                string database = @"|DataDirectory|\MinesweeperDB.mdf";
                conn = DBSQLServerUtils.GetDBConnection(datasource, database);
                //DBSQLServerUtils.DeleteGames();
                //DBSQLServerUtils.DeleteStatistics();
                //DBSQLServerUtils.DeleteUsers();
                //DBSQLServerUtils.DeleteFields();
                return true;
            }
            catch (SqlException e)
            {
                return false;
            }
        }


        public static bool AddUser(string Name)
        {
            bool IsCorect = DBSQLServerUtils.AddUser(Name);
            int ID = DBSQLServerUtils.GetUserID(Name);
            IsCorect &= DBSQLServerUtils.AddStatistics(ID, 0, 0, 0);
            return IsCorect;
        }
        public static int GetUserID(string UserName)
        {
            return DBSQLServerUtils.GetUserID(UserName);
        }
        public static List<int> GetUsersID()
        {
            return DBSQLServerUtils.GetUsersID();
        }
        public static string GetUserName(int UserID)
        {
            return DBSQLServerUtils.GetUserName(UserID);
        }
        public static List<string> GetUsersNames()
        {
            return DBSQLServerUtils.GetUsersNames();
        }
        public static bool SetParameters(int UserID, bool AlwaysSaveGame, bool AlwaysLoadGame, string LastGameLevel)
        {
            return DBSQLServerUtils.SetParameters(UserID, AlwaysSaveGame, AlwaysLoadGame, LastGameLevel);
        }
        public static Tuple<bool, bool, string> GetParameters(int UserID)
        {
            return DBSQLServerUtils.GetParameters(UserID);
        }

        public static Tuple<int, int, int, int> GetStatistics(int UserID, string GameLevel)
        {
            return DBSQLServerUtils.GetStatistics(UserID, GameLevel);
        }
        public static int GetGame(int UserID, string GameLevel)
        {
            return DBSQLServerUtils.GetGame(UserID, GameLevel);
        }
        public static bool SetGame(int UserID, string GameLevel, int GameID)
        {
            return DBSQLServerUtils.SetGame(UserID, GameLevel, GameID);
        }


        public static int SaveGame(int GameID, int Time, int BombsCount, int ClosedSquaresCount, int FieldHeight, int FieldWidth, bool IsFinished)
        {
            if (GameID == -1)
            {
                return DBSQLServerUtils.AddGame(Time, BombsCount, ClosedSquaresCount, FieldHeight, FieldWidth, IsFinished); 
            }
            else
            {
                if (DBSQLServerUtils.UpdateGame(GameID, Time, BombsCount, ClosedSquaresCount, IsFinished))
                {
                    return GameID;
                }
                else
                {
                    return -1;
                }
            }
        }
        public static Tuple<int, int, int, int, int, bool> LoadGame(int GameID)
        {
            return DBSQLServerUtils.LoadGame(GameID);
        }
        public static bool SaveFied(List<Tuple<int, byte, byte, short, short, bool, bool, Tuple<bool>>> CurrentField)
        {            
            if (CurrentField.Count > 0)
            {
                bool result = true;
                if (DBSQLServerUtils.LoadField(CurrentField[0].Item1).Count > 0)
                {
                    foreach (var i in CurrentField) 
                    {
                        result &= DBSQLServerUtils.UpdateField(i);
                    }
                }
                else
                {
                    foreach (var i in CurrentField)
                    {
                        result &= DBSQLServerUtils.MakeField(i);
                    }
                }
                return result;
            }
            else
            {
                return false;
            }
        }
        public static List<Tuple<byte, byte, short, short, bool, bool, bool>> LoadField(int GameID)
        {
            return DBSQLServerUtils.LoadField(GameID);
        }
        public static bool ChangeLoosersStatistics(int UserID, string GameLevel, int Time, int BombsCount, int ClosedSquaresCount, int FieldHeight, int FieldWidth)
        {
            bool result = true;
            Tuple<int, int, int, int> Looser = GetStatistics(UserID, GameLevel);
            result &= DBSQLServerUtils.SetStatistics(Looser.Item1, Looser.Item2, Looser.Item3 + 1, Looser.Item4);
            result &= DBSQLServerUtils.SetGame(UserID, GameLevel, SaveGame(DBSQLServerUtils.GetGame(UserID, GameLevel), Time, BombsCount, ClosedSquaresCount, FieldHeight, FieldWidth, true));
            result &= DBSQLServerUtils.RemoveField(DBSQLServerUtils.GetGame(UserID, GameLevel));
            return result;
        }
        public static bool ChangeWinersStatistics(int UserID, string GameLevel, int Time, int BombsCount, int ClosedSquaresCount, int FieldHeight, int FieldWidth)
        {
            bool result = true;
            Tuple<int, int, int, int> Winer = GetStatistics(UserID, GameLevel);
            if (Time < Winer.Item2 || Winer.Item2 == 0)
            {
                result &= DBSQLServerUtils.SetStatistics(Winer.Item1, Time, Winer.Item3 + 1, Winer.Item4 + 1);
            }
            else
            {
                result &= DBSQLServerUtils.SetStatistics(Winer.Item1, Winer.Item2, Winer.Item3 + 1, Winer.Item4 + 1);
            }
            result &= DBSQLServerUtils.SetGame(UserID, GameLevel, SaveGame(DBSQLServerUtils.GetGame(UserID, GameLevel), Time, BombsCount, ClosedSquaresCount, FieldHeight, FieldWidth, true));
            result &= DBSQLServerUtils.RemoveField(DBSQLServerUtils.GetGame(UserID, GameLevel));
            return result;
        }
    }
}
