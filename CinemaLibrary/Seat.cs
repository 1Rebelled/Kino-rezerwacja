using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaLibrary
{
    internal class Seat
    {
        internal bool Reserved { get; set; }
        internal uint NR { get; set; }
        internal Seat(uint _number, bool _reserved = true)
        {
            Reserved = _reserved;
            NR = _number;
        }
    }
}
