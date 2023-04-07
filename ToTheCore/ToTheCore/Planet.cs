using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ToTheCore
{
    internal class Planet
    {
        string planetChoice;
        public int planetNum;
        public string choosePlanet()
        {
            // let players choose the planet they wish to explore
            Thread.Sleep(500);
            Player.ImportantTextOn();
            WriteLine("Choose the planet you wish to explore\n" +
                "Some Planets contain more Monsters, whereas some contain more Hazards!\n");
            Player.ImportantTextOff();
            Thread.Sleep(500);
            WriteLine("1. Planet ORBLORG: ORBLORG is home to many monsters but not so many hazards\n" +
                "2. Planet XERXES: XERXES has many hazards but very few monsters");
            string userInput = ReadLine();
            switch (userInput)
            {
                case "1":
                    planetChoice = "ORBLORG";
                    planetNum = 1;
                    break;
                case "2":
                    planetChoice = "XERXES";
                    planetNum = 2;
                    break;
                default:
                    WriteLine("\nThis is not a vailid number...");
                    Thread.Sleep(1000);
                    return choosePlanet();
            }
            return planetChoice;
        }
        public void PlanetChosen()
        {
            // reiterate to the player which planet they chose
            WriteLine();
            Thread.Sleep(500);
            Player.ImportantTextOn();
            WriteLine($"You chose planet: {planetChoice}" +
                $"\nhit any key to continue...");
            Player.ImportantTextOff();
            ReadLine();
        }
        public void Xerxes()
        {
            // run the Xerxes planet
            Hazard hazard = new Hazard();
            hazard.RunHazard();
        }
        public void Orblorg()
        {
            // run the Orblorg planet
            Enemy enemy = new Enemy();
            enemy.RunEnemyEncounter();
        }

    }
}
