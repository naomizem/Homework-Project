using Homework_Project;
using static Homework_Project.Lesson4;

//Console.WriteLine();
//Console.WriteLine("-----lesson1------");
//lesson1.RunLesson1();

//Console.WriteLine("-----lesson2------");
//lesson2.RunLesson2();

//Console.WriteLine("-----lesson3------");
//lesson3.SumCalculator.RunSumCalculator();  
//lesson3.MaxCalculator.RunMaxCalculator();

Console.WriteLine("-----Lesson4------");

//Q1

int x = 5, y = 4;
Lesson4.SortTwoByComparison(ref x, ref y, (a, b) => a.CompareTo(b));
Console.WriteLine($"x: {x}, y: {y}");

int a = 8, b = 6;
Lesson4.SortTwoByIComparable(ref a, ref b);
Console.WriteLine($"a: {a}, b: {b}");

//Q2

var rowValues = new List<double> { 1, 2.0, 3.3, 4.5, 5.5 };
var colValues = new List<double> { 1, 2, 30, 4, 5 };

GenericOperationTable<double>.Operation add = (a, b) => a + b;
var tableAdd = new Lesson4.GenericOperationTable<double>(rowValues, colValues, add);
tableAdd.Calculate();
Console.WriteLine(tableAdd.ToString());

GenericOperationTable<double>.Operation multiply = (a, b) => a * b;
var tableMultiply = new Lesson4.GenericOperationTable<double>(rowValues, colValues, multiply);
tableMultiply.Calculate();
Console.WriteLine(tableMultiply.ToString());


