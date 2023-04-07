
using System.Runtime.CompilerServices;

namespace Adopt_an_Insect
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Adopt an Insect Agency!");
            Console.WriteLine(" ");
            
            //Insect #1
            Insect pete= new Insect();
            pete.Name = "pete";
            pete.Sname = "Mantis";
            pete.Numlegs = 6;
            pete.Diet = "other insects";
            pete.Age = "4 months";
            pete.Colour = "Green";
            pete.Size = "small";
            pete.Features = "Chirping";
            pete.Flyable= true;
            pete.Adoptable = true;
            Console.WriteLine("The insects name is " + pete.Name + ". He loves to eat "+ pete.Diet);
            pete.Adopted();
            pete.Eat();
            Console.WriteLine("");
            Console.WriteLine("Press any Key to Exit...");
            Console.ReadKey();

        }
    }
}
