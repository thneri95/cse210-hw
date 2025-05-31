using System;

class Program
{
    static void Main(string[] args)
    {
        // base
        Assignment a1 = new Assignment("Tiago Borges", "Multiplication");
        Console.WriteLine(a1.GetSummary());

        // derived class
        MathAssignment a2 = new MathAssignment("Miguel Neri", "Fractions", "7.3", "8-19");
        Console.WriteLine(a2.GetSummary());
        Console.WriteLine(a2.GetHomeworkList());

        WritingAssignment a3 = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.GetWritingInformation());
    }
}