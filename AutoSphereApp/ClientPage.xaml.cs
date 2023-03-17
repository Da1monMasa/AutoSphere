using AutoSphereApp.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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

namespace AutoSphereApp
{
    /// <summary>
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        public ClientPage()
        {
            InitializeComponent();
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Window newWindow = new MainWindow();
            Application.Current.MainWindow = newWindow;
            newWindow.Show();
            Window currentwindow = Window.GetWindow(this);
            currentwindow.Close();
        }
    }
}
