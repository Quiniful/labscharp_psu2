using System;

namespace Lab2
{
    internal class House
    {
        private int _floors;

        public House(int floors)
        {
            _floors = floors;
        }

        public int Floors
        {
            get
            {
                return _floors;
            }
        }

        public override string ToString()
        {
            string word = "этажами";
            if (_floors % 10 == 1 && _floors % 100 != 11)
            {
                word = "этажом";
            }
            return "дом с " + _floors + " " + word;
        }
    }
}
