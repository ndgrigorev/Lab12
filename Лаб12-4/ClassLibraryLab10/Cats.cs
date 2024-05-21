using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClassLibraryLab10
{
    public class Cats : Mammals, IInit
    {
        protected string breed;
        protected string color;
        protected double tailLength;

        public string Breed { get; set; }
        public string Color { get; set; }
        public double TailLength
        {
            get => tailLength;
            private set
            {
                if (value < 0)
                {
                    tailLength = 0;
                }
                else
                {
                    tailLength = value;
                }
            }
        }

        public Cats() : base()
        {
            Breed = "Сибирская";
            Color = "Белый";
            TailLength = 0.3;
        }

        public Cats(int id, string name, string gender, int age, float weight, string breed, string color, double tailLength) : base(id, name, gender, age, weight)
        {
            Breed = breed;
            Color = color;
            TailLength = tailLength;
        }
        override public void Show()
        {
            Console.WriteLine($"Кошка: имя: {Name}, пол:{Gender}, возраст: {Age} лет, вес: {Weight} кг., порода: {Breed}, окрас: {Color}, длина хвоста: {TailLength} м.");
        }
        public override string ToString()
        {
            return $"Кошка: имя: {Name}, пол:{Gender}, возраст: {Age} лет, вес: {Weight} кг., порода: {Breed}, окрас: {Color}, длина хвоста: {TailLength} м.";
        }
        public override void Init()
        {
            base.Init();
            string temp = Input("породу");
            if (temp != "-1")
            {
                Breed = temp;
            }
            temp = Input("окрас");
            if (temp != "-1")
            {
                Color = temp;
            }
            double tempDouble;
            bool isConvert;
            do
            {
                isConvert = double.TryParse(Input("длину хвоста"), out tempDouble);
            } while (!isConvert);
            if (tempDouble != -1)
            {
                TailLength = tempDouble;
            }
        }
        public override void RandomInit()
        {
            base.RandomInit();
            string[] catBreeds = {"Сиамская", "Персидская", "Британская короткошерстная", "Мейн-кун", "Русская голубая",
                        "Скоттиш-фолд", "Бенгальская", "Сфинкс", "Абиссинская", "Норвежская лесная",
                        "Шотландская прямоухая", "Турецкая ангора", "Манчкин", "Ориентальная", "Рэгдолл"};
            string[] catColors = { "черный", "белый", "рыжий" };
            Breed = catBreeds[Random.Next(catBreeds.Length)];
            Color = catColors[Random.Next(catColors.Length)];
            TailLength = Random.Next(1, 101) / 100.0;
        }
        public override bool Equals(object obj)
        {
            if (obj is Cats animal)
            {
                return animal.Name == Name && animal.Gender == Gender && animal.Age == Age && animal.Weight == Weight && animal.Breed == Breed && animal.Color == Color && animal.TailLength == TailLength;
            }
            else
            {
                return false;
            }
        }
    }
}
