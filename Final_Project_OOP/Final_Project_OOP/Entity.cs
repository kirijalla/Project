using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_OOP
{
    public abstract class Entity
    {
        private int id;
        private string name;
        private DateTime createdDate;

        public int Getid() { return id; }
        public void Setid(int id) { this.id = id; }
        public string Getname() { return name; }
        public void Setname(string name) 
        {
            if (string.IsNullOrWhiteSpace(name)) 
            {
                /*Mondongo*/
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
