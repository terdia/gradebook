using System;
using System.Collections.Generic;

namespace GradeBook
{

    public class Statistics
    {
        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }

        public double Highest;
        public double Lowest;
        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var d when d >= 90.0:
                        return 'A';

                    case var d when d >= 80.0:
                        return 'B';

                    case var d when d >= 70.0:
                        return 'C';

                    case var d when d >= 60.0:
                        return 'D';

                    default:
                        return 'F';

                }
            }
        }
        public double Sum;
        public int Count;

        public Statistics()
        {

            Highest = double.MinValue;
            Lowest = double.MaxValue;
            Sum = 0.0;
            Count = 0;
        }

        public void Add(double number)
        {
            Sum += number;
            Count += 1;
            Highest = Math.Max(number, Highest);
            Lowest = Math.Min(number, Lowest);
        }
    }
}