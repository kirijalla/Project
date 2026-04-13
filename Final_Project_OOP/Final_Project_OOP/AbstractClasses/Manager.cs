using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_OOP.AbstractClasses
{
    internal class Manager : Worker
    {
        private int teamSize;
        public Manager(int id, string name, DateTime createdDate, int experienceYear, int tasksCompleted, bool isAvailable, int teamSize) : base(id, name, createdDate,experienceYear,tasksCompleted,isAvailable)
        {
            this.teamSize = teamSize;
        }
        public Manager(Manager other) :base(other)
        {
            this.teamSize = other.teamSize;
        }
        public int GetteamSize() { return teamSize; }
        public void SetteamSize(int teamSize) { this.teamSize = teamSize; }
        public override void PerformTask()
        {
            Console.WriteLine($"Manager {Getname()} is assigning tasks to a team of {teamSize} workers.");
        }
        public Worker FindBestWorker(List<Worker> workers)
        {
            Worker best = workers[0];
            foreach (Worker worker in workers)
            {
                if (worker.CalculatePerformance() > best.CalculatePerformance())
                {
                    best = worker;
                }
            }
            return best;
        }
    }
}
