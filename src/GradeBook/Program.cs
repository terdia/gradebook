using System;
using System.Collections.Generic;

namespace GradeBook
{

    class Program
    {
        static void Main(string[] args)
        {

            var book = new DiskBook("gradebook");
            book.GradeAdded += OnGradeAdded;

            //var diskBook = new DiskBook("gradebook");

            EnterGrades(book);

            book.PrintStatistics();

        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine($"Add grade to {book.Name}, press 'q' to compute stats");
                string input = Console.ReadLine();

                if (input.ToLower() == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            };
        }

        static void OnGradeAdded(object sender, EventArgs args){
            Console.WriteLine("A grade was added listener");
        }
    }
}
