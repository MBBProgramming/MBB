using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ToTheCore
{
    internal class Treasure
    {
        public bool coreReached = false;
        // tell the player that they have won the game 
        public void win()
        {
            WriteLine("You have Reached the CORE! and have obtained the treasure!");

        }
    }
}
