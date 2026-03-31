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
        public string GetlicenseType() { return licenseType; }
        public void SetlicenseType(string licenseType) { this.licenseType = licenseType; }
        public override void PerformTask()
        {
            throw new NotImplementedException();
        }
    }
}
