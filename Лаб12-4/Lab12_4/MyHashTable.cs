using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryLab10;

namespace Lab12_4
{
    public class MyHashTable<T> where T : IInit, IComparable, new()
    {
        protected T[] table;
        protected int count = 0;
        protected bool[] check;
        protected double fillRatio = 0.72;

        public int Capacity => table.Length;
        public int Count => count;

        public MyHashTable(int size = 10, double fillRatio = 0.72)
        {
            table = new T[size];
            check = new bool[size];
            fillRatio = fillRatio;
        }

        public void Print()
        {
            if (Count == 0)
            {
                Console.WriteLine("Таблица пуста");
            }
            else
            {
                int i = 0;
                foreach (T item in table)
                {
                    Console.WriteLine($"{i++} : {item}");
                }
            }
        }

        public bool Contain(T item)
        {
            return !(FindItem(item) < 0);
        }

        public bool RemoveItem(T item)
        {
            int index = FindItem(item);
            if (index < 0)
            {
                index = FindItem(item);
                if (index < 0) return false;
            }
            count--;
            table[index] = default;
            check[index] = true;
            if (count == 0)
            {
                check = new bool[table.Length];
            }
            return true;
        }

        public void AddItem(T item)
        {
            if ((double)Count / Capacity > fillRatio)
            {
                T[] temp = (T[])table.Clone();
                table = new T[temp.Length * 2];
                count = 0;
                check = new bool[temp.Length * 2];
                for (int i = 0; i < temp.Length; i++)
                    AddData(temp[i]);
            }
            AddData(item);
        }

        public int GetIndex(T data)
        {
            return Math.Abs(data.GetHashCode()) % Capacity;
        }

        void AddData(T data)
        {
            if (data == null) return;
            int index = GetIndex(data);
            int current = index;
            if (table[index] != null)
            {
                while (current < table.Length && table[current] != null)
                {
                    current++;
                }
                if (current == table.Length)
                {
                    current = 0;
                    while (current < index && table[current] != null)
                    {
                        current++;
                    }
                    if (current == index)
                    {
                        throw new Exception("В таблице нет места");
                    }
                }
            }
            table[current] = data;
            check[current] = false;
            count++;
        }

        int FindItem(T data)
        {
            int index = GetIndex(data);
            if (table[index] == null && check[index] == false) return -1;
            if (table[index] != null && table[index].CompareTo(data) == 0) return index;
            int current = index;
            while (current < table.Length)
            {
                if (table[current] != null && table[current].CompareTo(data) == 0)
                {
                    return current;
                }
                current++;
            }
            current = 0;
            while (current < index)
            {
                if (table[current] != null && table[current].CompareTo(data) == 0)
                {
                    return current;
                }
                current++;
            }
            return -1;
        }
    }
}
