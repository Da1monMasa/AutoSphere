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
using System.Runtime.ConstrainedExecution;

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

            CarsView.ItemsSource = AutoSphereEntities.GetContext().Cars.ToList();

            CarsView.Visibility = Visibility.Visible;
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            
        }
        private void RefreshData()
        {
            var data = AutoSphereEntities.GetContext().Cars.ToList();

            // List<Models.Ingredient> listIngredients = _context.Ingredient.ToList();            

            _maxPages = (int)Math.Ceiling(data.Count * 1.0 / _countInPage);
            data = data.Skip((_currentPage - 1) * _countInPage).Take(_countInPage).ToList();

            LblPages.Content = $"{_currentPage}/{_maxPages}";

            CarsView.ItemsSource = data;

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
            Manager.MainFrame.Navigate(new ClientsPage());
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new CarsView());
        }

        private void BtnRedData_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddOrEditPage((sender as Button).DataContext as Cars));
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {

            var carsForRemoving = CarsView.SelectedItems.Cast<Cars>().ToList();

            if (MessageBox.Show($"Вы собираетесь удалить {carsForRemoving.Count()} записей", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AutoSphereEntities.GetContext().Cars.RemoveRange(carsForRemoving);
                    AutoSphereEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    RefreshData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var selectedItems = CarsView.SelectedItems;
            var totalPrice = selectedItems.Cast<Cars>().Sum(c => c.Cost);
            MessageBox.Show(totalPrice.ToString());
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddOrEditPage((sender as Button).DataContext as Cars));
        }

        private void CarsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
           
                // создаем окно редактирования и передаем ему выбранный объект данных
                
            
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
            wordApp.Visible = true;

            Microsoft.Office.Interop.Word.Document wordDoc = wordApp.Documents.Add();
            wordDoc.Activate();

            // Название таблицы
            Microsoft.Office.Interop.Word.Paragraph para = wordDoc.Content.Paragraphs.Add();
            para.Range.Text = "Список автомобилей";
            para.Range.Font.Bold = 1;
            para.Format.SpaceAfter = 10;
            para.Range.InsertParagraphAfter();

            // Таблица с данными
            Microsoft.Office.Interop.Word.Table table = wordDoc.Tables.Add(wordDoc.Bookmarks.get_Item("\\endofdoc").Range, CarsView.Items.Count + 1, 5);
            table.Cell(1, 1).Range.Text = "Марка";
            table.Cell(1, 2).Range.Text = "Модель";
            table.Cell(1, 3).Range.Text = "Цвет";
            table.Cell(1, 4).Range.Text = "Стоимость";
            table.Cell(1, 5).Range.Text = "Статус";

            int row = 2;
            foreach (var item in CarsView.Items)
            {
                Cars car = item as Cars;
                table.Cell(row, 1).Range.Text = car.Mark;
                table.Cell(row, 2).Range.Text = car.Model;
                table.Cell(row, 3).Range.Text = car.Color;
                table.Cell(row, 4).Range.Text = car.Cost.ToString();
                table.Cell(row, 5).Range.Text = car.Actuality;

                row++;
            }

            // Добавляем границы к таблице
            Microsoft.Office.Interop.Word.Borders borders = table.Borders;
            borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
            borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
            borders.InsideColor = Microsoft.Office.Interop.Word.WdColor.wdColorBlack;
            borders.OutsideColor = Microsoft.Office.Interop.Word.WdColor.wdColorBlack;
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
