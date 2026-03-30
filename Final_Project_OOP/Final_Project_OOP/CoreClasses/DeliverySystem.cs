using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project_OOP.Exceptions;

namespace Final_Project_OOP.CoreClasses
{
    public class DeliverySystem
    {

        private List<Warehouse> warehouses;
        private List<Package> allPackages;

        public DeliverySystem()
        {
            this.warehouses = new List<Warehouse>();
            this.allPackages = new List<Package>();
        }

        public List<Package> GetPackages()
        {
            List<Package> allPackages = new List<Package>();
            foreach (Package package in allPackages)
            {
                allPackages.Add(package);
            }
            return allPackages;
        }

        public void AddWarehouse(Warehouse w)
        {
            for (int i = 0; i < warehouses.Count; i++)
            {
                if (warehouses[i].GetName() == w.GetName())
                {
                    throw new InvalidDataException("[ERROR] - A warehouse with that name has already been added");
                }
            }
            warehouses.Add(w);
        }
        public void AddPackage(Package p)
        {
            for (int i = 0; i < allPackages.Count; i++)
            {
                if (allPackages[i].GetId() == p.GetId())
                {
                    throw new InvalidDataException("[ERROR] - A package with that ID has already been added");
                }
            }
            allPackages.Add(p);
        }

        public Package SearchPackageById(int id)
        {
            for (int i = 0; i < allPackages.Count; i++)
            {
                if (allPackages[i].GetId() == id)
                {
                    return allPackages[i];
                }
            }
            return null;
        }

        public void ProcessDeliveries()
        {
            foreach (Package package in allPackages)
            {
                if (package.GetStatus() != "Assigned" && package.GetPriorityLevel() != 5)
                {
                    continue;
                }

                foreach (Warehouse warehouse in warehouses)
                {
                    Vehicle bestVehicle = warehouse.FindBestVehicle(package);
                    Worker availableWorker = warehouse.AssignWorker();

                    if (bestVehicle != null && availableWorker != null)
                    {
                        double currentLoad = bestVehicle.GetCurrentLoad();

                        if (currentLoad + package.GetWeight() <= bestVehicle.GetmaxCapacity())
                        {
                            List<Package> packagesToDeliver = new List<Package>();
                            packagesToDeliver.Add(package);

                            availableWorker.PerformTask();
                            bestVehicle.Deliver(packagesToDeliver);
                            package.UpdateStatus("Delivered");

                            break;
                        }
                    }
                }
            }
        }

        public void SimulateDay()
        {
            Console.WriteLine("Simulated day.");
            int count = 0;
            foreach(Package package in allPackages)
            {
                if (package.GetStatus() == "Assigned" && package.GetPriorityLevel() == 5)
                {
                    count++;
                }
            }
            Console.WriteLine($"Packages delivered: {count}");          
            ProcessDeliveries();
            foreach (Package package in allPackages)
            {
                if (package.GetStatus() == "Pending")
                {
                    package.UpdateStatus("Assigned");
                }
                package.UpdatePriorityLevel();
            }
        }

        public void SortPackages()
        {
            // Bubble Sort

            for (int i = 0; i < allPackages.Count; i++)
            {
                for (int j = 0; j < allPackages.Count - i - 1; j++)
                {
                    if (allPackages[j].GetId() > allPackages[j + 1].GetId())
                    {
                        Package temp = allPackages[j];
                        allPackages[j] = allPackages[j + 1];
                        allPackages[j + 1] = temp;
                    }
                }
            }

            // Selection Sort is also an option to sort the packages. It involves fewer swaps than bubble sort
            // but both algorithms have a time complexity of O(n^2) where as the list or array grows, so does the amount swaps are involved

            // Selection Sort involves selecting the lowest value of the list or array and placing it in its correct position. So instead of
            // comparing neighbours (j and j + 1) like in bubble sort, we're finding the lowest value and swap.

            /*
            for (int i = 0; i < allPackages.Count; i++)
            {
                int minPackage = i;

                for (int j = i + 1; j < allPackages.Count; j++)
                {
                    if (allPackages[j].GetId() < allPackages[minPackage].GetId())
                    {
                        minPackage = j;
                    }
                }
                Package temp = allPackages[minPackage];
                allPackages[minPackage] = allPackages[i];
                allPackages[i] = temp;
            }
            */
        }
    }
}