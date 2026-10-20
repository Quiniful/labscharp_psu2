using System;

namespace Lab2
{
    internal class Gun
    {
        private int _bullets;

        public Gun()
        {
            _bullets = 5;
        }

        public Gun(int bullets)
        {
            _bullets = bullets;
        }

        public int Bullets
        {
            get
            {
                return _bullets;
            }
        }

        public override string ToString()
        {
            return "Патронов: " + _bullets;
        }

        public void Shoot()
        {
            if (_bullets > 0)
            {
                Console.WriteLine("Бах!");
                _bullets = _bullets - 1;
            }
            else
            {
                Console.WriteLine("Клац!");
            }
        }
    }
}
