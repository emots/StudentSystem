using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UserLogin
{
    class Program
    {
        public static void errorModel(string errorMsg)
        {
            Console.WriteLine("!!! " + errorMsg + " !!!");
        }

        public static Dictionary<string, int> allusers = UserData.AllUsersNames();

        static void Main(string[] args)
        {

            //User user1 = new User("Emil", "12345", "121216092", 1);
            //user1.toPrint();
            //UserData.TestUser.toPrint();
            //DateTime dt = DateTime.MaxValue;
            //Console.WriteLine(dt.ToLongDateString());
            //DateTime dt2 = dt.AddHours(13);
            //int nextyear = dt2.Day;

            //Console.WriteLine(dt2.ToLongTimeString());
            //Console.WriteLine(nextyear);

            //string date = Console.ReadLine();
            //DateTime dt = DateTime.Parse(date);
            //Console.WriteLine(dt.ToLongDateString() + " " + dt.ToLongTimeString());

            //int ad = Convert.ToInt32( Console.ReadLine());
            //Console.WriteLine(ad);

            string name = null;
            string pass = null;

            Console.WriteLine("Enter Username:");
            name = Console.ReadLine();
            Console.WriteLine("Enter Password:");
            pass = Console.ReadLine();

            LoginValidation login = new LoginValidation(name, pass, errorModel);
            User user = null;

            if (login.ValidateUserInput(ref user))
            {
                switch ((int)LoginValidation.CurrentUserRole)
                {
                    case 0:
                        {
                            Console.WriteLine("You are {0}! There is no user with this Username!", LoginValidation.CurrentUserRole);
                            break;
                        }
                    case 1:
                        {
                            Console.WriteLine("You are {0}! you have permission to do anything!", LoginValidation.CurrentUserRole);
                            MenuAdmin();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("You are {0}! you have permission to see private data!", LoginValidation.CurrentUserRole);
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("You are {0}! you have permission to add or delete materials!", LoginValidation.CurrentUserRole);
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("You are {0}! you have permission raed materials !", LoginValidation.CurrentUserRole);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Error with your position!");
                            break;
                        }
                }
            }
        }

        private static void MenuAdmin()
        {
            Console.WriteLine("Изберете опция:");
            Console.WriteLine("0: Изход");
            Console.WriteLine("1: Промяна на роля на потребител");
            Console.WriteLine("2: Промяна на активност на потребител");
            Console.WriteLine("3: Списък потребители");
            Console.WriteLine("4: Преглед на лог на активност");
            Console.WriteLine("5: Преглед на текуща активност");

            int choice = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine(chouse);

            switch (choice)
            {
                case 0:
                    {
                        Console.WriteLine("Goodbay!");
                        break;
                    }

                case 1:
                    {
                        ChangeRole();
                        break;
                    }
                case 2:
                    {
                        ChangeActivity();
                        break;
                    }
                case 3:
                    {
                        ListUsers();
                        break;
                    }
                case 4:
                    {
                        CheckLogs();
                        break;
                    }
                case 5:
                    {
                        CurrentActivity();
                        break;
                    }

                default:
                    break;
            }
        }

        //CASE 1
        private static void ChangeRole()
        {
            string name;
            int role;
            Console.WriteLine("/n!!!!CHANGE ROLE OF USER!!!");
            Console.WriteLine("Enter Username:");
            name = Console.ReadLine();
            if (!allusers.ContainsKey(name))
            {
                Console.WriteLine("No such user!");
                MenuAdmin();
            }

            Console.WriteLine("Enter role\n1 - anonymous\n2 - admin" +
                "\n3 - inspector\n4 - professor\n5 - student");
            role = Convert.ToInt32(Console.ReadLine());

            if (role < 0 && role > 5)
            {
                Console.WriteLine("Wrong enter!!!");
                MenuAdmin();
            }

            UserData.AssignUserRole(allusers[name], (roles)(role - 1));
        }

        //CASE 2
        private static void ChangeActivity()
        {
            string name;
            string date;
            DateTime dateValid;
            Console.WriteLine("/nCHANGE ACTIVITY TO USER!");
            Console.WriteLine("Enter Username:");
            name = Console.ReadLine();

            if (!allusers.ContainsKey(name))
            {
                Console.WriteLine("No such user!");
                MenuAdmin();
            }

            Console.WriteLine("Enter date:");
            date = Console.ReadLine();

            if (DateTime.TryParse(date, out dateValid))
            {
                UserData.SetUserActiveTo(allusers[name], dateValid);
            }
            else
            {
                Console.WriteLine("Wrong date!");
                MenuAdmin();
            }
        }

        //CASE 3
        private static void ListUsers()
        {
            //Dictionary<string, int> allusers = UserData.AllUsersNames();
            Console.WriteLine("/nUSER LIST:");
            foreach (KeyValuePair<string, int> user in allusers)
            {
                Console.WriteLine(user);
            }
        }

        //CASE 4
        private static void CheckLogs()
        {
            StreamReader sr = new StreamReader("test.txt");
            StringBuilder sb = new StringBuilder();
            //string line;
            sb.Append("LOG FILE:\n");
            sb.Append(sr.ReadToEnd());
            Console.WriteLine(sb.ToString());

            //while (!sr.EndOfStream)
            //{
            //    line = sr.Console.ReadLine();
            //    Console.WriteLine(line);
            //}

            sr.Close();
        }

        //CASE 5
        private static void CurrentActivity()
        {
            Console.WriteLine("/nSEE CURRENT ACTIVITY:");
            Console.WriteLine("Enter filter:");
            string filter = Console.ReadLine();
            Logger.GetCurrentSeassionActivities(filter);
        }
    }
}
