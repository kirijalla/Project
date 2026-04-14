using Final_Project_OOP.AbstractClasses;
using Final_Project_OOP.Exceptions;
using Final_Project_OOP.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;


namespace Final_Project_OOP.FileHandling
{
    public class WorkerFileHandler : IFileHandler
    {
        private List<Worker> workers = new List<Worker>();

        public WorkerFileHandler(List<Worker> workers)
        {
            this.workers = workers;
        }

        public void Save(string path)
        {
            StreamWriter writer = new StreamWriter(path);

            foreach (Worker worker in workers)
            {
                writer.WriteLine(worker.ToFileString());
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
            workers.Clear();
            while ((line = reader.ReadLine()) != null)
            {

                string[] parts = line.Split('|');

                string type = parts[0];

                if (type == "Loader")
                {
                    Worker loader = new Loader(
                        parts[2],
                        DateTime.Parse(parts[3]),
                        int.Parse(parts[4]),
                        int.Parse(parts[5]),
                        bool.Parse(parts[6]),
                        double.Parse(parts[8])
                    );

                    loader.Setid(int.Parse(parts[1]));
                    loader.SetWarehouseId(int.Parse(parts[7]));
                    workers.Add(loader);
                }
                else if (type == "Driver")
                {
                    Worker driver = new Driver(
                        parts[2],
                        DateTime.Parse(parts[3]),
                        int.Parse(parts[4]),
                        int.Parse(parts[5]),
                        bool.Parse(parts[6]),
                        parts[8]
                    );

                    driver.Setid(int.Parse(parts[1]));
                    driver.SetWarehouseId(int.Parse(parts[7]));
                    workers.Add(driver);
                }
                else if (type == "Manager")
                {
                    Worker manager = new Manager(
                        parts[2],
                        DateTime.Parse(parts[3]),
                        int.Parse(parts[4]),
                        int.Parse(parts[5]),
                        bool.Parse(parts[6]),
                        int.Parse(parts[8])
                    );

                    manager.Setid(int.Parse(parts[1]));
                    manager.SetWarehouseId(int.Parse(parts[7]));
                    workers.Add(manager);
                }
           }
            reader.Close();
        }
    }
}
