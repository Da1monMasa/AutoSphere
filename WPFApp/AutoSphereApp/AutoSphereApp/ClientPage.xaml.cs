using AutoSphereApp.Classes;
using AutoSphereApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        private List<Cars> allCars;
        private User user;
        public ClientPage(User user)
        {
            InitializeComponent();
            this.user = user;
            // Получаем все марки и привязываем к комбобоксу
            var allMarks = AutoSphereEntities.GetContext().Marks.ToList();
            MarksList.ItemsSource = allMarks;
            MarksList.DisplayMemberPath = "MarkName";
            MarksList.SelectedValue = "MarkName";
            Firstname.Text = user.FirstName;
            MiddleName.Text = user.MiddleName;
            LastName.Text = user.LastName;
            PassNumbers.Text = user.PassNumber;
            PhoneNumber.Text = user.PhoneNumber;
            Email.Text = user.Email;
            ClientIdBox.Text = user.ClientID.ToString();

            // Получаем все автомобили и запоминаем их
            allCars = AutoSphereEntities.GetContext().Cars.ToList();
            List<Dates> dates = AutoSphereEntities.GetContext().Dates.ToList();
            DatesComboBox.ItemsSource = dates;
            DatesComboBox.DisplayMemberPath = "Date";
            

            // Заполняем список автомобилей по умолчанию
            UpdateCarsPage();

        }
       
        private void UpdateCarsPage()
        {
            // Создаем копию всех автомобилей, чтобы фильтровать только ее
            var currentCars = allCars.ToList();

            // Фильтруем список автомобилей по поисковому запросу
            string searchText = SearchList.Text.ToLower();
            currentCars = currentCars.Where(p => p.Model.ToLower().Contains(searchText) || p.Mark.ToLower().Contains(searchText)).ToList();

            // Фильтруем список автомобилей по состоянию "В наличии"
            if (ActualCars.IsChecked == true)
            {
                currentCars = currentCars.Where(p => p.Actuality == "В наличии").ToList();
            }

            // Фильтруем список автомобилей по состоянию "Под заказ"
            if (PodZakaz.IsChecked == true)
            {
                currentCars = currentCars.Where(p => p.Actuality == "Под заказ").ToList();
            }

            // Фильтруем список автомобилей по выбранной марке
            var selectedMark = MarksList.SelectedItem as Marks;
            if (selectedMark != null)
            {
                string selectedBrand = selectedMark.MarkName;
                currentCars = currentCars.Where(p => p.Mark == selectedBrand).ToList();
            }

            // Обновляем список автомобилей на странице
            CarsViewPanel.ItemsSource = currentCars;
        }

        private void ActualCars_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdateCarsPage();
            ClientDataPAnel.Visibility = Visibility.Collapsed;
        }

        private void SearchList_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateCarsPage();
            ClientDataPAnel.Visibility = Visibility.Collapsed;
        }

        private void MarksList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateCarsPage();
            ClientDataPAnel.Visibility = Visibility.Collapsed;
        }

        private void ActualCars_Checked(object sender, RoutedEventArgs e)
        {
            UpdateCarsPage();
            ClientDataPAnel.Visibility = Visibility.Collapsed;
        }

        private void PodZakaz_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdateCarsPage();
            ClientDataPAnel.Visibility = Visibility.Collapsed;
        }

        private void PodZakaz_Checked(object sender, RoutedEventArgs e)
        {

            UpdateCarsPage();
            ClientDataPAnel.Visibility = Visibility.Collapsed;
        }

        private void ResetFilters_Click(object sender, RoutedEventArgs e)
        {
            // Сбрасываем значения фильтров и поискового поля
            SearchList.Text = "";
            MarksList.SelectedIndex = -1;
            ActualCars.IsChecked = false;
            PodZakaz.IsChecked = false;

            // Сбрасываем сортировку
            CollectionViewSource.GetDefaultView(CarsViewPanel.ItemsSource).SortDescriptions.Clear();

            // Сбрасываем фильтры
            CollectionViewSource.GetDefaultView(CarsViewPanel.ItemsSource).Filter = null;
            ClientDataPAnel.Visibility = Visibility.Collapsed;
            // Обновляем список автомобилей на странице
            UpdateCarsPage();
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

        private void CarsViewPanel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = CarsViewPanel.SelectedItem as Cars;
            if (selected != null)
            {
                var view = CollectionViewSource.GetDefaultView(CarsViewPanel.ItemsSource);
                view.Filter = item => item == selected;
                ClientDataPAnel.Visibility = Visibility.Visible;

               
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var selected = CarsViewPanel.SelectedItem as Cars;
            var selectedDate = DatesComboBox.SelectedItem as Dates;
            DateTime? date = selectedDate?.Date;
            decimal discount = selected.Cost.Value * (decimal)0.005;
            decimal discountedPrice = selected.Cost.Value - discount;

            // Выводим данные в MessageBox с учетом скидки
            string message = "Марка: " + selected.Mark + "\n" +
                             "Модель: " + selected.Model + "\n" +
                             "Год выпуска: " + selected.Year + "\n" +
                             "Цвет: " + selected.Color + "\n" +
                             "Цена: " + discount.ToString("#.##") + " руб. (Цена теста-драйва составляет 0.5% от общей стоимости автомобиля ";

            MessageBoxResult result = MessageBox.Show(message, "Подтверждение данных", MessageBoxButton.YesNo, MessageBoxImage.Question);
            var currentUser = AutoSphereEntities.GetContext().Users.FirstOrDefault(u => u.ClientID == user.ClientID);
            if (currentUser == null)
            {
                return;
            }
            var newTestDrive = new TestDrive
            {
               
                CarID = selected.CarID,
                //Data = selectedDate.Value,
                ClientID = currentUser.ClientID,
                Price = discount,
                Data = date // явное преобразование типа
            };
            AutoSphereEntities.GetContext().TestDrives.Add(newTestDrive);
            AutoSphereEntities.GetContext().SaveChanges();
            Cart.ItemsSource = AutoSphereEntities.GetContext().TestDrives.Where(td => td.ClientID == currentUser.ClientID).ToList();
            if (result == MessageBoxResult.No)
            {
                // Если данные неверны, можно снова скрыть ClientDataPAnel
                ClientDataPAnel.Visibility = Visibility.Collapsed;
            }
        }
        private bool isSortedAscending = false;

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Получаем текущий список автомобилей из ItemsSource
            var currentCars = CarsViewPanel.ItemsSource as List<Cars>;

            // Сортируем список автомобилей в зависимости от флага
            if (!isSortedAscending)
            {
                currentCars = currentCars.OrderBy(p => p.Cost).ToList();
                isSortedAscending = true;
            }
            else
            {
                currentCars = currentCars.OrderByDescending(p => p.Cost).ToList();
                isSortedAscending = false;
            }

            // Обновляем список автомобилей на странице
            CarsViewPanel.ItemsSource = currentCars;

        }

    }
}
