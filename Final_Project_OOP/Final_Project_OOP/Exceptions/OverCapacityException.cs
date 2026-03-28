using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_OOP.Exceptions
{
    internal class OverCapacityException : Exception
    {
        public OverCapacityException(string message) :base (message)
        {

        }
    }
}
