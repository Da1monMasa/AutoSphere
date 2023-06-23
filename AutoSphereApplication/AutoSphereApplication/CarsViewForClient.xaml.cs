using AutoSphereApplication.Classes;
using AutoSphereApplication.Models;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
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
using Paragraph = iTextSharp.text.Paragraph;
using System.Collections.ObjectModel;
using System.Runtime.ConstrainedExecution;
using System.Windows.Threading;
using System.Media;
using System.Windows.Media.Animation;

namespace AutoSphereApplication
{
    /// <summary>
    /// Логика взаимодействия для CarsView.xaml
    /// </summary>
    public partial class CarsViewForClient : System.Windows.Controls.Page
    {
        private List<Cars> allCars;
        public User user;
        private ObservableCollection<Cars> cars; // Коллекция с данными о машинах
        private int currentCarIndex; // Текущий индекс автомобиля

        public string ImagePath { get; set; }
      
       

        public CarsViewForClient(User user)
        {
            InitializeComponent();
            var allMarks = AutoSphereBDEntities1.GetContext().Marks.ToList();
            MarksList.ItemsSource = allMarks;
            MarksList.DisplayMemberPath = "MarkName";
            MarksList.SelectedValue = "MarkName";
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
            allCars = AutoSphereBDEntities1.GetContext().Cars.ToList();
            DateTime currentdata = DateTime.Now;
            List<DateTime> dates = new List<DateTime>();
            VideoPlayerMers.LoadedBehavior = MediaState.Manual;
            VideoPlayerMers.UnloadedBehavior = MediaState.Manual;
            VideoPlayerMers.Play();
            VideoPlayerAudi.LoadedBehavior = MediaState.Manual;
            VideoPlayerAudi.UnloadedBehavior = MediaState.Manual;
            VideoPlayerAudi.Play();
            StartColorAnimation();
           


            // DatesComboBox.DisplayMemberPath = "Date";
            for (int i = 0; i < 6; i++)
            {
                dates.Add(currentdata.AddDays(i));
            }
            DatesComboBox.ItemsSource = dates;
            
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
            CarsViewPanel.Visibility = Visibility.Visible;
          

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
           /* NextPhotoAudi.Visibility = Visibility.Collapsed;
            NextPhotoBmw.Visibility = Visibility.Collapsed;*/
            // Сбрасываем сортировку
            CollectionViewSource.GetDefaultView(CarsViewPanel.ItemsSource).SortDescriptions.Clear();

            // Сбрасываем фильтры
            CollectionViewSource.GetDefaultView(CarsViewPanel.ItemsSource).Filter = null;
            ClientDataPAnel.Visibility = Visibility.Collapsed;
            Calendar.Visibility = Visibility.Collapsed;
            SelectedCarTrue.Visibility = Visibility.Collapsed;
            VideoPlayerView.Visibility = Visibility.Collapsed;
            ClientDataPAnel.Visibility = Visibility.Collapsed;
            // Обновляем список автомобилей на странице
            InitializeComponent();
            UpdateCarsPage();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        /*private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Window newWindow = new MainWindow();
            Application.Current.MainWindow = newWindow;
            newWindow.Show();
            Window currentwindow = Window.GetWindow(this);
            currentwindow.Close();
        }*/

        private void CarsViewPanel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           /* var selected = CarsViewPanel.SelectedItem as Cars;
            if (selected != null)
            {
               *//* var view = CollectionViewSource.GetDefaultView(CarsViewPanel.ItemsSource);
                view.Filter = item => item == selected;*//*
                ClientDataPAnel.Visibility = Visibility.Visible;


            }*/
          

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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var selected = CarsViewPanel.SelectedItem as Cars;
            var selectedDate = DatesComboBox.SelectedItem;
            
           
            decimal discount = selected.Cost.Value * (decimal)0.005;
            decimal discountedPrice = selected.Cost.Value - discount;

            // Выводим данные в MessageBox с учетом скидки
            string message = "Марка: " + selected.Mark + "\n" +
                             "Модель: " + selected.Model + "\n" +
                             "Год выпуска: " + selected.Year + "\n" +
                             "Цвет: " + selected.Color + "\n" +
                             "Цена: " + discount.ToString("#.##") + " руб. (Цена тест-драйва составляет 0.5% от общей стоимости автомобиля) ";

            MessageBoxResult result = MessageBox.Show(message, "Подтверждение данных", MessageBoxButton.YesNo, MessageBoxImage.Question);
            
           if(result == MessageBoxResult.Yes)
            {
                var newTestDrive = new TestDrive
                {
                    TestDriveID = 1,
                    CarID = selected.CarID,
                    //Data = selectedDate.Value,
                    ClientID = 1,
                    Price = discount.ToString(),
                    Data = selectedDate.ToString(), // явное преобразование типа
                    Serv = 6
                };
                AutoSphereBDEntities1.GetContext().TestDrive.Add(newTestDrive);
                AutoSphereBDEntities1.GetContext().SaveChanges();
                var document = new iTextSharp.text.Document();

                // Создаем PDF-файл
                var output = new FileStream("Check.pdf", FileMode.Create);
                PdfWriter.GetInstance(document, output);
                var baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                var font = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL);
                // Открываем документ для редактирования
                document.Open();

                // Добавляем логотип компании
                var table = new PdfPTable(1);
                table.WidthPercentage = 50; // ширина таблицы - 100% от ширины страницы

                // добавляем изображение в ячейку
                var imageCell = new PdfPCell(iTextSharp.text.Image.GetInstance("AutosphereLogotip.png"), true);
                imageCell.HorizontalAlignment = Element.ALIGN_CENTER; // выравнивание содержимого ячейки по центру
                imageCell.Border = 0; // убираем границу ячейки
                table.AddCell(imageCell);

                // добавляем таблицу в документ
                document.Add(table);



                // Добавляем текст
                document.Add(new Paragraph("Марка: " + selected.Mark, font));
                document.Add(new Paragraph("Модель: " + selected.Model, font));
                document.Add(new Paragraph("Год выпуска: " + selected.Year, font));
                document.Add(new Paragraph("Цвет: " + selected.Color, font));
                document.Add(new Paragraph("Цена: " + discount.ToString("#.##") + " руб. (Цена тест-драйва составляет 0.5% от общей стоимости автомобиля ", font));
                document.Add(new Paragraph("Фамилия: " + MiddleName.Text, font));
                document.Add(new Paragraph("Имя: " + Firstname.Text, font));
                document.Add(new Paragraph("Отчество: " + LastName.Text, font));
                document.Add(new Paragraph("Электронная почта: " + Email.Text, font));
                document.Add(new Paragraph("Номер телефона: " + PhoneNumber.Text, font));
                document.Add(new Chunk("Подпись клиента: ______________________", font));
                document.Add(new Chunk("Подпись менеджера: _____________________", font));
                // Добавляем таблицу с QR-кодом
                var qrTable = new PdfPTable(1);
                qrTable.WidthPercentage = 50;
                var qrCode = new BarcodeQRCode("http://example.com/payment?id=123456", 200, 200, null);
                var qrImage = qrCode.GetImage();
                var qrCell = new PdfPCell(qrImage);
                qrCell.HorizontalAlignment = Element.ALIGN_CENTER;
                qrCell.Border = 0;
                qrTable.AddCell(qrCell);
                document.Add(qrTable);
                document.Add(new Paragraph("ООО 'Авто-сфера'. Все права защищены.", font));
                document.Add(new Paragraph("Этот чек является подтверждением оплаты.", font));



                // Закрываем документ
                document.Close();
                // Закрываем поток вывода
                output.Close();

                // Открываем PDF-файл
                System.Diagnostics.Process.Start("Check.pdf");
            }
           

        }
        private void Button_Click_Next(object sender, RoutedEventArgs e)
        {
            
        }

