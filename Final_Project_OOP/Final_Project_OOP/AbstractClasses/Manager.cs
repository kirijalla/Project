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
        public int GetteamSize() { return teamSize; }
        public void SetteamSize(int teamSize) { this.teamSize = teamSize; }
        public override void PerformTask()
        {
            throw new NotImplementedException();
        }
        public Worker FindBestWorker(List<Worker> workers)
        { throw new NotImplementedException(); }
    }
}
