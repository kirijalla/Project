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

            string[] Menu = { "1 Add entities\n2 Assign deliveries\n3 Sort\n4 Search\n5 Run simulation\n6 Undo\n7 Save / Load\n8 Exit" };
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
                                packages.Add(new Package(10, 9, "Montreal"));
                                packages.Add(new Package(14, 4, "Boston"));
                                packages.Add(new Package(19, 4, "France"));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            Console.WriteLine("Created Packages. Creating Warehouses.");

                             warehouses.Add(new Warehouse("Warehouse1"));
                            warehouses.Add(new Warehouse("Warehouse2"));

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
