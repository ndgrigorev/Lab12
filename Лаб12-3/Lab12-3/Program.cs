using ClassLibraryLab10;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;

namespace Lab12_3
{
    internal class Program
    {
        static Random rnd = new Random();
        static void PrintMenu()
        {
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("1.Сформировать идельно-сбалансированное бинарное дерево");
            Console.WriteLine("2.Распечатать дерево");
            Console.WriteLine("3.Найти количество элементов дерева, у которых имя начинается с заданной буквы");
            Console.WriteLine("4.Преобразовать сбалансированное дерево в дерево поиска");
            Console.WriteLine("5.Удалить дерево");
            Console.WriteLine("6.Выход");
        }

        static int InputNumber(string message, int left = -2147483648, int right = 2147483647)
        {
            Console.WriteLine(message);
            int number;
            bool check = true;
            do
            {
                check = int.TryParse(Console.ReadLine(), out number);
                if (!check) Console.WriteLine("Вы ввели нечисло, введите число ещё раз");
                if (number < left)
                {
                    check = false;
                    Console.WriteLine($"Данное число не может быть меньше {left}");
                }
                if (number > right)
                {
                    check = false;
                    Console.WriteLine($"Данное число не может быть больше {right}");
                }
            } while (!check);
            return number;
        }

        static char InputLetter(string message)
        {
            Console.WriteLine(message);
            char letter;
            bool check = true;
            do
            {
                check = char.TryParse(Console.ReadLine(), out letter);
                if (!check) Console.WriteLine("Вы ввели не букву, введите букву ещё раз");
            } while (!check);
            return letter;
        }
        static Animals RandomAnimal()
        {
            int x = rnd.Next(0, 4);
            if (x == 0)
            {
                Animals animal = new Animals();
                animal.RandomInit();
                return animal;
            }
            if (x == 1)
            {
                Mammals animal = new Mammals();
                animal.RandomInit();
                return animal;
            }
            if (x == 2)
            {
                Cats animal = new Cats();
                animal.RandomInit();
                return animal;
            }
            else
            {
                Fishes animal = new Fishes();
                animal.RandomInit();
                return animal;
            }
        }
        static void ShowTree(MyTree<Animals> tree)
        {
            if (tree.Count == 0)
            {
                Console.WriteLine("Дерево пустое");
            }
            else { tree.ShowTree(); }
        }
        static MyTree<Animals> CreatingTree(int amount = -1)
        {
            int size;
            if (amount < 0)
            {
                size = InputNumber("Введите кол-во элементов дерева", 0);
            }
            else
            {
                size = amount;
            }
            if (size == 0)
            {
                Console.WriteLine("Было создано пустое дерево");
                return new MyTree<Animals>();
            }
            else
            {
                Animals[] animals = new Animals[size];
                for(int i = 0; i < animals.Length; i++)
                {
                    animals[i] = RandomAnimal();
                }
                MyTree<Animals> tree = new MyTree<Animals>(animals);
                if (amount == -1) Console.WriteLine("Дерево создано");
                return tree;
            }
        }
        static int CheckNames(MyTree<Animals> tree, char letter)
        {
            Animals[] arr = tree.TreeToArray();
            int count = 0;
            for(int i = 0;  i < arr.Length; i++)
            {
                if (arr[i].Name[0] == letter)
                {
                    count++;
                }
            }
            return count;
        }
        static void Main(string[] args)
        {
            MyTree<Animals> tree = new MyTree<Animals>();
            int answer;
            do
            {
                PrintMenu();
                answer = InputNumber("Введите номер пункта меню");
                switch (answer)
                {
                    case 1:
                        {
                            tree = CreatingTree();
                            break;
                        }
                    case 2:
                        {
                            ShowTree(tree);
                            break;
                        }
                    case 3:
                        {
                            char letter = InputLetter("Введите букву");
                            int amount = CheckNames(tree, letter);
                            Console.WriteLine($"Всего в дереве {amount} элементов, имя которых начинается с буквы {letter}");
                            break;
                        }
                    case 4:
                        {
                            if(tree.Count == 0)
                            {
                                Console.WriteLine("Дерево пустое");
                            }
                            else
                            {
                                tree.TransformToFindTree();
                                Console.WriteLine("Дерево преобразовано");
                            }
                            break;
                        }
                    case 5:
                        {
                            tree = new MyTree<Animals>();
                            Console.WriteLine("Дерево удалено");
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Выход из программы");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Данного пункта меню нет, попробуйте ещё раз");
                            break;
                        }
                }
            } while (answer != 6);
        }
    }
}
