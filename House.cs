using System;

namespace Lab2
{
    internal class House
    {
        private int floors;

        public House(int floors)
        {
            this.floors = floors;
        }

        public int Floors
        {
            get
            {
                return this.floors;
            }
        }

        public override string ToString()
        {
            string word = "этажами";
            if (this.floors % 10 == 1 && this.floors % 100 != 11)
            {
                word = "этажом";
            }
            return "дом с " + this.floors + " " + word;
        }
    }
}
