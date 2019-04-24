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


namespace StudentInfoSystem
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            User user = UserData.IsUserPassCorrect(txtBoxName.Text, txtBoxPass.Text);
            if (user != null)
            {
                InfoWindow info = new InfoWindow(StudentData.IsThereStudent(user.FakNum));
                this.Visibility = Visibility.Collapsed;
                info.ShowDialog();
                this.Visibility = Visibility.Visible;
                this.Close();
            }
            else
            {
                MessageBox.Show("There is no such User!");
            }
        }
    }
}
