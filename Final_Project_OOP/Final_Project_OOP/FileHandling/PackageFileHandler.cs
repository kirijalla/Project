using Final_Project_OOP.CoreClasses;
using Final_Project_OOP.Exceptions;
using Final_Project_OOP.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;


namespace Final_Project_OOP.FileHandling
{
    public class PackageFileHandler : IFileHandler
    {

        private List<Package> packages = new List<Package>();

        public PackageFileHandler(List<Package> packages)
        {
            this.packages = packages;
        }


        public void Save(string path)
        {
            StreamWriter writer = new StreamWriter(path,true);

            foreach (Package package in packages)
            {
                writer.WriteLine(package.ToFileString());
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

            packages.Clear();

            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split('|');

                // create Package object from parts
                Package package = new Package(
                    double.Parse(parts[1]),
                    int.Parse(parts[2]),
                    parts[3]
                );

                package.SetId(int.Parse(parts[0]));
                package.SetStatus(parts[4]);
                package.SetWarehouseId(int.Parse(parts[5]));

                packages.Add(package);
            }

            reader.Close();
        }
    }
}
