using ClassLibraryLab10;

namespace Lab12_4
{
    internal class Program
    {
        static void PrintMenu()
        {
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("1.Сформировать хеш-таблицу");
            Console.WriteLine("2.Распечатать хеш-таблицу");
            Console.WriteLine("3.Проверить наличие элемента по имени");
            Console.WriteLine("4.Удалить элемент с заданным именем");
            Console.WriteLine("5.Добавить элемент в хеш-таблицу");
            Console.WriteLine("6.Удалить хеш-таблицу");
            Console.WriteLine("7.Записать элементы хеш-таблицы в массив");
            Console.WriteLine("8.Выход");
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

        static bool FindItem(string name, MyCollection<Animals> table)
        {
            Animals animal = new Animals(0, name, "", 0);
            bool check = table.Contains(animal);
            return check;
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
        static void TableToArray(MyCollection<Animals> table)
        {
            int index = InputNumber("Введите номер с которого копировать хеш-таблицу в массив", 0, table.Capacity - 1);
            Animals[] animals = new Animals[table.Count];
            table.CopyTo(animals, index);
            Console.WriteLine("Получившийся массив");
            foreach (Animals animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
        static MyCollection<Animals> CreatingHashTable(int amount = -1)
        {
            int size;
            if (amount < 0)
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
                return new MyCollection<Animals>();
            }
            else
            {
                Random rnd = new Random();
                MyCollection<Animals> table = new MyCollection<Animals>();
                for (int i = 0; i < size; i++)
                {
                    table.Add(RandomAnimal());
                }
                if (amount == -1) Console.WriteLine("Таблица создана");
                return table;
            }
        }
        static MyCollection<Animals> Delete(MyCollection<Animals> table)
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
        static MyCollection<Animals> Add(MyCollection<Animals> table)
        {
            int amount = InputNumber("Введите кол-во элементов для добавления", 0);
            if (amount == 0)
            {
                Console.WriteLine("Добавление не было выполнено");
                return table;
            }
            for (int i = 0; i < amount; i++)
            {
                table.Add(RandomAnimal());
            }
            Console.WriteLine("Добавление было выполнено");
            return table;
        }
        Random rnd = new Random();
        static void Main(string[] args)
        {
            MyCollection<Animals> table = new MyCollection<Animals>();
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
                            Console.WriteLine("Введите имя");
                            bool check = FindItem(Console.ReadLine(), table);
                            if (check)
                            {
                                Console.WriteLine("Элемент с таким именем есть в таблице");
                            }
                            else
                            {
                                Console.WriteLine("Элемент с таким именем в таблице не найден");
                            }
                            break;
                        }
                    case 4:
                        {
                            table = Delete(table);
                            break;
                        }
                    case 5:
                        {
                            table = Add(table);
                            break;
                        }
                    case 6:
                        {
                            table.Clear();
                            Console.WriteLine("Таблица удалена");
                            break;
                        }
                    case 7:
                        {
                            TableToArray(table);
                            break;
                        }
                    case 8:
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
            } while (answer != 8);
        }
    }
}