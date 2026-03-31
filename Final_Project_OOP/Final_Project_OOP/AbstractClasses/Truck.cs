using Final_Project_OOP.CoreClasses;
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
            throw new NotImplementedException();
        }
        public override double CalculateEfficiency() 
        {
            return base.CalculateEfficiency() - fuelConsumption * 0.1;
        }

    }
}
