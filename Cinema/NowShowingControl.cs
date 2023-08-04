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
    public partial class NowShowingControl : UserControl
    {
        public NowShowingControl()
        {
            InitializeComponent();
            pnlMovies.AutoScroll = true;
            ShowMovies();
        }

        private void ShowMovies()
        {
            var lst = DataTools.NowShowing();
            if (lst == null) return;
            //Creating control for each movie
            for(int i=0;i<lst.Count;i++)
            {
                var control = new OneMovieControl(ShowType.NowShowing, lst[i].Room, lst[i].SessionTime);
                control.Location = new Point(0, control.Height * i);
                control.lblTitle.Text = lst[i].Title;
                control.lblDescription.Text = lst[i].Descr;
                control.lblDuration.Text = lst[i].Duration.ToShortTimeString();
                control.lblAgeRestriction.Text = lst[i].AgeRestriction.ToString();
                control.picPoster.Image = lst[i].Poster;
                pnlMovies.Controls.Add(control);
            }
        }
    }
}
