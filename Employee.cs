using System;
using System.Collections.Generic;

namespace Lab2
{
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
            get
            {
                return this.name;
            }
        }

        public Department Department
        {
            get
            {
                return this.department;
            }
            set
            {
                if (this.department == value)
                {
                    return;
                }
                if (this.department != null)
                {
                    this.department.RemoveEmployee(this);
                }
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
                return this.name + " начальник отдела "
                    + this.department.Name;
            }
            if (this.department.Boss == null)
            {
                return this.name + " работает в отделе "
                    + this.department.Name
                    + ", начальник не назначен";
            }
            return this.name + " работает в отделе "
                + this.department.Name + ", начальник которого "
                + this.department.Boss.Name;
        }
    }
}
