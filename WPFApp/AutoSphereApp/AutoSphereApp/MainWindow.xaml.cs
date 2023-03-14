using AutoSphereApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new LogINPage());
            Manager.MainFrame = MainFrame;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
           
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {

            MainFrame.Navigate(new RegPage());
        }   

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }
        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                BackButton.Visibility = Visibility.Visible;
                
            }
            else
            {
                BackButton.Visibility = Visibility.Hidden;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            MainFrame.Navigate(new RegPage());
            Manager.MainFrame = MainFrame;
        }
        private void QuitButton_Click(object sender, EventArgs e)
        {
            Manager.MainFrame = MainFrame;
        }

        
    }
}
