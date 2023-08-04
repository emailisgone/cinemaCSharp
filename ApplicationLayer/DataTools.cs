using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DatabaseLayer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft;
using DatabaseLayer.AdminDbTools;
using System.Windows.Forms;

namespace ApplicationLayer
{
    public class DataTools
    {
#nullable enable

        //Function, which will get info from database, works with it and sends to the design
        public static List<NowShowingMovie>? NowShowing()
        {
            try
            {
                //Getting movie table
                DataTable tbl = DbTools.GetCurrentMovies();

                //If no movies or an error
                if (tbl == null || tbl.Rows.Count == 0) return null;

                List<NowShowingMovie> allMovies = new List<NowShowingMovie>();
                foreach (DataRow row in tbl.Rows)
                {
                    var item = new NowShowingMovie()
                    {
                        //itemArray - stulpeliu masyvas
                        Title = row.ItemArray[0].ToString(),
                        Descr = row.ItemArray[1].ToString(),
                        Duration = Convert.ToDateTime(row.ItemArray[2].ToString()),
                        Poster = Image.FromStream(new MemoryStream((byte[])row.ItemArray[3])),
                        AgeRestriction = row.ItemArray[4].ToString(),
                        Room = row.ItemArray[5].ToString(),
                        SessionTime = Convert.ToDateTime(row.ItemArray[6])
                    };
                    allMovies.Add(item);
                }
                return allMovies;
            }
            catch (Exception ex)
            {
                Console.WriteLine("=======NowShowing exception start=======");
                Console.WriteLine(ex.Message);
                Console.WriteLine("=======NowShowing exception end=========");
                return null;
            }
        }

        public static List<Movie>? AllMovies()
        {
            try
            {
                //Getting movie table
                DataTable tbl = DbTools.GetAllMovies();

                //If no movies or an error
                if (tbl == null || tbl.Rows.Count == 0) return null;

                List<Movie> allMovies = new List<Movie>();
                foreach (DataRow row in tbl.Rows)
                {
                    var item = new Movie()
                    {
                        //itemArray - stulpeliu masyvas
                        Title = row.ItemArray[1].ToString(),
                        Descr = row.ItemArray[2].ToString(),
                        ReleaseDate = Convert.ToDateTime(row.ItemArray[3]),
                        Duration = Convert.ToDateTime(row.ItemArray[4].ToString()),
                        Poster = Image.FromStream(new MemoryStream((byte[])row.ItemArray[5])),
                        AgeRestriction = row.ItemArray[6].ToString(),
                    };
                    allMovies.Add(item);
                }
                return allMovies;
            }
            catch (Exception ex)
            {
                Console.WriteLine("=======AllMovies exception start=======");
                Console.WriteLine(ex.Message);
                Console.WriteLine("=======AllMovies exception end=========");
                return null;
            }
        }

        public static List<Movie>? PopularMovies(int count)
        {
            try
            {
                //Getting movie table
                DataTable tbl = DbTools.GetPopularMovies(count);

                //If no movies or an error
                if (tbl == null || tbl.Rows.Count == 0) return null;

                List<Movie> allMovies = new List<Movie>();
                foreach (DataRow row in tbl.Rows)
                {
                    var item = new Movie()
                    {
                        //itemArray - stulpeliu masyvas
                        Title = row.ItemArray[1].ToString(),
                        Descr = row.ItemArray[2].ToString(),
                        Duration = Convert.ToDateTime(row.ItemArray[4].ToString()),
                        Poster = Image.FromStream(new MemoryStream((byte[])row.ItemArray[5])),
                        AgeRestriction = row.ItemArray[6].ToString(),
                        ReleaseDate = Convert.ToDateTime(row.ItemArray[3].ToString()),
                        ViewCount = Convert.ToInt32(row.ItemArray[7])
                    };
                    allMovies.Add(item);
                }
                return allMovies;
            }
            catch (Exception ex)
            {
                Console.WriteLine("=======NowShowing exception start=======");
                Console.WriteLine(ex.Message);
                Console.WriteLine("=======NowShowing exception end=========");
                return null;
            }
        }

