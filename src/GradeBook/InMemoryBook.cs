using System;
using System.Collections.Generic;

namespace GradeBook
{

    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class InMemoryBook : Book
    {

        public InMemoryBook(string name) : base(name)
        {
            this.Name = name;
            this.grades = new List<double>() { };
        }

        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                this.grades.Add(grade);

                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }

        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            var result = new Statistics();
            if (grades.Count < 1)
            {
                return result;
            }


            foreach (var grade in grades)
            {
                result.Add(grade);
            }

            return result;
        }

        public override event GradeAddedDelegate GradeAdded;

        private List<double> grades;

    }

}