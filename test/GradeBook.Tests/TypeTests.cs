using System;
using Xunit;

namespace GradeBook.Tests
{

    public delegate string WriteLogDelegate(string message);

    public class TypeTests
    {

        [Fact]
        public void WriteLogDelegateTest()
        {
            WriteLogDelegate log = LogMessage;

            var result = log("Works");
            Assert.Equal("Works", result);

        }

        string LogMessage(string message)
        {
            return message;
        }


        //value type test
        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string x = "Scott";
            var upper = MakeUppercase(x);

            Assert.Equal("Scott", x);
            Assert.Equal("SCOTT", upper);
        }

        private string MakeUppercase(string x)
        {
            return x.ToUpper();
        }

        [Fact]
        public void ValueTypeIsAlwaysPassByValue()
        {
            var x = GetInt();

            Assert.Equal(3, x);

            SetInt(ref x);
            Assert.Equal(10, x);
        }

        private int GetInt()
        {
            return 3;
        }

        private void SetInt(ref int x)
        {
            x = 10;
        }

        //reference type tests
        [Fact]
        public void CSharpCanPassByReference()
        {

            var book = GetBook("book");
            GetSetNameByRef(ref book, "New name");

            Assert.Equal("New name", book.Name);

        }


        private void GetSetNameByRef(ref Book book, string newName)
        {
            book = new Book(newName);
            book.Name = newName;
        }


        [Fact]
        public void CSharpIsPassByValueByDefault()
        {

            var book = GetBook("book");
            GetSetName(book, "New name");

            Assert.NotEqual("New name", book.Name);

        }

        private void GetSetName(Book book, string newName)
        {
            book = new Book(newName); // points to a different reference in memory
            book.Name = newName;
        }


        [Fact]
        public void CanChangeNameFromReference()
        {

            var book = GetBook("book");
            SetName(book, "New name"); //pass by value.

            Assert.Equal("New name", book.Name);

        }

        private void SetName(Book book, string newName)
        {
            book.Name = newName;
        }


        [Fact]
        public void GetBookReturnsDifferentObjects()
        {

            var book1 = GetBook("book1");
            var book2 = GetBook("book2");

            Assert.Equal("book1", book1.Name);
            Assert.Equal("book2", book2.Name);
            Assert.NotSame(book1, book2);

        }


        [Fact]
        public void TwoVariabesCanRefSameObjects()
        {

            var book1 = GetBook("book1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));

        }

        private Book GetBook(string name)
        {
            return new Book(name);
        }
    }

}
