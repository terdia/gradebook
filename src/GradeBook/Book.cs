using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        private List<double> grades;
        public string Name; // public member Always has uppercase name 

        public Book(string name)
        {
            this.Name = name;
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

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.Highest = double.MinValue;
            result.Lowest = double.MaxValue;

            var sum = 0.0;
            foreach (var grade in this.grades)
            {
                result.Highest = Math.Max(grade, result.Highest);
                result.Lowest = Math.Min(grade, result.Lowest);

                sum += grade;
            }
            
            result.Average = sum / this.grades.Count;

            return result;
        }

        public void PrintStatistics()
        {
            var stats = this.GetStatistics();

            System.Console.WriteLine($"The highest grade is {stats.Highest}");
            System.Console.WriteLine($"The lowest grade is {stats.Lowest}");
            System.Console.WriteLine($"The average grade is {stats.Average:N1}");
        }
    }
}