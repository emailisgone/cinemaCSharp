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
    public partial class AllMoviesControl : UserControl
    {
        public AllMoviesControl()
        {
            InitializeComponent();
            pnlMovies.AutoScroll = true;
            ShowMovies();
        }

        private void ShowMovies()
        {
            var lst = DataTools.AllMovies();
            if (lst == null) return;
            //Creating control for each movie
            for (int i = 0; i < lst.Count; i++)
            {
                var control = new OneMovieControl(ShowType.AllMovies, lst[i].Room, lst[i].SessionTime);
                control.Location = new Point(0, control.Height * i);
                control.lblTitle.Text = lst[i].Title;
                control.lblDescription.Text = lst[i].Descr;
                control.lblDuration.Text = lst[i].Duration.ToShortTimeString();
                control.lblAgeRestriction.Text = lst[i].AgeRestriction.ToString();
                control.lblReleaseDate.Text = lst[i].ReleaseDate.ToShortDateString();             
                control.picPoster.Image = lst[i].Poster;
                control.btnTicket.Visible = false;
                pnlMovies.Controls.Add(control);
            }
        }
    }
}
