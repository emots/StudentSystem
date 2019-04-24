using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using UserLogin;
using StudentRepository;

namespace StudentInfoSystem
{
    class StudentInfoContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }

        public StudentInfoContext()
            :base(Properties.Settings.Default.DbConnect)
        {

        }
    }
}
