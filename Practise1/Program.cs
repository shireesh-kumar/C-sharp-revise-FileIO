using Studentapplication.Models;
using Studentapplication.Services;


namespace Studentapplication
{
    class Program
    {
        private static string className;
        private static uint numberOfStudents;
        public static void Main()
        {

            type1: Console.WriteLine("Enter Class Name : ");
            className = Console.ReadLine();
            if(className== null || className == string.Empty) goto type1;

            type2:  Console.WriteLine("Enter valid number of students (>= 1) : ");
            numberOfStudents = (uint)Convert.ToInt32(Console.ReadLine());
            if(numberOfStudents <= 0) goto type2;

            StudentDetailsService studentDetailsService = new StudentDetailsService();
            Class classDetails = studentDetailsService.GetStudentDetails(className, numberOfStudents);

            Console.WriteLine("Class Details Entered Successfully");

            Console.WriteLine("Now writting to CSV file");
            if (studentDetailsService.SaveToCSV(@"E:\Programming and Tech Practices\C sharp Practices\", $"{className}.csv", classDetails))
                Console.WriteLine("Successfully written to CSV file ");
            else
            {
                Console.WriteLine("Error while writting to file");
            }
        }
    }
}
