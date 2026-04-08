using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_OOP.AbstractClasses
{
    internal class Driver : Worker
    {
        private string licenseType;
        public Driver(int id, string name, DateTime createdDate, int experienceYear, int tasksCompleted, bool isAvailable, string licenseType) : base(id, name, createdDate, experienceYear, tasksCompleted, isAvailable)
        {
            this.licenseType = licenseType;
        }
        public string GetlicenseType() { return licenseType; }
        public void SetlicenseType(string licenseType) { this.licenseType = licenseType; }
        public override void PerformTask()
        {
            Console.WriteLine($"Driver {Getname()} is driving deliveries with license type: {licenseType}");
        }
    }
}
