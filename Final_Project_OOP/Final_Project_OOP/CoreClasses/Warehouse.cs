using Final_Project_OOP;
using Final_Project_OOP.CoreClasses;
using System.Collections.Generic;
using Final_Project_OOP.Exceptions;

public class Warehouse
{
    private string name;
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
        return packages;
    }

    public List<Vehicle> GetListVehicles()
    {
        return this.vehicles;
    }

    public List<Worker> GetListWorkers()
    {
        return this.workers;
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
            throw new InvalidDataException("Worker cannot be null.");
        }

        foreach (Worker existingWorker in workers)
        {
            if (existingWorker.Getid() == worker.Getid())
            {
                throw new InvalidDataException("Duplicate worker ID.");
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
        if (packageId.GetId() == null)
        {
            throw new InvalidPackageException("[ERROR] - Package cannot be null");
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
                throw new InvalidDataException("Duplicate worker ID.");
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
        for (int i = 0; i < workers.Count; i++)
        {
            if (workers[i].GetIsAvailable() == true)
            {
                return workers[i];
            }
        }
        return null;
    }
}