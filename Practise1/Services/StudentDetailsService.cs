using System;
using Studentapplication.Models;

namespace Studentapplication.Services
{
    public class StudentDetailsService
    {
        private Class classDetails;
        private Student studentDetails;
        public Class GetStudentDetails(string className, uint numberOfStudents)
        {
            classDetails = new Class();
            classDetails.Roster = new List<Student>();

            for (byte i = 1; i<= numberOfStudents; i++)
            {
                studentDetails = new Student();
                Console.WriteLine("Enter Student" + i + "Details");
                Console.WriteLine("Enter Valid First Name : ");
                Type1: var firstName = Console.ReadLine();
                if (firstName == null) goto Type1;


                Type2:  Console.WriteLine("Enter Valid Last Name: ");
                var lastName = Console.ReadLine();
                if(lastName == null) goto Type2;


                type3:  Console.WriteLine("Enter valid number of tests appeared by the student (>=1)");
                uint num = (uint)Convert.ToInt32(Console.ReadLine());
                if (num <= 0) goto type3;

                studentDetails.FirstName = firstName;
                studentDetails.LastName = lastName;
                studentDetails.Grades = new List<TestResult>();

                for(byte j = 1;j<=num;j++)
                {
                    Console.WriteLine("Enter test "+j+" type :");
                    var type = Console.ReadLine();
                    Console.WriteLine("Enter number grade :");
                    uint grade = (uint)Convert.ToInt32(Console.ReadLine());
                    studentDetails.Grades.Add(new TestResult() {TestTitle = type,Score = grade});
                }
                classDetails.Roster.Add(studentDetails);
            }
            return classDetails;

        }

        public bool SaveToCSV(string filepath, string fileName, Class cl)
        {
            
            try
            {
                byte count = 1;
                string completePath = Path.Combine(filepath, fileName);
                StreamWriter writer = new StreamWriter(completePath, true);
                //Console.WriteLine("Complete file path: " + completePath);
                writer.WriteLine("SlNo,FN,LN,TT,TS");
                foreach (Student s in cl.Roster)
                {
                    foreach(TestResult t in s.Grades)
                    {
                        //Console.WriteLine("Grades count for " + s.FirstName + " " + s.LastName + ": " + s.Grades.Count);
                        writer.WriteLine( $"{count++}"+","+s.FirstName+ "," + s.LastName+","+ t.TestTitle+","+t.Score);
                    }
                }
                writer.Close();



                string line;


                List<Dictionary<string,string>> StudentDataFromCSVFile = new List<Dictionary<string, string>>();
                
                using (StreamReader reader = new StreamReader(completePath))
                {   //Dummy reaad for headers
                    line = reader.ReadLine();

                    while((line = reader.ReadLine()) != null )
                    {
                        var data = line.Split(',');
                        var dictionaryData = new Dictionary<string, string>
                        {
                            { "SLNO", data[0] },
                            { "FN", data[1] },
                            { "LN", data[2] },
                            { "TT", data[3] },
                            { "TS", data[4] }
                        };

                        StudentDataFromCSVFile.Add(dictionaryData);
                        Console.WriteLine(line); 
                    }
                }

                foreach(var i in StudentDataFromCSVFile)
                {
                   Console.WriteLine(i["SLNO"]);
                }

                Console.WriteLine("Lecture Name " + fileName.Split(".csv")[0]);
                Console.WriteLine(System.IO.Directory.GetCurrentDirectory());

                // Playing with data from csv file


                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
