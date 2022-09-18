using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp0
{
    public class Student
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int NumberSchool { get; set; }
        public int FirstMark { get; set; }
        public int SecondMark { get; set; }

        public Student(string lastName, string firstName, int numberSchool, int firstMark, int secondMark)
        {
            LastName = lastName;
            FirstName = firstName;
            NumberSchool = numberSchool;
            FirstMark = firstMark;
            SecondMark = secondMark;
        }
    }
}
