using System;
using Xunit;

namespace GradeBook.Tests
{
    // Deleagate type if we invoke method which must same delegate type
    // this mean u need to retun string and take paramater string type 
    // those are have to same like a below delagate 
    //(return type and paramater type and number )
    public delegate string WriteLogDelegate(string LogMessage);

    public class TypeTests 
    {
        int count = 0;

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;

            // log = new WriteLogDelegate(ReturnMessage);
            log += ReturnMessage;
            log += IncrementCount;

            var result = log("Hello!");
            Assert.Equal("hello!", result);
            Assert.Equal(3, count);

        }

        string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }

        string ReturnMessage(string message)
        {
            count++;
            return message;
        }









        /*   
         When we pass the parameters to methods, we always those 
         paramaeters by the value.
        */
        // Reference types define by classes
        // Struct is a value type if we are find out what's the 
        // type of varieble ref or value type we could inspect of the metadata
        // (f12) varible if it's type of struct 
        //that's a value(int double float boolean DataTime) type
        // Strings are refrence type but mostyly that behaves like value type
        [Fact]
        public void ValueTypeAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(out x);

            Assert.Equal(42,x);
        }

        private void SetInt(out int z)
        {
            z = 42;        
        }

        private int GetInt()
        {
            return 3;
        }

        
        [Fact]
        public void CSharpCanPassByRef()
        {
            var book1 = GetBook("Book 1");
           GetBookSetName(ref book1,"New Name");
            
            Assert.Equal("New Name",book1.Name);
        }

        private void GetBookSetName(ref InMemoryBook book, string name)
        {
            // if we are use "out" instead of "ref" behave is the same
            // only diffrence out has taken compice eror if we 
            // dont initialize (book = new Book(name);) inside of method
            // before invoke we would
            // take an error cuz c# complier assume out paramater like a 
            // uninitialize variable we have to intialize paramater.
            book = new InMemoryBook(name);
            
        }



        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
           GetBookSetName(book1,"New Name");
            
            Assert.Equal("Book 1",book1.Name);
        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1,"New Name");
            
            Assert.Equal("New Name",book1.Name);
        }

        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            // Strings are immutable
            string name = "Scott";
            var upper = MakeUppercase(name);
            
            Assert.Equal("Scott",name);
            Assert.Equal("SCOTT",upper);

        }

        private string MakeUppercase(string paramater)
        {
            return paramater.ToUpper();
        }


        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            // var returnType = GetBook(book1.Name);
            
            Assert.Equal("Book 1",book1.Name);
            Assert.Equal("Book 2",book2.Name);
            
            Assert.NotSame(book1,book2);


        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            
            Assert.Same(book1,book2);
            Assert.True(Object.ReferenceEquals(book1, book2));

        }

        public InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
