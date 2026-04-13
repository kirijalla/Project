using Final_Project_OOP.DataStructures;
using Final_Project_OOP.Exceptions;
using Final_Project_OOP.FileHandling;
using Final_Project_OOP.Interfaces;
using System;
using System.Collections.Generic;

namespace Final_Project_OOP.CoreClasses
{
    public class DeliverySystem : ISortable
    {

        private List<Warehouse> warehouses;
        private List<Package> allPackages;

        private List<Package> deliverPackages = new List<Package>();
        private CustomQueue<Package> remainingPackages = new CustomQueue<Package>();

        private CustomStack<Snapshot> undoStack = new CustomStack<Snapshot>(10);


        public DeliverySystem()
        {
            this.warehouses = new List<Warehouse>();
            this.allPackages = new List<Package>();
        }


        public List<Package> GetPackages()
        {
            List<Package> copy = new List<Package>();

            foreach (Package package in allPackages)
            {
                copy.Add(package);
            }

            return copy;
        }
        public void AddWarehouse(Warehouse w)
        {
            SaveState();
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
            SaveState();
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

        public void AssignDeliveries()
        {
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
        }

        private void ProcessDeliveries()
        {
            foreach (Warehouse warehouse in warehouses)
            {
                Worker worker = warehouse.AssignWorker();

                if (worker == null)
                {
                    continue;
                }

                List<Package> warehousePackages = warehouse.GetListPackages();
                List<Package> bulkPackages = new List<Package>();
                Vehicle bestVehicle = null;
                double currentLoad = 0;

                foreach (Package package in deliverPackages)
                {
                    if (!warehousePackages.Contains(package))
                    {
                        continue;
                    }

                    if (package.GetStatus() == "Delivered")
                    {
                        continue;
                    }

                    if (bestVehicle == null)
                    {
                        bestVehicle = warehouse.FindBestVehicle(package);

                        if (bestVehicle == null)
                        {
                            continue;
                        }
                    }

                    double maxCapacity = bestVehicle.GetmaxCapacity();

                    if (currentLoad + package.GetWeight() <= maxCapacity)
                    {
                        bulkPackages.Add(package);
                        currentLoad += package.GetWeight();
                    }
                }

                if (bulkPackages.Count > 0 && bestVehicle != null)
                {
                    bestVehicle.Deliver(bulkPackages);

                    foreach (Package package in bulkPackages)
                    {
                        package.UpdateStatus("Delivered");
                    }
                }
            }

            foreach (Package package in deliverPackages)
            {
                if (package.GetStatus() != "Delivered")
                {
                    remainingPackages.Enqueue(package);
                }
            }
        }

        public void SimulateDay()
        {
            Console.Clear();
            Console.WriteLine("Simulating Day.");
            SaveState();

            allPackages.Clear();
            deliverPackages.Clear();
            remainingPackages.Clear();

                AssignDeliveries();

            ProcessDeliveries();

            while (!remainingPackages.IsEmpty())
            {
                Package package = remainingPackages.Dequeue();

                package.UpgradePriorityLevel();

                if (package.GetPriorityLevel() == 5)
                {
                    package.UpdateStatus("Assigned");
                }
                else if (package.CalculatePriorityScore(package) > 20)
                {
                    package.OverridePriorityLevel(5);
                    package.UpdateStatus("Assigned");
                }
            }

            Console.WriteLine("Day has been simulated");
        }

        public void Sort()
        {
            SaveState();
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

        private void SaveState()
        {
            Snapshot snapshot = new Snapshot(warehouses, allPackages);
            undoStack.Push(snapshot);
        }

        public void Undo()
        {
            if (undoStack.IsEmpty())
            {
                Console.WriteLine("No actions to undo.");
                return;
            }

            Snapshot previousState = undoStack.Pop();

            warehouses.Clear();
            allPackages.Clear();
            deliverPackages.Clear();
            remainingPackages.Clear();

            foreach (Warehouse warehouse in previousState.GetWarehouses())
            {
                warehouses.Add(new Warehouse(warehouse));
            }

            foreach (Warehouse warehouse in warehouses)
            {
                List<Package> packages = warehouse.GetListPackages();

                foreach (Package package in packages)
                {
                    allPackages.Add(package);
                }
            }

            Console.WriteLine("Previous state restored.");
        }

        public void SetWarehouses(List<Warehouse> warehouses)
        {
            this.warehouses = warehouses;

            allPackages.Clear();

            foreach (Warehouse warehouse in warehouses)
            {
                foreach (Package package in warehouse.GetListPackages())
                {
                    allPackages.Add(package);
                }
            }
        }


        public void RebuildWarehouseRelationships(List<Warehouse> warehouses, List<Package> packages, List<Vehicle> vehicles, List<Worker> workers)
        {
            foreach (Warehouse warehouse in warehouses)
            {
                warehouse.GetListPackages().Clear();
                warehouse.GetListVehicles().Clear();
                warehouse.GetListWorkers().Clear();
            }

            foreach (Package package in packages)
            {
                foreach (Warehouse warehouse in warehouses)
                {
                    if (package.GetWarehouseId() == warehouse.GetId())
                    {
                        warehouse.GetListPackages().Add(package);
                        break;
                    }
                }
            }

            foreach (Vehicle vehicle in vehicles)
            {
                foreach (Warehouse warehouse in warehouses)
                {
                    if (vehicle.GetWarehouseId() == warehouse.GetId())
                    {
                        warehouse.GetListVehicles().Add(vehicle);
                        break;
                    }
                }
            }

            foreach (Worker worker in workers)
            {
                foreach (Warehouse warehouse in warehouses)
                {
                    if (worker.GetWarehouseId() == warehouse.GetId())
                    {
                        warehouse.GetListWorkers().Add(worker);
                        break;
                    }
                }
            }
        }
    }
}