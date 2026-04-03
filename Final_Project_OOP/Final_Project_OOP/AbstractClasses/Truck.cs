using Final_Project_OOP.CoreClasses;
using Final_Project_OOP.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_OOP.AbstractClasses
{
    internal class Truck : Vehicle
    {
        private double fuelConsumption;
        public double GetfuelConsumption() { return fuelConsumption; }
        public void SetfuelConsumption(double fuelConsumption) { this.fuelConsumption = fuelConsumption; }
        public override void Deliver(List<Package> packages)
        {
            foreach (Package package in packages)
            {
                if (package.GetWeight() > 50)
                {
                    Console.WriteLine($"Truck delivering heavy package: {package.GetID()}, Weight: {package.GetWeight()}kg");
                    package.SetStatus("Delivered");
                }
                else { throw new InvalidPackageException("Invalid Weight for this vehicle"); }            
            }
        }
        public override double CalculateEfficiency() 
        {
            return base.CalculateEfficiency() - fuelConsumption * 0.1;
        }

    }
}
