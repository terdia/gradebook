using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTest
    {
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            // arrange
            var book = new InMemoryBook("");
            book.AddGrade(56.3);
            book.AddGrade(10.4);
            book.AddGrade(12.7);

            //act 
            var result = book.GetStatistics();

            //assert 
            Assert.Equal(26.5, result.Average, 1);
            Assert.Equal(56.3, result.Highest, 1);
            Assert.Equal(10.4, result.Lowest, 1);
            Assert.Equal('F', result.Letter);
        }

        [Fact]
        public void AddGradeThrowsArgumentExceptionForInvalidValues()
        {
            var book = new InMemoryBook("");

            Assert.Throws<ArgumentException>(() => book.AddGrade(-4));

        }
    }
}
