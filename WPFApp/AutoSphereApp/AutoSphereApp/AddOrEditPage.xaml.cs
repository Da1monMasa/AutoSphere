using AutoSphereApp.Classes;
using AutoSphereApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
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
    /// Логика взаимодействия для AddOrEditPage.xaml
    /// </summary>
   
    public partial class AddOrEditPage : Page
    {
        private Cars _currentCars = new Cars();
        public AddOrEditPage(Cars currentCars)
        {
            InitializeComponent();
            if (currentCars != null)
            {
                _currentCars = currentCars;
               
            }
            DataContext = _currentCars;
           

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            try
            {
               // AutoSphereEntities.GetContext().Cars.Add(_currentCars);
                AutoSphereEntities.GetContext().SaveChanges();
                MessageBox.Show("Сохранено");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
