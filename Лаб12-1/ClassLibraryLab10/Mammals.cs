using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClassLibraryLab10
{
    public class Mammals : Animals, IInit
    {
        protected double weight;

        public double Weight
        {
            get => weight;
            private set
            {
                if (value <= 0)
                {
                    weight = 1;
                }
                else
                {
                    weight = value;
                }
            }
        }

        public Mammals() : base()
        {
            Weight = 1;
        }

        public Mammals(int id, string name, string gender, int age, float weight) : base(id, name, gender, age)
        {
            Weight = weight;
        }

        override public void Show()
        {
            Console.WriteLine($"Млекопитающее: имя: {Name}, пол:{Gender}, возраст: {Age} лет, вес: {Weight} кг.");
        }

        public override void Init()
        {
            base.Init();
            double tempDouble;
            bool isConvert;
            do
            {
                isConvert = double.TryParse(Input("вес"), out tempDouble);
            } while (!isConvert);
            if (tempDouble != -1)
            {
                Weight = tempDouble;
            }
        }
        public override void RandomInit()
        {
            base.RandomInit();
            Weight = Random.NextDouble() * 50;
            Weight = Math.Round(Weight, 2);
        }
        public override string ToString()
        {
            return $"Млекопитающее: имя: {Name}, пол:{Gender}, возраст: {Age} лет, вес: {Weight} кг.";
        }
        public override bool Equals(object obj)
        {
            if (obj is Mammals animal)
            {
                return animal.Name == Name && animal.Gender == Gender && animal.Age == Age && animal.Weight == Weight;
            }
            else
            {
                return false;
            }
        }
    }
}
