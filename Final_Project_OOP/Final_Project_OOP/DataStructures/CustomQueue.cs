using Final_Project_OOP.CoreClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_OOP.DataStructures
{
    public class CustomQueue<T>
    {
        private List<T> items;

        public CustomQueue()
        {
            items = new List<T>();
        }

        public void Enqueue(T item)
        {
            items.Add(item);
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty");
            }

            T item = items[0];
            items.RemoveAt(0);
            return item;
        }
        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty");
            }
                
            return items[0];
        }

        public bool IsEmpty()
        {
            if (items.Count == 0)
            {
                return true;
            }
            return false;
        }

        public void Clear()
        {
            items.Clear();
        }
    }
}
