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

namespace AutoSphereApp
{
    /// <summary>
    /// Логика взаимодействия для CarsView.xaml
    /// </summary>
    public partial class CarsView : Page
    {
        public CarsView()
        {
            InitializeComponent();
           
            UpdateCarsPage();

        }
        private void UpdateCarsPage()
        {
            var currentCars = AutoSphereEntities.GetContext().Cars.ToList();
            var AllMarks = AutoSphereEntities.GetContext().Marks.ToList();
            MarksList.ItemsSource = AllMarks;
            MarksList.DisplayMemberPath = "MarkName";
            MarksList.SelectedValue = "MarkName";
            CarsViewPanel.ItemsSource = currentCars;
            currentCars = currentCars.Where(p=>p.Model.ToLower().Contains(SearchList.Text.ToLower())).ToList();

           /* if(ActualCars.IsChecked.Value)
            {
                //CarsViewPanel.ItemsSource = currentCars.OrderBy(p==p.)
            }
            if (ActualCars.Unchecked)
            {

            }
           */
        }

        private void ActualCars_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void SearchList_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string SearchedText = SearchList.Text;
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(CarsViewPanel.ItemsSource);
                view.Filter = (item) =>
                {


                    if (item is Cars Model)
                    {
                        return Model.Model.Contains(SearchedText);
                    }

                    return false;



                };
            }
            finally
            {
                string SearchedText = SearchList.Text;
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(CarsViewPanel.ItemsSource);
                view.Filter = (item) =>
                {


                    if (item is Cars Mark)
                    {
                        return Mark.Mark.Contains(SearchedText);
                    }

                    return false;



                };
            }
          
        }
    }
}
