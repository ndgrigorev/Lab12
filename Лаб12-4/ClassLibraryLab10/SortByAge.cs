using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLab10
{
    public class SortByAge : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x == null || y == null) { return -1; }
            if (!(x is Animals animal1 && y is Animals animal2)) { return -1; }
            if (animal1.Age < animal2.Age) { return -1; }
            if (animal1.Age > animal2.Age) { return 1; }
            else { return 0; }
        }
    }
}
