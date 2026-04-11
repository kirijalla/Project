using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_OOP
{
    public abstract class Worker : Entity
    {
        private int experienceYear;
        private int tasksCompleted;
        private bool isAvailable;

        public Worker(int id, string name,DateTime createdDate, int experienceYear, int tasksCompleted, bool isAvailable) : base(id, name, createdDate)
        {
            this.experienceYear = experienceYear;
            this.tasksCompleted = tasksCompleted;
            this.isAvailable = isAvailable;
        }
        public string ToFileString()
        {
            return $"{GetType().Name},{Getid()},{Getname()},{GetcreatedDate()},{experienceYear},{tasksCompleted},{isAvailable}";
        }

        public int GetexperienceYear() { return experienceYear; }
        public void SetexperienceYear(int experienceYear) { this.experienceYear = experienceYear; }
        public int GetTasksCompleted() { return tasksCompleted; }
        public void SetTasksCompleted(int tasksCompleted) { this.tasksCompleted = tasksCompleted; }
        public bool GetIsAvailable() { return isAvailable; }
        public void SetIsAvailable(bool isAvailable) { this.isAvailable = isAvailable; }

        public void AddTask() { tasksCompleted++; }
        public virtual double CalculatePerformance() 
        {
            return experienceYear * 1.5 + tasksCompleted * 2.0;
        }
       public abstract void PerformTask();
        public override void Display()
        {
            Console.WriteLine($"ID: {Getid()}\n" +
                $"Name: {Getname()}\n" +
                $"Experience: {experienceYear} years\n" +
                $"Tasks Completed: {tasksCompleted}\n" +
                $"Is available {isAvailable}\n" +
                $"Performance Score: {CalculatePerformance()}");
        }
    }
}
