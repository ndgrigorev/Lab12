using ClassLibraryLab10;
using System.Security.Cryptography;

namespace Лаб12_1
{
    internal class Program
    {
        static void PrintMenu()
        {
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("1.Сформировать двунаправленный список");
            Console.WriteLine("2.Распечатать список");
            Console.WriteLine("3.Удалить из списка первый элемент с заданным именем");
            Console.WriteLine("4.Добавить K элементов после элемента с заданным именем");
            Console.WriteLine("5.Выполнить глубокое клонирование списка");
            Console.WriteLine("6.Удалить список из памяти");
            Console.WriteLine("7.Выход");
        }

        static int InputNumber(string message, int left =-2147483648, int right = 2147483647)
        {
            Console.WriteLine(message);
            int number;
            bool check = true;
            do
            {
                check = int.TryParse(Console.ReadLine(), out number);
                if(!check) Console.WriteLine("Вы ввели нечисло, введите число ещё раз");
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
        static MyList<Animals> CreatingList()
        {
            int size = InputNumber("Введите длину списка", 0);
            if (size == 0)
            {
                Console.WriteLine("Был создан пустой список");
                return new MyList<Animals>();
            }
            else
            {
                Console.WriteLine("Список создан");
                return new MyList<Animals>(size);
            }
        }
        static MyList<Animals> Delete(MyList<Animals> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Список пуст");
                return list;
            }
            Console.WriteLine("Введите имя элемента, которого хотите удалить");
            string name = Console.ReadLine();
            Animals animal = new Animals(0, name, "", 0);
            if (list.RemoveItem(animal))
            {
                Console.WriteLine("Элемент удалён");
            }
            else
            {
                Console.WriteLine("Элемент с заданным именем не был найден");
            }
            return list;
        }
        static MyList<Animals> Add(MyList<Animals> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Список пуст");
                return list;
            }
            int amount = InputNumber("Введите кол-во элементов для добавления", 0);
            if(amount == 0)
            {
                Console.WriteLine("Добавление не было выполнено");
                return list;
            }
            Console.WriteLine("Введите имя элемента, после которого надо добавить элементы");
            string name = Console.ReadLine();
            Animals animal = new Animals(0, name, "", 0);
            if(list.AddToList(amount, animal))
            {
                Console.WriteLine("Добавление выполнено");
            }
            else
            {
                Console.WriteLine("Элемент с заданным именем не был найден, добавление не выполнено");
            }
            return list;
        }
        static MyList<Animals> Clone(MyList<Animals> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Список пуст");
                return list;
            }
            else
            {
                return list.Clone();
            }
        }
        static void CheckIfClone(MyList<Animals> list, MyList<Animals> listClone)
        {
            if (list.Count != 0)
            {
                Console.WriteLine("Оригинальный список:");
                list.PrintList();
                listClone.beg.Data.RandomInit();
                listClone.end.Data.RandomInit();
                Console.WriteLine("Изменённый клон:");
                listClone.PrintList();
            }
        }
        Random rnd = new Random();
        static void Main(string[] args)
        {
            MyList<Animals> list = new MyList<Animals>();
            MyList<Animals> listClone = new MyList<Animals>();
            int answer;
            do
            {
                PrintMenu();
                answer = InputNumber("Введите номер пункта меню");
                switch (answer)
                {
                    case 1:
                        {
                            list = CreatingList();
                            break;
                        }
                    case 2:
                        {
                            list.PrintList();
                            break;
                        }
                    case 3:
                        {
                            list = Delete(list);
                            break;
                        }
                    case 4:
                        {
                            list = Add(list);
                            break;
                        }
                    case 5:
                        {
                            listClone = Clone(list);
                            CheckIfClone(list, listClone);
                            break;
                        }
                    case 6:
                        {
                            list.Delete();
                            break;
                        }
                    case 7:
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
            }while (answer != 7);
        }
    }
}
