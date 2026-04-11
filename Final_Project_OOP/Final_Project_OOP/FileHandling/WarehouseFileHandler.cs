using Final_Project_OOP.CoreClasses;
using Final_Project_OOP.Exceptions;
using Final_Project_OOP.Interfaces;
using System.Collections.Generic;
using System.IO;


namespace Final_Project_OOP.FileHandling
{
    public class WarehouseFileHandler : IFileHandler
    {
        private List<Warehouse> warehouses = new List<Warehouse>();

        public WarehouseFileHandler(List<Warehouse> warehouses)
        {
            this.warehouses = warehouses;
        }

        public void Save(string path)
        {
            StreamWriter writer = new StreamWriter(path);

            foreach (Warehouse warehouse in warehouses)
            {
                writer.WriteLine(warehouse.ToFileString());
            }

            writer.Close();
        }

        public void Load(string path)
        {
            if (!File.Exists(path))
            {
                throw new InvalidFileHandlingException("There is no such file to load for Warehouses.");
            }
            StreamReader reader = new StreamReader(path);

            string line;

            warehouses.Clear();

            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');

                Warehouse warehouse = new Warehouse(
                    parts[0]
                    );

                warehouses.Add(warehouse);
            }

            reader.Close();
        }
    }
}
