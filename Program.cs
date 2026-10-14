using Lab2;

internal class Program
{
    private static void Main(string[] args)
    {
        Program program = new Program();
        program.Run();
    }

    public void Run()
    {
        int choice = -1;
        while (choice != 0)
        {
            Console.WriteLine();
            Console.WriteLine("Лабораторная работа №2");
            Console.WriteLine("Вариант 6");
            Console.WriteLine("1 - Задание 1.4. Время");
            Console.WriteLine("2 - Задание 1.5. Дом");
            Console.WriteLine("3 - Задание 2.4. Сотрудники");
            Console.WriteLine("4 - Задание 3.4. Список отдела");
            Console.WriteLine("5 - Задание 4.3. Дом");
            Console.WriteLine("6 - Задание 5.1. Пистолет");
            Console.WriteLine("7 - Показать все задачи");
            Console.WriteLine("0 - Выход");

            choice = ReadInt("Ваш выбор: ");
            if (choice == 7)
            {
                ShowAll();
            }
            else
            {
                ShowTask(choice);
            }
        }
    }

    private void ShowTask(int choice)
    {
        switch (choice)
        {
            case 1:
                ShowTime();
                break;
            case 2:
                ShowHouseFirst();
                break;
            case 3:
                ShowDepartment();
                break;
            case 4:
                ShowEmployees();
                break;
            case 5:
                ShowHouseFourth();
                break;
            case 6:
                ShowGun();
                break;
            case 0:
                break;
            default:
                Console.WriteLine("Нет такой задачи.");
                break;
        }
    }

    private void ShowAll()
    {
        int number = 1;
        while (number <= 6)
        {
            ShowTask(number);
            number++;
        }
    }

    private int ReadInt(string message)
    {
        string input = "";
        int value = 0;
        bool valid = false;
        while (!valid)
        {
            Console.Write(message);
            input = Console.ReadLine();
            if (input == null)
            {
                return 0;
            }
            valid = int.TryParse(input, out value);
            if (!valid)
            {
                Console.WriteLine("Введите целое число.");
            }
        }
        return value;
    }

    private void ShowTime()
    {
        Time first = new Time(10);
        Time second = new Time(10000);
        Time third = new Time(100000);
        Console.WriteLine("Задание 1.4. Время");
        Console.WriteLine(first);
        Console.WriteLine(second);
        Console.WriteLine(third);
    }

    private void ShowHouseFirst()
    {
        House first = new House(1);
        House second = new House(5);
        House third = new House(23);
        Console.WriteLine("Задание 1.5. Дом");
        Console.WriteLine(first);
        Console.WriteLine(second);
        Console.WriteLine(third);
    }

    private void ShowDepartment()
    {
        Department department = new Department("IT");
        Employee petrov = new Employee("Петров", department);
        Employee kozlov = new Employee("Козлов", department);
        Employee sidorov = new Employee("Сидоров", department);
        department.Manager = kozlov;
        Console.WriteLine("Задание 2.4. Сотрудники");
        Console.WriteLine(petrov);
        Console.WriteLine(kozlov);
        Console.WriteLine(sidorov);
    }

    private void ShowEmployees()
    {
        Department department = new Department("IT");
        Employee first = new Employee("Петров", department);
        Employee second = new Employee("Козлов", department);
        Employee third = new Employee("Сидоров", department);
        department.Manager = second;
        Employee[] employees = first.Department.Employees;
        int index = 0;
        Console.WriteLine("Задание 3.4. Список отдела");
        for (index = 0; index < employees.Length; index++)
        {
            Console.WriteLine(employees[index].Name);
        }
        Console.WriteLine(third);
    }

    private void ShowHouseFourth()
    {
        House first = new House(2);
        House second = new House(35);
        House third = new House(91);
        Console.WriteLine("Задание 4.3. Дом");
        Console.WriteLine(first);
        Console.WriteLine(second);
        Console.WriteLine(third);
        Console.WriteLine("Количество этажей нельзя изменить:");
        Console.WriteLine(
            "Свойство Floors доступно только для чтения.");
    }

    private void ShowGun()
    {
        Gun gun = new Gun(3);
        int shot = 0;
        Console.WriteLine("Задание 5.1. Пистолет");
        for (shot = 0; shot < 5; shot++)
        {
            gun.Shoot();
        }
    }
}