        // Обработчик события клика на кнопку "Предыдущее"
        private void Button_Click_Previous(object sender, RoutedEventArgs e)
        {
            
        }
        private int currentImageIndex = 0; // Текущий индекс изображения, начиная с 0

        private void NextPhoto_Click(object sender, RoutedEventArgs e)
        {
            if (CarsViewPanel.SelectedItem is Cars selectedCar)
            {
                // Переключение индекса изображения
                currentImageIndex++;

                // Переключение между ImagePaths и ImagePaths2, ImagePaths3 и ImagePaths4
                switch (currentImageIndex)
                {
                    
                    case 1:
                        selectedCar.ImagePaths = selectedCar.ImagePaths2;
                        break;
                    case 2:
                        selectedCar.ImagePaths = selectedCar.ImagePaths3;
                        break;
                    case 3:
                        selectedCar.ImagePaths = selectedCar.ImagePaths4;
                        break;
                    case 4:
                        selectedCar.ImagePaths = selectedCar.SalonPath1;
                        break;
                    case 5:
                        selectedCar.ImagePaths = selectedCar.SalonPath2;
                        break;
                    case 6:
                        selectedCar.ImagePaths = selectedCar.SalonPath3;
                        break;
                    case 7:
                        selectedCar.ImagePaths = selectedCar.SalonPath4;
                        break;
                    
                }

                // Обновление привязки изображения внутри DataTemplate
                var carImage = FindVisualChild<System.Windows.Controls.Image>(sender as Button);
                if (carImage != null)
                {
                    var bindingExpression = carImage.GetBindingExpression(System.Windows.Controls.Image.SourceProperty);
                    bindingExpression?.UpdateTarget();
                }

                UpdateCarsPage();

                // Переключение индекса изображения
                if (currentImageIndex > 7)
                {
                    currentImageIndex = 0;
                    UpdateCarsPage();
                }
            }
        }

      
      /*  private string GetNextImagePathFromDatabase(Cars car)
        {
            // Здесь нужно реализовать логику получения следующего пути к изображению из базы данных или другого источника
            // Можно использовать индекс или другое поле, чтобы определить следующее изображение для автомобиля
            // Вернуть путь к следующему изображению
            // Пример: return car.ImagePath2;
            return car.ImagePaths4;
        }*/
        private T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
        {
            int childCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is T typedChild)
                {
                    return typedChild;
                }
                else
                {
                    var foundChild = FindVisualChild<T>(child);
                    if (foundChild != null)
                        return foundChild;
                }
            }
            return null;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
           
            if (VideoPlayerAudi.IsMuted == true)
            {
                VideoPlayerAudi.IsMuted=false;
            }
            else
            {
                VideoPlayerAudi.IsMuted=true;
            }
        }
        private void Button_ClickMersVolume(object sender, RoutedEventArgs e)
        {

            if (VideoPlayerMers.IsMuted == true)
            {
                VideoPlayerMers.IsMuted = false;
            }
            else
            {
                VideoPlayerMers.IsMuted = true;
            }
        }
        private bool isAudiPaused = false; // Флаг состояния паузы видео Audi
        private bool isMersPaused = false; // Флаг состояния паузы видео Mers

        private void StopAudi_Click(object sender, RoutedEventArgs e)
        {
            if(isAudiPaused == false)
            {
                VideoPlayerAudi.Pause();
                isAudiPaused = true; // Сброс флага паузы
            }
            else
            {
                VideoPlayerAudi.Play();
                isAudiPaused = false;
            }
           
            
        }

        private void Back15SecAudi_Click(object sender, RoutedEventArgs e)
        {
            VideoPlayerAudi.Position -= TimeSpan.FromSeconds(15);
            if (isAudiPaused)
            {
                VideoPlayerAudi.Play();
                isAudiPaused = false; // Сброс флага паузы
            }
        }

        private void Front15SecAudi_Click(object sender, RoutedEventArgs e)
        {
            VideoPlayerAudi.Position += TimeSpan.FromSeconds(15);
            if (isAudiPaused)
            {
                VideoPlayerAudi.Play();
                isAudiPaused = false; // Сброс флага паузы
            }
        }

        private void StopMers_Click(object sender, RoutedEventArgs e)
        {
           
           
            if (isMersPaused == false)
            {
                VideoPlayerMers.Pause();
                isMersPaused = true; // Сброс флага паузы
            }
            else
            {
                VideoPlayerMers.Play();
                isMersPaused = false;
            }
        }

        private void Back15SecMers_Click(object sender, RoutedEventArgs e)
        {
            VideoPlayerMers.Position -= TimeSpan.FromSeconds(15);
            if (isMersPaused)
            {
                VideoPlayerMers.Play();
                isMersPaused = false; // Сброс флага паузы
            }
        }

        private void Front15SecMers_Click(object sender, RoutedEventArgs e)
        {
            VideoPlayerMers.Position += TimeSpan.FromSeconds(15);
            if (isMersPaused)
            {
                VideoPlayerMers.Play();
                isMersPaused = false; // Сброс флага паузы
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var selected = CarsViewPanel.SelectedItem as Cars;

            // Получите путь к изображению выбранного автомобиля
            string imagePath = selected.ImagePaths; // Здесь предполагается, что у модели Cars есть свойство ImagePath, которое содержит путь к изображению

            // Установите новое изображение для элемента SelectedCarImage
            Uri imageUri = new Uri(imagePath, UriKind.RelativeOrAbsolute);
            BitmapImage bitmapImage = new BitmapImage(imageUri);
            SelectedCarImage.Source = bitmapImage;
            CarsViewPanel.Visibility = Visibility.Collapsed;
            Calendar.Visibility = Visibility.Visible;
            SelectedCarTrue.Visibility = Visibility.Visible;
            VideoPlayerView.Visibility = Visibility.Visible;
            ClientDataPAnel.Visibility = Visibility.Visible;
            SelectedCarDescription.Text = selected.Description;
            SelectedCarVost.Content = $"{selected.Cost:N0} ₽";
            SelectedCarColor.Content = selected.Color;
            CarMark.Content = selected.Mark;
            CarModel.Content = selected.Model;
            SelectedCarTestDriveCost.Content = selected.VIN;
            SelectedCarYear.Content = selected.Year;
            SelectedCarActuality.Content = selected.Actuality;
            int driveID = (int)selected.DriveID;
            string driveText;

            switch (driveID)
            {
                case 1:
                    driveText = "Передний";
                    break;
                case 2:
                    driveText = "Задний";
                    break;
                case 3:
                    driveText = "Полный";
                    break;
                default:
                    driveText = string.Empty; // Если driveID не равно 1, 2 или 3
                    break;
            }

            SelectedCarDrive.Content = driveText;

        }
        private void StartColorAnimation()
        {
            // Создание анимации цвета
            ColorAnimationUsingKeyFrames colorAnimation = new ColorAnimationUsingKeyFrames
            {
                Duration = TimeSpan.FromSeconds(1),
                RepeatBehavior = RepeatBehavior.Forever
            };

            // Определение цветовой палитры для переливающихся цветов
            Color[] colors = { Colors.Red, Colors.Orange, Colors.Yellow, Colors.Green, Colors.Blue, Colors.Indigo, Colors.Violet };

            // Установка ключевых кадров анимации с использованием цветовой палитры
            double keyTime = 0;
            double step = 1.0 / (colors.Length - 1);

            for (int i = 0; i < colors.Length; i++)
            {
                colorAnimation.KeyFrames.Add(new LinearColorKeyFrame(colors[i], KeyTime.FromTimeSpan(TimeSpan.FromSeconds(keyTime))));
                keyTime += step;
            }

            // Создание и применение анимации к свойству Foreground элемента SelectedCarVost
            Storyboard.SetTarget(colorAnimation, SelectedCarVost);
            Storyboard.SetTargetProperty(colorAnimation, new PropertyPath("(Label.Foreground).(SolidColorBrush.Color)"));

            // Создание и запуск анимации
            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(colorAnimation);
            storyboard.Begin();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (CarsViewPanel.SelectedItem is Cars selectedCar)
            {
                // Переключение индекса изображения
                currentImageIndex++;
                if (currentImageIndex > 3)
                {
                    currentImageIndex = 2;
                }

                // Обновление SelectedCarImage в соответствии с новым индексом
                switch (currentImageIndex)
                {
                    case 2:
                        SelectedCarImage.Source = new BitmapImage(new Uri(selectedCar.ImagePaths2, UriKind.RelativeOrAbsolute));
                        break;
                    case 3:
                        SelectedCarImage.Source = new BitmapImage(new Uri(selectedCar.ImagePaths3, UriKind.RelativeOrAbsolute));
                        break;
                }
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            string message = "Помощь уже в пути, ожидайте...";

            // Создание нового окна сообщения
            System.Windows.Window attentionWindow = new System.Windows.Window
            {
                Title = "Внимание",
                Content = new TextBlock { Text = message, HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center },
                WindowStyle = WindowStyle.None,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.NoResize,
                Topmost = true,
                ShowInTaskbar = false,
                ShowActivated = true
            };
            // Загрузка и проигрывание аудиофайла
            MediaPlayer mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri("C:/Users/daimo/Downloads/helpcomingw8.mp3"));
            mediaPlayer.Play();

            // Показать окно сообщения
            attentionWindow.Show();
            
            // Закрыть окно сообщения через 5 секунд
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += (s, args) =>
            {
                timer.Stop();
                attentionWindow.Close();
            };
            timer.Start();
        }

        private void butttttt_Click(object sender, RoutedEventArgs e)
        {
            if (CarsViewPanel.SelectedItem is Cars selectedCar)
            {
                // Переключение между ImagePaths2, ImagePaths3 и ImagePaths4
                switch (currentImageIndex)
                {
                    case 1:
                        selectedCar.ImagePaths = selectedCar.ImagePaths4;
                        break;
                    case 2:
                        selectedCar.ImagePaths = selectedCar.ImagePaths3;
                        break;
                    case 3:
                        selectedCar.ImagePaths = selectedCar.ImagePaths2;
                        break;
                }

                // Обновление привязки изображения внутри DataTemplate
                var carImage = FindVisualChild<System.Windows.Controls.Image>(sender as Button);
                if (carImage != null)
                {
                    var bindingExpression = carImage.GetBindingExpression(System.Windows.Controls.Image.SourceProperty);
                    bindingExpression?.UpdateTarget();
                }
                UpdateCarsPage();

                // Переключение индекса изображения
                currentImageIndex--;
                if (currentImageIndex < 1)
                {
                    currentImageIndex = 3;
                }
            }
        }

        private T FindVisualChildRecursive<T>(DependencyObject parent) where T : DependencyObject
        {
            int childCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is T typedChild)
                {
                    return typedChild;
                }
                else
                {
                    var foundChild = FindVisualChildRecursive<T>(child);
                    if (foundChild != null)
                        return foundChild;
                }
            }
            return null;
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (CarsViewPanel.SelectedItem is Cars selectedCar)
            {
                // Переключение индекса изображения
                currentImageIndex++;
                

                // Обновление SelectedCarImage в соответствии с новым индексом
                switch (currentImageIndex)
                {
                    case 1:
                        SelectedCarImage.Source = new BitmapImage(new Uri(selectedCar.ImagePaths2, UriKind.RelativeOrAbsolute));
                        break;
                    case 2:
                        SelectedCarImage.Source = new BitmapImage(new Uri(selectedCar.ImagePaths3, UriKind.RelativeOrAbsolute));
                        break;
                    case 3:
                        SelectedCarImage.Source = new BitmapImage(new Uri(selectedCar.ImagePaths4, UriKind.RelativeOrAbsolute));
                        break;
                    case 4:
                        SelectedCarImage.Source = new BitmapImage(new Uri(selectedCar.SalonPath1, UriKind.RelativeOrAbsolute));
                        break;
                    case 5:
                        SelectedCarImage.Source = new BitmapImage(new Uri(selectedCar.SalonPath2, UriKind.RelativeOrAbsolute));
                        break;
                    case 6:
                        SelectedCarImage.Source = new BitmapImage(new Uri(selectedCar.SalonPath3, UriKind.RelativeOrAbsolute));
                        break;
                    case 7:
                        SelectedCarImage.Source = new BitmapImage(new Uri(selectedCar.SalonPath4, UriKind.RelativeOrAbsolute));
                        break;
                }
                if (currentImageIndex > 7)
                {
                    currentImageIndex = 0;
                }
            }
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            _3dViewAudi newWindow = new _3dViewAudi();  // Создание экземпляра нового окна
            newWindow.Show();  // Отображение нового окна
        }
    }
}
