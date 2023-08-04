using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer
{
    public class Movie
    {
        public string Title { get; set; }
        public string Descr { get; set; }
        public DateTime Duration { get; set; }
        public Image Poster { get; set; }
        public string AgeRestriction { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ViewCount { get; set; }
        public string Room { get; set; }
        public DateTime SessionTime { get; set; }
    }
}
