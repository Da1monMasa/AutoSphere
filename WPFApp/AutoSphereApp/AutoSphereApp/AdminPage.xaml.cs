using AutoSphereApp.Classes;
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
using AutoSphereApp.Models;
using System.Windows.Markup;
using System.Data.SqlClient;

namespace AutoSphereApp
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        int _currentPage = 1, _countInPage = 10, _maxPages;
        public AdminPage()
        {
            InitializeComponent();
            ClientsList.ItemsSource = AutoSphereEntities.GetContext().Clients.ToList();
            CarsList.ItemsSource = AutoSphereEntities.GetContext().Cars.ToList();
            ClientsList.Visibility = Visibility.Collapsed;
            CarsList.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ClientPage());
            
        }
        private void RefreshData()
        {
            var data = AutoSphereEntities.GetContext().Cars.ToList();

            // List<Models.Ingredient> listIngredients = _context.Ingredient.ToList();            

            _maxPages = (int)Math.Ceiling(data.Count * 1.0 / _countInPage);
            data = data.Skip((_currentPage - 1) * _countInPage).Take(_countInPage).ToList();

            LblPages.Content = $"{_currentPage}/{_maxPages}";

            CarsList.ItemsSource = data;

            ManageButtonsEnable();

        }

        private void NavigateToSelectedPage(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string pageStr = btn.Content.ToString();
            int page = int.Parse(pageStr);
            _currentPage = page;
            RefreshData();
        }
        private void ManageButtonsEnable()
        {
            BtnLastPage.IsEnabled = BtnNextPage.IsEnabled = true;
            BtnFirstPage.IsEnabled = BtnPreviousPage.IsEnabled = true;

            if (_currentPage == 1)
            {
                BtnFirstPage.IsEnabled = BtnPreviousPage.IsEnabled = false;
            }

            if (_currentPage == _maxPages)
            {
                BtnLastPage.IsEnabled = BtnNextPage.IsEnabled = false;
            }
        }

        private void BtnLastPage_Click(object sender, RoutedEventArgs e)
        {
           // if (CarsList.ItemsSource == AutoSphereEntities.GetContext().Cars.ToList())
           // {

           // }
            _currentPage = _maxPages;
            RefreshData();

        }

        private void BtnNextPage_Click(object sender, RoutedEventArgs e)
        {
            _currentPage++;
            RefreshData();
        }

        private void BtnPreviousPage_Click(object sender, RoutedEventArgs e)
        {
            _currentPage--;
            RefreshData();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if(ClientsList.Visibility == Visibility.Collapsed)
            {
                CarsList.Visibility = Visibility.Collapsed;
                ClientsList.Visibility = Visibility.Visible;
            }
            else
            {
                CarsList.Visibility = Visibility.Visible;
                ClientsList.Visibility = Visibility.Collapsed;
            }
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new CarsView());
        }

        private void BtnFirstPage_Click(object sender, RoutedEventArgs e)
        {
            _currentPage = 1;
            RefreshData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
