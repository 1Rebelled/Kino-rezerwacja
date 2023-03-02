using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaLibrary
{
    internal class _4DX : Hall
    {
        internal _4DX(uint seats_rows = 8, uint seats_cols = 4 * 8, double pricePerMinute = 0.67) : base(seats_rows, seats_cols, pricePerMinute) { }
    }
}
