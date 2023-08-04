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
using ApplicationLayer.AdminTools;

namespace CinemaAdmin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dgvAdmin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        List<DataGridViewRow> updatedRows = new List<DataGridViewRow>();
        //List<DataGridViewRow> insertedRows = new List<DataGridViewRow>();
        List<ulong> deletedIndex = new List<ulong>();
        //List<ulong> insertedIndex = new List<ulong>();
        List<string> insertData;
        bool isThereInsertData = false;
        private string tableName;
        bool sessionTable = false;
        int mouseX;
        int mouseY;
        string currentMenuStrip;
        
        private void FormatDgv()
        {
            dgvAdmin.Columns[0].ReadOnly = true;    //cannot change ID
            tableName = (dgvAdmin.DataSource as DataTable).TableName;
            //check if picture cell exists
            foreach (DataGridViewColumn item in dgvAdmin.Columns)
            {
                if (item.GetType() == typeof(DataGridViewImageColumn))
                {
                    (item as DataGridViewImageColumn).ImageLayout = DataGridViewImageCellLayout.Zoom;
                }
            }
        }

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvAdmin.AllowUserToAddRows = true;
            dgvAdmin.DataSource = AdminDataTools.GetAllRooms();
            FormatDgv();
            sessionTable = false;
            currentMenuStrip = "room";
        }

        private void dgvAdmin_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //Checking if the list has this row
            var found = updatedRows.FindAll(x => x.Cells[0].Value == dgvAdmin[0, e.RowIndex].Value);
            if (found == null)
            {
                updatedRows.Add(dgvAdmin.Rows[e.RowIndex]);
                return;
            }
            //If row was found
            updatedRows.Remove(dgvAdmin.Rows[e.RowIndex]);
            updatedRows.Add(dgvAdmin.Rows[e.RowIndex]);
            Console.WriteLine("==============test==============");
            foreach (var item in updatedRows)
            {
                Console.WriteLine(item.Cells[0].Value + " " + item.Cells[1].Value);
            }
        }

        private void dgvAdmin_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            deletedIndex.Add((ulong)dgvAdmin[0, e.Row.Index].Value);
            updatedRows.RemoveAll(x=>(ulong)x.Cells[0].Value==deletedIndex[deletedIndex.Count-1]);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Checking for empty rows
            insertData = new List<string>();
            Console.WriteLine("Null cells:");
            //List<string> data = new List<string>();
            /*foreach (var item in updatedRows)
            {
                Console.WriteLine(item.Cells[1].Value);
                for(int i=0; i<item.Cells.Count; i++)
                {
                    data.Add(item.Cells[i].Value.ToString());
                }
                if(item.Cells[0].Value == null || item.Cells[0].Value == DBNull.Value)
                {
                    
                    switch (currentMenuStrip)
                    {
                        case "room":
                            AdminDataTools.RowsToAdd(currentMenuStrip, data);
                            break;
                        case "movie":
                            break;
                        case "session":
                            break;
                    }
                }
            }
            foreach (var item in data)
            {
                Console.WriteLine(item);
            }*/
            dgvAdmin.AllowUserToAddRows = false;
            foreach (DataGridViewRow row in dgvAdmin.Rows)
            {
                if (row.Cells[0].Value == null || row.Cells[0].Value == DBNull.Value)
                {
                    //Console.WriteLine(row.Cells[1].Value + " " + row.Cells[2].Value);
                    if (currentMenuStrip == "room")
                    {
                        //MessageBox.Show(row.Cells[2].Value.ToString());
                        insertData.Add(row.Cells[1].Value.ToString());
                        insertData.Add(Convert.ToInt32(row.Cells[2].Value).ToString());
                    }
                    isThereInsertData = true;
                    dgvAdmin.AllowUserToAddRows = true;
                    break;
                }
            }
            if (dgvAdmin.EndEdit())
            {
                if (deletedIndex.Count == 0 && updatedRows.Count == 0) return;
                if (AdminDataTools.UpdateDeleteData(deletedIndex, updatedRows, tableName))
                {
                    Console.WriteLine("Save OK!");
                    deletedIndex.Clear();
                    updatedRows.Clear();
                }
                if (isThereInsertData)
                {
                    if(AdminDataTools.GetInsertData(currentMenuStrip, insertData))
                    {
                        insertData.Clear();
                        isThereInsertData = false;
                        dgvAdmin.AllowUserToAddRows = true;
                    }
                }
            }
        }

        private void moviesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvAdmin.DataSource = AdminDataTools.GetAllMovies();
            FormatDgv();
            sessionTable = false;
            currentMenuStrip = "movie";
        }

        private void sessionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvAdmin.DataSource = AdminDataTools.GetAllSessions();
            FormatDgv();
            sessionTable = true;
            currentMenuStrip = "session";
        }

        private void dgvAdmin_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvAdmin.EndEdit();
            if (!sessionTable) return;
            //If movie title column
            if (e.Button == MouseButtons.Right)
            {
                if (dgvAdmin.Columns[e.ColumnIndex].HeaderText == "Title")
                {
                    FillContextMenu("Title", e.ColumnIndex, e.RowIndex);             
                }
                else if (dgvAdmin.Columns[e.ColumnIndex].HeaderText == "Name")
                {
                    FillContextMenu("Name", e.ColumnIndex, e.RowIndex);
                }
            }
        }

        private void FillContextMenu(string header, int column, int row)
        {
            List<string> lst = new List<string>();
            if (header == "Title")
            {
                lst = AdminDataTools.GetMovieTitles();
            }
            else if(header == "Name")
            {
                lst = AdminDataTools.GetRoomNames();
            }
            cMenu.Items.Clear();
            foreach (var item in lst)
            {
                var data = new ToolStripMenuItem();
                data.Text = item;
                data.Click += delegate (object sender, EventArgs e)
                {
                    dgvAdmin.CurrentCell.Value = data.Text;
                };
                cMenu.Items.Add(data);
            }

            cMenu.Hide();
            foreach (DataGridViewCell item in dgvAdmin.SelectedCells)
            {
                item.Selected = false;
            }
            dgvAdmin[column, row].Selected = true;
            dgvAdmin.CurrentCell = dgvAdmin[column, row];
            cMenu.Show(dgvAdmin, mouseX, mouseY);
        }

        private void dgvAdmin_MouseMove(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;
        }
    }
}
