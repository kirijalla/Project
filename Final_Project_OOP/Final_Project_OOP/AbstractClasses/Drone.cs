using Final_Project_OOP.CoreClasses;
using Final_Project_OOP.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_OOP.AbstractClasses
{
    internal class Drone : Vehicle
    {
        private double maxDistance;
        public double GetmaxDistance() { return maxDistance; }
        public void SetmaxDistance(double maxDistance) { this.maxDistance = maxDistance; }

        public override void Deliver(List<Package> packages)
        {
            foreach (Package package in packages)
            {
                if (package.GetWeight() < 10)
                {
                    Console.WriteLine($"Drone delivering light package: {package.GetID()}, Weight: {package.GetWeight()}kg");
                    package.SetStatus("Delivered");
                }
                else { throw new InvalidPackageException("Invalid Weight for this vehicle"); }
            }
        }

        public override double CalculateEfficiency()
        {
            return base.CalculateEfficiency() + maxDistance * 0.05;
        }
    }
}
