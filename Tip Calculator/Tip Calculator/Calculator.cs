using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tip_Calculator
{
    internal class Calculator
    {
        public void Calculate()
        {
            // ask user for bill amount
            // convert answer to double
            // ask user for tip amount show them 3 different options
            // figure out users poercentage from choice
            // summary of bill + tip
           
            double billAmount = GetBillAmount();
            double percent = GetBillPercent();
            
            double tipAmount = billAmount * percent;
            double finalBill = billAmount + tipAmount;
            Console.WriteLine($"Your final amount is: {finalBill:C}");
            if ( percent >= .2 ) 
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Thank you for being a good tipper");
            }
            else if (percent > .1)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("You are an ok tipper");                
            }
            else 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You are not a good tipper");
            }
            Console.ResetColor();
            Console.WriteLine("Thank you for using our Tip Calculator!");
        }
        public double GetBillAmount()
        {

            double billAmount = 0;
            Console.WriteLine("Welcome to the Tip Calculator what is your Bill?");
            string userInput = Console.ReadLine();
           
            try
            {
                billAmount = Convert.ToDouble(userInput);
            }
            catch (Exception)
            {

                Console.WriteLine("Thats not a valid number");
            }
            if (billAmount > 0)
            {
                return billAmount;
            }
            else  
            {
                return GetBillAmount();
            }
            
        }
        public double GetBillPercent()
        {
            Console.WriteLine("Choose a Tip Percentage:");
            Console.WriteLine("1. 10%");
            Console.WriteLine("2. 15%");
            Console.WriteLine("3. 20%");
            Console.WriteLine("4. Enter custom Percentage");
            string userInput = Console.ReadLine();
            double percent = 0;
            switch (userInput)
            {
                case "1":
                    percent = .1;
                    break;
                case "2":
                    percent = .15;
                    break;
                case "3":
                    percent = .2;
                    break;
                case "4":
                    percent = GetCustomTip();
                    break;
                default:
                    return GetBillPercent();
                    break;
            }
            return percent;
        }
        public double GetCustomTip()
        {
            double percent = 0;
            Console.WriteLine("Please enter a custom tip between 1 and 100?");
            string userInput = Console.ReadLine();

            try
            {
                percent = Convert.ToDouble(userInput);
            }
            catch (Exception)
            {

                Console.WriteLine("Thats not a valid number");
            }
            if (percent > 0 && percent <= 100)
            {
                percent = percent/ 100;
                return percent;
            }
            else
            {
                return GetCustomTip();
            }
        }
    }
}
