using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;

namespace StudentRepository
{
    public class StudentValidation
    {
        public static Student GetStudentDataByUser(User user)
        {
            if (user.FakNum != null)
            {
                StudentContext context = new StudentContext();

                Student stud = (from item in context.Students
                                where item.FakNumber.Equals(user.FakNum)
                                select item).FirstOrDefault();

                if (stud == null)
                {
                    Console.WriteLine("There is no such student!");
                }
                return stud;
            }
            else
            {
                Console.WriteLine("No fak Number!");
                return null;
            }
        }
    }
}
