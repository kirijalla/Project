using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project_OOP.CoreClasses;

namespace Final_Project_OOP
{
    public class Snapshot
    {
        private List<Warehouse> warehouses;
        private List<Package> packages;
        public Snapshot(List<Warehouse> warehouses, List<Package> packages)
        {
            this.warehouses = new List<Warehouse>();
            foreach (Warehouse warehouse in warehouses)
            {
                this.warehouses.Add(new Warehouse(warehouse));
            }

            this.packages = new List<Package>();
            foreach (Package package in packages)
            {
                this.packages.Add(new Package(package));
            }
        }

        public List<Warehouse> GetWarehouses()
        {
            return warehouses;
        }

        public List<Package> GetPackages()
        {
            return packages;
        }
    }
}
