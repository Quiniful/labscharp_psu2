using System;
using System.Collections.Generic;

namespace Lab2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("=== Задание 1.4 Время ===");
            int timeCount = ReadPositiveInt(
                "Сколько значений времени вывести: ");
            int timeIndex = 0;
            int seconds = 0;
            Time time = null;
            for (timeIndex = 0; timeIndex < timeCount; timeIndex++)
            {
                seconds = ReadNonNegativeInt(
                    "Введите количество секунд: ");
                time = new Time(seconds);
                Console.WriteLine(time);
            }

            Console.WriteLine("\n=== Задание 1.5 Дом ===");
            ShowHouses("Введите количество домов: ");

            Console.WriteLine("\n=== Задание 2.4 Сотрудники и отделы ===");
            List<Employee> allEmployees = ReadEmployees();
            List<Department> departments =
                WorkWithDepartment(allEmployees);

            Console.WriteLine("\n=== Задание 3.4 Список сотрудников отдела ===");
            PrintDepartmentEmployees(departments);

            Console.WriteLine("\n=== Задание 4.3 Создаем Дом ===");
            ShowHouses("Введите количество домов: ");
            Console.WriteLine("Изменить количество этажей нельзя - у класса нет сеттера.");

            Console.WriteLine("\n=== Задание 5.1 Пистолет ===");
            Console.WriteLine("Создать пистолет:");
            Console.WriteLine("1 - без указания патронов (по умолчанию 5)");
            Console.WriteLine("2 - с указанием количества патронов");
            int gunChoice = ReadIntInRange("Ваш выбор (1-2): ", 1, 2);

            Gun gun = null;
            if (gunChoice == 1)
            {
                gun = new Gun();
            }
            else
            {
                int bullets = ReadNonNegativeInt("Введите начальное количество патронов: ");
                gun = new Gun(bullets);
            }

            int shots = ReadNonNegativeInt("Введите количество выстрелов: ");
            int j = 0;
            for (j = 0; j < shots; j++)
            {
                gun.Shoot();
            }
        }

        private static void ShowHouses(string message)
        {
            int count = ReadPositiveInt(message);
            int index = 0;
            int floors = 0;
            House house = null;
            for (index = 0; index < count; index++)
            {
                floors = ReadPositiveInt("Введите количество этажей: ");
                house = new House(floors);
                Console.WriteLine(house);
            }
        }

        private static List<Employee> ReadEmployees()
        {
            List<Employee> employees = new List<Employee>();
            int count = ReadPositiveInt("Введите количество сотрудников: ");
            int index = 0;
            string name = "";
            Employee employee = null;
            for (index = 0; index < count; index++)
            {
                name = ReadUniqueName(
                    "Введите имя сотрудника: ", employees);
                employee = new Employee(name);
                employees.Add(employee);
            }
            return employees;
        }

        private static List<Department> WorkWithDepartment(
            List<Employee> employees)
        {
            List<Department> departments =
                new List<Department>();
            int command = -1;
            while (command != 0)
            {
                Console.WriteLine(
                    "1 - Назначить сотрудника в отдел");
                Console.WriteLine(
                    "2 - Назначить начальника отдела");
                Console.WriteLine(
                    "3 - Вывести сотрудников отдела");
                Console.WriteLine("0 - Продолжить");
                command = ReadIntInRange("Команда: ", 0, 3);
                if (command == 1)
                {
                    AssignEmployee(employees, departments);
                }
                if (command == 2)
                {
                    AssignBoss(employees, departments);
                }
                if (command == 3)
                {
                    PrintDepartmentEmployees(departments);
                }
            }
            return departments;
        }

        private static void AssignEmployee(
            List<Employee> employees,
            List<Department> departments)
        {
            Department department = SelectDepartment(departments);
            string employeeName = ReadNonEmptyString(
                "Введите имя сотрудника: ");
            Employee employee = FindEmployee(
                employees, employeeName);
            while (employee == null)
            {
                Console.WriteLine("Такого сотрудника нет.");
                employeeName = ReadNonEmptyString(
                    "Введите имя сотрудника: ");
                employee = FindEmployee(employees, employeeName);
            }
            employee.Department = department;
            Console.WriteLine("Сотрудник назначен в отдел.");
        }

        private static Department SelectDepartment(
            List<Department> departments)
        {
            int choice = 0;
            string name = "";
            Department department = null;
            if (departments.Count == 0)
            {
                name = ReadNonEmptyString(
                    "Введите название нового отдела: ");
                department = new Department(name, null);
                departments.Add(department);
                return department;
            }
            Console.WriteLine("0 - Создать новый отдел");
            PrintDepartmentNames(departments);
            choice = ReadIntInRange(
                "Выберите отдел: ", 0, departments.Count);
            if (choice == 0)
            {
                name = ReadNonEmptyString(
                    "Введите название нового отдела: ");
                department = new Department(name, null);
                departments.Add(department);
                return department;
            }
            return departments[choice - 1];
        }

        private static void PrintDepartmentNames(
            List<Department> departments)
        {
            int index = 0;
            for (index = 0; index < departments.Count; index++)
            {
                Console.WriteLine((index + 1) + " - "
                    + departments[index].Name);
            }
        }

        private static void AssignBoss(
            List<Employee> employees,
            List<Department> departments)
        {
            Department department = null;
            if (departments.Count == 0)
            {
                Console.WriteLine(
                    "Сначала назначьте сотрудника в отдел.");
                return;
            }
            department = SelectExistingDepartment(departments);
            string bossName = ReadNonEmptyString(
                "Введите имя начальника: ");
            Employee boss = FindEmployee(employees, bossName);
            while (boss == null || boss.Department != department)
            {
                Console.WriteLine(
                    "Начальник должен быть сотрудником этого отдела.");
                bossName = ReadNonEmptyString(
                    "Введите имя начальника: ");
                boss = FindEmployee(employees, bossName);
            }
            department.Boss = boss;
            Console.WriteLine("Начальник назначен.");
        }

        private static Department SelectExistingDepartment(
            List<Department> departments)
        {
            PrintDepartmentNames(departments);
            int choice = ReadIntInRange(
                "Выберите отдел: ", 1, departments.Count);
            return departments[choice - 1];
        }

        private static void PrintDepartmentEmployees(
            List<Department> departments)
        {
            int index = 0;
            Department department = null;
            if (departments.Count == 0)
            {
                Console.WriteLine(
                    "Сначала назначьте сотрудников в отдел.");
                return;
            }
            department = SelectExistingDepartment(departments);
            if (department.Employees.Count == 0)
            {
                Console.WriteLine("В отделе нет сотрудников.");
                return;
            }
            for (index = 0; index < department.Employees.Count; index++)
            {
                Console.WriteLine(department.Employees[index]);
            }
        }

        private static Employee FindEmployee(List<Employee> employees, string name)
        {
            int i = 0;
            for (i = 0; i < employees.Count; i++)
            {
                if (employees[i].Name == name)
                {
                    return employees[i];
                }
            }
            return null;
        }

        private static int ReadNonNegativeInt(string message)
        {
            int result = 0;
            bool ok = false;
            while (!ok)
            {
                Console.Write(message);
                string input = Console.ReadLine();
                if (input == null)
                {
                    Console.WriteLine("Ошибка! Ввод прерван. Попробуйте ещё раз.");
                    continue;
                }
                input = input.Trim();
                if (input == "")
                {
                    Console.WriteLine("Ошибка! Строка пустая. Введите целое число.");
                    continue;
                }
                if (!int.TryParse(input, out result))
                {
                    Console.WriteLine("Ошибка! Введено не целое число.");
                    continue;
                }
                if (result < 0)
                {
                    Console.WriteLine("Ошибка! Число не может быть отрицательным.");
                    continue;
                }
                ok = true;
            }
            return result;
        }

        private static int ReadPositiveInt(string message)
        {
            int result = 0;
            bool ok = false;
            while (!ok)
            {
                Console.Write(message);
                string input = Console.ReadLine();
                if (input == null)
                {
                    Console.WriteLine("Ошибка! Ввод прерван. Попробуйте ещё раз.");
                    continue;
                }
                input = input.Trim();
                if (input == "")
                {
                    Console.WriteLine("Ошибка! Строка пустая. Введите целое число.");
                    continue;
                }
                if (!int.TryParse(input, out result))
                {
                    Console.WriteLine("Ошибка! Введено не целое число.");
                    continue;
                }
                if (result <= 0)
                {
                    Console.WriteLine("Ошибка! Число должно быть больше нуля.");
                    continue;
                }
                ok = true;
            }
            return result;
        }

        private static int ReadIntInRange(string message, int min, int max)
        {
            int result = 0;
            bool ok = false;
            while (!ok)
            {
                Console.Write(message);
                string input = Console.ReadLine();
                if (input == null)
                {
                    Console.WriteLine("Ошибка! Ввод прерван. Попробуйте ещё раз.");
                    continue;
                }
                input = input.Trim();
                if (input == "")
                {
                    Console.WriteLine("Ошибка! Строка пустая. Введите целое число.");
                    continue;
                }
                if (!int.TryParse(input, out result))
                {
                    Console.WriteLine("Ошибка! Введено не целое число.");
                    continue;
                }
                if (result < min || result > max)
                {
                    Console.WriteLine("Ошибка! Число должно быть от " + min + " до " + max + ".");
                    continue;
                }
                ok = true;
            }
            return result;
        }

        private static string ReadNonEmptyString(string message)
        {
            string result = "";
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();
                if (input == null)
                {
                    Console.WriteLine("Ошибка! Ввод прерван. Попробуйте ещё раз.");
                    continue;
                }
                input = input.Trim();
                if (input == "")
                {
                    Console.WriteLine("Ошибка! Строка не может быть пустой.");
                    continue;
                }
                result = input;
                break;
            }
            return result;
        }

        private static string ReadUniqueName(string message, List<Employee> employees)
        {
            string result = "";
            while (true)
            {
                result = ReadNonEmptyString(message);

                bool exists = false;
                int k = 0;
                for (k = 0; k < employees.Count; k++)
                {
                    if (employees[k].Name == result)
                    {
                        exists = true;
                    }
                }

                if (exists)
                {
                    Console.WriteLine("Ошибка! Сотрудник с именем \"" + result + "\" уже существует.");
                    continue;
                }

                break;
            }
            return result;
        }
    }
}