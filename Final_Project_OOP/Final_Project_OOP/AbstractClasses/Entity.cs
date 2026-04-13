using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project_OOP.Exceptions;

namespace Final_Project_OOP
{
    public abstract class Entity
    {
        private int id;
        private string name;
        private DateTime createdDate;

        public Entity(int id, string name, DateTime createdDate)
        {
            this.id = id;
            this.name = name;
            this.createdDate = createdDate;
        }

        protected Entity(Entity other)
        {
            this.id = other.id;
            this.name = other.name;
            this.createdDate = other.createdDate;
        }

        public int Getid() { return id; }
        public void Setid(int id) { this.id = id; }
        public string Getname() { return name; }
        public void Setname(string name) 
        {
            if (string.IsNullOrWhiteSpace(name)) 
            {
                throw new InvalidDataException("invalid name");
            } 
            else { this.name = name; } 
        }
        public DateTime GetcreatedDate() { return createdDate; }
        public void SetcreatedDate(DateTime createdDate) { this.createdDate = createdDate; }

        public virtual bool Validate()
        {
            if (id <= 0)
            { 
                return false;
            }
            else if (string.IsNullOrWhiteSpace(name))
            { 
                return false;
            }
            else if (createdDate == DateTime.MinValue)
            { 
                return false; 
            }
            else 
            {
                return true; 
            }
        }
        public abstract void Display();

    }
}
