using System;
using System.Collections.Generic;

namespace GradeBook
{

    class Program
    {
        static void Main(string[] args)
        {

            var book = new Book("Terry's grade book");
            book.AddGrade(56.3);
            book.AddGrade(10.4);
            book.AddGrade(12.7);

            book.ShowStatistics();

        }
    }
}
