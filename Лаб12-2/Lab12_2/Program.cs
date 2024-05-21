using ClassLibraryLab10;
using System.Collections;
using System.Data;

namespace Lab12_2
{
    internal class Program
    {
        static void PrintMenu()
        {
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("1.Сформировать хеш-таблицу");
            Console.WriteLine("2.Распечатать хеш-таблицу");
            Console.WriteLine("3.Удалить элемент с заданным именем");
            Console.WriteLine("4.Добавить элемент в хеш-таблицу");
            Console.WriteLine("5.Добавить элемент к максимальному числу элементов");
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

        static Animals RandomAnimal()
        {
            Random rnd = new Random();
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
        static MyHashTable<Animals> CreatingHashTable(int amount = -1)
        {
            int size;
            if(amount < 0)
            {
                size = InputNumber("Введите кол-во элементов таблицы", 0);
            }
            else
            {
                size = amount;
            }
            if (size == 0)
            {
                Console.WriteLine("Была создана пустая хэш-таблица");
                return new MyHashTable<Animals>();
            }
            else
            {
                Random rnd = new Random();
                MyHashTable<Animals> table = new MyHashTable<Animals>();
                for (int i = 0; i < size; i++)
                {
                    table.AddItem(RandomAnimal());
                }
                if (amount == -1) Console.WriteLine("Таблица создана");
                return table;
            }
        }
        static MyHashTable<Animals> Delete(MyHashTable<Animals> table)
        {
            if (table.Count == 0)
            {
                Console.WriteLine("Таблица пуста");
                return table;
            }
            Console.WriteLine("Введите имя элемента, которого хотите удалить");
            string name = Console.ReadLine();
            Animals animal = new Animals(0, name, "", 0);
            if (table.Remove(animal))
            {
                Console.WriteLine("Элемент удалён");
            }
            else
            {
                Console.WriteLine("Элемент с заданным именем не был найден");
            }
            return table;
        }
        static MyHashTable<Animals> Add(MyHashTable<Animals> table)
        {
            int amount = InputNumber("Введите кол-во элементов для добавления", 0);
            if (amount == 0)
            {
                Console.WriteLine("Добавление не было выполнено");
                return table;
            }
            for (int i = 0; i < amount; i++)
            {
                table.AddItem(RandomAnimal());
            }
            Console.WriteLine("Добавление было выполнено");
            return table;
        }
        static void ShowFullTable()
        {
            MyHashTable<Animals> table = CreatingHashTable(7);
            Console.WriteLine("Таблица из 7 элементов (Capacity = 10): ");
            table.Print();
            table.AddItem(RandomAnimal());
            table.AddItem(RandomAnimal());
            Console.WriteLine("Таблица после добавления двух элементов: ");
            table.Print();
        }
        Random rnd = new Random();
        static void Main(string[] args)
        {
            MyHashTable<Animals> table = new MyHashTable<Animals>();
            int answer;
            do
            {
                PrintMenu();
                answer = InputNumber("Введите номер пункта меню");
                switch (answer)
                {
                    case 1:
                        {
                            table = CreatingHashTable();
                            break;
                        }
                    case 2:
                        {
                            table.Print();
                            break;
                        }
                    case 3:
                        {
                            table = Delete(table);
                            break;
                        }
                    case 4:
                        {
                            table = Add(table);
                            break;
                        }
                    case 5:
                        {
                            ShowFullTable();
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
