using AutoSphereApplication.Classes;
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
using AutoSphereApplication.Models;
using System.Windows.Markup;
using System.Data.SqlClient;
using System.Runtime.ConstrainedExecution;
using System.Windows.Threading;

namespace AutoSphereApplication
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        int _currentPage = 1, _countInPage = 10, _maxPages;
        private DispatcherTimer timer;
        private TimeSpan timerInterval;
        private DateTime startTime;
        private bool isAttentionBoxVisible = true;

        public AdminPage()
        {
            InitializeComponent();
            CarsView.ItemsSource = AutoSphereBDEntities1.GetContext().Cars.ToList();
            StaffView.ItemsSource = AutoSphereBDEntities1.GetContext().Stuff.ToList();
            EnterHistoryView.ItemsSource = AutoSphereBDEntities1.GetContext().EnterHistory.ToList();
            ClientsView.ItemsSource = AutoSphereBDEntities1.GetContext().Clients.ToList();
            OrdersView.ItemsSource = AutoSphereBDEntities1.GetContext().Orders.ToList();
            CarsView.Visibility = Visibility.Visible;
            timer = new DispatcherTimer();
            timerInterval = TimeSpan.FromSeconds(1);
            timer.Interval = timerInterval;
            timer.Tick += Timer_Tick;

            // Запуск таймера
            startTime = DateTime.Now;
            timer.Start();


        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Обновление значения таймера
            TimeSpan elapsedTime = DateTime.Now - startTime;
            TimerLabel.Content = "Время работы: " + elapsedTime.ToString(@"hh\:mm\:ss");

            // Проверка, достигнуто ли 15 секунд
            if (elapsedTime.Seconds % 15 == 0)
            {
                // Инвертирование состояния видимости
                isAttentionBoxVisible = !isAttentionBoxVisible;

                // Обновление видимости AttentionBox и AttentionBox2
                if (isAttentionBoxVisible)
                {
                    AttentionBox.Visibility = Visibility.Visible;
                    AttentionBox2.Visibility = Visibility.Collapsed;
                }
                else
                {
                    AttentionBox.Visibility = Visibility.Collapsed;
                    AttentionBox2.Visibility = Visibility.Visible;
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {


        }
        private void RefreshData()
        {
            var data = AutoSphereBDEntities1.GetContext().Cars.ToList();
            var datastaff = AutoSphereBDEntities1.GetContext().Stuff.ToList();
            var dataEnter = AutoSphereBDEntities1.GetContext().EnterHistory.ToList();
            var dataorders = AutoSphereBDEntities1.GetContext().Orders.ToList();
            var dataclients = AutoSphereBDEntities1.GetContext().Clients.ToList();



           


            

            CarsView.ItemsSource = data;
            StaffView.ItemsSource = datastaff;
            EnterHistoryView.ItemsSource = dataEnter;
            ClientsView.ItemsSource = dataclients;
            OrdersView.ItemsSource = dataorders;

           

        }

        private void NavigateToSelectedPage(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string pageStr = btn.Content.ToString();
            int page = int.Parse(pageStr);
            _currentPage = page;
            RefreshData();
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

       /* private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ClientsPage());

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new CarsView());
        }*/

        private void BtnRedData_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddOrEditPage((sender as Button).DataContext as Cars));
        }
        private void BtnRedDataStaff_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddOrEditPageStuff((sender as Button).DataContext as Stuff));
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {

            var carsForRemoving = CarsView.SelectedItems.Cast<Cars>().ToList();

            if (MessageBox.Show($"Вы собираетесь удалить {carsForRemoving.Count()} записей", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AutoSphereBDEntities1.GetContext().Cars.RemoveRange(carsForRemoving);
                    AutoSphereBDEntities1.GetContext().SaveChanges();
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

            // Логотип предприятия
            Microsoft.Office.Interop.Word.Paragraph logoPara = wordDoc.Content.Paragraphs.Add();
            Microsoft.Office.Interop.Word.InlineShape logoShape = logoPara.Range.InlineShapes.AddPicture("C:/Users/daimo/source/repos/AutoSphereApplication/AutoSphereApplication/Resources/AutosphereLogotip.png");
            logoShape.Select();
            wordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
            logoPara.Range.InsertParagraphAfter();

            // Подпись рисунка
            Microsoft.Office.Interop.Word.Paragraph captionPara = wordDoc.Content.Paragraphs.Add();
            captionPara.Range.Text = "ООО Авто-сфера";
            captionPara.Range.Font.Bold = 1;
            captionPara.Range.Font.Size = 20;
            captionPara.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
            captionPara.Format.SpaceAfter = 5;
            captionPara.Range.InsertParagraphAfter();

            // Название таблицы
            Microsoft.Office.Interop.Word.Paragraph para = wordDoc.Content.Paragraphs.Add();
            para.Range.Text = "Список премиум автомобилей";
            para.Range.Font.Bold = 0;
            para.Format.SpaceAfter = 5;
            para.Range.InsertParagraphAfter();

            List<Cars> expensiveCars = new List<Cars>(); // Создаем список для хранения дорогих автомобилей

            // Фильтруем автомобили со стоимостью выше одного миллиона рублей
            foreach (var item in CarsView.Items)
            {
                Cars car = item as Cars;
                if (car.Cost > 1000000)
                {
                    expensiveCars.Add(car);
                }
            }

            // Таблица с данными
            Microsoft.Office.Interop.Word.Table table = wordDoc.Tables.Add(wordDoc.Bookmarks.get_Item("\\endofdoc").Range, expensiveCars.Count + 1, 5);
            table.Cell(1, 1).Range.Text = "Марка";
            table.Cell(1, 2).Range.Text = "Модель";
            table.Cell(1, 3).Range.Text = "Цвет";
            table.Cell(1, 4).Range.Text = "Стоимость";
            table.Cell(1, 5).Range.Text = "Статус";
           

            int row = 2;
            foreach (var car in expensiveCars)
            {
                table.Cell(row, 1).Range.Text = car.Mark;
                table.Cell(row, 2).Range.Text = car.Model;
                table.Cell(row, 3).Range.Text = car.Color;
                table.Cell(row, 4).Range.Text = $"{car.Cost:N2} ₽ Руб.";
                table.Cell(row, 5).Range.Text = car.Actuality;

                // Применение шрифта Times New Roman и размера 12 к каждой ячейке таблицы
                table.Cell(row, 1).Range.Font.Name = "Times New Roman";
                table.Cell(row, 1).Range.Font.Size = 12;
                table.Cell(row, 2).Range.Font.Name = "Times New Roman";
                table.Cell(row, 2).Range.Font.Size = 12;
                table.Cell(row, 3).Range.Font.Name = "Times New Roman";
                table.Cell(row, 3).Range.Font.Size = 12;
                table.Cell(row, 4).Range.Font.Name = "Times New Roman";
                table.Cell(row, 4).Range.Font.Size = 12;
                table.Cell(row, 5).Range.Font.Name = "Times New Roman";
                table.Cell(row, 5).Range.Font.Size = 12;

                row++;
            }

            // Применение шрифта Times New Roman и размера 12 к заголовку таблицы
            table.Rows[1].Range.Font.Name = "Times New Roman";
            table.Rows[1].Range.Font.Size = 12;
            // Добавление отступа после таблицы
            Microsoft.Office.Interop.Word.Paragraph afterTablePara = wordDoc.Content.Paragraphs.Add();
            afterTablePara.Range.Text = "\n"; // Вставка пустой строки (Enter)
            afterTablePara.Format.SpaceAfter = 12; // Установка отступа в 12 единиц


            // Добавляем границы к таблице
            Microsoft.Office.Interop.Word.Borders borders = table.Borders;
            borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
            borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
            borders.InsideColor = Microsoft.Office.Interop.Word.WdColor.wdColorBlack;
            borders.OutsideColor = Microsoft.Office.Interop.Word.WdColor.wdColorBlack;

            // Подпись Администратора/Менеджера
            Microsoft.Office.Interop.Word.Paragraph signaturePara = wordDoc.Content.Paragraphs.Add();
            signaturePara.Range.Text = "Подпись Администратора/Менеджера: __________________________";
            signaturePara.Range.Font.Size = 12;
            signaturePara.Format.SpaceAfter = 20;
            signaturePara.Range.InsertParagraphAfter();

            // Информация о правах
            Microsoft.Office.Interop.Word.Paragraph rightsPara = wordDoc.Content.Paragraphs.Add();
            rightsPara.Range.Text = "Все права защищены, документы Авто-сфера";
            rightsPara.Range.Font.Size = 12;
            rightsPara.Range.Font.Italic = 1;
            rightsPara.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
            rightsPara.Format.SpaceAfter = 10;
            rightsPara.Range.InsertParagraphAfter();

            Microsoft.Office.Interop.Word.Paragraph rightsParag = wordDoc.Content.Paragraphs.Add();
            rightsParag.Range.Text = "Официальный документ созданный через приложение AutosphereApplication";
            rightsParag.Range.Font.Size = 12;
            rightsParag.Range.Font.Italic = 1;
            rightsParag.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
            rightsParag.Format.SpaceAfter = 10;
            rightsParag.Range.InsertParagraphAfter();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            CarsView.Visibility = Visibility.Collapsed;
            StaffView.Visibility = Visibility.Collapsed;
            EnterHistoryView.Visibility = Visibility.Collapsed;
            OrdersView.Visibility = Visibility.Collapsed;
            ClientsView.Visibility = Visibility.Visible;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            CarsView.Visibility = Visibility.Collapsed;
            EnterHistoryView.Visibility = Visibility.Collapsed;
            OrdersView.Visibility = Visibility.Collapsed;
            ClientsView.Visibility = Visibility.Collapsed;
            StaffView.Visibility = Visibility.Visible;
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            CarsView.Visibility = Visibility.Collapsed;
            StaffView.Visibility = Visibility.Collapsed;
            EnterHistoryView.Visibility = Visibility.Visible;
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            CarsView.Visibility = Visibility.Collapsed;
            StaffView.Visibility = Visibility.Collapsed;
            EnterHistoryView.Visibility = Visibility.Collapsed;
            OrdersView.Visibility = Visibility.Visible;
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            CarsView.Visibility = Visibility.Visible;
            EnterHistoryView.Visibility = Visibility.Collapsed;
            OrdersView.Visibility = Visibility.Collapsed;
            ClientsView.Visibility = Visibility.Collapsed;
            StaffView.Visibility = Visibility.Collapsed;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Search(TxtSearch.Text);
        }
        private void Search(string searchText)
        {
            var data = AutoSphereBDEntities1.GetContext().Cars.ToList();
            // Фильтрация записей по тексту поиска
            data = data.Where(c => c.Model.ToLower().Contains(searchText.ToLower()) || c.Mark.ToLower().Contains(searchText.ToLower())).ToList();
            // Обновление данных в DataGrid
            CarsView.ItemsSource = data;
            var datastuff = AutoSphereBDEntities1.GetContext().Stuff.ToList();
            // Фильтрация записей по тексту поиска
            datastuff = datastuff
            .Where(c => c.FirstName.ToLower().Contains(searchText.ToLower())
              || c.MiddleName.ToLower().Contains(searchText.ToLower())
              || c.FirstName.ToLower().Contains(searchText.ToLower())
              || c.RoleID.ToString().Contains(searchText.ToLower())
              || c.DateOfBirth.ToString().Contains(searchText.ToLower())
              || c.Salary.ToString().Contains(searchText.ToLower())
              || c.StaffID.ToString().Contains(searchText.ToLower())
              || c.LastName.ToLower().Contains(searchText.ToLower())
              || c.ZoneID.ToString().Contains(searchText))
              
            .ToList();
            StaffView.ItemsSource = datastuff;
            var dataclients = AutoSphereBDEntities1.GetContext().Clients.ToList();
            // Обновление данных в DataGrid
            ClientsView.ItemsSource = dataclients;

            var dataClients = AutoSphereBDEntities1.GetContext().Clients.ToList();
            // Фильтрация записей по тексту поиска
            dataclients = dataclients
            .Where(c => c.FirstName.ToLower().Contains(searchText.ToLower())
              || c.MiddleName.ToLower().Contains(searchText.ToLower())
              || c.LastName.ToLower().Contains(searchText.ToLower())
              || c.PhoneNumber.ToString().Contains(searchText))

            .ToList();
            // Обновление данных в DataGrid
            ClientsView.ItemsSource = dataClients;

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
