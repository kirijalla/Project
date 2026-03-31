using Final_Project_OOP.CoreClasses;
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
        public bool GetisElectric() { return isElectric; }
        public void SetisElectric(bool isElectric) { this.isElectric = isElectric; }
        public override void Deliver(List<Package> packages)
        {
            throw new NotImplementedException();
        }

    }
}
