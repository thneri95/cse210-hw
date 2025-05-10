using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Business Account Manager";
        job1._company = " Banco Santander";
        job1._startYear = 2017;
        job1._endYear = 2021;

        Job job2 = new Job();
        job2._jobTitle = "Personal Banker | Investment Consultant";
        job2._company = "T2 Group";
        job2._startYear = 2021;
        job2._endYear = 2025;

        Job job3 = new Job();
        job3._jobTitle = "Comercial Executive - IT Solutions";
        job3._company = "ClearSale SA";
        job3._startYear = 2024;
        job3._endYear = 2025;

        Resume myResume = new Resume();
        myResume._name = "Tiago Borges";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);
        myResume._jobs.Add(job3);

        myResume.Display();







    }
}