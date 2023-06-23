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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using HelixToolkit;
using HelixToolkit.Wpf;


namespace AutoSphereApplication
{
    /// <summary>
    /// Логика взаимодействия для PageObject.xaml
    /// </summary>
    public partial class PageObject : Page
    {
        private const string MODEL_PATH = "C:/Users/daimo/Downloads/Audi-A3-Sedan-3D-model/Audi a3.obj";
        private Model3DGroup model; // Поле для хранения модели
        private PerspectiveCamera camera;
        private double rotationAngle = 0;
        private DispatcherTimer timer; // Объявление переменной timer
        private double rotationSpeed = 0.2; // Скорость вращения
        private RotateTransform3D cameraTransform;

        private AxisAngleRotation3D cameraRotation;

        public PageObject()
        {
            InitializeComponent();

            // Создание камеры
            camera = new PerspectiveCamera(new Point3D(5, 0, 10), new Vector3D(0, 25, -25), new Vector3D(0, 2, 0), 90);

            // Создание вращения камеры
            cameraRotation = new AxisAngleRotation3D(new Vector3D(0, 0, 5), 0);

            // Установка вращения камеры в Transform3D
            Transform3DGroup transformGroup = new Transform3DGroup();
            transformGroup.Children.Add(new RotateTransform3D(cameraRotation));
            camera.Transform = transformGroup;

            // Установка камеры во Viewport3D
            viewPort3d.Camera = camera;

            // Инициализация таймера
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1); // Интервал для скорости вращения камеры
            timer.Tick += Timer_Tick;
            timer.Start();

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
            double deltaAngle = 0.1; // Измените эту величину, чтобы настроить скорость вращения
            double newAngle = currentAngle + deltaAngle;

            // Применение нового угла вращения к камере
            cameraRotation.Angle = newAngle;
        }
    }
}
