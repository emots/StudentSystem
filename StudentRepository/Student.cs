using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRepository
{
    public class Student
    {       
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string Faculty { get; set; }
        public string Specialty { get; set; }
        public string EducationClassification { get; set; }
        public string FakNumber { get; set; }
        public int Status { get; set; }
        public String GetStatus { get { return ((status)Status).ToString(); } }
        public int Flow { get; set; }
        public int Course { get; set; }
        public int Group { get; set; }
        public DateTime? LastGrade { get; set; }
        public DateTime? LastMonthOfPay { get; set; }
        public byte[] Photo { get; set; } = null;

        public Student()
        { }

        public Student(string firstName, string secondName, string thirdName, string faculty, string specialty,
            string educationClassification, int status, string fakNumber, int course, int flow, int group)
        {
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            Faculty = faculty;
            Specialty = specialty;
            EducationClassification = educationClassification;
            Status = status;
            FakNumber = fakNumber;
            Course = course;
            Flow = flow;
            Group = group;
        }

    }

}
