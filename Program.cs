using System;
using System.Collections.Generic;

namespace Lab2
{
    internal class Program
    {
        public Program()
        {
        }

        private static void Main(string[] args)
        {
            // Задание 1.4 Время
            Console.WriteLine("=== Задание 1.4 Время ===");
            Time time1 = new Time(10);
            Time time2 = new Time(10000);
            Time time3 = new Time(100000);
            Console.WriteLine(time1);
            Console.WriteLine(time2);
            Console.WriteLine(time3);

            // Задание 1.5 Дом
            Console.WriteLine("\n=== Задание 1.5 Дом ===");
            House house1 = new House(1);
            House house2 = new House(5);
            House house3 = new House(23);
            Console.WriteLine(house1);
            Console.WriteLine(house2);
            Console.WriteLine(house3);

            // Задание 2.4 Сотрудники и отделы
            Console.WriteLine("\n=== Задание 2.4 Сотрудники и отделы ===");
            Employee petrov = new Employee("Петров");
            Employee kozlov = new Employee("Козлов");
            Employee sidorov = new Employee("Сидоров");
            Department it = new Department("IT", kozlov);
            petrov.Department = it;
            kozlov.Department = it;
            sidorov.Department = it;
            Console.WriteLine(petrov);
            Console.WriteLine(kozlov);
            Console.WriteLine(sidorov);

            // Задание 3.4 Список сотрудников отдела
            Console.WriteLine("\n=== Задание 3.4 Список сотрудников отдела IT ===");
            List<Employee> itEmployees = petrov.GetDepartmentEmployees();
            int i = 0;
            for (i = 0; i < itEmployees.Count; i++)
            {
                Console.WriteLine(itEmployees[i].Name);
            }

            // Задание 4.3 Создаем Дом
            Console.WriteLine("\n=== Задание 4.3 Создаем Дом ===");
            House house4 = new House(2);
            House house5 = new House(35);
            House house6 = new House(91);
            Console.WriteLine(house4);
            Console.WriteLine(house5);
            Console.WriteLine(house6);
            // house4.Floors = 10; - нельзя, у свойства Floors нет сеттера
            Console.WriteLine("Изменить количество этажей нельзя - у класса нет сеттера.");

            // Задание 5.1 Пистолет стреляет
            Console.WriteLine("\n=== Задание 5.1 Пистолет ===");
            Gun gun = new Gun(3);
            int j = 0;
            for (j = 0; j < 5; j++)
            {
                gun.Shoot();
            }
        }
    }
}