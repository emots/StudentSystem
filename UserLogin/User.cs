using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FakNum { get; set; }
        public int Role { get; set; }
        public DateTime? Created { get; set; } 
        public DateTime? ActiveTo { get; set; }

        public User()
        {

        }

        public User(string name, string pass, string fakNumber, int roleOfUser)
        {
            Username = name;
            Password = pass;
            FakNum = fakNumber;
            Role = roleOfUser;
        }

        public void toPrint()
        {
            Console.WriteLine("Name: {0}, FakNumber: {1}, Role: {2}\n", Username, FakNum, (roles)Role);
        }
    }
}
