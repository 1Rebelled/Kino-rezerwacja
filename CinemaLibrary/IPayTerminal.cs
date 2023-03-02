using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaLibrary
{
    internal interface IPayTerminal
    {
        bool InputPersonalData();
        bool Transaction();
        bool Pay(double amount);
    }
}
