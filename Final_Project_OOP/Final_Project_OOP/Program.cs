using Final_Project_OOP.CoreClasses;
using Final_Project_OOP.Exceptions;
using System;
using System.Collections.Generic;

namespace Final_Project_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] Menu = { "1 Add entities\n2 Assign deliveries\n3 Sort\n4 Search\n5 Run simulation\n6 Undo\n7 Save / Load" };
            int a = 0;
            do
            {
                Console.WriteLine("MENU");
                foreach (string item in Menu)
                {
                    Console.WriteLine(item);
                }
                a++;

            } while (a < 3);
        }
    }
}
