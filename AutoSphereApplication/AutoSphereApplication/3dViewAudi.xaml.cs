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
using System.Windows.Shapes;

namespace AutoSphereApplication
{
    /// <summary>
    /// Логика взаимодействия для _3dViewAudi.xaml
    /// </summary>
    public partial class _3dViewAudi : Window
    {
        private const string MODEL_PATH = "C:/Users/daimo/Downloads/Audi-A3-Sedan-3D-model/Audi a3.obj";
        private Model3DGroup model; // Поле для хранения модели
        private PerspectiveCamera camera;
        private Point lastMousePosition;

        public _3dViewAudi()
        {
            InitializeComponent();

            // Создание камеры
            camera = new PerspectiveCamera(new Point3D(55, 55, -1), new Vector3D(1, 55, -5), new Vector3D(0, 1, 10), 85);
            camera.Position = new Point3D(4.5, 30, 2);
            camera.LookDirection = new Vector3D(0, -10, 2);
            // Установка камеры во Viewport3D
            viewPort3d.Camera = camera;

            // Загрузка модели и добавление в Viewport3D
            model = new Model3DGroup();
            Model3D device3D = Display3d(MODEL_PATH);
            model.Children.Add(device3D);
            viewPort3d.Children.Add(new ModelVisual3D { Content = model });

            // Привязка событий мыши для управления камерой
            viewPort3d.MouseMove += Viewport3D_MouseMove;
            viewPort3d.MouseWheel += Viewport3D_MouseWheel;
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
                // Handle exception in case can not find 3D model
                MessageBox.Show("Exception Error: " + e.StackTrace);
            }
            return device;
        }

        private void Viewport3D_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Point currentPosition = e.GetPosition(viewPort3d);
                double deltaX = currentPosition.X - lastMousePosition.X;
                double deltaY = currentPosition.Y - lastMousePosition.Y;

                RotateCamera(deltaX, deltaY);
            }

            lastMousePosition = e.GetPosition(viewPort3d);
        }

        private void Viewport3D_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            double delta = e.Delta / 2000.0;
            double newDistance = camera.Position.Z - delta;

            if (newDistance > 1 && newDistance < 10)
            {
                camera.Position = new Point3D(camera.Position.X, camera.Position.Y, newDistance);
            }
        }

        private void RotateCamera(double deltaX, double deltaY)
        {
            const double sensitivity = 0.4;

            double yawAngle = deltaX * sensitivity;
            double pitchAngle = deltaY * sensitivity;

            Matrix3D matrix = camera.Transform.Value;
            matrix.Rotate(new Quaternion(camera.UpDirection, yawAngle));
            matrix.Rotate(new Quaternion(camera.LookDirection, -pitchAngle));

            camera.Transform = new MatrixTransform3D(matrix);
        }
    }
}
