using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaLibrary
{
    internal class Imax : Hall
    {
        internal Imax(uint seats_rows = 15, uint seats_cols = 35, double pricePerMinute = 0.5) : base(seats_rows, seats_cols, pricePerMinute) { }
    }
}
