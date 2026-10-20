using System;

namespace Lab2
{
    internal class Gun
    {
        private int bullets;

        public Gun()
        {
            this.bullets = 5;
        }

        public Gun(int bullets)
        {
            this.bullets = bullets;
        }

        public int Bullets
        {
            get
            {
                return this.bullets;
            }
        }

        public override string ToString()
        {
            return "Патронов: " + this.bullets;
        }

        public void Shoot()
        {
            if (this.bullets > 0)
            {
                Console.WriteLine("Бах!");
                this.bullets = this.bullets - 1;
            }
            else
            {
                Console.WriteLine("Клац!");
            }
        }
    }
}
