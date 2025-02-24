namespace Module_9;

public class Program
{
    static void Main(string[] args)
    {
        var employee1 = new Employee { Id = 1, Name = "Иван", Experience = 2, Salary = 10_000 };
        var employee2 = new Employee { Id = 2, Name = "Петр", Experience = 5, Salary = 120_000 };
        var employee3 = new Employee { Id = 2, Name = "Степан", Experience = 15, Salary = 210_000 };
        var employees = new List<Employee>
        {
            employee1, employee2, employee3
        };

        Employee.PromoteEmployee(employees, employee => employee.Experience >= 5);
    }
}

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Experience { get; set; }
    public int Salary { get; set; }

    public static void PromoteEmployee(List<Employee> employees, Predicate<Employee> isEmployeeEligible)
    {
        foreach (var employee in employees)
        {
            if (isEmployeeEligible(employee))
                Console.WriteLine($"Сотрудник {employee.Name} повышен");
        }
    }
}