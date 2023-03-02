using System;

namespace CinemaLibrary
{
    internal class CinemaErrors : Exception
    {
        internal CinemaErrors(string message) : base(message) { }
    }
    internal class WrongDataProvided : CinemaErrors
    {
        public WrongDataProvided(string message) : base(message) { }
    }

    internal class ServiceImpossible : CinemaErrors
    {
        internal ServiceImpossible(string message) : base(message) { }
    }

    internal class WrongDate : CinemaErrors
    {
        internal WrongDate(string message) : base(message) { }
    }
}