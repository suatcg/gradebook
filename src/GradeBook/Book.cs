using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
    public class NamedObject  //Object // object = same (friendly keyword)
    {
        public NamedObject(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name{get; }
        event InMemoryBook.GradeAddedDelegate GradeAdded;
        
    }

      
    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
            
        } 

        public abstract event InMemoryBook.GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
        
    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
             
        }
        public override event InMemoryBook.GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using(var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
            // writer.Close();
            // writer.Dispose();    
                if(GradeAdded != null)
                {
                    GradeAdded(this,new EventArgs()); 
                }
            } 
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            using (var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while(line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }

            return result;
        }
    }

    public class InMemoryBook : Book
    {
        public delegate void GradeAddedDelegate(object sender, EventArgs args);



        // Construction Method
        public InMemoryBook(string name) : base(name)
        {
            //WRITER = ""; which isn't assign or change anywhere if it consanant value
            category = "";
            grades = new List<double>();
            // this.name = name;
            Name = name;
        }

        // ıf we were use like below we had an eror the reason
        // return type doesn't a method signature this way we couldn't
        // overload method AddGrade(char letter) again which has to be 
        // // different paramaters or paramaters numbers
        // paramater name do not matter
        // simply the number of paramaters and this paramater type

        // public string AddGrade(char letter)
        // {
        //     return "";
        // }

        public void AddGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }
        public override void AddGrade(double grade)
        {
            if(grade <= 100 && grade >= 0)
            {
                grades.Add(grade); // same below
                // this.grades.Add(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this,new EventArgs());
                }

            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }

                
        }

        public override event GradeAddedDelegate GradeAdded;

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            
            // var resultOne = 0.0;
            // var highGrade = double.MinValue; 
            // var lowGrade = double.MaxValue;

            foreach (var grade in grades)
            {
                // if(grade == 42.1 )
                // {
                //      break;
                //      continue;
                // }

                // lowGrade = Math.Min(number,lowGrade);
                // result.Low = Math.Min(grade, result.Low);
                // highGrade = Math.Max(number,highGrade); 
                // result.High = Math.Max(grade, result.High);
                
                // result.Average += grade;
                result.Add(grade);
                // if(number > highGrade)
                // {
                //     highGrade = number;
                // }
                // resultOne += number;
            } 
            // resultOne /= grades.Count;
            // result.Average /= grades.Count; 
            // Console.WriteLine($"The lowest grade is {lowGrade}");
            // Console.WriteLine($"The highest grade is {highGrade}");
            // Console.WriteLine($"The average grade is {resultOne:N1}");

            

            return result;
        }  

        // List<double> grades = new List<double>();
        // public List<double> grades;
        private List<double> grades;

        
        // readonly field just only initialize variable like a below
        // or constructor
        readonly string category = "Science ";

        //Consonant field treated like a static members
        //u can access calling the class as a Book.WRITER
        public const string WRITER = "Gogol";

            
        // Property Long Syntax
        // public string Name
        // {
        //     get
        //     {
        //         return name;
        //     }
        //     set
        //     {
        //         if(!String.IsNullOrEmpty(value))
        //         {
        //             name = value;
        //         }
        //     }
        // }

        // private string name ;

        
    }
}