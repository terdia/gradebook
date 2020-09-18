using System;
using System.Collections.Generic;

namespace GradeBook
{

    class Program
    {
        static void Main(string[] args)
        {

            var book = new Book("Terry's grade book");

            Console.WriteLine($"Add grades to {book.Name}, when done press Q to compute stats");
            string input = Console.ReadLine();

            while (input.ToUpper() != "Q")
            {
                book.AddGrade(double.Parse(input));
                input = Console.ReadLine();
            };

            book.PrintStatistics();

        }
    }
}
