using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаб12_1
{
    public class Point<T>
    {
        public T? Data{ get; set; }
        public Point<T>? Next { get; set; }
        public Point<T>? Pred { get; set; }

        public Point()
        {
            Data = default(T);
            Pred = null;
            Next = null;
        }
        public Point(T data)
        {
            Data = data;
            Pred = null;
            Next = null;
        }
        public override string? ToString()
        {
            return Data == null ? null : Data.ToString();
        }

        public override int GetHashCode()
        {
            return Data == null? 0 : Data.GetHashCode();
        }
    }
}
