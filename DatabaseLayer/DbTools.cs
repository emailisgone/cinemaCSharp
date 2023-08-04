using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DatabaseLayer
{
    public class DbTools
    {
        private static MySqlConnection connection;

        private static string GetConnectionString()
        {
            var builder = new MySqlConnectionStringBuilder()
            {
                Server = "localhost",
                Port = 3306,
                UserID = "cinema_user",
                Password = "cinema_password",
                Database = "cinema",
                ConnectionTimeout = 45
            };
            return builder.ToString();
        }

        private static void CheckConnection()
        {
            if(connection == null)
            {
                connection = new MySqlConnection();
                connection.ConnectionString = GetConnectionString();
                connection.InfoMessage += Connection_InfoMessage;
                connection.StateChange += Connection_StateChange;
            }
        }

        private static void Connection_StateChange(object sender, System.Data.StateChangeEventArgs e)
        {
            Console.WriteLine("=======State change start=======");
            Console.WriteLine(e.CurrentState);
            Console.WriteLine("=======State change end=========");
        }

        private static void Connection_InfoMessage(object sender, MySqlInfoMessageEventArgs args)
        {
            Console.WriteLine("=======Info message start=======");
            foreach (var item in args.errors)
            {
                Console.WriteLine($"Code : {item.Code}; Message {item.Message}");
            }
            Console.WriteLine("=======Info message end=========");
        }

        private static bool CheckOpenConnection()
        {
            CheckConnection();
            if (connection.State == System.Data.ConnectionState.Open)
                return true;
            return false;
        }

        private static bool OpenConnection()
        {
            try
            {
                if (!CheckOpenConnection())
                {
                    connection.Open();
                }
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("=======Open connection exception start=======");
                Console.WriteLine(ex.Message);
                Console.WriteLine("=======Open connection exception end=========");
                return false;
            }
        }

        internal static bool SendDataToServer(string sqlText)
        {
            try
            {
                if (!OpenConnection()) return false;
                MySqlCommand cmd = new MySqlCommand(sqlText, connection);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("=======SendData exception start=======");
                Console.WriteLine(ex.Message);
                Console.WriteLine("=======SendData exception end=========");
                return false;
            }
        }

        internal static bool SendDataToServerTransaction(string sqlText)
        {
            MySqlTransaction transaction;
            if (!OpenConnection()) return false;
            transaction = connection.BeginTransaction();
            try
            {
                MySqlCommand cmd = new MySqlCommand(sqlText, connection);
                cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("=======SendDataTransaction exception start=======");
                Console.WriteLine(ex.Message);
                Console.WriteLine("=======SendDataTransaction exception end=========");
                transaction.Rollback();
                return false;
            }
        }

        internal static MySqlDataReader GetDataFromServerReader(string sqlText)
        {
            try
            {
                if (!OpenConnection()) return null;
                MySqlCommand cmd = new MySqlCommand(sqlText, connection);
                return cmd.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("=======GetDataFromServerReader exception start=======");
                Console.WriteLine(ex.Message);
                Console.WriteLine("=======GetDataFromServerReader exception end=========");
                return null;
            }
        }

        internal static MySqlDataAdapter GetDataFromServerAdapter(string sqlText)
        {
            try
            {
                if (!OpenConnection()) return null;
                MySqlCommand cmd = new MySqlCommand(sqlText, connection);
                return new MySqlDataAdapter(cmd);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("=======GetDataFromServerAdapter exception start=======");
                Console.WriteLine(ex.Message);
                Console.WriteLine("=======GetDataFromServerAdapter exception end=========");
                return null;
            }
        }

        internal static object GetDataFromServerScalar(string sqlText)
        {
            try
            {
                if (!OpenConnection()) return null;
                MySqlCommand cmd = new MySqlCommand(sqlText, connection);
                return cmd.ExecuteScalar();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("=======GetDataFromServerScalar exception start=======");
                Console.WriteLine(ex.Message);
                Console.WriteLine("=======GetDataFromServerScalar exception end=========");
                return null;
            }
        }

        public static DataTable GetCurrentMovies()
        {
            try
            {
                DataTable tbl = new DataTable();

                string sqlText = "SELECT m.Title,m.Descr,m.Duration,m.Poster,m.AgeRestriction,r.Name as Room,s.SessionTime FROM session as s,movie as m, room as r WHERE s.SessionTime LIKE concat((SELECT CURDATE()),'%') AND s.MovieID=m.ID AND s.RoomID=r.ID;";
                GetDataFromServerAdapter(sqlText).Fill(tbl);
                return tbl;
            }
            catch (Exception ex)
            {
                Console.WriteLine("=======GetCurrentMovies exception start=======");
                Console.WriteLine(ex.Message);
                Console.WriteLine("=======GetCurrentMovies exception end=========");
                return null;
            }
        }

        public static DataTable GetPopularMovies(int movieCount)
        {
            try
            {
                DataTable tbl = new DataTable();

                string sqlText = $"SELECT * FROM movie ORDER BY ViewCount DESC LIMIT {movieCount};";
                GetDataFromServerAdapter(sqlText).Fill(tbl);
                return tbl;
            }
            catch (Exception ex)
            {
                Console.WriteLine("=======GetPopularMovies exception start=======");
                Console.WriteLine(ex.Message);
                Console.WriteLine("=======GetPopularMovies exception end=========");
                return null;
            }
        }

        public static DataTable GetAllMovies()
        {
            try
            {
                DataTable tbl = new DataTable();

                string sqlText = $"SELECT * FROM movie;";
                GetDataFromServerAdapter(sqlText).Fill(tbl);
                return tbl;
            }
            catch (Exception ex)
            {
                Console.WriteLine("=======GetAllMovies exception start=======");
                Console.WriteLine(ex.Message);
                Console.WriteLine("=======GetAllMovies exception end=========");
                return null;
            }
        }

        public static DataTable GetSelectDateMovies(DateTime date)
        {
            try
            {
                DataTable tbl = new DataTable();

                string sqlText = $"SELECT m.Title,m.Descr,m.ReleaseDate,m.Duration,m.Poster,m.AgeRestriction,r.Name as Room,s.SessionTime FROM session as s,movie as m, room as r WHERE s.SessionTime BETWEEN '{date}' AND '{date.AddHours(23).AddMinutes(59).AddSeconds(59)}' AND s.MovieID=m.ID AND s.RoomID=r.ID;";
                GetDataFromServerAdapter(sqlText).Fill(tbl);
                return tbl;
            }
            catch (Exception ex)
            {
                Console.WriteLine("=======GetSelectDateMovies exception start=======");
                Console.WriteLine(ex.Message);
                Console.WriteLine("=======GetSelectDateMovies exception end=========");
                return null;
            }
        }

        public static byte GetRoomSeatNr(string roomName)
        {
            try
            {
                string sqlText = $"Select SeatNr From room where Name='{roomName}';";
                var nr = GetDataFromServerScalar(sqlText); // GetDatafromserverscalar gives ONLY 1 out of a list of variables
                if (nr == null) return 0;
                return (byte)nr;
            }
            catch (Exception ex)
            {
                Console.WriteLine("=======GetRoomSeatNr exception start=======");
                Console.WriteLine(ex.Message);
                Console.WriteLine("=======GetRoomSeatNr exception end=========");
                return 0;
            }
        }

        public static string TakenSeats(string roomName, DateTime sessionTime)
        {
            try
            {
                string sqlText = $"Select TakenSeats FROM Session WHERE RoomID=(SELECT ID FROM room WHERE Name='{roomName}') AND SessionTime='{sessionTime}'";
                var data = GetDataFromServerScalar(sqlText);
                if (data == null) return null;
                return data.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("=======TakenSeats exception start=======");
                Console.WriteLine(ex.Message);
                Console.WriteLine("=======TakenSeats exception end=========");
                return null;
            }
        }
        
        public static bool BuyTicket(List<int> reservedSeats, string roomName, DateTime sessionTime)
        {
            try
            {
                StringBuilder sqlText = new StringBuilder();

                sqlText.Append($"SELECT ID FROM Session WHERE sessionTime='{sessionTime}' AND RoomID=(Select ID FROM Room WHERE Name='{roomName}');");

                var sessionID = GetDataFromServerScalar(sqlText.ToString());
                if (sessionID == null) return false;

                sqlText.Append("Insert into Ticket(SessionID, SeatNr) VALUES ");
                foreach (var item in reservedSeats)
                {
                    sqlText.Append($"({(ulong)sessionID}, {item}),");
                }
                sqlText.Remove(sqlText.Length - 1, 1).Append(";");

                return SendDataToServer(sqlText.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("=======BuySeats exception start=======");
                Console.WriteLine(ex.Message);
                Console.WriteLine("=======BuySeats exception end=========");
                return false;
            }
        }

        public static bool UpdateTakenSeats(string roomName, DateTime sessionTime, string takenSeats)
        {
            try
            {
                string sqlText = $"Update session SET TakenSeats ='{takenSeats}' WHERE sessionTime='{sessionTime}' AND RoomID=(Select ID FROM Room WHERE Name='{roomName}');";
                return SendDataToServer(sqlText);
            }
            catch (Exception ex)
            {
                Console.WriteLine("=======UpdateTakenSeats exception start=======");
                Console.WriteLine(ex.Message);
                Console.WriteLine("=======UpdateTakenSeats exception end=========");
                return false;
            }
        }
    }

    namespace AdminDbTools
    {
        public class AdminDb
        {
            public static DataTable GetAllRooms()
            {
                try
                {
                    string sqlText = "Select * from Room";
                    var data = DbTools.GetDataFromServerAdapter(sqlText);
                    if (data == null) return null;
                    DataTable tbl = new DataTable();
                    data.Fill(tbl);
                    tbl.TableName = "room";
                    return tbl;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("=======Admin GetAllRooms exception start=======");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("=======Admin GetAllRooms exception end=========");
                    return null;
                }
            }

            public static DataTable GetAllMovies()
            {
                try
                {
                    string sqlText = "Select * from movie";
                    var data = DbTools.GetDataFromServerAdapter(sqlText);
                    if (data == null) return null;
                    DataTable tbl = new DataTable();
                    data.Fill(tbl);
                    tbl.TableName = "movie";
                    return tbl;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("=======Admin GetAllMovies exception start=======");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("=======Admin GetAllMovies exception end=========");
                    return null;
                }
            }

            public static DataTable GetAllSessions()
            {
                try
                {
                    string sqlText = "Select s.ID,m.Title, r.Name, s.TakenSeats,s.SessionTime,s.Price from session s LEFT JOIN room r ON s.RoomID=r.ID LEFT JOIN movie m ON s.MovieID=m.ID;";
                    var data = DbTools.GetDataFromServerAdapter(sqlText);
                    if (data == null) return null;
                    DataTable tbl = new DataTable();
                    data.Fill(tbl);
                    tbl.TableName = "session";
                    return tbl;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("=======Admin GetAllSessions exception start=======");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("=======Admin GetAllSessions exception end=========");
                    return null;
                }
            }

            public static bool UpdateDeleteData(List<ulong> delete, List<List<string>> valuesToUpdate, string tblName)
            {
                try
                {
                    StringBuilder sqlText = new StringBuilder();
                    foreach (var item in delete)
                    {
                        sqlText.Append($"DELETE FROM {tblName} WHERE ID = {item};");
                    }
                    sqlText.Append(RowsToUpdate(tblName, valuesToUpdate));
                    return DbTools.SendDataToServerTransaction(sqlText.ToString());
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("=======Admin UpdateDeleteData exception start=======");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("=======Admin UpdateDeleteData exception end=========");
                    return false;
                }
            }

            private static string RowsToUpdate(string tblName, List<List<string>> valuesToUpdate)
            {
                StringBuilder updateString = new StringBuilder();
                //Strings with ''
                foreach (var item in valuesToUpdate)
                {
                    if (tblName == "room")
                    {
                        updateString.Append($"UPDATE room SET Name={item[1]},SeatNr={item[2]} WHERE ID={item[0]};");
                    }
                    else if (tblName == "movie")
                    {
                        updateString.Append($"UPDATE movie SET Title={item[1]}, Descr={item[2]},ReleaseDate={item[3]},Duration={item[4]},AgeRestriction={item[6]} WHERE ID={item[0]};");
                    }
                    else if (tblName == "session")
                    {

                    }
                }
                return updateString.ToString();
            }

            public static List<string> GetMovieTitles()
            {
                try
                {
                    string sqlText = "Select Title FROM movie;";
                    var data = DbTools.GetDataFromServerReader(sqlText);
                    if (data == null) return new List<string>();
                    var lst = new List<string>();
                    while (data.Read())
                    {
                        lst.Add(data[0].ToString());
                    }
                    data.Close();
                    return lst;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("=======Admin GetMovieTitles exception start=======");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("=======Admin GetMovieTitles exception end=========");
                    return new List<string>();
                }
            }

            public static List<string> GetRoomNames()
            {
                try
                {
                    string sqlText = "Select Name FROM room;";
                    var data = DbTools.GetDataFromServerReader(sqlText);
                    if (data == null) return new List<string>();
                    var lst = new List<string>();
                    while (data.Read())
                    {
                        lst.Add(data[0].ToString());
                    }
                    data.Close();
                    return lst;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("=======Admin GetRoomNames exception start=======");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("=======Admin GetRoomNames exception end=========");
                    return new List<string>();
                }
            }

            public static bool InsertData(string currentMenuStrip, List<string> insertData)
            {
                try
                {
                    StringBuilder sqlText = new StringBuilder();
                    if (currentMenuStrip == "room") 
                        //Console.WriteLine(insertData[1] + " THIS SHOULD BE A NUMBER");
                        sqlText.Append($"INSERT INTO {currentMenuStrip} VALUES (null, '{insertData[0]}', {insertData[1]});");
                    else if(currentMenuStrip == "session") sqlText.Append($"INSERT INTO {currentMenuStrip} VALUES (null, {insertData[0]}, {insertData[1]}, {insertData[2]}, {insertData[3]}, {insertData[4]});");
                    else if(currentMenuStrip == "movie") sqlText.Append($"INSERT INTO {currentMenuStrip} VALUES (null, {insertData[0]}, {insertData[1]}, {insertData[2]}, {insertData[3]}, {insertData[4]}, {insertData[5]}, {insertData[6]});");
                    //Console.WriteLine(sqlText.ToString());
                    return DbTools.SendDataToServerTransaction(sqlText.ToString());
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("=======Admin InsertData exception start=======");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("=======Admin InsertData exception end=========");
                    return false;
                }
            }

            /*public static string RowsToAdd(string tblName, List<List<string>> valuesToAdd)
            {
                StringBuilder insertString = new StringBuilder();
                foreach (var item in valuesToAdd)
                {

                }
            }*/
        }
    }
}