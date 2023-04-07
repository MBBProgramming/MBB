using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Console;

namespace ToTheCore
{
     public class Player
    {
        public string Name;
        public static string Class;
        public static int ClassNum;
        string bonus;
        public void playerName()
        {
            // ask Character for their name and abilities
            ImportantTextOn();
            Thread.Sleep(500);
            WriteLine("First you need to create your Adventurer...\n");
            ImportantTextOff();
            Thread.Sleep(500);
            WriteLine("What is your Adventurer's name: ");
            Name = ReadLine();
        }
        public string playerClass()
        {
            // ask the player what class they want and tell player how class affects the game
            WriteLine();
            Thread.Sleep(500);
            ImportantTextOn();
            WriteLine($"Please choose a class for {Name}\n" +
                    "Your class will give you a bonus in certain scenarios you will come across\n" +
                    "when travelling to the core\n");
            ImportantTextOff();
            Thread.Sleep(500);
            WriteLine("1. Fighter: Fighters have a +3 bonus to Strength rolls\n");
            Thread.Sleep(500);
            WriteLine("2. Scholar: Scholars have a +3 bonus to Smart rolls\n");
            Thread.Sleep(500);
            WriteLine("3. Rogue: Rogues have a +3 bonus to Speed Rolls\n");
            string userInput = ReadLine();
            switch (userInput)
            {
                case "1":
                    Class = "Fighter";
                    ClassNum= 0;
                    bonus = "Strength";
                    break;
                case "2":
                    Class = "Scholar";
                    ClassNum= 1;
                    bonus = "Smarts";
                    break;
                case "3":
                    Class = "Rogue";
                    ClassNum= 2;
                    bonus = "Speed";
                    break;
                default:
                    return playerClass();

            }
            return Class;
        }
        public void Summary()
        { 
           //provides a summary of the players character
            Clear();
            Thread.Sleep(500);
            WriteLine($"Summary:\n\n" +
                $"Adventure's Name: {Name}\n\n" +
                $"Adventure's Class: {Class}\n\n" +
                $"Your Character has a +3 bonus to: {bonus}\n\n" +
                $"Hit any key to continue");
            ReadKey();
        }
        // create a quick way to express important text over less important
        public static void ImportantTextOn()
        {
            ForegroundColor = ConsoleColor.Blue;
        }
        public static void ImportantTextOff()
        {
            ForegroundColor = ConsoleColor.Green;
        }
    }
    
}
