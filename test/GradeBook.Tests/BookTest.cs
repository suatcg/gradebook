using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTest
    {
        [Fact]
        public void BookCalculateAnAverageGrade()
        {
            // arrange
            /*
            var x = 5;
            var y = 2;
            var expected = 7;
            */
            var book = new InMemoryBook("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

              


            // act 
            // var actual = x * y;// failure
            // var actual = x + y;//  pass
            var result = book.GetStatistics();  


            // assert
            //Assert.Equal(expected, actual);  
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);  
            Assert.Equal(77.3, result.Low, 1);
            Assert.Equal('B',result.Letter);


        }
    }
}
