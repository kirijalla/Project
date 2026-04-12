using System;
using System.Collections.Generic;
using Final_Project_OOP.Exceptions;
using Final_Project_OOP.DataStructures;
using System.Threading.Tasks;
using Final_Project_OOP.Interfaces;

namespace Final_Project_OOP.CoreClasses
{
    public class DeliverySystem : ISortable
    {

        private List<Warehouse> warehouses;
        private List<Package> allPackages;

        private List<Package> deliverPackages = new List<Package>();
        private CustomQueue<Package> remainingPackages = new CustomQueue<Package>();


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

        private void ProcessDeliveries()
        {
            foreach (Warehouse warehouse in warehouses)
            {
                Vehicle bestVehicle = null;

                Worker worker = warehouse.AssignWorker();

                if (worker == null)
                {
                    continue; // skip process, move to next warehouse
                }

                List<Package> bulkPackages = new List<Package>();
                double currentLoad = 0;

                foreach (Package package in deliverPackages)
                {
                      bestVehicle = warehouse.FindBestVehicle(package);

                    double maxCapacity = bestVehicle.GetmaxCapacity();

                    if (currentLoad + package.GetWeight() <= maxCapacity)
                    {
                        bulkPackages.Add(package);
                        currentLoad += package.GetWeight();
                        package.UpdateStatus("Delivered");
                    }
                }

                if (bulkPackages.Count > 0 && bestVehicle != null)
                {
                    bestVehicle.Deliver(bulkPackages);
                }

                foreach (Package package in deliverPackages)
                {
                    if (package.GetStatus() != "Delivered")
                    {
                        remainingPackages.Enqueue(package);
                    }
                }
            }
        }

        public void SimulateDay()
        {
            allPackages.Clear();
            deliverPackages.Clear();
            remainingPackages.Clear();

            foreach (Warehouse warehouse in warehouses)
            {
                List<Package> packages = warehouse.GetListPackages();

                foreach (Package package in packages)
                {
                    if (package.GetStatus() != "Delivered")
                    {
                        allPackages.Add(package);
                    }
                }
            }

            foreach (Package package in allPackages)
            {
                if (package.GetStatus() == "Assigned" && package.GetPriorityLevel() == 5)
                {
                    deliverPackages.Add(package);
                }
                else
                {
                    remainingPackages.Enqueue(package);
                }
            }

            ProcessDeliveries();

            while (!remainingPackages.IsEmpty())
            {
                Package validatePackage = remainingPackages.Dequeue();

                validatePackage.UpgradePriorityLevel();
                
                if (validatePackage.GetPriorityLevel() == 5)
                {
                    validatePackage.UpdateStatus("Assigned");
                }
                if (validatePackage.CalculatePriorityScore(validatePackage) > 20 && validatePackage.GetPriorityLevel() != 5)
                {
                    validatePackage.OverridePriorityLevel(5);
                    validatePackage.UpdateStatus("Assigned");
                }
            }

            Console.WriteLine($"Day has been simulated");
        }

        public void Sort()
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