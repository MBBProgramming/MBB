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
    internal class Hazard
    {
        public static Random rnd = new Random();
        public static Player player = new Player();
        public static Enemy enemy = new Enemy();
        string Names;
        public int playerWin=0;
        // variable to store bonus index for hazards
        int bNum;
        // variable to store player roll number
        int pNum;
        //varriable to store the hazard survive number
        int sNum;
        // list of hazards
        private string[] hazardNames = { "RockSlide", "Magma River", "Acid Rain" };
        //list of strengths
        public string[] bonus = { "Strength", "Smarts", "Speed" };
        //list of survive numbers
        private int[] surviveNum = new int[3]{ 5, 10, 15 };
        public void RunHazard()
        {
            randomHazard();
            surviveHazard();
        }
        private void randomHazard()
        {
            // create random hazard from a list of hazards
            int hazardIndex = rnd.Next(hazardNames.Length);
            int sIndex = surviveNum[rnd.Next(surviveNum.Length)];
            Names = hazardNames[hazardIndex];
            sNum = sIndex;
            Clear();
            Thread.Sleep(500);
            WriteLine("You Feel the world shake around you as a {0} occurs\n", hazardNames[hazardIndex]);
            Thread.Sleep(500);
            Player.ImportantTextOn();
            WriteLine($"You need to roll a {sNum} or greater to survive\n" +
                $"hit any key to roll your survivability rating...");
            Player.ImportantTextOff();
            Thread.Sleep(500);
            ReadLine();
        }
        private void surviveHazard()
        {
            // tell the user what they have scored and if the player has knowledge on this hazard or not
            int pRoll = rnd.Next(1, 20);
            pNum = pRoll;
            WriteLine($"You have Rolled a {pNum}!");
            bool failure = false;
            int bonusIndex = rnd.Next(bonus.Length);
            bNum = bonusIndex;
            if (bNum == Player.ClassNum)
            {
                // is knowledgable against the hazard
                pNum = pNum + 3;
                Player.ImportantTextOn();
                Thread.Sleep(500);
                WriteLine($"\nYour class {Player.Class} has knowledge against this hazard!\n" +
                    $"your Survivability rating has increased by 3!");
                Player.ImportantTextOff();
                WriteLine($"\nYour total survivability score is {pNum}");
                Thread.Sleep(500);
            }
            else 
            {
                // is not knowledgable
                Thread.Sleep(500);
                Player.ImportantTextOn();
                WriteLine($"\nyour class {Player.Class} has NO knowledge against this hazard!\n" +
                    $"your Survivability rating does not change!");
                Player.ImportantTextOff();
                WriteLine($"\nYour total survivability score is {pNum}");
                Thread.Sleep(500);
            }
            if (pNum >= sNum)
            {
                // The player survives the hazard and if the player has won the game or not
                Treasure treasure = new Treasure();
                playerWin++;
                Thread.Sleep(500);
                Player.ImportantTextOn();
                WriteLine("\nYou have survived the Hazard!" +
                    "\nYou proceed further towards the core!" +
                    $"\nhit any key to continue...");
                Player.ImportantTextOff();
                ReadLine();
                Clear();
                treasure.coreReached = true;
                if (treasure.coreReached == true && playerWin == 3)
                {
                    Clear();
                    treasure.win();
                }
                else
                {
                    Clear();
                    RunHazard();
                }
            }
            else
            {
                // the player doesnt not survive the hazard
                failure = true;
                Thread.Sleep(500);
                Player.ImportantTextOn();
                WriteLine("\nYou did not survive the Hazard!" +
                    "\nDo you wish to try again? Y/N");
                Player.ImportantTextOff();
                Thread.Sleep(500);
                while (failure == true)
                {
                    string userInput = ReadLine();
                    switch (userInput)
                    {
                        case "Y":
                        case "y":
                            WriteLine("\nYou try again to overcome the Hazard...");
                            Thread.Sleep(500);
                            failure = false;
                            Clear();
                            RunHazard();
                            break;
                        case "N":
                        case "n":
                            Clear();
                            WriteLine("\nYou Exited the Game...");
                            failure = false;
                            break;
                        default:
                            WriteLine("\nThat is not a valid input. Please input Y or N");
                            continue;
                    }
                }
            }
        }
    }
}
