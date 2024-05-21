namespace Lab12_3
{
    public class MyTree<T> where T : IComparable
    {
        public Point<T> root = null;

        int count = 0;

        public int Count => count;

        public MyTree() { }

        public MyTree(T[] arr)
        {
            count = arr.Length;
            root = MakeTree(arr);
        }
        public void ShowTree()
        {
            Show(root);
        }
        public T[] TreeToArray()
        {
            T[] arr = new T[count];
            Stack<Point<T>> inS = new Stack<Point<T>>();
            Stack<Point<T>> outS = new Stack<Point<T>>();
            if (root != null)
            {
                inS.Push(root);
                while (inS.Count > 0)
                {
                    Point<T> temp = inS.Pop();
                    outS.Push(temp);
                    if (temp.Left != null) inS.Push(temp.Left);
                    if (temp.Right != null) inS.Push(temp.Right);
                }
                int i = 0;
                while (outS.Count > 0)
                {
                    arr[i++] = outS.Pop().Data;
                }
            }
            return arr;
        }

        Point<T>? MakeTree(T[] arr)
        {
            if (arr.Length == 0 || arr == null)
            {
                return null;
            }
            Point<T> newItem = new Point<T>(arr[0]);
            int nl = arr.Length / 2;
            int nr = arr.Length - nl - 1;
            T[] arrLeft = new T[nl];
            T[] arrRight = new T[nr];
            for (int i = 1; i <= nl; i++)
            {
                arrLeft[i - 1] = arr[i];
            }
            for (int i = nl + 1; i < arr.Length; i++)
            {
                arrRight[i - nl - 1] = arr[i];
            }
            newItem.Left = MakeTree(arrLeft);
            newItem.Right = MakeTree(arrRight);
            return newItem;
        }


        void Show(Point<T>? point, int spaces = 0)
        {
            if (point != null)
            {
                Show(point.Left, spaces + 5);
                for (int i = 0; i < spaces; i++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine(point.Data);
                Show(point.Right, spaces + 5);
            }
        }

        public void TransformToFindTree()
        {
            T[] arr = new T[count];
            int current = 0;
            Stack<Point<T>> inS = new Stack<Point<T>>();
            Stack<Point<T>> outS = new Stack<Point<T>>();
            if (root != null)
            {
                inS.Push(root);
                while (inS.Count > 0)
                {
                    Point<T> temp = inS.Pop();
                    outS.Push(temp);
                    if (temp.Left != null) inS.Push(temp.Left);
                    if (temp.Right != null) inS.Push(temp.Right);
                }
                int i = 1;
                root = new Point<T>(root.Data);
                count = 1;
                arr[0] = root.Data;
                while (outS.Count > 0)
                {
                    Point<T> temp = outS.Pop();
                    bool check = true;
                    for (int j = 0; j < arr.Length; j++)
                    {
                        if (arr[j] != null && arr[j].Equals(temp.Data))
                        {
                            check = false;
                        }
                    }
                    if (!temp.Equals(root) && check)
                    {
                        AddPoint(temp.Data);
                        arr[i++] = temp.Data;
                    }
                }
            }
        }
        public void AddPoint(T data)
        {
            Point<T>? point = root;
            Point<T>? current = null;
            while (point != null)
            {
                current = point;
                    if (point.Data.CompareTo(data) < 0)
                    {
                        point = point.Left;
                    }
                    else
                    {
                        point = point.Right;
                    }
            }
            Point<T> newPoint = new Point<T>(data);
            if (current.Data.CompareTo(data) < 0)
            {
                current.Left = newPoint;
            }
            else
            {
                current.Right = newPoint;
            }
            count++;
        }
    }
}
