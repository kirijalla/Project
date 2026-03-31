using Final_Project_OOP.CoreClasses;
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
            throw new NotImplementedException();
        }

        public override double CalculateEfficiency()
        {
            return base.CalculateEfficiency() + maxDistance * 0.05;
        }
    }
}
