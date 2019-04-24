using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UserLogin;
using StudentRepository;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;


namespace StudentInfoSystem
{   
    public partial class InfoWindow : Window
    {
        public Student Stud { get; set; }

        public InfoWindow(Student std)
        {
            InitializeComponent();
            
            if (std != null)
            {
                Stud = std;
                this.DataContext = std;
            }
        }      
           
        private void Btn_log_out_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Visibility = Visibility.Collapsed;
            main.ShowDialog();
            this.Visibility = Visibility.Visible;
            this.Close();
        }

        //public List<string> StudStatusChoices { get; set; }
        //private void FillStudStatusChoices()
        //{
        //    StudStatusChoices = new List<string>();

        //    using (IDbConnection connection = new
        //        SqlConnection(Properties.Settings.Default.DbConnect))
        //    {
        //        string sqlquery =
        //            @"SELECT StatusDescr
        //              FROM StudStatus";

        //        IDbCommand command = new SqlCommand();
        //        command.Connection = connection;
        //        connection.Open();

        //        command.CommandText = sqlquery;
        //        IDataReader reader = command.ExecuteReader();

        //        bool notEndOfResult;

        //        notEndOfResult = reader.Read();
        //        while (notEndOfResult)
        //        {
        //            string s = reader.GetString(0);
        //            StudStatusChoices.Add(s);
        //            notEndOfResult = reader.Read();
        //        }
        //    }
        //}

        //private void CopyStudents()
        //{
        //    StudentInfoContext context = new StudentInfoContext();
        //    IEnumerable<Student> queryStudents = context.Students;

        //    int countStudents = queryStudents.Count();

        //    if (countStudents == 0)
        //    {
        //        foreach (Student student in StudentData.Students)
        //        {
        //            context.Students.Add(student);
        //        }
        //        context.SaveChanges();
        //    }          

        //}
        //private void CopyUsers()
        //{
        //    StudentInfoContext context = new StudentInfoContext();
        //    IEnumerable<User> queryUsers = context.Users;

        //    int countUsers = queryUsers.Count();
        //    if (countUsers==0)
        //    {
        //        foreach (User user in UserData.Users)
        //        {
        //            context.Users.Add(user);
        //        }
        //        context.SaveChanges();
        //    }
        //}        
    }
}
