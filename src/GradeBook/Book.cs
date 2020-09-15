using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Book
    {
        private List<double> grades;
        private string name;

        public Book(string name)
        {
            this.name = name;
            this.grades = new List<double>() { };
        }

        public void AddGrade(double grade)
        {
            this.grades.Add(grade);
        }

        public List<double> GetGrades()
        {
            return this.grades;
        }

        public void ShowStatistics()
        {
            var result = 0.0;
            var highGrade = double.MinValue;
            var lowGrade = double.MaxValue;

            foreach (var item in this.grades)
            {
                highGrade = Math.Max(item, highGrade);
                lowGrade = Math.Min(item, lowGrade);

                result += item;
            }

            System.Console.WriteLine($"The highest grade is {highGrade}");
            System.Console.WriteLine($"The lowest grade is {lowGrade}");
            System.Console.WriteLine($"The average grade is {result / this.grades.Count:N1}");
        }
    }
}