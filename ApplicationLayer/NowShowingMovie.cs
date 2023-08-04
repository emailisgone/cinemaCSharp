using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer
{
    public class NowShowingMovie : Movie
    {
        public string Room { get; set; }
        public DateTime SessionTime { get; set; }
    }
}
