using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClassLibraryLab10
{
    public class Fishes : Animals, IInit
    {
        protected string typeOfFish;
        protected int numberOfFins;

        public string TypeOfFish { get; set; }
        public int NumberOfFins
        {
            get => numberOfFins;
            private set
            {
                if (value < 0)
                {
                    numberOfFins = 0;
                }
                else
                {
                    numberOfFins = value;
                }
            }
        }
        public Fishes() : base()
        {
            TypeOfFish = "пресноводная";
            NumberOfFins = 3;
        }
        public Fishes(int id, string name, string pol, int age, string typeOfFish, int numberOfFins) : base(id, name, pol, age)
        {
            TypeOfFish = typeOfFish;
            NumberOfFins = numberOfFins;
        }
        public override void Show()
        {
            Console.WriteLine($"Рыба: имя: {Name}, пол:{Gender}, возраст: {Age} лет, тип рыбы: {TypeOfFish}, кол-во плавников: {NumberOfFins}");
        }
        public override string ToString()
        {
            return $"Рыба: имя: {Name}, пол:{Gender}, возраст: {Age} лет, тип рыбы: {TypeOfFish}, кол-во плавников: {NumberOfFins}";
        }
        public override void Init()
        {
            base.Init();
            string temp = Input("тип рыбы (пресноводная или морская)");
            if (temp != "-1")
            {
                TypeOfFish = temp;
            }
            int tempInt;
            bool isConvert;
            do
            {
                isConvert = int.TryParse(Input("кол-во плавников"), out tempInt);
            } while (!isConvert);
            if (tempInt != -1)
            {
                NumberOfFins = tempInt;
            }
        }
        public override void RandomInit()
        {
            base.RandomInit();
            if (Random.Next(2) == 0)
            {
                TypeOfFish = "морская";
            }
            else
            {
                TypeOfFish = "пресноводная";
            }
            NumberOfFins = Random.Next(13);
        }
        public override bool Equals(object obj)
        {
            if (obj is Fishes animal)
            {
                return animal.Name == Name && animal.Gender == Gender && animal.Age == Age && animal.TypeOfFish == TypeOfFish && animal.NumberOfFins == NumberOfFins;
            }
            else
            {
                return false;
            }
        }
    }
}
