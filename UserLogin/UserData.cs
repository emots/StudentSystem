using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public static class UserData
    {

        public static User IsUserPassCorrect(string name, string pass)
        {
            UserContext context = new UserContext();

            User user = (from item in context.Users
                         where item.Username.Equals(name)
                         where item.Password.Equals(pass)
                         select item).FirstOrDefault();
            return user;
        }

        public static void SetUserActiveTo(int index, DateTime dt)
        {
            UserContext context = new UserContext();
            User usr = (from u in context.Users
                        where u.UserId == (index + 1)
                        select u).First();
            usr.ActiveTo = dt;
            context.SaveChanges();

            usr.toPrint();
            Console.WriteLine(usr.ActiveTo.Value.ToLongTimeString());

            Logger.LogActivity("Change in  " + usr.Username + " activity!");
        }

        public static void AssignUserRole(int index, roles role)
        {
            UserContext context = new UserContext();
            User usr = (from u in context.Users
                        where u.UserId == (index + 1)
                        select u).First();
            usr.Role = (int)role;
            context.SaveChanges();
            Logger.LogActivity("Change " + usr.Username + " role!");
        }

        public static Dictionary<string, int> AllUsersNames()
        {
            UserContext context = new UserContext();
            Dictionary<string, int> result = new Dictionary<string, int>();
            int i = 0;
            foreach (User user in context.Users)
            {
                result.Add(user.Username, i);
                i++;
            }
            return result;
        }

        //private static List<User> _users;

        //public static List<User> Users
        //{
        //    get
        //    {
        //        ResetTestUserData();
        //        return _users;
        //    }
        //    set { }
        //}

        //private static void ResetTestUserData()
        //{
        //    _users = new List<User>();
        //    _users.Add(new User("Aleks", "123456", "121216544", 1));
        //    _users[0].Created = DateTime.Now;
        //    _users[0].ActiveTo = DateTime.MaxValue;
        //    _users.Add(new User("Petko", "123456", "121216093", 4));
        //    _users[1].Created = DateTime.Now;
        //    _users[1].ActiveTo = DateTime.MaxValue;
        //    _users.Add(new User("Venci", "123456", "121216545", 4));
        //    _users[2].Created = DateTime.Now;
        //    _users[2].ActiveTo = DateTime.MaxValue;
        //}
    }
}
