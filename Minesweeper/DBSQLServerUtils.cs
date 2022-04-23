using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;

namespace Minesweeper
{
    class DBSQLServerUtils
    {
        static SqlConnection Conection;
        static SqlCommand Command;
        public static SqlConnection GetDBConnection(string datasource, string database)
        {
            //Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Максим\Documents\Minesweeper\Minesweeper\bin\Debug\MinesweeperDB.mdf; Integrated Security = True
             string connString = @"Data Source=" + datasource + ";AttachDbFilename=" + database + ";Integrated Security=True";

            Conection = new SqlConnection(connString);

            Conection.Open();

            return Conection;
        }

        public static bool DeleteUsers()
        {
            Command = Conection.CreateCommand();
            Command.CommandText = "DELETE FROM Users";
            int RowCount = Command.ExecuteNonQuery();
            return RowCount > 0;
        }
        public static bool DeleteStatistics()
        {
            Command = Conection.CreateCommand();
            Command.CommandText = "DELETE FROM GameLevels";
            int RowCount = Command.ExecuteNonQuery();
            return RowCount > 0;
        }
        public static bool DeleteGames()
        {
            Command = Conection.CreateCommand();
            Command.CommandText = "DELETE FROM Games";
            int RowCount = Command.ExecuteNonQuery();
            return RowCount > 0;
        }
        public static bool DeleteFields()
        {
            Command = Conection.CreateCommand();
            Command.CommandText = "DELETE FROM Fields";
            int RowCount = Command.ExecuteNonQuery();
            return RowCount > 0;
        }
        public static bool AddUser(string Name)
        {
            Command = Conection.CreateCommand();
            Command.CommandText = "INSERT INTO Users (Name)" +
                                  "VALUES (@Name)";
            Command.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar).Value = Name;
            int RowCount = Command.ExecuteNonQuery();
            return RowCount == 1;
        }
        public static int GetUserID(string UserName)
        {
            Command = Conection.CreateCommand();
            Command.CommandText = "SELECT UserID " +
                                  "FROM Users " +
                                  "WHERE Name = @UserName";
            Command.Parameters.Add("@UserName", System.Data.SqlDbType.NVarChar).Value = UserName;
            using (DbDataReader reader = Command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();                    
                    int UserID = reader.GetInt32(reader.GetOrdinal("UserID"));
                    return UserID;
                }
                else
                {
                    return -1;
                }
            }
        }
        public static List<int> GetUsersID()
        {
            Command = Conection.CreateCommand();
            List<int> Users = new List<int>();
            int UserID;
            Command.CommandText = "SELECT UserID " +
                                  "FROM Users ";
            using (DbDataReader reader = Command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        UserID = reader.GetInt32(reader.GetOrdinal("UserID"));
                        Users.Add(UserID);
                    }
                    
                }
                return Users;
            }
        }
        public static string GetUserName(int UserID)
        {
            Command = Conection.CreateCommand();
            Command.CommandText = "SELECT Name " +
                                  "FROM Users " +
                                  "WHERE UserID = @UserID";
            Command.Parameters.Add("@UserID", System.Data.SqlDbType.NVarChar).Value = UserID;
            using (DbDataReader reader = Command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    string UserName = reader.GetString(reader.GetOrdinal("Name"));
                    return UserName;
                }
                else
                {
                    return null;
                }
            }
        }
        public static List<string> GetUsersNames()
        {
            Command = Conection.CreateCommand();
            string UserName;
            List<string> Users = new List<string>();
            Command.CommandText = "SELECT Name " +
                                  "FROM Users";
            using (DbDataReader reader = Command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        UserName = reader.GetString(reader.GetOrdinal("Name"));
                        Users.Add(UserName);
                    }                    
                }
                return Users;
            }
        }
        public static bool SetParameters(int UserID, bool AlwaysSaveGame, bool AlwaysLoadGame, string LastGameLevel)
        {
            Command = Conection.CreateCommand();
            Command.CommandText = "UPDATE Users " +
                                  "SET AlwaysSaveGame = @AlwaysSaveGame, AlwaysLoadGame = @AlwaysLoadGame, LastGameLevel = @LastGameLevel " +
                                  "WHERE UserID = @UserID";
            Command.Parameters.Add("@AlwaysSaveGame", System.Data.SqlDbType.Bit).Value = AlwaysSaveGame;
            Command.Parameters.Add("@AlwaysLoadGame", System.Data.SqlDbType.Bit).Value = AlwaysLoadGame;
            Command.Parameters.Add("@LastGameLevel", System.Data.SqlDbType.NVarChar).Value = LastGameLevel;
            Command.Parameters.Add("@UserID", System.Data.SqlDbType.Int).Value = UserID;
            int RowCount = Command.ExecuteNonQuery();
            return RowCount == 1;
        }
        public static Tuple<bool, bool, string> GetParameters(int UserID)
        {
            Command = Conection.CreateCommand();
            Command.CommandText = "SELECT AlwaysSaveGame, AlwaysLoadGame, LastGameLevel " +
                                  "FROM Users " +
                                  "WHERE UserID = @UserID";
            Command.Parameters.Add("@UserID", System.Data.SqlDbType.Int).Value = UserID;
            using (DbDataReader reader = Command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    bool AlwaysSaveGame = false, AlwaysLoadGame = false;
                    string LastGameLevel = "";
                    while (reader.Read())
                    {
                        AlwaysSaveGame = reader.GetBoolean(reader.GetOrdinal("AlwaysSaveGame"));
                        AlwaysLoadGame = reader.GetBoolean(reader.GetOrdinal("AlwaysLoadGame"));
                        LastGameLevel = reader.GetString(reader.GetOrdinal("LastGameLevel"));                        
                    }
                    return new Tuple<bool, bool, string>(AlwaysSaveGame, AlwaysLoadGame, LastGameLevel);
                }
                else
                {
                    return null;
                }
            }
        }


        public static bool AddStatistics(int UserID, int BestTime, int GamesCount, int WinsCount)
        {
            Command = Conection.CreateCommand();
            Command.CommandText = "INSERT INTO GameLevels (UserID, DifficultyLevel, BestTime, WinsCount, GamesCount)" +
                                  "VALUES (@ID, N'Новичек', @BestTime, @WinsCount, @GamesCount), " +
                                  "(@ID, N'Любитель', @BestTime, @WinsCount, @GamesCount), " +
                                  "(@ID, N'Профессионал', @BestTime, @WinsCount, @GamesCount), " +
                                  "(@ID, N'Пользовательский', @BestTime, @WinsCount, @GamesCount)";
            Command.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = UserID;
            Command.Parameters.Add("@BestTime", System.Data.SqlDbType.Int).Value = BestTime;
            Command.Parameters.Add("@GamesCount", System.Data.SqlDbType.Int).Value = GamesCount;
            Command.Parameters.Add("@WinsCount", System.Data.SqlDbType.Int).Value = WinsCount;
            int RowCount = Command.ExecuteNonQuery();
            return RowCount == 1;
        }
        public static Tuple<int, int, int, int> GetStatistics(int UserID, string GameLevel)
        {
            Command = Conection.CreateCommand();
            Command.CommandText = "SELECT LevelID, BestTime, GamesCount, WinsCount " +
                                  "FROM GameLevels " +
                                  "WHERE UserID = @UserID " +
                                  "AND DifficultyLevel = @DifficultyLevel";
            Command.Parameters.Add("@UserID", System.Data.SqlDbType.Int).Value = UserID;
            Command.Parameters.Add("@DifficultyLevel", System.Data.SqlDbType.NVarChar).Value = GameLevel;
            using (DbDataReader reader = Command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    int LevelID = -1;
                    int BestTime = -1;
                    int GamesCount = -1, WinsCount = -1;
                    while (reader.Read())
                    {
                        LevelID = reader.GetInt32(reader.GetOrdinal("LevelID"));
                        BestTime = reader.GetInt32(reader.GetOrdinal("BestTime"));
                        GamesCount = reader.GetInt32(reader.GetOrdinal("GamesCount"));
                        WinsCount = reader.GetInt32(reader.GetOrdinal("WinsCount"));
                    }
                    return new Tuple<int, int, int, int>(LevelID, BestTime, GamesCount, WinsCount);
                }
                else
                {
                    return null;
                }
            }
        }
        public static int GetGame(int UserID, string GameLevel)
        {
            Command = Conection.CreateCommand();
            Command.CommandText = "SELECT GameID " +
                                  "FROM GameLevels " +
                                  "WHERE UserID = @UserID " +
                                  "AND DifficultyLevel = @DifficultyLevel";
            Command.Parameters.Add("@UserID", System.Data.SqlDbType.Int).Value = UserID;
            Command.Parameters.Add("@DifficultyLevel", System.Data.SqlDbType.NVarChar).Value = GameLevel;
            using (DbDataReader reader = Command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    int GameID = -1;
                    while (reader.Read())
                    {
                        GameID = reader.GetInt32(reader.GetOrdinal("GameID"));
                    }
                    return GameID;
                }
                else
                {
                    return -1;
                }
            }
        }
        public static bool SetGame(int UserID, string GameLevel, int GameID)
        {
            Command = Conection.CreateCommand();
            Command.CommandText = "UPDATE GameLevels " +
                                  "SET GameID = @GameID " +
                                  "WHERE UserID = @UserID " +
                                  "AND DifficultyLevel = @DifficultyLevel";
            Command.Parameters.Add("@GameID", System.Data.SqlDbType.Int).Value = GameID;
            Command.Parameters.Add("@UserID", System.Data.SqlDbType.Int).Value = UserID;
            Command.Parameters.Add("@DifficultyLevel", System.Data.SqlDbType.NVarChar).Value = GameLevel;
            int RowCount = Command.ExecuteNonQuery();
            return RowCount == 1;
        }
        public static bool SetStatistics(int LevelID, int BestTime, int GamesCount, int WinsCount)
        {
            Command = Conection.CreateCommand();
            Command.CommandText = "UPDATE GameLevels " +
                                  "SET BestTime = @BestTime, GamesCount = @GamesCount, WinsCount = @WinsCount " +
                                  "WHERE LevelID = @LevelID";
            Command.Parameters.Add("@BestTime", System.Data.SqlDbType.Int).Value = BestTime;
            Command.Parameters.Add("@GamesCount", System.Data.SqlDbType.Int).Value = GamesCount;
            Command.Parameters.Add("@WinsCount", System.Data.SqlDbType.Int).Value = WinsCount;
            Command.Parameters.Add("@LevelID", System.Data.SqlDbType.Int).Value = LevelID;
            int RowCount = Command.ExecuteNonQuery();
            return RowCount == 1;
        }



        public static int AddGame(int Time, int BombsCount, int ClosedSquaresCount, int FieldHeight, int FieldWidth, bool IsFinished)
        {
            Command = Conection.CreateCommand();
            Command.CommandText = "INSERT INTO Games (Time, Bombs, Closed, FieldHeight, FieldWidth, IsFinished) " +
                                  "VALUES (@Time, @Bombs, @Closed, @FieldHeight, @FieldWidth, @IsFinished)";
            Command.Parameters.Add("@Time", System.Data.SqlDbType.Int).Value = Time;
            Command.Parameters.Add("@Bombs", System.Data.SqlDbType.Int).Value = BombsCount;
            Command.Parameters.Add("@Closed", System.Data.SqlDbType.Int).Value = ClosedSquaresCount;
            Command.Parameters.Add("@FieldHeight", System.Data.SqlDbType.Int).Value = FieldHeight;
            Command.Parameters.Add("@FieldWidth", System.Data.SqlDbType.Int).Value = FieldWidth;
            Command.Parameters.Add("@IsFinished", System.Data.SqlDbType.Bit).Value = IsFinished;
            int RowCount = Command.ExecuteNonQuery();
            if (RowCount == 1)
            {
                Command = Conection.CreateCommand();
                Command.CommandText = "SELECT GameID " +
                                      "FROM Games " +
                                      "WHERE Time = @Time " +
                                      "AND Bombs = @Bombs " +
                                      "AND Closed = @Closed " +
                                      "AND FieldHeight = @FieldHeight " +
                                      "AND FieldWidth = @FieldWidth " +
                                      "AND IsFinished = @IsFinished";
                Command.Parameters.Add("@Time", System.Data.SqlDbType.Int).Value = Time;
                Command.Parameters.Add("@Bombs", System.Data.SqlDbType.Int).Value = BombsCount;
                Command.Parameters.Add("@Closed", System.Data.SqlDbType.Int).Value = ClosedSquaresCount;
                Command.Parameters.Add("@FieldHeight", System.Data.SqlDbType.Int).Value = FieldHeight;
                Command.Parameters.Add("@FieldWidth", System.Data.SqlDbType.Int).Value = FieldWidth;
                Command.Parameters.Add("@IsFinished", System.Data.SqlDbType.Bit).Value = IsFinished;
                using (DbDataReader reader = Command.ExecuteReader())
                {
                    int GameID = -1;
                    while (reader.Read())
                    {
                        GameID = reader.GetInt32(reader.GetOrdinal("GameID"));
                    }
                    return GameID;
                }
            }
            else
            {
                return -1;
            }
        }
        public static bool UpdateGame(int GameID, int Time, int BombsCount, int ClosedSquaresCount, bool IsFinished)
        {
            Command = Conection.CreateCommand();
            Command.CommandText = "UPDATE Games " +
                                  "SET Time = @Time, Bombs = @Bombs, Closed = @Closed, IsFinished = @IsFinished " +
                                  "WHERE GameID = @GameID";
            Command.Parameters.Add("@GameID", System.Data.SqlDbType.Int).Value = GameID;
            Command.Parameters.Add("@Time", System.Data.SqlDbType.Int).Value = Time;
            Command.Parameters.Add("@Bombs", System.Data.SqlDbType.Int).Value = BombsCount;
            Command.Parameters.Add("@Closed", System.Data.SqlDbType.Int).Value = ClosedSquaresCount;
            Command.Parameters.Add("@IsFinished", System.Data.SqlDbType.Bit).Value = IsFinished;
            int RowCount = Command.ExecuteNonQuery();
            return RowCount == 1;
        }
        public static Tuple<int, int, int, int, int, bool> LoadGame(int GameID)
        {
            Command = Conection.CreateCommand();
            Command.CommandText = "SELECT Time, Bombs, Closed, FieldHeight, FieldWidth, IsFinished " +
                                  "FROM Games " +
                                  "WHERE GameID = @GameID";
            Command.Parameters.Add("@GameID", System.Data.SqlDbType.Int).Value = GameID;
            using (DbDataReader reader = Command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    int Time = 0;
                    int Bombs = 0, Empty = 0;
                    int FieldHeight = 0, FieldWidth = 0;
                    bool IsFinished = false;
                    while (reader.Read())
                    {
                        Time = reader.GetInt32(reader.GetOrdinal("Time"));
                        Bombs = reader.GetInt32(reader.GetOrdinal("Bombs"));
                        Empty = reader.GetInt32(reader.GetOrdinal("Closed"));
                        FieldHeight = reader.GetInt32(reader.GetOrdinal("FieldHeight"));
                        FieldWidth = reader.GetInt32(reader.GetOrdinal("FieldWidth"));
                        IsFinished = reader.GetBoolean(reader.GetOrdinal("IsFinished"));
                    }
                    return new Tuple<int, int, int, int, int, bool>(Time, Bombs, Empty, FieldHeight, FieldHeight, IsFinished);
                }
                else
                {
                    return null;
                }
            }
        }
        public static bool MakeField(Tuple<int, byte, byte, short, short, bool, bool, Tuple<bool>> Field)
        {
            int RowCount;
            Command = Conection.CreateCommand();
            Command.CommandText = "INSERT INTO Fields (GameID, PositionX, PositionY, StartValue, CurrentValue, " +
                                  "IsOpened, IsMarked, IsHighlighted) " +
                                  "VALUES (@GameID, @PositionX, @PositionY, @StartValue, @CurrentValue, @IsOpened, " +
                                  "@IsMarked, @IsHighlighted)";
            Command.Parameters.Add("@GameID", System.Data.SqlDbType.Int).Value = Field.Item1;
            Command.Parameters.Add("@PositionX", System.Data.SqlDbType.TinyInt).Value = Field.Item2;
            Command.Parameters.Add("@PositionY", System.Data.SqlDbType.TinyInt).Value = Field.Item3;
            Command.Parameters.Add("@StartValue", System.Data.SqlDbType.SmallInt).Value = Field.Item4;
            Command.Parameters.Add("@CurrentValue", System.Data.SqlDbType.SmallInt).Value = Field.Item5;
            Command.Parameters.Add("@IsOpened", System.Data.SqlDbType.Bit).Value = Field.Item6;
            Command.Parameters.Add("@IsMarked", System.Data.SqlDbType.Bit).Value = Field.Item7;
            Command.Parameters.Add("@IsHighlighted", System.Data.SqlDbType.Bit).Value = Field.Rest.Item1;
            RowCount = Command.ExecuteNonQuery();
            return RowCount == 1;
        }
        public static bool UpdateField(Tuple<int, byte, byte, short, short, bool, bool, Tuple<bool>> Field)
        {
            int RowCount;
            Command = Conection.CreateCommand();
            Command.CommandText = "UPDATE Fields " +
                                  "SET CurrentValue = @CurrentValue, IsOpened = @IsOpened, IsMarked = @IsMarked, IsHighlighted = @IsHighlighted " +
                                  "WHERE GameID = @GameID " +
                                  "AND PositionX = @PositionX " +
                                  "AND PositionY = @PositionY";
            Command.Parameters.Add("@GameID", System.Data.SqlDbType.Int).Value = Field.Item1;
            Command.Parameters.Add("@PositionX", System.Data.SqlDbType.TinyInt).Value = Field.Item2;
            Command.Parameters.Add("@PositionY", System.Data.SqlDbType.TinyInt).Value = Field.Item3;
            Command.Parameters.Add("@CurrentValue", System.Data.SqlDbType.SmallInt).Value = Field.Item5;
            Command.Parameters.Add("@IsOpened", System.Data.SqlDbType.Bit).Value = Field.Item6;
            Command.Parameters.Add("@IsMarked", System.Data.SqlDbType.Bit).Value = Field.Item7;
            Command.Parameters.Add("@IsHighlighted", System.Data.SqlDbType.Bit).Value = Field.Rest.Item1;
            RowCount = Command.ExecuteNonQuery();
            return RowCount == 1;
        }
        public static List<Tuple<byte, byte, short, short, bool, bool, bool>> LoadField(int GameID)
        {
            Command = Conection.CreateCommand();
            Command.CommandText = "SELECT PositionX, PositionY, StartValue, CurrentValue, IsOpened, IsMarked, IsHighlighted " +
                                  "FROM Fields " +
                                  "WHERE GameID = @GameID";
            Command.Parameters.Add("@GameID", System.Data.SqlDbType.Int).Value = GameID;
            using (DbDataReader reader = Command.ExecuteReader())
            {
                List<Tuple<byte, byte, short, short, bool, bool, bool>> ReturnedField =
                    new List<Tuple<byte, byte, short, short, bool, bool, bool>>();
                if (reader.HasRows)
                {
                    Tuple<byte, byte, short, short, bool, bool, bool> Buffer;
                    byte PositionX = 0, PositionY = 0;
                    short StartValue = 0, CurrentValue = 0;
                    bool IsOpened = false, IsMarked = false, IsHighlighted = false;
                    while (reader.Read())
                    {
                        PositionX = reader.GetByte(reader.GetOrdinal("PositionX"));
                        PositionY = reader.GetByte(reader.GetOrdinal("PositionY"));
                        StartValue = reader.GetInt16(reader.GetOrdinal("StartValue"));
                        CurrentValue = reader.GetInt16(reader.GetOrdinal("CurrentValue"));
                        IsOpened = reader.GetBoolean(reader.GetOrdinal("IsOpened"));
                        IsMarked = reader.GetBoolean(reader.GetOrdinal("IsMarked"));
                        IsHighlighted = reader.GetBoolean(reader.GetOrdinal("IsHighlighted"));
                        Buffer = new Tuple<byte, byte, short, short, bool, bool, bool>(PositionX, PositionY, StartValue,
                            CurrentValue, IsOpened, IsMarked, IsHighlighted);
                        ReturnedField.Add(Buffer);
                    }                    
                }
                return ReturnedField;
            }
        }
        public static bool RemoveField(int GameID)
        {
            Command = Conection.CreateCommand();
            Command.CommandText = "DELETE FROM Fields " +
                                  "WHERE GameID = @GameID";
            Command.Parameters.Add("@GameID", System.Data.SqlDbType.Int).Value = GameID;
            int RowCount = Command.ExecuteNonQuery();
            return RowCount > 0;
        }
    }
}
