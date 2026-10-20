using System;
using System.Collections.Generic;

namespace Lab2
{
    internal class Employee
    {
        private string _name;
        private Department _department;

        public Employee(string name)
        {
            _name = name;
            _department = null;
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public Department Department
        {
            get
            {
                return _department;
            }
            set
            {
                if (_department == value)
                {
                    return;
                }
                if (_department != null)
                {
                    _department.RemoveEmployee(this);
                }
                _department = value;
                if (value != null)
                {
                    value.AddEmployee(this);
                }
            }
        }

        public List<Employee> GetDepartmentEmployees()
        {
            if (_department == null)
            {
                return new List<Employee>();
            }
            return _department.Employees;
        }

        public override string ToString()
        {
            if (_department == null)
            {
                return _name + " не работает в отделе";
            }
            if (_department.Boss == this)
            {
                return _name + " начальник отдела "
                    + _department.Name;
            }
            if (_department.Boss == null)
            {
                return _name + " работает в отделе "
                    + _department.Name
                    + ", начальник не назначен";
            }
            return _name + " работает в отделе "
                + _department.Name + ", начальник которого "
                + _department.Boss.Name;
        }
    }
}
