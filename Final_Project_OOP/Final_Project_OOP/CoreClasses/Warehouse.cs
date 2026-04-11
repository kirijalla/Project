using Final_Project_OOP;
using Final_Project_OOP.CoreClasses;
using Final_Project_OOP.Exceptions;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;

public class Warehouse
{
    private string name;
    private int id;
    private static int currentId = 1;
    private List<Package> packages;
    private List<Vehicle> vehicles;
    private List<Worker> workers;

    // No setters for lists, the constructor will create the lists for you (prevents outside classes from creating lists)

    public Warehouse(string name)
    {
        ValidateName(name);

        SetName(name);
        this.packages = new List<Package>();
        this.vehicles = new List<Vehicle>();
        this.workers = new List<Worker>();
        this.id = currentId;
        currentId++;
    }

    public int GetId()
    {
        return id;
    }

    public void SetName(string name)
    {
        this.name = name;
    }
    public string GetName()
    {
        return this.name;
    }

    public List<Package> GetListPackages()
    {
        List<Package> packages = new List<Package>();

        foreach (Package package in this.packages)
        {
            packages.Add(package);
        }

        if (packages.Count < 1)
        {
            return null;
        }
        return packages;
    }

    public List<Vehicle> GetListVehicles()
    {
        List<Vehicle> vehicles = new List<Vehicle>();

        foreach (Vehicle vehicle in this.vehicles)
        {
            vehicles.Add(vehicle);
        }

        if (vehicles.Count < 1)
        {
            return null;
        }

        return vehicles;
    }

    public List<Worker> GetListWorkers()
    {
        List<Worker> workers = new List<Worker>();

        foreach (Worker worker in this.workers)
        {
            workers.Add(worker);
        }

        if (workers.Count < 1)
        {
            return null;
        }

        return workers;
    }

    private void ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new InvalidDataException("[ERROR] - Name input is empty");
        }
    }

    public void AddWorker(Worker worker)
    {
        if (worker == null)
        {
            throw new InvalidDataException("[ERROR] - Worker cannot be null.");
        }

        foreach (Worker existingWorker in workers)
        {
            if (existingWorker.Getid() == worker.Getid())
            {
                throw new InvalidDataException($"[ERROR] - A worker with ID {worker.Getid()} already exists");
            }
        }

        workers.Add(worker);
    }

    public void RemoveWorker(Worker worker)
    {
        workers.Remove(worker);
    }
    public void AddPackage(Package packageId)
    {
        if (packageId == null)
        {
            throw new InvalidPackageException("[ERROR] - Package cannot be null");
        }
        foreach (Package existingPackage in packages)
        {
            if (existingPackage.GetId() == packageId.GetId())
            {
                throw new InvalidDataException("Duplicate worker ID.");
            }
        }
        packages.Add(packageId);
    }
    public void RemovePackage(Package packageId)
    {
        if (packageId.GetId() == 0)
        {
            throw new InvalidPackageException("[ERROR] - Package cannot be null or 0");
        }
        packages.Remove(packageId);
    }
    public void AddVehicle(Vehicle vehicle)
    {
        if (vehicle == null)
        {
            throw new InvalidPackageException("[ERROR] - Vehicle cannot be null");
        }
        foreach (Vehicle existingVehicle in vehicles)
        {
            if (existingVehicle.Getid() == vehicle.Getid())
            {
                throw new InvalidDataException($"[ERROR] - A vehicle with ID {vehicle.Getid()} already exists");
            }
        }
        vehicles.Add(vehicle);
    }
    public void RemoveVehicle(Vehicle vehicle)
    {
        if (vehicle == null)
        {
            throw new InvalidPackageException("[ERROR] - Vehicle cannot be null");
        }
        vehicles.Remove(vehicle);
    }

    public Vehicle FindBestVehicle(Package package)
    {
        Vehicle bestVehicle = null;

        foreach (Vehicle vehicle in vehicles)
        {
            if (vehicle.GetIsAvailable() == true) // Is it available
            {
                if (vehicle.GetmaxCapacity() > package.GetWeight()) // Can the vehicle carry the package
                {
                    if (vehicle.CalculateEfficiency() > 80) // Does the vehicle have efficiency
                    {
                        if (bestVehicle == null || vehicle.GetmaxCapacity() > bestVehicle.GetmaxCapacity()) // Is the current vehicle being checked better than the best vehicle set
                        {
                            bestVehicle = vehicle; // swap
                        }
                    }

                }
            }
        }
        return bestVehicle;
    }
    public List<Package> GetPendingPackages()
    {
        if (packages.Count < 1)
        {
            throw new InvalidDataException("[ERROR] - Packages list is empty");
        } 
        List<Package> pendingPackages = new List<Package>();
        for (int i = 0; i < packages.Count; i++)
        {
            if (packages[i].GetStatus() == "Pending")
            {
                pendingPackages.Add(packages[i]);
            }
        }
        return pendingPackages;
    }
    public Worker AssignWorker()
    {
        if (workers.Count < 1)
        {
            throw new InvalidDataException("[ERROR] - Worker list is empty");
        }
        for (int i = 0; i < workers.Count; i++)
        {
            if (workers[i].GetIsAvailable() == true)
            {
                workers[i].SetIsAvailable(false);
                return workers[i]; // Returning the first available worker
                
            }
        }
        return null;
    }
    public override string ToString()
    {
        return $"Warehouse name: {name} | ID: {id}";
    }

    public string ToFileString()
    {
        return $"{name},{id}";
    }
}