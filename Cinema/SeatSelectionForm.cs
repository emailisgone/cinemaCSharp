using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApplicationLayer;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using excel = Microsoft.Office.Interop.Excel;

namespace Cinema
{
    public partial class SeatSelectionForm : Form
    {
        string roomName;
        DateTime sessionTime;
        string movieName;
        byte columns = 10;
        List<int> reservedSeats = new List<int>();
        List<int> takenSeats;
        public SeatSelectionForm(string roomName, DateTime sessionTime, string movieName)
        {
            InitializeComponent();
            this.roomName = roomName;
            this.sessionTime = sessionTime;
            this.movieName = movieName;
            ShowSeats();
        }

        private void ShowSeats()
        {
            byte seats = DataTools.RoomSeatNr(roomName);
            takenSeats = DataTools.TakenSeats(roomName, sessionTime);
            if (takenSeats == null) takenSeats = new List<int>();
            //calc how many rows
            if (seats == 0) return;
            byte rows;
            if (seats % columns == 0)
                rows = (byte)(seats / columns);
            rows = (byte)((seats / columns) + 1);
            tblSeats.ColumnCount = 0;
            tblSeats.RowCount = 0;
            tblSeats.ColumnCount = columns;
            tblSeats.RowCount = rows;
            tblSeats.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;


            for (int i = 0; i < rows; i++)
            {
                tblSeats.RowStyles.Add(new RowStyle() { SizeType = SizeType.AutoSize});
            }

            for (int i = 0; i < columns; i++)
            {
                tblSeats.ColumnStyles.Add(new ColumnStyle() {SizeType = SizeType.AutoSize});
            }
            int counter = 1;

            //fill tablelayoutpanel
            bool broken = false;
            for (int i = 0; i < tblSeats.RowCount; i++)
            {
                for (int j = 0; j < tblSeats.ColumnCount; j++)
                {
                    Button btn = new Button();
                    btn.Text = $"{counter}";
                    if (takenSeats != null && takenSeats.Contains(counter))
                    {
                        btn.BackColor = Color.Red;
                        btn.Enabled = false;
                    }
                    else
                    {
                        btn.BackColor = Color.Green;
                    }
                    //btn.AutoSize = true;
                    btn.Click += Btn_Click;
                    tblSeats.Controls.Add(btn, j, i);
                    //seats--;
                    if (seats == counter)
                    {
                        broken = true;
                        break;
                    }
                    counter++;
                }
                if (broken) break;
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            var btn = (sender as Button);
            if(btn.BackColor == Color.Green)
            {
                btn.BackColor = Color.Yellow;
                reservedSeats.Add(Convert.ToInt32(btn.Text));
            }
            else
            {
                btn.BackColor = Color.Green;
                reservedSeats.Remove(Convert.ToInt32(btn.Text));
            }
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            if (reservedSeats.Count == 0) return;
            var rez = MessageBox.Show("Are you sure?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rez==DialogResult.No)
            {
                return;
            }
            if (DataTools.BuyTicket(reservedSeats, roomName, sessionTime))
            {
                takenSeats.AddRange(reservedSeats);
                if(DataTools.UpdateTakenSeats(roomName, sessionTime, takenSeats))
                {
                    //Print ticket
                    PrintTicket(reservedSeats);
                    this.Close();
                }
            }
        }

        private void PrintTicket(List<int> reservedSeats)
        {
            excel.Application app = new excel.Application();
            excel._Workbook book = app.Workbooks.Open (Application.StartupPath+@"\ticketTemplate.xlsx");
            excel._Worksheet sheet = (excel._Worksheet)book.ActiveSheet;

            foreach (var item in reservedSeats)
            {
                //Movie name
                sheet.Cells[1, 2] = movieName;
                //Session time
                sheet.Cells[2, 2] = sessionTime.ToShortDateString();
                //Seat nr.
                sheet.Cells[3, 2] = item+", "+roomName;
                //sheet.PrintOutEx(1, 1, 1, false, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            app.ActiveWorkbook.Save();
            book.Close();
            app.Quit();
            //Cleaning up
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(sheet);
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(book);
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(app);
            GC.Collect(); //Garbage collector
            //GC.WaitForPendingFinalizers();
        }
    }
}
