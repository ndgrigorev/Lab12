using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLab10
{
    public class IdNumber
    {
        int number;
        public int Number
        {
            get => number;
            set
            {
                if (value < 0)
                {
                    number = 0;
                }
                else
                {
                    number = value;
                }
            }
        }
        public IdNumber(int number)
        {
            Number = number;
        }
        public override string ToString()
        {
            return Number.ToString();
        }
        public override bool Equals(object obj)
        {
            if (obj is IdNumber num)
            {
                return num.Number == Number;
            }
            else
            {
                return false;
            }
        }
    }
    public class Animals : IInit, IComparable, ICloneable
    {
        protected static Random Random = new Random();
        protected string name;
        protected string gender;
        protected int age;
        public IdNumber Id { get; set; }

        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age
        {
            get => age;
            private set
            {
                if (value < 0)
                {
                    age = 0;
                }
                else
                {
                    age = value;
                }
            }
        }
        public Animals()
        {
            Id = new IdNumber(1);
            Name = "Безымянный";
            Gender = "мужской";
            Age = 0;
        }
        public Animals(int id, string name, string gender, int age)
        {
            Id = new IdNumber(id);
            Name = name;
            Gender = gender;
            Age = age;
        }
        public Animals(Animals animals)
        {
            Id = animals.Id;
            Name = animals.Name;
            Gender = animals.Gender;
            Age = animals.Age;
        }
        virtual public void Show()
        {
            Console.WriteLine($"Животное: имя: {Name}, пол:{Gender}, возраст: {Age} лет");
        }
        protected string Input(string output)
        {
            Console.WriteLine($"Введите {output} (введите -1, если не хотите менять текущее значение)");
            string temp = Console.ReadLine();
            return temp;
        }
        virtual public void Init()
        {
            int tempInt;
            bool isConvert;
            do
            {
                isConvert = int.TryParse(Input("id"), out tempInt);
            } while (!isConvert);
            if (tempInt != -1)
            {
                Id = new IdNumber(tempInt);
            }
            string temp = Input("имя");
            if (temp != "-1")
            {
                Name = temp;
            }
            temp = Input("пол");
            if (temp != "-1")
            {
                Gender = temp;
            }
            do
            {
                isConvert = int.TryParse(Input("возраст"), out tempInt);
            } while (!isConvert);
            if (tempInt != -1)
            {
                Age = tempInt;
            }
        }
        virtual public void RandomInit()
        {
            Age = Random.Next(100);
            if (Random.Next(2) == 0)
            {
                Gender = "мужской";
            }
            else
            {
                Gender = "женский";
            }
            string[] names = {"Белла", "Макс", "Луна", "Рекс", "Лола", "Барсик", "Мурка", "Джек", "Мишка", "Бобик", "Джесси", "Тайсон",
                "Симба", "Коко", "Чарли", "Люси", "Рокки", "Джаззи", "Грейси", "Оливер", "Лео", "Джулия", "Руби", "Бэйли", "Мия", "Чарли", "Пушок", "Снежок" };
            Name = names[Random.Next(names.Length)];
            Id = new IdNumber(Random.Next(1, 100000000));
        }
        public override bool Equals(Object obj)
        {
            if (obj is Animals animal)
            {
                return animal.Id.Number == Id.Number && animal.Name == Name && animal.Gender == Gender && animal.Age == Age;
            }
            else
            {
                return false;
            }
        }
        public override string ToString()
        {
            return $"Животное: id: {Id}, имя: {Name}, пол:{Gender}, возраст: {Age} лет";
        }

        public static double SrWeight(Animals[] animals)
        {
            double sum = 0;
            int count = 0;
            foreach (Animals animal in animals)
            {
                if (animal is Mammals mammal)
                {
                    if (mammal.Gender == "мужской")
                    {
                        sum += mammal.Weight;
                        count++;
                    }
                }
            }
            return Math.Round(sum / count, 2);
        }

        public static string[] SpecialCats(Animals[] animals)
        {
            string[] names = new string[animals.Length];
            int j = 0;
            foreach (Animals animal in animals)
            {
                Cats cat = animal as Cats;
                if (cat != null)
                {
                    if (cat.Color == "рыжий" && cat.Gender == "женский")
                    {
                        names[j++] = cat.Name;
                    }
                }
            }
            return names;
        }
        public static string ElderFish(Animals[] animals)
        {
            int maxAge = -1;
            string name = null;
            foreach (Animals animal in animals)
            {
                if (typeof(Fishes) == animal.GetType())
                {
                    Fishes fish = (Fishes)animal;
                    if (fish.TypeOfFish == "морская")
                    {
                        if (fish.Age > maxAge)
                        {
                            maxAge = fish.Age;
                            name = fish.Name;
                        }
                    }
                }
            }
            return name;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return -1;
            if (obj is Animals animals)
            {
                return string.Compare(Name, animals.Name);
            }
            else
            {
                return -1;
            }
        }

        public object Clone()
        {
            return new Animals(Id.Number, Name, Gender, Age);
        }
        public object ShallowCopy()
        {
            return MemberwiseClone();
        }
    }
}
