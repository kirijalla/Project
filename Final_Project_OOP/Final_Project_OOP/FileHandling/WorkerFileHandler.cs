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

            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');

                string type = parts[0];

                if (type == "Loader")
                {
                    Worker Loader = new Loader(
                        int.Parse(parts[0]),
                        parts[1],
                        DateTime.Parse(parts[2]),
                        int.Parse(parts[3]),
                        int.Parse(parts[4]),
                        bool.Parse(parts[5]),
                        double.Parse(parts[6])
                        );

                    workers.Add(Loader);
                }
                else if (type == "Driver")
                {
                    Worker driver = new Driver(
                        int.Parse(parts[0]),
                        parts[1],
                        DateTime.Parse(parts[2]),
                        int.Parse(parts[3]),
                        int.Parse(parts[4]),
                        bool.Parse(parts[5]),
                        parts[6]
                        );
                    workers.Add(driver);
                }
                else if (type == "Manager")
                {
                    Worker manager = new Manager(
                         int.Parse(parts[0]),
                         parts[1],
                         DateTime.Parse(parts[2]),
                         int.Parse(parts[3]),
                         int.Parse(parts[4]),
                         bool.Parse(parts[5]),
                         int.Parse(parts[6])
                        );
                    workers.Add(manager);
                }
           }
            reader.Close();
        }
    }
}
