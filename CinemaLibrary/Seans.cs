using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaLibrary
{
    internal class Seans
    {
        internal Movie movie;
        internal DateTime date;
        internal Hall hall;
        public Ticket[] tickets;
        internal Seat[] seats;

        internal uint number_of_seats;
        internal uint reserved_seats;

        public Seans(ref Movie _movie, Hall _hall, DateTime _date)
        {
            number_of_seats = (uint)_hall.Seats.Length;
            reserved_seats = 0;

            movie = _movie;
            date = _date;
            hall = _hall;
            seats = _hall.Seats; 

            tickets = new Ticket[number_of_seats];
        }

        internal bool IsEnoughSeats(uint reservation_number)
        {
            return reservation_number <= number_of_seats - reserved_seats;
        }

        public ArraySegment<Ticket>? ReserveSeats(uint reservation_number)
        {
            try
            {
                if (reserved_seats + reservation_number <= number_of_seats)
                {
                    for (int i = 0; i < reservation_number; i++)
                    {
                        tickets[reserved_seats] = new Ticket(this, reserved_seats);
                        seats[reserved_seats].Reserved = true;
                        ++reserved_seats;
                    }
                }
                else
                {
                    throw new ServiceImpossible($"Tylko {number_of_seats - reserved_seats} dostepne miejsca.");
                }
            }
            catch (ServiceImpossible e)
            {
                Console.WriteLine(e.ToString());

                return null;
            }

            var reserved = new ArraySegment<Ticket>(tickets, (int)(reserved_seats - reservation_number), (int)reserved_seats);

            return reserved;
        }

        public override string ToString() => $"Seans: {movie.Name}, {hall.ToString()}, {date.ToString()}  --> Cena to {movie.Duration*hall.PricePerMinute}";
    }
}
