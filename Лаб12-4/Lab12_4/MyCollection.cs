using ClassLibraryLab10;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12_4
{
    internal class MyCollection<T> : MyHashTable<T>, IEnumerable<T>, ICollection<T> where T : IInit, IComparable, ICloneable, new()
    {
        public MyCollection(): base() { }
        public MyCollection(int size) : base(size) { }
        public MyCollection(MyCollection<T> collection)
        {
            table = new T[collection.Capacity];
            check = new bool[collection.Capacity];
            fillRatio = collection.fillRatio;
            for (int i = 0; i < Capacity; i++)
            {
                if (collection.table[i] != null)
                {
                    table[i] = collection.table[i];          //поверхностное копирование, переделать
                }
            }
        }

        public bool IsReadOnly => false;  //доделать

        public void Add(T item)
        {
            AddItem(item);
        }

        public void Clear()
        {
            table = new T[10]; 
            check = new bool[0];
            count = 0;
        }

        public bool Contains(T item)
        {
            return Contain(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            int j = 0;
            for (int i = arrayIndex; i < Capacity; i++)
            {
                if (table[i] != null)
                {
                    array[j++] = table[i];
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = 0; i < Capacity; i++)
            {
                if (table[i] != null)
                {
                    yield return table[i];
                }
            }
        }

        public bool Remove(T item)
        {
            return RemoveItem(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
