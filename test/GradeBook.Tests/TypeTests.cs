using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void Test1()
        {
        
            var book1 = new GetBook("book1");
            var book2 = new GetBook("book2");
            
        }
    }

    private Book GetBook(string name) {
        return new Book(name);
    }
}
