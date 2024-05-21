using ClassLibraryLab10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Лаб12_1
{
    public class MyList<T> where T : IInit, ICloneable, IComparable, new()
    {
        public Point<T>? beg = null;
        public Point<T>? end = null;
        int count = 0;

        public int Count => count;

        public Point<T> RandomData()
        {
            T data = new T();
            data.RandomInit();
            return new Point<T>(data);
        }

        public T RandomItem()
        {
            T data = new T();
            data.RandomInit();
            return data;
        }

        public void AddToBegin(T item)
        {
            T newData = (T)item.Clone();
            Point<T> newItem = new Point<T>(newData);
            count++;
            if (beg != null)
            {
                beg.Pred = newItem;
                newItem.Next = beg;
                beg = newItem;
            }
            else
            {
                beg = newItem;
                end = beg;
            }
        }
        public void AddToEnd(T item)
        {
            T newData = (T)item.Clone();
            Point<T> newItem = new Point<T>(newData);
            count++;
            if (end != null)
            {
                end.Next = newItem;
                newItem.Pred = end;
                end = newItem;
            }
            else
            {
                beg = newItem;
                end = beg;
            }
        }
        public void Delete()
        {
            beg = end = null;
            Console.WriteLine("Список удалён");
        }
        public bool AddToList(int amount, T item)
        {
            Point<T>? pos = FindItem(item);
            if (pos == null) { return false; }
            if (pos == end)
            {
                for (int i = 0; i < amount; i++)
                {
                    AddToEnd(RandomItem());
                }
            }
            else
            {
                Point<T> next = pos.Next;
                Point<T> notCurrent = pos;
                for (int i = 0; i < amount; i++)
                {
                    count++;
                    Point<T> current = RandomData();
                    notCurrent.Next = current;
                    current.Pred = notCurrent;
                    notCurrent = current;
                }
                notCurrent.Next = next;
                notCurrent.Next.Pred = notCurrent;
            }
            return true;
        }
        public MyList() { }

        public MyList(int size)
        {
            if (size <= 0) throw new Exception("Длина меньше или равна 0");
            beg = RandomData();
            end = beg;
            for (int i = 1; i < size; i++)
            {
                T newItem = RandomItem();
                AddToEnd(newItem);
            }
            count = size;
        }

        public MyList(T[] collection)
        {
            if (collection == null) throw new Exception("collection = null");
            if (collection.Length == 0) throw new Exception("collection empty");
            T newData = (T)collection[0].Clone();
            beg = new Point<T>(newData);
            end = beg;
            for(int i = 1; i < collection.Length; i++)
            {
                AddToEnd(collection[i]);
            }
        }
        public void PrintList()
        {
            if (count == 0) Console.WriteLine("Лист пустой");
            Point<T>? current = beg;
            for(int i = 0; i < count; i++)
            {
                Console.WriteLine(current);
                current = current.Next;
            }
            
        }
        public Point<T>? FindItem(T item)
        {
            Point<T>? current = beg;
            while (current != null)
            {
                if(current.Data == null) throw new Exception("Data is null");
                if (current.Data.CompareTo(item) == 0)
                {
                    return current;
                }
                current = current.Next;
            }
            return null;
        }

        public bool RemoveItem(T item)
        {
            if (beg == null) throw new Exception("Лист пустой");
            Point<T> ? pos = FindItem(item);
            if (pos == null) { return false; }
            count--;
            if (beg==end)
            {
                beg = end = null;
                return true;
            }
            if (pos.Pred == null)
            {
                beg = beg.Next;
                beg.Pred = null;
                return true;
            }
            if(pos.Next == null)
            {
                end = end.Pred;
                end.Next = null;
                return true;
            }
            Point<T> next = pos.Next;
            Point<T> pred = pos.Pred;
            pos.Next.Pred = pred;
            pos.Pred.Next = next;
            return true;
        }
        public MyList<T> Clone()
        {
            if (beg == null) throw new ArgumentException("Лист пустой");
            MyList<T> clone = new MyList<T>();
            Point<T> current = beg;
            while (current != null)
            {
                clone.AddToEnd((T)current.Data.Clone());
                current = current.Next;
            }
            return clone;
        }
    }
}
