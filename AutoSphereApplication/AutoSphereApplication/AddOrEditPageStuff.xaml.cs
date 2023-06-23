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
    /// Логика взаимодействия для AddOrEditPageStuff.xaml
    /// </summary>
    public partial class AddOrEditPageStuff : Page
    {
        private Stuff _currentStuff = null;

        private bool _isNew = false;
        public AddOrEditPageStuff(Stuff currentStuff)
        {
            InitializeComponent();
            if (currentStuff != null)
            {
                _currentStuff = currentStuff;
                DataContext = _currentStuff;
            }
            else
            {
                _isNew = true;
                _currentStuff = new Stuff();
                DataContext = _currentStuff;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_currentStuff.StaffID == 0 && !_isNew)
            {
                MessageBox.Show("Выберите запись для редактирования или создайте новую.");
                return;
            }

            try
            {
                AutoSphereBDEntities1 context = AutoSphereBDEntities1.GetContext();

                if (_isNew)
                {
                    context.Stuff.Add(_currentStuff);
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
