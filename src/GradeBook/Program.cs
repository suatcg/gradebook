using System;
using System.Collections.Generic;

namespace GradeBook
{
    
    class Program
    {
        static void Main(string[] args)
        {
            /*
            var p = new Program();
            p.Main(args);
            Program.Main(args);
            // Program would run forever in an infinite loop cux
            // Main calls Main
            //  actually we wouldn't run Program will crash
            
            
            // Static member like this Main method not associatied with object 
            // static method just only way to reach from Class(associatied with clcass) as Program.Main(args);
            // we're not able to reach object reference like a p.Main(args) we'd compile eror
            */

            // var book2 = new Book();
            // var book = new InMemoryBook("Scoot's Grade Book");

            // var book = new InMemoryBook("Scott's Grade Book");
            IBook book = new DiskBook("Can's Grade Book");

            // Book bookNew =  null;
            // NewMethod(null);

            book.GradeAdded += OnGradeAdded;
            // book.GradeAdded += OnGradeAdded;
            // book.GradeAdded -= OnGradeAdded;
            // book.GradeAdded += OnGradeAdded;




            //book.GradeAdded = null;
            // we'd get compile error event doesn't allow assignment unlike delegate
            //The event can only appear on the left hand side of
            // "+=" or "-="

            // book.AddGrade(89.1);
            // book.AddGrade(90.5);
            // book.AddGrade(77.5);
            //    book.grades.Add(101);

            

            EnterGrades(book);

            var stats = book.GetStatistics();


            // Console.WriteLine(InMemoryBook.WRITER);
            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");

            // /*
            // Book.AddGrade(70.5)
            // // just only work when add grade would static we can reach
            // // out from using Book class also grades field inside of 
            // // AddGrade method needs static access modifier cuz 
            // // if AddGrade method static then field need static 
            // */


            // double x = 34.1;
            // var y = 10.3;
            // var result = x + y;
            // Console.WriteLine(result);// static method 

            // var numbers = new double[3];
            // numbers[0] = 12.7;
            // numbers[1] = 10.3;
            // numbers[2] = 6.11;

            // var numbers = new double[] {12.7,10.3,6.11,4.1};
            // var numbers = new [] {12.7,10.3,6.11,4.1};

            // var grades = new List<double>(){12.7,10.3,6.11,4.1};
            // grades.Add(56.1);



            // var resultOne = numbers[0];
            // result += numbers[1];
            // result += numbers[2];
            // Console.WriteLine(resultOne);


            // Console.WriteLine("Hello " + args[0] + "!");
            if (args.Length > 0)
                Console.WriteLine($"Hello, {args[0]}!");
            else
                Console.WriteLine("Hello!");
        }

        private static void NewMethod(IBook bookNew)
        {
            bookNew.AddGrade(90.5);
            var statsNew = bookNew.GetStatistics();


            Console.WriteLine($"For the book named {bookNew.Name}");
            Console.WriteLine($"The lowest grade is {statsNew.Low}");
            Console.WriteLine($"The highest grade is {statsNew.High}");
            Console.WriteLine($"The average grade is {statsNew.Average:N1}");
            Console.WriteLine($"The letter grade is {statsNew.Letter}");
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                    // book.AddGrade('A');
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    // throw;
                    // continue to propagate the error we're use throw.
                    // Re-throe the currenxt exception.Write out the meessage
                    // but then re-throw the exception using by throw and 
                    // program'll terminate(if we use throw)
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        { 
            Console.WriteLine("A grade was added");
        }
    }
}
