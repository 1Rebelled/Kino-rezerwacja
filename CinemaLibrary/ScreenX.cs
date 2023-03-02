using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaLibrary
{
    internal class ScreenX : Hall
    {
        internal ScreenX(uint seats_rows = 14, uint seats_cols = 2 * 18, double pricePerMinute = 0.7) : base(seats_rows, seats_cols, pricePerMinute) { }
    }
}
