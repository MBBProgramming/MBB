using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Net.Mime.MediaTypeNames;


namespace ToTheCore
{
    public class Enemy
    {
        public static Random rnd = new Random();
        public static Player player = new Player();
        string Name;
        int bNum;
        int wNum;
        int pNum;
        int playerTotal;
        int eNum;
        int playerWin=0;
        // create list of enemies to face
        private string[] enemyNames = { "Great Vort", "Deadly CatBear", "FrogLord" };
        // list of bonuses
        public string[] bonus = { "Strength", "Smarts", "Speed" };
        // list of weaknesses
        public string[] weak = { "Strength", "Smarts", "Speed" };

        public void RunEnemyEncounter()
        {
            // more organized running of encounters
            randomEnemy();
            randomAbility();
            playerAttack();
            fight();
        }
        public void randomEnemy() 
        {
            //create random index for the names
            int enemyIndex = rnd.Next(enemyNames.Length);
            Name = enemyNames[enemyIndex];
            Clear();
            Thread.Sleep(500);
            WriteLine($"You encounter a {Name}" +
                $"\nhit any key to continue...");
            ReadLine();
        }
        public void randomAbility()
        {
            //create lists and random indexs of strengths and weaknesses
            int bonusIndex = rnd.Next(bonus.Length);
            int weakIndex = rnd.Next(weak.Length);
            bNum= bonusIndex;
            wNum = weakIndex;
            // dont want the bonus to be the same as the weakness
            while (bNum == wNum)
            {
                weakIndex = rnd.Next(weak.Length);
            }
            Thread.Sleep(500);
            WriteLine("\nThis creature is strong against {0} attacks and it is weak to {1} attacks.\n", bonus[bonusIndex], weak[weakIndex]);
        }
        public void playerAttack()
        {
            // tell the player if they are weak or strong against this enemy
            Thread.Sleep(500);
            Player.ImportantTextOn();
            if (bNum == Player.ClassNum)
            {
                WriteLine($"Your class, {Player.Class}, is vunerable to this enemy! You get a -3 bonus to your roll!\n");
            }
            else
            {
                WriteLine($"Your class, {Player.Class}, is not Vunerable against this Enemy.\n");
            }
            if (wNum == Player.ClassNum)
            {
                WriteLine($"Your class, {Player.Class}, is strong against this enemy! You gain a +3 bonus to your roll!\n");
            }
            else 
            {
                WriteLine($"Your class, {Player.Class}, is not strong against this Enemy.\n");
            }
            WriteLine("Hit any key to roll the scores...");
            ReadLine();
            Player.ImportantTextOff();
        }
        public void fight()
        {
            // where the fight happens and if the player will win, lose or tie against the monster
            bool failure = false;
            int enemyRoll = rnd.Next(1, 20);
            int playerRoll = rnd.Next(1, 20);
            eNum = enemyRoll;
            pNum = playerRoll;
            Thread.Sleep(500);
            WriteLine($"The enemy has rolled a {eNum}\n");
            Thread.Sleep(500);
            WriteLine($"You rolled a {pNum}");
            //add bonuses or deductions
            Thread.Sleep(500);
            Player.ImportantTextOn();
            if (bNum == Player.ClassNum && wNum != Player.ClassNum)
            {
                WriteLine("\nYou are Vunerable to this enemy. 3 points will be deducted from your roll!");
                WriteLine("\nYou are not Strong against this ememy NO points will be added.");
                playerTotal = pNum - 3;
            }
            else if (bNum != Player.ClassNum && wNum == Player.ClassNum)
            {
                WriteLine("\nYou are Strong against this enemy. 3 points will be added to your roll!");
                WriteLine("\nYou are not Strong against this ememy NO points will be added.");
                playerTotal = pNum + 3;
            }
            if (playerTotal <= 0)
            { 
             playerTotal= 0;
            }
            Player.ImportantTextOff();
            Thread.Sleep(500);
            WriteLine($"\nYour total is {playerTotal}");
            // Win or lose
            Thread.Sleep(500);
            if (eNum > playerTotal)
            {
                failure = true;
                Player.ImportantTextOn();
                WriteLine($"\nYou lost against the {Name}" +
                    $"\nDo you wish to fight again? Y/N");
                Player.ImportantTextOff();
                while (failure == true)
                {
                    string userInput = ReadLine();
                    switch (userInput)
                    {
                        case "Y": case "y":
                            WriteLine("\nYou continue your fight...");
                            Thread.Sleep(500);
                            failure= false;
                            Clear();
                            fight();
                            break;
                        case "N": case "n":
                            Clear();
                            Thread.Sleep(500);
                            WriteLine("\nYou Exited the Game...");
                            failure= false;
                            break;
                        default:
                            WriteLine("\nThat is not a valid input. Please input Y or N");
                            continue;
                            
                    }
                }
            }
            else if (eNum == playerTotal)
            {
                // if the player and the enemy tie in score
                Player.ImportantTextOn();
                WriteLine("\nYou both tied! Hit enter to roll again...");
                Player.ImportantTextOff();
                ReadKey();
                Clear();
                fight();
            }
            else
            {
               // if the player defeats the monster
               // determine if the player has won the game or not
                Treasure treasure = new Treasure();
                playerWin++;
                Player.ImportantTextOn();
                WriteLine($"\nYOU defeated the {Name}! You proceed further towards the core!" +
                    $"\nHit Enter to Continue...");
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
                    RunEnemyEncounter(); 
                }
            }
        }
    }
}