        public static List<NowShowingMovie>? ShowSelectDateMovies(DateTime date)
        {
            try
            {
                //Getting movie table
                DataTable tbl = DbTools.GetSelectDateMovies(new DateTime(date.Year, date.Month, date.Day, 0,0,0));

                //If no movies or an error
                if (tbl == null || tbl.Rows.Count == 0) return null;

                List<NowShowingMovie> allMovies = new List<NowShowingMovie>();
                foreach (DataRow row in tbl.Rows)
                {
                    var item = new NowShowingMovie()
                    {
                        //itemArray - stulpeliu masyvas
                        Title = row.ItemArray[0].ToString(),
                        Descr = row.ItemArray[1].ToString(),
                        ReleaseDate = Convert.ToDateTime(row.ItemArray[2]),
                        Duration = Convert.ToDateTime(row.ItemArray[3].ToString()),
                        Poster = Image.FromStream(new MemoryStream((byte[])row.ItemArray[4])),
                        AgeRestriction = row.ItemArray[5].ToString(),
                        Room = row.ItemArray[6].ToString(),
                        SessionTime = Convert.ToDateTime(row.ItemArray[7])
                    };
                    allMovies.Add(item);
                }
                return allMovies;
            }
            catch (Exception ex)
            {
                Console.WriteLine("=======NowShowing exception start=======");
                Console.WriteLine(ex.Message);
                Console.WriteLine("=======NowShowing exception end=========");
                return null;
            }
        }

        public static byte RoomSeatNr(string roomName)
        {
            return DbTools.GetRoomSeatNr(roomName);
        }

        public static List<int>? TakenSeats(string roomName, DateTime sessionTime)
        {
            string? data = DbTools.TakenSeats(roomName, sessionTime);
            if (data == null) return null;
            return JsonConvert.DeserializeObject<List<int>>(data);
        }

        public static bool UpdateTakenSeats(string roomName, DateTime sessionTime, List<int> takenSeats)
        {
            return DbTools.UpdateTakenSeats(roomName, sessionTime, JsonConvert.SerializeObject(takenSeats));
        }

        public static bool BuyTicket(List<int> reservedSeats, string roomName, DateTime sessionTime)
        {
            return DbTools.BuyTicket(reservedSeats, roomName, sessionTime);
        }
    }

    namespace AdminTools
    {
        public class AdminDataTools
        {
            public static DataTable GetAllRooms()
            {
                return AdminDb.GetAllRooms();
            }

            public static DataTable GetAllMovies()
            {
                return AdminDb.GetAllMovies();
            }

            public static DataTable GetAllSessions()
            {
                return AdminDb.GetAllSessions();
            }

            public static bool UpdateDeleteData(List<ulong> delete, List<DataGridViewRow> update, string tblName)
            {
                List<List<string>> valuesToUpdate = new List<List<string>>();
                foreach (var item in update)
                {
                    var lst = new List<string>();
                    for(int i=0; i<item.Cells.Count; i++)
                    {
                        if (item.Cells[i].ValueType == typeof(string) || 
                            item.Cells[i].ValueType == typeof(DateTime) || 
                            item.Cells[i].ValueType==typeof(TimeSpan))
                            lst.Add($"'{item.Cells[i].Value}'");
                        else
                            lst.Add(item.Cells[i].Value.ToString());
                    }
                    valuesToUpdate.Add(lst);
                }

                return AdminDb.UpdateDeleteData(delete, valuesToUpdate, tblName);
            }

            public static List<string> GetMovieTitles()
            {
                return AdminDb.GetMovieTitles();
            }

            public static List<string> GetRoomNames()
            {
                return AdminDb.GetRoomNames();
            }

            public static bool GetInsertData(string currentMenuStrip, List<string> insertData)
            {
                return AdminDb.InsertData(currentMenuStrip, insertData);
            }
        }
    }
}
