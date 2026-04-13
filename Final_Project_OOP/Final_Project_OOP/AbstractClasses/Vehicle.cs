using Final_Project_OOP.CoreClasses;
using System;
using System.Collections.Generic;
using Final_Project_OOP.Exceptions;

namespace Final_Project_OOP
{
    public abstract class Vehicle : Entity
    {
        private double speed;
        private double maxCapacity;
        private double currentLoad;
        private bool isAvailable;

        public Vehicle(int id, string name, DateTime createdDate, double speed, double maxCapacity, double currentLoad, bool isAvailable) : base(id, name, createdDate)
        {
            this.speed = speed;
            this.maxCapacity = maxCapacity;
            this.currentLoad = currentLoad;
            this.isAvailable = isAvailable;
        }

        protected Vehicle(Vehicle other) :base(other)
        {
            this.speed = other.speed;
            this.maxCapacity = other.maxCapacity;
            this.currentLoad = other.currentLoad;
            this.isAvailable = other.isAvailable;
        }

        public string ToFileString()
        {
            return $"{GetType().Name},{Getid()},{Getname()},{GetcreatedDate()},{speed},{maxCapacity},{currentLoad},{isAvailable}";
        }

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
            if (capacity <= 0) { throw new InvalidDataException("invalid name"); }
            else { capacity = maxCapacity; }
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
