using AutoSphereApplication.Classes;
using HelixToolkit.Wpf;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace AutoSphereApplication
{
    /// <summary>
    /// Логика взаимодействия для LogINPage.xaml
    /// </summary>
    public partial class LogINPage : Page
    {
        private int attemps = 0;
        Random _random = new Random();
        private TextBlock myTextBlock;
        private const string MODEL_PATH = "C:\\Users\\daimo\\Downloads\\Chevrolet Camaro\\Chevrolet Camaro.3ds";
        private Model3DGroup model; // Поле для хранения модели
        private PerspectiveCamera camera;
        private double rotationAngle = 0;
        private DispatcherTimer timer; // Объявление переменной timer
        private double rotationSpeed = 0.2; // Скорость вращения
        private RotateTransform3D cameraTransform;

        private AxisAngleRotation3D cameraRotation;

        /// <summary>
        /// Происходит как только страница загружается
        /// </summary>
        public LogINPage()
        {
            InitializeComponent();

            Classes.DbConnect.modeldb = new Models.AutoSphereBDEntities1();
            // Создание камеры
            camera = new PerspectiveCamera(new Point3D(55, 55, -1), new Vector3D(1, 55, -5), new Vector3D(0, 1, 10), 85);
            camera.Position = new Point3D(4.5, 30, 2);
            camera.LookDirection = new Vector3D(0, -10, 2);
            // Создание вращения камеры

            cameraRotation = new AxisAngleRotation3D(new Vector3D(0, 0, 1), -45);
            // Установка вращения камеры в Transform3D
            Transform3DGroup transformGroup = new Transform3DGroup();
            transformGroup.Children.Add(new RotateTransform3D(cameraRotation));
            camera.Transform = transformGroup;

            // Установка камеры во Viewport3D
            viewPort3d.Camera = camera;

           


            // Загрузка модели и добавление в Viewport3D
            model = new Model3DGroup();
            Model3D device3D = Display3d(MODEL_PATH);
            model.Children.Add(device3D);
            viewPort3d.Children.Add(new ModelVisual3D { Content = model });
        }
        private Model3D Display3d(string modelPath)
        {
            Model3D device = null;
            try
            {
                // Import 3D model file
                ModelImporter import = new ModelImporter();
                // Load the 3D model file
                device = import.Load(modelPath);
                
            }
            catch (Exception e)
            {
                // Handle exception in case can not file 3D model
                MessageBox.Show("Exception Error : " + e.StackTrace);
            }
            return device;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Получение текущего угла вращения камеры
            double currentAngle = cameraRotation.Angle;

            // Увеличение угла на заданную величину
            double deltaAngle =2; // Измените эту величину, чтобы настроить скорость вращения
            double newAngle = currentAngle + deltaAngle;

            // Применение нового угла вращения к камере
            cameraRotation.Angle = newAngle;
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Password.Password))
            {
                MessageBox.Show("Для начала, введите пароль!", "Уведомление");

                CheckBoxPass.IsChecked = false;
            }
            else
            {
                TxbPassword.Visibility = Visibility.Visible;
                Password.Visibility = Visibility.Collapsed;
                TxbPassword.Text = Password.Password;
            }
        }
        private void CheckBox_UnChecked(object sender, RoutedEventArgs e)
        {
            TxbPassword.Visibility = Visibility.Collapsed;
            Password.Visibility = Visibility.Visible;
            TxbPassword.Text = Password.Password;
        }
        private void LogIN()
        {
          
            try
            {
                var userObj = Classes.DbConnect.modeldb.Users.FirstOrDefault(x => x.Login == LoginTB.Text && x.Password == Password.Password);
                if (userObj != null)
                {
                    Models.AutoSphereBDEntities1.currentuser = userObj;
                    MessageBox.Show("Здравствуйте " + userObj.Roles.RoleName + ", " + userObj.Login, "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                    switch (userObj.RoleID)
                    {
                        case 1:
                            Manager.MainFrame.Navigate(new AdminPage());
                            Window window = Window.GetWindow(this);
                            if (window != null)
                            {
                                window.WindowState = WindowState.Maximized;
                            }
                            break;
                        case 2:
                            Manager.MainFrame.Navigate(new AdminPage());
                            Window window2 = Window.GetWindow(this);
                            if (window2 != null)
                            {
                                window2.WindowState = WindowState.Maximized;
                            }
                            break;
                        case 3:
                            var clientdata = Classes.DbConnect.modeldb.Clients.FirstOrDefault(c => c.ClientID == userObj.ClientID);
                            if (clientdata != null)
                            {
                                User user = new User
                                {
                                    FirstName = clientdata.FirstName,
                                    MiddleName = clientdata.MiddleName,
                                    LastName = clientdata.LastName,
                                    Email = clientdata.Email,
                                    PhoneNumber = clientdata.PhoneNumber,
                                    PassNumber = clientdata.PassNumber,
                                    ClientID = clientdata.ClientID
                                };
                                Manager.MainFrame.Navigate(new CarsViewForClient(user));
                                Window window3 = Window.GetWindow(this);
                                if (window3 != null)
                                {
                                    window3.WindowState = WindowState.Maximized;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Данные клиента не найдены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                            }
                            break;
                        default:
                            MessageBox.Show("Данные не обнаружены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;
                    }

                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль", "Уведомление");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message.ToString(), "Критическая работа приложения",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var userObj = Classes.DbConnect.modeldb.Users.FirstOrDefault(x => x.Login == LoginTB.Text && x.Password == Password.Password);

            if (userObj == null)
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка при авторизации",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                attemps++;
                CheckAttemps();
            }
            else
            {
                LogIN();
            }
        }
        private void CheckAttemps()
        {

            if (attemps == 2)
            {

                MessageBox.Show("Слишком много неудачных попыток! Подтвердите, что вы человек", "Не удается войти!", MessageBoxButton.OK, MessageBoxImage.Warning);
                Noises.Visibility = Visibility.Visible;
                SymbolsGen.Visibility = Visibility.Visible;
                GetCapcha.Visibility = Visibility.Visible;
                UpdateCapcha.Visibility = Visibility.Visible;
                ConfirmCapcha.Visibility = Visibility.Visible;
                LoginTB.Visibility = Visibility.Collapsed;
                Password.Visibility = Visibility.Collapsed;
                GenerateNoisesForCapcha(30);
                GenerateSymbols(3);
                if (GetCapcha.Text != Symbols)
                {

                }


            }
            else
            {
                if (attemps == 3)
                {
                    MessageBox.Show("Возможность входа заблокирована", "Слишком много неудачных попыток", MessageBoxButton.OK, MessageBoxImage.Warning);
                    Blocked.Visibility = Visibility.Visible;

                    // Блокируем элементы интерфейса
                    foreach (UIElement element in UIInt.Children)
                    {
                        if (element is Control control && control.Name != "ExitButton" && control.Name != "SupportButton")
                        {
                            control.IsEnabled = false;
                        }
                    }

                    // Запускаем таймер на 10 секунд
                    double seconds = 10;
                    DispatcherTimer timer = new DispatcherTimer();
                    timer.Interval = TimeSpan.FromSeconds(1);
                    timer.Tick += (sender, args) =>
                    {
                        seconds--;
                        TimerTextBlock.Text = $"Попробуйте снова через {seconds} сек.";
                        if (seconds == 0)
                        {
                            timer.Stop();
                            Blocked.Visibility = Visibility.Collapsed;
                            TimerTextBlock.Visibility = Visibility.Collapsed;
                            // Разблокируем элементы интерфейса
                            foreach (UIElement element in UIInt.Children)
                            {
                                if (element is Control control && control.Name != "ExitButton" && control.Name != "SupportButton")
                                {
                                    control.IsEnabled = true;
                                    attemps = 0;
                                }
                            }
                        }
                    };
                    timer.Start();
                    TimerTextBlock.Visibility = Visibility.Visible;
                }
            }
        }
        private void GenerateNoisesForCapcha(int volumeNoise)
        {
            Noises.Visibility = Visibility.Visible;
            for (int i = 0; i < volumeNoise; i++)
            {
                Ellipse ellipse = new Ellipse
                {
                    Fill = new SolidColorBrush(Color.FromArgb((byte)_random.Next(100, 200),

                     (byte)_random.Next(0, 256),
                     (byte)_random.Next(0, 256),
                     (byte)_random.Next(0, 256)))
                };

                ellipse.Height = ellipse.Width = _random.Next(20, 60);

                Canvas.SetLeft(ellipse, _random.Next(0, 290));
                Canvas.SetTop(ellipse, _random.Next(0, 100));

                Noises.Children.Add(ellipse);
            }
        }
        public string Symbols = "";
        private void GenerateSymbols(int count)
        {
            string alphabet = "ABCDEFGHJKLMN123456789";
            for (int i = 0; i < count; i++)
            {
                string symbol = alphabet.ElementAt(_random.Next(0, alphabet.Length)).ToString();
                TextBlock lbl = new TextBlock();

                lbl.Text = symbol;
                lbl.FontSize = _random.Next(20, 40);
                lbl.RenderTransform = new RotateTransform(_random.Next(-45, 45));
                lbl.Margin = new Thickness(20, 20, 20, 20);

                Noises.Visibility = Visibility.Visible;
                SymbolsGen.Children.Add(lbl);
                Symbols = Symbols + symbol;
                myTextBlock = lbl;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Symbols = "";
            SymbolsGen.Children.Clear();
            Noises.Children.Clear();
            GenerateSymbols(3);
            GenerateNoisesForCapcha(25);

        }

        private void ConfirmCapcha_Click(object sender, RoutedEventArgs e)
        {                
            if (GetCapcha.Text == Symbols)
            {
                Noises.Visibility = Visibility.Collapsed;
                SymbolsGen.Visibility = Visibility.Collapsed;
                GetCapcha.Visibility = Visibility.Collapsed;
                UpdateCapcha.Visibility = Visibility.Collapsed;
                ConfirmCapcha.Visibility = Visibility.Collapsed;
                LoginTB.Visibility = Visibility.Visible;
                Password.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (timer != null && timer.IsEnabled) // Проверяем, активен ли таймер
            {
                // Если таймер активен, останавливаем его
                timer.Stop();
            }
            else
            {
                // Если таймер не активен, запускаем его
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(1);
                timer.Tick += Timer_Tick;
                timer.Start();
            }
        }

        private void CheckBoxPass_Checked(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Password.Password))
            {
                MessageBox.Show("Для начала, введите пароль!", "Уведомление");

                CheckBoxPass.IsChecked = false;
            }
            else
            {
                TxbPassword.Visibility = Visibility.Visible;
                Password.Visibility = Visibility.Collapsed;
                TxbPassword.FontSize = 14;
                TxbPassword.Text = Password.Password;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
