using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_OOP.DataStructures
{
    public class CustomStack<T>
    {
        private T[] arr;
        private int top;
        private int capacity;
        public CustomStack(int s)
        {
            capacity = s;
            arr = new T[capacity];
            top = -1;
        }
        public void Push(T value)
        {
            if (top == capacity - 1)
            {
                Console.WriteLine("Stack is full");
                return;
            }
            top++;
            arr[top] = value;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack is empty");
                return default(T);
            }
            T value = arr[top];
            top--;
            return value;

        }

        public T Peek()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack is empty");
                return default(T);
            }
            return arr[top];
        }
        public bool IsEmpty()
        {
            return top == -1;
        }
    }
}
