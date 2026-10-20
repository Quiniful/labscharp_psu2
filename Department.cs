using System;
using System.Collections.Generic;

namespace Lab2
{
    internal class Department
    {
        private string _name;
        private Employee _boss;
        private List<Employee> _employees;

        public Department(string name, Employee boss)
        {
            _name = name;
            _boss = boss;
            _employees = new List<Employee>();
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public Employee Boss
        {
            get
            {
                return _boss;
            }
            set
            {
                _boss = value;
            }
        }

        public List<Employee> Employees
        {
            get
            {
                return _employees;
            }
        }

        public override string ToString()
        {
            return _name;
        }

        public void AddEmployee(Employee employee)
        {
            if (!_employees.Contains(employee))
            {
                _employees.Add(employee);
            }
        }

        public void RemoveEmployee(Employee employee)
        {
            _employees.Remove(employee);
            if (_boss == employee)
            {
                _boss = null;
            }
        }
    }
}
