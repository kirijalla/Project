using Final_Project_OOP.CoreClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_OOP
{
    public abstract class Vehicle : Entity
    {
        private double speed;
        private double maxCapacity;
        private double currentLoad;
        private bool isAvailable;

        public double Getspeed() { return speed; }
        public void Setspeed(double speed) { this.speed = speed; }
        public double GetmaxCapacity() { return maxCapacity; }
        public void SetmaxCapacity(double maxCapacity) 
        {
            this.maxCapacity = maxCapacity;
        }
        public double GetCurrentLoad() { return currentLoad; }
        public void SetCurrentLoad(double currentLoad) { this.currentLoad = currentLoad; }
        public bool GetIsAvailable() { return isAvailable; }
        public void SetIsAvailable(bool isAvailable) { this.isAvailable = isAvailable; }

        public void SetCapacity(double capacity) {
            if (capacity > 0) { capacity = maxCapacity; }
            else {/*Mondongo*/ }
        }
        public double GetRemainingCapacity() 
        {
            return maxCapacity - currentLoad;
        }
        public virtual double CalculateEfficiency()
        {
            return speed / currentLoad;
        }
        public abstract void Deliver(List<Package> packages);

        public override void Display()
        {
            Console.WriteLine($"ID: {Getid()}\n" +
                $"Name: {Getname()}\n" +
                $"Max Capacity: {maxCapacity}\n" +
                $"Current Load: {currentLoad}\n" +
                $"Is available {isAvailable}\n" +
                $"Efficiency: {CalculateEfficiency()}");
        }
    }
}
