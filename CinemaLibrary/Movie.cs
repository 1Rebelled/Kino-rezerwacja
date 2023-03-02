using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaLibrary
{
    public enum EGenres
    {
        Horror,
        Fantasy,
        Animation,
        SciFi,
        Dramat,
        Thriller,
        Comedy
    }

    public class Movie
    {
        public EGenres Genre { get; set; }
        public string Name { get; set; }
        public byte Age { get; set; }
        public byte Duration { get; set; }

        public Movie(EGenres genre, string name, byte age, byte duration)
        {
            Genre = genre;
            Name = name;
            Age = age;
            Duration = duration;
        }

        public override string ToString()
        {
            string genre = Enum.GetName(typeof(EGenres), this.Genre).ToString();

            return $"\"{Name}\", {Genre}, +{Age}, {Duration}min";
        }
    }
}
