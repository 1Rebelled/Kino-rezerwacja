using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaLibrary
{
    public class Ticket
    {
        public string Title { get; set; }
        public uint Hall_number { get; set; }
        public uint Number { get; set; }
        public DateTime SeansDate { get; set; }


        internal Ticket(Seans seans, uint seat_or_ticket__number)
        {
            Title = seans.movie.Name;
            Hall_number = seans.hall.number;
            SeansDate = seans.date;
            Number = seat_or_ticket__number;
        }

        internal Ticket(Ticket ticket)
        {
            Title = ticket.Title;
            Hall_number = ticket.Hall_number;
            SeansDate = ticket.SeansDate;
            Number = ticket.Number;
        }

        public override string ToString() => $"Seans: {Title}, Sala.{Hall_number}, {SeansDate.ToString()},  Bilet.{Number}";
    }
}
