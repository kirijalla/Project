using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_OOP.AbstractClasses
{
    internal class Loader : Worker
    {
        private double maxLiftWeight;
        public override void PerformTask()
        {
            Console.WriteLine($"Loader {Getname()}'s max lift is {maxLiftWeight} for loading/unloading packages.");
        }
    }
}
