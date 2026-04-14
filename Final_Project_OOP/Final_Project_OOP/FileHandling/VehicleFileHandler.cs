using Final_Project_OOP.AbstractClasses;
using Final_Project_OOP.Exceptions;
using Final_Project_OOP.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Policy;


namespace Final_Project_OOP.FileHandling
{
    public class VehicleFileHandler : IFileHandler
    {
        private List<Vehicle> vehicles = new List<Vehicle>();

        public VehicleFileHandler(List<Vehicle> vehicles)
        {
            this.vehicles = vehicles;
        }

        public void Save(string path)
        {
            StreamWriter writer = new StreamWriter(path);

            foreach (Vehicle vehicle in vehicles)
            {
                writer.WriteLine(vehicle.ToFileString());
            }

            writer.Close();
        }

        public void Load(string path)
        {
            if (!File.Exists(path))
            {
                throw new InvalidFileHandlingException("There is no such file to load for Packages.");
            }
            StreamReader reader = new StreamReader(path);

            string line;

            while ((line = reader.ReadLine()) != null)
            {
                vehicles.Clear();
                string[] parts = line.Split('|');

                string type = parts[0];

                if (type == "Drone")
                {
                    Vehicle drone = new Drone(
                        parts[2],
                        DateTime.Parse(parts[3]),
                        double.Parse(parts[4]),
                        double.Parse(parts[5]),
                        double.Parse(parts[6]),
                        bool.Parse(parts[7]),
                        double.Parse(parts[9])
                    );

                    drone.Setid(int.Parse(parts[1]));
                    drone.SetWarehouseId(int.Parse(parts[8]));
                    vehicles.Add(drone);
                }
                else if (type == "Truck")
                {
                    Vehicle truck = new Truck(
                        parts[2],
                        DateTime.Parse(parts[3]),
                        double.Parse(parts[4]),
                        double.Parse(parts[5]),
                        double.Parse(parts[6]),
                        bool.Parse(parts[7]),
                        double.Parse(parts[9])
                    );

                    truck.Setid(int.Parse(parts[1]));
                    truck.SetWarehouseId(int.Parse(parts[8]));
                    vehicles.Add(truck);
                }
                else if (type == "Van")
                {
                    Vehicle van = new Van(
                        parts[2],
                        DateTime.Parse(parts[3]),
                        double.Parse(parts[4]),
                        double.Parse(parts[5]),
                        double.Parse(parts[6]),
                        bool.Parse(parts[7]),
                        bool.Parse(parts[9])
                    );

                    van.Setid(int.Parse(parts[1]));
                    van.SetWarehouseId(int.Parse(parts[8]));
                    vehicles.Add(van);
                }
            }
            reader.Close();
        }
    }
}
