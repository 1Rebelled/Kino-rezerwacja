using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaLibrary
{
    internal class Hall
    {
        internal Seat[] Seats;
        internal static byte hall_numbers;
        internal uint rows, cols;
        internal double PricePerMinute;
        internal byte number;

        internal Hall(uint seats_rows = 10, uint seats_cols = 14, double pricePerMinute = 0.33)
        {
            rows = seats_rows;
            cols = seats_cols;
            PricePerMinute = pricePerMinute;
            number = Hall.hall_numbers;
            Seats = new Seat[rows * cols];
            for (uint i = 0; i < rows * cols; i++)
                Seats[i] = new Seat(i, true);
        }

        override public string ToString()
        {
            var hall_type = this.GetType().Name;
            if (hall_type == "Sala") hall_type = "Normalny 2D";

            return $"Sala.{number} [{hall_type}]";
        }
    }
}
