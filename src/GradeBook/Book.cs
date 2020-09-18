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
            if (grade <= 100 && grade >= 0)
            {
                this.grades.Add(grade);
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }

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

            if (this.grades.Count < 1)
            {
                return result;
            }

            var sum = 0.0;
            foreach (var grade in this.grades)
            {
                result.Highest = Math.Max(grade, result.Highest);
                result.Lowest = Math.Min(grade, result.Lowest);

                sum += grade;
            }

            result.Average = sum / this.grades.Count;
            result.Letter = this.GetLetterGradeFromAverage(result.Average);

            return result;
        }

        public void PrintStatistics()
        {
            var stats = this.GetStatistics();

            System.Console.WriteLine($"The highest grade is {stats.Highest}");
            System.Console.WriteLine($"The lowest grade is {stats.Lowest}");
            System.Console.WriteLine($"The average grade is {stats.Average:N1}");
            System.Console.WriteLine($"The letter grade is {stats.Letter}");
        }

        public char GetLetterGradeFromAverage(double average)
        {
            char letterGrade;

            switch (average)
            {
                case var d when d >= 90.0:
                    letterGrade = 'A';
                    break;
                case var d when d >= 80.0:
                    letterGrade = 'B';
                    break;
                case var d when d >= 70.0:
                    letterGrade = 'C';
                    break;
                case var d when d >= 60.0:
                    letterGrade = 'D';
                    break;
                default:
                    letterGrade = 'F';
                    break;
            }

            return letterGrade;
        }
    }
}