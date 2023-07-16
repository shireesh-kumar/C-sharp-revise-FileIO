using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentapplication.Models
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<TestResult> Grades { get; set; }
    }
}
