using System;
using System.Collections.Generic;

namespace Lab2
{
    internal class Time
    {
        private int seconds;

        public Time(int seconds)
        {
            this.seconds = seconds;
        }

        public override string ToString()
        {
            int totalSeconds = this.seconds % 86400;
            int hours = totalSeconds / 3600;
            int minutes = (totalSeconds % 3600) / 60;
            int secs = totalSeconds % 60;
            string result = hours.ToString("00") + ":" + minutes.ToString("00") + ":" + secs.ToString("00");
            return result;
        }
    }

    internal class House
    {
        private int floors;

        public House(int floors)
        {
            this.floors = floors;
        }

        public int Floors
        {
            get { return this.floors; }
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

    internal class Employee
    {
        private string name;
        private Department department;

        public Employee(string name)
        {
            this.name = name;
            this.department = null;
        }

        public string Name
        {
            get { return this.name; }
        }

        public Department Department
        {
            get { return this.department; }
            set
            {
                this.department = value;
                if (value != null)
                {
                    value.AddEmployee(this);
                }
            }
        }

        public List<Employee> GetDepartmentEmployees()
        {
            if (this.department == null)
            {
                return new List<Employee>();
            }
            return this.department.Employees;
        }

        public override string ToString()
        {
            if (this.department == null)
            {
                return this.name + " не работает в отделе";
            }
            if (this.department.Boss == this)
            {
                return this.name + " начальник отдела " + this.department.Name;
            }
            return this.name + " работает в отделе " + this.department.Name + ", начальник которого " + this.department.Boss.Name;
        }
    }

    internal class Department
    {
        private string name;
        private Employee boss;
        private List<Employee> employees;

        public Department(string name, Employee boss)
        {
            this.name = name;
            this.boss = boss;
            this.employees = new List<Employee>();
        }

        public string Name
        {
            get { return this.name; }
        }

        public Employee Boss
        {
            get { return this.boss; }
        }

        public List<Employee> Employees
        {
            get { return this.employees; }
        }

        public void AddEmployee(Employee employee)
        {
            if (!this.employees.Contains(employee))
            {
                this.employees.Add(employee);
            }
        }
    }

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