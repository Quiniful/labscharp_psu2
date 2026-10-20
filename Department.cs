using System;
using System.Collections.Generic;

namespace Lab2
{
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
            get
            {
                return this.name;
            }
        }

        public Employee Boss
        {
            get
            {
                return this.boss;
            }
            set
            {
                this.boss = value;
            }
        }

        public List<Employee> Employees
        {
            get
            {
                return this.employees;
            }
        }

        public override string ToString()
        {
            return this.name;
        }

        public void AddEmployee(Employee employee)
        {
            if (!this.employees.Contains(employee))
            {
                this.employees.Add(employee);
            }
        }

        public void RemoveEmployee(Employee employee)
        {
            this.employees.Remove(employee);
            if (this.boss == employee)
            {
                this.boss = null;
            }
        }
    }
}
