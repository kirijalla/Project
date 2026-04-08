using Final_Project_OOP.CoreClasses;
using Final_Project_OOP.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_OOP.AbstractClasses
{
    internal class Van : Vehicle
    {
        private bool isElectric;

        public Van(int id, string name, DateTime createdDate, double speed, double maxCapacity, double currentLoad, bool isAvailable, bool isElectric) : base(id, name, createdDate, speed, maxCapacity, currentLoad, isAvailable)
        { 
            this.isElectric = isElectric;
        }
        public bool GetisElectric() { return isElectric; }
        public void SetisElectric(bool isElectric) { this.isElectric = isElectric; }
        public override void Deliver(List<Package> packages)
        {
            foreach (Package package in packages)
            {
                if (package.GetWeight() >= 10 && package.GetWeight() <= 50)
                {
                    Console.WriteLine($"Van delivering medium package: {package.GetID()}, Weight: {package.GetWeight()}kg");
                    package.SetStatus("Delivered");
                }
                else{ throw new InvalidPackageException("Invalid Weight for this vehicle"); }
            }
        }

    }
}
