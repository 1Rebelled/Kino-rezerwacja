using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaLibrary
{
    public class Cinema : ICustomerHandler, IPayTerminal
    {
        Hall[] halls;
        Seans[] Seanses { get; }

        public Cinema(int _normal, int _imax = 0, int _4dx = 0, int _sceenX = 0)
        {
            halls = new Hall[_normal + _imax + _4dx + _sceenX];

            for (int i = 0; i < halls.Length; i++)
            {
                ++Hall.hall_numbers;
                if (i >= _normal + _imax + _4dx) halls[i] = new ScreenX();
                else if (i >= _normal + _imax) halls[i] = new _4DX();
                else if (i >= _normal) halls[i] = new Imax();
                else if (i < _normal) halls[i] = new Hall();
               
            }


            string date = "31/12/2012 23:59:59";
            Movie DragonBall = new Movie(EGenres.Animation, "Dragon Ball Super", 12, 99);
            Movie EvilDead = new Movie(EGenres.Horror, "Evil Dead", 18, 92);
            Movie DontLookUp = new Movie(EGenres.Comedy, "Don't Look Up", 8, 145);
            Movie Venom = new Movie(EGenres.Fantasy, "Venom", 12, 112);
            Movie DontBreathe2 = new Movie(EGenres.Thriller, "Don't Breathe 2", 18, 98);

            Seanses = new Seans[7];
            Seanses[0] = new Seans(ref DragonBall, halls[5], DateTime.Parse("11 / 06 / 2022 20:30:00"));
            Seanses[1] = new Seans(ref EvilDead, halls[0], DateTime.Parse("08 / 03 / 2013 21:30:30"));
            Seanses[2] = new Seans(ref DontLookUp, halls[3], DateTime.Parse("10 / 12 / 2022 09:55:00"));
            Seanses[3] = new Seans(ref DontLookUp, halls[1], DateTime.Parse("10 / 12 / 2022 13:00:00"));
            Seanses[4] = new Seans(ref DragonBall, halls[0], DateTime.Parse("12 / 06 / 2022 08:10:00"));
            Seanses[5] = new Seans(ref Venom, halls[4], DateTime.Parse("01 / 10 / 2018 18:45:00"));
            Seanses[6] = new Seans(ref DontBreathe2, halls[4], DateTime.Parse("12 / 07 / 2021 16:55:00"));
        }

        public void DisplayHarmonogram()
        {
            foreach (var seans in Seanses)
                Console.WriteLine(seans.ToString());
        }

        public ArraySegment<Ticket>? BuyTickets()
        {
            try
            {
                var selectedseans = SelectSeans();
                Console.WriteLine("Ile miejsc chcesz zarezerwowac: ");
                uint reservation_number = Convert.ToUInt32(Console.ReadLine());
                double price = selectedseans.hall.PricePerMinute * selectedseans.movie.Duration * reservation_number;
                Console.WriteLine($"Cena to {price}");


                if (selectedseans.IsEnoughSeats(reservation_number) && InputPersonalData() && Transaction() && Pay(price))
                {
                    var reserved_tickets = selectedseans.ReserveSeats(reservation_number);

                    Console.WriteLine("Twoj bilet: ");
                    foreach (var _ticket in reserved_tickets)
                        Console.WriteLine(_ticket.ToString());

                    return reserved_tickets;
                }
                else throw (new WrongDataProvided("Pozostało za mało miejsc lub podane dane były nieprawidłowe."));
            }
            catch (CinemaErrors e)
            {
                Console.WriteLine(e.ToString()); ;
                return null;
            }
        }

        public bool Pay(double amount)
        {
            Console.WriteLine($"Czy na pewno chcesz zapłacić? {amount}?");
            Console.WriteLine($"Nacisnij \"t\" dla tak, \"n\" dla nie");
            string answer = Console.ReadLine();
            if (answer == "t") return true;
            else return false;
        }

        Seans SelectSeans()
        {
            Console.WriteLine("\nNa jaki chcesz isc seans? :");
            string _title = Console.ReadLine();

            var xd = (from item in Seanses
                      where item.movie.Name == _title
                      select item);

            foreach (var x in xd)
                Console.WriteLine($"{x.hall.ToString()}  -  {x.date}");

            if (xd.Count() == 0)
                throw new ServiceImpossible("\nNie znaleziono filmu!");

            if (xd.Count() > 1)
                return SelectDate(xd);

            return xd.First();
        }

        Seans SelectDate(IEnumerable<Seans> titles)
        {
            Console.WriteLine("Data w formacie [31/12/2012 23:59:59]: ");
            DateTime datetime;

            DateTime.TryParse(Console.ReadLine(), out datetime);

            var xd = (from item in Seanses
                      where item.date == datetime
                      select item);

            if (xd.Count() == 0) throw new WrongDate($"\nSeans w wybranym dniu = {datetime}, nie zostal znaleziony!");

            return xd.First();
        }

        
        public bool InputPersonalData()
        {
            Console.WriteLine("\nPodaj niezbedne dane osobowe: ");
            Console.WriteLine("Imie: ");
            Console.ReadLine();
            Console.WriteLine("Nazwisko: ");
            Console.ReadLine();
            Console.WriteLine("Wiek: ");
            Console.ReadLine();
            return true;
        }

        
        public bool Transaction()
        {
            Console.WriteLine("\nPodaj niezbedne dane do wykonania transakcji: ");
            Console.WriteLine("Numer karty: ");
            Console.ReadLine();
            Console.WriteLine("Data waznosci: ");
            Console.ReadLine();
            Console.WriteLine("CVV/CID/CVC: ");
            Console.ReadLine();
            return true;
        }
    }
}
