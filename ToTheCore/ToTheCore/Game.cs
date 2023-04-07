using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace ToTheCore
{
    internal class Game
    {
        public Game() 
        {
            Title = "To The Core";
            // I got this ASCII art from https://patorjk.com/
            WriteLine(@"
_________ _______   _________          _______    _______  _______  _______  _______ 
\__   __/(  ___  )  \__   __/|\     /|(  ____ \  (  ____ \(  ___  )(  ____ )(  ____ \
   ) (   | (   ) |     ) (   | )   ( || (    \/  | (    \/| (   ) || (    )|| (    \/
   | |   | |   | |     | |   | (___) || (__      | |      | |   | || (____)|| (__    
   | |   | |   | |     | |   |  ___  ||  __)     | |      | |   | ||     __)|  __)   
   | |   | |   | |     | |   | (   ) || (        | |      | |   | || (\ (   | (      
   | |   | (___) |     | |   | )   ( || (____/\  | (____/\| (___) || ) \ \__| (____/\
   )_(   (_______)     )_(   |/     \|(_______/  (_______/(_______)|/   \__/(_______/
                                                                                     
");
            Greeting();
            //create new player
            Player player= new Player();
            player.playerName();
            player.playerClass();
            player.Summary();
            //create the planet
            Planet planet= new Planet();
            Clear();
            planet.choosePlanet();
            planet.PlanetChosen();
            // run the correct planet order
            if (planet.planetNum == 1)
            { 
                planet.Orblorg();

            }
            else 
            {
                planet.Xerxes();
            }
        }
        //greet player and provide info on game
        void Greeting()
        {
            // Greet player to the game
            ForegroundColor = ConsoleColor.Green;
            Thread.Sleep(500);
            WriteLine($"Hello, Welcome to the game: TO THE CORE!\n");
            Player.ImportantTextOn();
            Thread.Sleep(500);
            WriteLine($"This is a text-based adventure game in which the Player will control an adventurer");
            Thread.Sleep(500);
            WriteLine($"who must travel to the core of the planet to obtain its treasure!\n" +
                $"Hit any key to begin...");
            Player.ImportantTextOff();
            WriteLine();
            ReadKey();
            Clear();
            
        }

    }
}
