using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApplicationLayer;

namespace Cinema
{
    public partial class OneMovieControl : UserControl
    {
        string roomName;
        DateTime sessionTime;
        public OneMovieControl(ShowType showType, string roomName, DateTime sessionTime)
        {
            InitializeComponent();
            this.roomName = roomName;
            this.sessionTime = sessionTime;

            switch (showType)
            {
                case ShowType.NowShowing:
                    lblRD.Visible = false;
                    lblV.Visible = false;
                    lblReleaseDate.Visible = false;
                    lblViews.Visible = false;
                    break;
                case ShowType.Popular:
                    break;
                case ShowType.AllMovies:
                    lblV.Visible = false;
                    lblViews.Visible = false;
                    break;
                case ShowType.SelectDate:
                    lblV.Visible = false;
                    lblViews.Visible = false;
                    break;
            }
        }

        private void btnTicket_Click(object sender, EventArgs e)
        {
            new SeatSelectionForm(roomName, sessionTime, lblTitle.Text).ShowDialog();
        }
    }
}
