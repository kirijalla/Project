using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_OOP.Exceptions
{
    public class InvalidDataException : Exception
    {
        public InvalidDataException(string message) :base(message)
        {

        }
    }
}
