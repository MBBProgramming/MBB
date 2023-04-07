using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adopt_an_Insect
{
    internal class Insect
    {
        public string Name { get; set; }
        public string Sname { get; set; }
        public int Numlegs { get; set; }
        public string Diet { get; set; }
        public string Age { get; set; }
        public string Colour { get; set; }
        public string Size { get; set; }
        public string Features { get; set; }
        public bool Flyable { get; set; }
        public bool Adoptable { get; set; }
        
        public void Feature()
        {
            Console.WriteLine(Name + ": " + Features);
        }
        public void Eat()
        {
            Console.WriteLine(Name + " is currently eating.");
        }
        public void Fly()
        {
            Flyable = true;
            Console.WriteLine(Name + " can fly!");
        }
        public void Adopted()
        {
            if (Adoptable == false)
            {

                Console.WriteLine($"{Name} cannot be Adopted");

            }
            if (Adoptable == true)
            {

                Console.WriteLine($"{Name} can be adopted");

            }
        }

    }
}

