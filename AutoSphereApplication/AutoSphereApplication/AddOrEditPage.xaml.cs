using AutoSphereApplication.Classes;
using AutoSphereApplication.Models;
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

namespace AutoSphereApplication
{
    /// <summary>
    /// Логика взаимодействия для AddOrEditPage.xaml
    /// </summary>
    public partial class AddOrEditPage : Page
    {
        private Cars _currentCars = null;
      
        private bool _isNew = false;

        public AddOrEditPage(Cars currentCars)
        {
            InitializeComponent();

            if (currentCars != null)
            {
                _currentCars = currentCars;
                DataContext = _currentCars;
            }
            else
            {
                _isNew = true;
                _currentCars = new Cars();
                DataContext = _currentCars;
            }

        }
       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_currentCars.CarID == 0 && !_isNew)
            {
                MessageBox.Show("Выберите запись для редактирования или создайте новую.");
                return;
            }

            try
            {
                AutoSphereBDEntities1 context = AutoSphereBDEntities1.GetContext();

                if (_isNew)
                {
                    context.Cars.Add(_currentCars);
                }

                context.SaveChanges();
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
