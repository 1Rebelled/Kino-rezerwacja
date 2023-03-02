using System;
using CinemaLibrary;

namespace CinemaNet5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kino Gloria");


            
            string date = "31/12/2012 23:59:59";


            Cinema cinema = new Cinema(3, 2, 1, 1);
            cinema.DisplayHarmonogram();


            var bought_tickets = cinema.BuyTickets();

        }
    }
}
