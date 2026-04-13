using Final_Project_OOP.CoreClasses;
using Final_Project_OOP.Exceptions;
using Final_Project_OOP.AbstractClasses;
using Final_Project_OOP.DataStructures;
using Final_Project_OOP.Interfaces;
using System;
using System.Collections.Generic;
using Final_Project_OOP.FileHandling;


namespace Final_Project_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string packageFile = "packages.txt";
            string vehicleFile = "vehicles.txt";
            string warehouseFile = "warehouses.txt";
            string workerFile = "workers.txt";

            List<Package> packages = new List<Package>();
            PackageFileHandler packageHandle = new PackageFileHandler(packages);
            List<Warehouse> warehouses = new List<Warehouse>();
            WarehouseFileHandler warehouseHandler = new WarehouseFileHandler(warehouses);
            List<Worker> workers = new List<Worker>();
            WorkerFileHandler workerHandler = new WorkerFileHandler(workers);
            List<Vehicle> vehicles = new List<Vehicle>();
            VehicleFileHandler vehicleHandler = new VehicleFileHandler(vehicles);

            DeliverySystem deliverySystem = new DeliverySystem();

            string[] Menu = { "1 Add entities", "2 Assign deliveries", "3 Sort", "4 Search", "5 Run simulation", "6 Undo", "7 Save / Load", "8 Exit"};
            int choice;
            do
            {
                Console.WriteLine("MENU");
                foreach (string item in Menu)
                {
                    Console.WriteLine(item);
                }
                Console.Write("Enter an option: ");
                int.TryParse(Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1:
                        {
                          
                            Console.WriteLine("Creating entities for Packages");
                            try
                            {
                                packages.Add(new Package (20, 5, "China"));
                                packages.Add(new Package(10, 5, "Montreal"));
                                packages.Add(new Package(14, 4, "Boston"));
                                packages.Add(new Package(19, 4, "France"));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            Console.WriteLine("Created Packages. Creating Warehouses.");

                             warehouses.Add(new Warehouse("Warehouse1"));

                            Console.WriteLine("Created Warehouses.");

                            Console.WriteLine("Setting up Delivery System");

                            for (int i = 0; i < packages.Count; i++)
                            {
                                deliverySystem.AddPackage(packages[i]);
                            }

                            for (int i = 0; i < warehouses.Count; i++)
                            {
                                deliverySystem.AddWarehouse(warehouses[i]);
                            }

                            Console.WriteLine("Delivery System Set up.");

                            Console.WriteLine("Creating vehicles.");

                            vehicles.Add(new Truck("Ford", DateTime.Now, 30, 100, 0, true, 20));
                            vehicles.Add(new Van("GMC", DateTime.Now, 25, 150, 0, true, true));
                            vehicles.Add(new Drone("ESP", DateTime.Now, 20, 15, 0, true, 300));

                            Console.WriteLine("Created Vehicles");
                            Console.WriteLine("Creating workers.");

                            workers.Add(new Loader("Andres", DateTime.Now, 5, 0, true, 200));
                            workers.Add(new Manager("Pargol", DateTime.Now, 23, 14, true, 3));
                            workers.Add(new Driver("Dario", DateTime.Now, 2, 1, true, "Expired"));

                            Console.WriteLine("Created workers.");

                            Console.WriteLine("Assigning workers, vehicles, and packages to warehouse1.");

                            for (int i = 0; i < packages.Count; i++)
                            {
                                warehouses[0].GetListPackages().Add(packages[i]);
                                packages[i].SetWarehouseId(warehouses[0].GetId());
                            }

                            for (int i = 0; i < vehicles.Count; i++)
                            {
                                warehouses[0].GetListVehicles().Add(vehicles[i]);
                                vehicles[i].SetWarehouseId(warehouses[0].GetId());
                            }

                            for (int i = 0; i < workers.Count; i++)
                            {
                                warehouses[0].GetListWorkers().Add(workers[i]);
                                workers[i].SetWarehouseId(warehouses[0].GetId());
                            }

                        }
                        break;
                    case 2:
                        {
                            deliverySystem.AssignDeliveries();
                        }
                        break;
                    case 3:
                        deliverySystem.Sort();
                        Console.WriteLine("Sorted Packages.");
                        break;
                    case 4:
                        {                           
                            Console.WriteLine("Enter ID of your package");
                            int userId = Convert.ToInt32(Console.ReadLine());

                            Package foundPackage = deliverySystem.SearchPackageById(userId);

                            if (foundPackage == null)
                            {
                                Console.WriteLine($"Could not find package with the ID {userId}");
                            }
                            else
                            {
                                Console.WriteLine(foundPackage);
                            }
                        }

                        break;
                    case 5:
                        deliverySystem.SimulateDay();
                        break;
                    case 6:
                        try
                        {
                            deliverySystem.Undo();
                            Console.WriteLine("Undo successful.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 7:
                        {
                            char saveOrLoad;
                            Console.WriteLine("Would you like to save or load the files? (1. Load 2. Save)");
                            saveOrLoad = Convert.ToChar(Console.ReadLine());
                            if (saveOrLoad == '1')
                            {
                                try
                                {
                                    packageHandle.Load(packageFile);
                                    workerHandler.Load(workerFile);
                                    warehouseHandler.Load(warehouseFile);
                                    vehicleHandler.Load(vehicleFile);

                                    deliverySystem.RebuildWarehouseRelationships(warehouses, packages, vehicles, workers);
                                    deliverySystem.SetWarehouses(warehouses);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            else if (saveOrLoad == '2')
                            {
                                packageHandle.Save(packageFile);
                                workerHandler.Save(workerFile);
                                warehouseHandler.Save(warehouseFile);
                                vehicleHandler.Save(vehicleFile);
                            }
                        }
                        break;
                    case 8:
                        Console.WriteLine("Exiting the program...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option from the menu.");
                        break;
                }
            } while (choice != 8);
        }
    }
}
