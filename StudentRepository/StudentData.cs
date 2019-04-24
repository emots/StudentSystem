using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlTypes;

namespace StudentRepository
{
    public static class StudentData
    {
        //public static List<Student> Students
        //{ get; private set; }

        //public static void SetSomeUsers()
        //{
        //    Students = new List<Student>();

        //    Students.Add(new Student("Petko", "Petrov", "Georgiev", "fkst", "ksi", "bechelor", 0, "121216093", 1, 9, 46));
        //    Students[0].LastGrade = DateTime.Now;
        //    Students[0].LastMonthOfPay = DateTime.Now;
        //    Students.Add(new Student("Aleksandar", "Petrov", "Todorov", "fkst", "ksi", "bechelor", 1, "121216544", 4, 9, 46));
        //    Students[1].LastGrade = DateTime.Now;
        //    Students[1].LastMonthOfPay = DateTime.Now;
        //    Students.Add(new Student("Venci", "Georgiev", "Rosenov", "fkst", "ksi", "bechelor", 1, "121216545", 3, 9, 46));
        //    Students[2].LastGrade = new DateTime(2014, 4, 12);
        //    Students[2].LastMonthOfPay = DateTime.Now;
        //}

        //IS THERE STUDENT
        public static Student IsThereStudent(string fakNumber)
        {
            StudentContext context = new StudentContext();

            Student student = (from stud in context.Students
                               where stud.FakNumber.Equals(fakNumber)
                               select stud).FirstOrDefault();
            return student;
        }

        //PREPARE CERTIFICATE
        public static void PrepareCertificate(string fakNumber)
        {
            StringBuilder certificate = new StringBuilder();
            Student student = IsThereStudent(fakNumber);
            if (student != null)
            {
                certificate.Append("Certificate!\n");
                certificate.Append("Студент: " + student.FirstName + " " + student.SecondName + " " + student.ThirdName + "\n" +
                                       "Факултет: " + student.Faculty + "\n" +
                                    "Специалност: " + student.Specialty + "\n" +
                                    "Успешно завърши курс: " + student.Course + "\n" +
                                    "Статус: " + (status)student.Status + "\n");

                SaveCertificate(certificate);

            }
            //return certificate;
        }

        //SAVE CERTIFICATE
        public static void SaveCertificate(StringBuilder certificate)
        {
            if (File.Exists("certificate.txt") == true)
            {
                //Console.WriteLine(certificate.ToString());
                File.AppendAllText("certificate.txt", certificate.ToString() + Environment.NewLine);
            }
            else
            {
                Console.WriteLine("Error with file!");
            }
        }

        //CERTIFICATE TO ALL
        public static void CertificateToAll()
        {
            List<Student> graduateStudents = new List<Student>();
            StudentContext context = new StudentContext();

            foreach (Student item in context.Students)
            {

                if (item.LastGrade.Value.Year == DateTime.Now.Year)
                {
                    if (item.LastMonthOfPay.Value.Month == DateTime.Now.Month)
                    {
                        if (item.Course < 4)
                        {
                            item.Status = 1;
                            PrepareCertificate(item.FakNumber);
                            item.Course += 1;

                        }
                        else if (item.Course == 4)
                        {
                            item.Status = 3;
                            PrepareCertificate(item.FakNumber);
                            //To Remove(item);
                            graduateStudents.Add(item);
                        }
                        else
                        {
                            Console.WriteLine("Wrong course of: {0}", item.FakNumber);
                        }
                    }
                    else
                    {
                        Console.WriteLine("The student {0} first have to pay!");
                    }
                }
                else
                {
                    Console.WriteLine("The student {0} don't have grade", item.FakNumber);
                    item.Status = 2;
                }
            }

            //remove students who already graduate
            foreach (Student item in graduateStudents)
            {
                //Students.Remove(item);
                Student delObj = (from st in context.Students
                                  where st.FakNumber == item.FakNumber
                                  select st).First();
                context.Students.Remove(delObj);
            }
            context.SaveChanges();
        }
    }
}
