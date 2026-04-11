using Final_Project_OOP.CoreClasses;
using Final_Project_OOP.Exceptions;
using Final_Project_OOP.AbstractClasses;
using Final_Project_OOP.DataStructures;
using Final_Project_OOP.Interfaces;
using System;
using System.Collections.Generic;


namespace Final_Project_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] Menu = { "1 Add entities\n2 Assign deliveries\n3 Sort\n4 Search\n5 Run simulation\n6 Undo\n7 Save / Load\n8 Exit"};
            int choice;
            do
            {
                Console.WriteLine("MENU");
                foreach (string item in Menu)
                {
                    Console.WriteLine(item);
                }
                Console.Write("Enter an option: ");
                int.TryParse(Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1:
                        {

                        }
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        Console.WriteLine("Exiting the program...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option from the menu.");
                        break;
                }
            } while (choice != 8);
        }
    }
}
