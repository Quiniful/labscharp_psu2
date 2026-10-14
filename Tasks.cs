namespace Lab2;

internal class Time
{
    private int seconds;

    public Time(int seconds)
    {
        this.seconds = seconds % 86400;
        if (this.seconds < 0)
        {
            this.seconds += 86400;
        }
    }

    public int Hours
    {
        get { return this.seconds / 3600; }
    }

    public int Minutes
    {
        get { return this.seconds / 60 % 60; }
    }

    public int Seconds
    {
        get { return this.seconds % 60; }
    }

    public override string ToString()
    {
        return $"{Hours}:{Minutes:00}:{Seconds:00}";
    }
}

internal class House
{
    private readonly int floors;

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
        int lastTwo = this.floors % 100;
        int last = this.floors % 10;
        string word = "этажей";
        if (lastTwo < 11 || lastTwo > 14)
        {
            if (last == 1)
            {
                word = "этаж";
            }
            if (last >= 2 && last <= 4)
            {
                word = "этажа";
            }
        }
        return $"дом с {this.floors} {word}";
    }
}

internal class Department
{
    private string name;
    private Employee manager;
    private Employee[] employees;

    public Department(string name)
    {
        this.name = name;
        this.manager = null;
        this.employees = new Employee[0];
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public Employee Manager
    {
        get { return this.manager; }
        set { this.manager = value; }
    }

    public Employee[] Employees
    {
        get { return this.employees; }
    }

    public void AddEmployee(Employee employee)
    {
        int index = 0;
        int length = this.employees.Length + 1;
        Employee[] result = new Employee[length];
        for (index = 0; index < this.employees.Length; index++)
        {
            if (this.employees[index] == employee)
            {
                return;
            }
            result[index] = this.employees[index];
        }
        result[this.employees.Length] = employee;
        this.employees = result;
    }

    public override string ToString()
    {
        return this.name;
    }
}

internal class Employee
{
    private string name;
    private Department department;

    public Employee(string name, Department department)
    {
        this.name = name;
        this.department = department;
        this.department.AddEmployee(this);
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public Department Department
    {
        get { return this.department; }
        set { this.department = value; }
    }

    public override string ToString()
    {
        string result = this.name;
        if (this.department.Manager == this)
        {
            return result + " начальник отдела "
                + this.department;
        }
        result += " работает в отделе " + this.department;
        result += ", начальник которого ";
        if (this.department.Manager == null)
        {
            return result + "не назначен";
        }
        return result + this.department.Manager.Name;
    }
}

internal class Gun
{
    private int bullets;

    public Gun()
        : this(5)
    {
    }

    public Gun(int bullets)
    {
        this.bullets = bullets;
    }

    public int Bullets
    {
        get { return this.bullets; }
    }

    public void Shoot()
    {
        if (this.bullets > 0)
        {
            Console.WriteLine("Бах!");
            this.bullets--;
        }
        else
        {
            Console.WriteLine("Клац!");
        }
    }

    public override string ToString()
    {
        return "Патронов: " + this.bullets;
    }
}
