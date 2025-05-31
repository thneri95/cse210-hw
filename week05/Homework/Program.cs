using System;

class Program
{
    static void Main(string[] args)
    {
        // base
        Assignment a1 = new Assignment("Tiago Borges", "Inheritance in C#");
        Console.WriteLine(a1.GetSummary());

        // derived class
        MathAssignment a2 = new MathAssignment("Miguel Neri", "How to use Inheritance", "8", "1-10");
        Console.WriteLine(a2.GetSummary());
        Console.WriteLine(a2.GetHomeworkList());

        WritingAssignment a3 = new WritingAssignment("Tiago Borges", "Cse-210 Programming with Classes", "Learning Activity- Inheritance");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.GetWritingInformation());
    }
}