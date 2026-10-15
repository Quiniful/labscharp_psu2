using System;
using System.Collections.Generic;

namespace Lab2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("=== Задание 1.4 Время ===");
            int sec1 = ReadNonNegativeInt("Введите количество секунд: ");
            Time time1 = new Time(sec1);
            Console.WriteLine(time1);
            int sec2 = ReadNonNegativeInt("Введите количество секунд: ");
            Time time2 = new Time(sec2);
            Console.WriteLine(time2);
            int sec3 = ReadNonNegativeInt("Введите количество секунд: ");
            Time time3 = new Time(sec3);
            Console.WriteLine(time3);

            Console.WriteLine("\n=== Задание 1.5 Дом ===");
            ShowHouses("Введите количество домов: ");

            Console.WriteLine("\n=== Задание 2.4 Сотрудники и отделы ===");
            List<Employee> allEmployees = ReadEmployees();
            WorkWithDepartment(allEmployees);

            Console.WriteLine("\n=== Задание 3.4 Список сотрудников отдела ===");
            PrintDepartmentEmployees(allEmployees);

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

        private static void WorkWithDepartment(
            List<Employee> employees)
        {
            int command = -1;
            while (command != 0)
            {
                Console.WriteLine("1 - Назначить отдел");
                Console.WriteLine("2 - Вывести сотрудников отдела");
                Console.WriteLine("0 - Продолжить");
                command = ReadIntInRange("Команда: ", 0, 2);
                if (command == 1)
                {
                    AssignDepartment(employees);
                }
                if (command == 2)
                {
                    PrintDepartmentEmployees(employees);
                }
            }
        }

        private static void AssignDepartment(
            List<Employee> employees)
        {
            string departmentName = ReadNonEmptyString(
                "Введите название отдела: ");
            string bossName = ReadNonEmptyString(
                "Введите имя начальника: ");
            Employee boss = FindEmployee(employees, bossName);
            while (boss == null)
            {
                Console.WriteLine("Такого сотрудника нет.");
                bossName = ReadNonEmptyString(
                    "Введите имя начальника: ");
                boss = FindEmployee(employees, bossName);
            }
            Department department = new Department(
                departmentName, boss);
            int index = 0;
            for (index = 0; index < employees.Count; index++)
            {
                employees[index].Department = department;
            }
            Console.WriteLine("Отдел назначен.");
        }

        private static void PrintDepartmentEmployees(
            List<Employee> employees)
        {
            int index = 0;
            if (employees.Count == 0)
            {
                Console.WriteLine("Сотрудников нет.");
                return;
            }
            if (employees[0].Department == null)
            {
                Console.WriteLine("Сначала назначьте отдел командой 1.");
                return;
            }
            List<Employee> departmentEmployees =
                employees[0].GetDepartmentEmployees();
            for (index = 0; index < departmentEmployees.Count; index++)
            {
                Console.WriteLine(departmentEmployees[index]);
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