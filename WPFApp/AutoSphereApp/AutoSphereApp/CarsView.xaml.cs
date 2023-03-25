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
using Microsoft.Office.Interop.Word;

namespace AutoSphereApp
{
    /// <summary>
    /// Логика взаимодействия для CarsView.xaml
    /// </summary>
    public partial class CarsView : System.Windows.Controls.Page
    {
        private List<Cars> allCars;

        public CarsView()
        {
            InitializeComponent();

            // Получаем все марки и привязываем к комбобоксу
            var allMarks = AutoSphereEntities.GetContext().Marks.ToList();
            MarksList.ItemsSource = allMarks;
            MarksList.DisplayMemberPath = "MarkName";
            MarksList.SelectedValue = "MarkName";

            // Получаем все автомобили и запоминаем их
            allCars = AutoSphereEntities.GetContext().Cars.ToList();

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
        }

        private void SearchList_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateCarsPage();
        }

        private void MarksList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateCarsPage();
        }

        private void ActualCars_Checked(object sender, RoutedEventArgs e)
        {
            UpdateCarsPage();
        }

        private void PodZakaz_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdateCarsPage();
        }

        private void PodZakaz_Checked(object sender, RoutedEventArgs e)
        {
            UpdateCarsPage();
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

            // Обновляем список автомобилей на странице
            UpdateCarsPage();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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
            Microsoft.Office.Interop.Word.Table table = wordDoc.Tables.Add(wordDoc.Bookmarks.get_Item("\\endofdoc").Range, CarsViewPanel.Items.Count + 1, 5);
            table.Cell(1, 1).Range.Text = "Марка";
            table.Cell(1, 2).Range.Text = "Модель";
            table.Cell(1, 3).Range.Text = "Цвет";
            table.Cell(1, 4).Range.Text = "Стоимость";
            table.Cell(1, 5).Range.Text = "Статус";

            int row = 2;
            foreach (var item in CarsViewPanel.Items)
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

            // Сохранение документа

        }
    }
}
