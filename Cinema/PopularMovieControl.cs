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
    public partial class PopularMovieControl : UserControl
    {
        public PopularMovieControl()
        {
            InitializeComponent();
            pnlMovies.AutoScroll = true;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            var lst = DataTools.PopularMovies((int)numMovies.Value);
            if (lst == null) return;
            pnlMovies.Controls.Clear();
            for (int i = 0; i < lst.Count; i++)
            {
                var control = new OneMovieControl(ShowType.Popular, lst[i].Room, lst[i].SessionTime);
                control.Location = new Point(0, control.Height * i);
                control.lblTitle.Text = lst[i].Title;
                control.lblDescription.Text = lst[i].Descr;
                control.lblDuration.Text = lst[i].Duration.ToShortTimeString();
                control.lblAgeRestriction.Text = lst[i].AgeRestriction.ToString();
                control.picPoster.Image = lst[i].Poster;
                control.lblReleaseDate.Text = lst[i].ReleaseDate.ToShortDateString();
                control.lblViews.Text = lst[i].ViewCount.ToString();
                control.btnTicket.Visible = false;
                pnlMovies.Controls.Add(control);
            }
        }
    }
}
