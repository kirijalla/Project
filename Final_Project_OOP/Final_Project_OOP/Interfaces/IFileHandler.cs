using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_OOP.Interfaces
{
    public interface IFileHandler
    {
        void Save(string path);
        void Load(string path);
    }
}
