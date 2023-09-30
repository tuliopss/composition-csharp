// See https://aka.ms/new-console-template for more information
using ContractExercise.Entities;
using ContractExercise.Entities.Enums;
using System.Globalization;

Console.Write("Enter department's name:");
string department = Console.ReadLine();

Console.WriteLine("Enter worker data:");
Console.Write("Name:");
string name = Console.ReadLine();

Console.Write("Level (Junior/MidLevel/Senior):");
WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());

Console.Write("Base Salary:");
double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

Department dept = new Department(department);
Worker w = new Worker(name, level, baseSalary, dept);

Console.WriteLine("How many contracts to this worker?");
int n = int.Parse(Console.ReadLine());

for (int i = 1; i <= n; i++) {
    Console.WriteLine("Enter #" +i + "contract data");
    Console.Write("Date (DD/MM/YYYY)");
    DateTime date = DateTime.Parse(Console.ReadLine());

    Console.Write("Value per hour: ");
    double valuePerHour = double.Parse(Console.ReadLine());

    Console.Write("Duration (hours): ");
    int hours = int.Parse(Console.ReadLine());

    HourContract contract = new HourContract(date, valuePerHour, hours);
    w.AddContract(contract);

}
Console.WriteLine();

Console.Write("Enter month and year to calculate income (MM/YYYY):");
string monthAndYear = Console.ReadLine();
int month = int.Parse(monthAndYear.Substring(0, 2));
int year = int.Parse(monthAndYear.Substring(3));

Console.WriteLine("Name: " + w.Name);
Console.WriteLine("Department: " + w.Department.Name);
Console.WriteLine($"Income for {monthAndYear}: {w.Income(month, year).ToString("f2")}");