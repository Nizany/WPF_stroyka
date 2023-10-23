using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace WPF_стройка
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void ChooseAction_Click(object sender, RoutedEventArgs e)
        {
            MyListView.View = new GridView(); // Очищаем существующие столбцы

            if (ListBuildings.IsChecked == true)
            {
                var data = SqlConnect.BuildingsData();
                MyListView.ItemsSource = data;

                // Добавляем столбцы, которые хотим отобразить
                AddColumn("ID", "Id");
                AddColumn("Название", "Name");
                AddColumn("Кол-во этажей", "Floors");
                AddColumn("Высота", "Height");
                AddColumn("Жилой", "IsResidential");
            }
            else if (ListGroupBuildings.IsChecked == true)
            {
                var data = SqlConnect.BuildingsGroupData();
                MyListView.ItemsSource = data;

                // Добавляем столбцы, которые хотим отобразить
                AddColumn("ID", "Id");
                AddColumn("Название", "Name");
                AddColumn("Кол-во строений", "NumberOfBuildings");
            }
            else if (ListCompanies.IsChecked == true)
            {
                var data = SqlConnect.CompaniesData();
                MyListView.ItemsSource = data;

                // Добавляем столбцы, которые хотим отобразить
                AddColumn("ID", "Id");
                AddColumn("Название", "Name");
                AddColumn("Местоположение", "Location");
            }
            else if (Back.IsChecked == true)
            {
                var window = new MainWindow();
                window.Show();
                Close();
            }
        }
        private void AddColumn(string header, string binding)
        {
            GridView gridView = (GridView)MyListView.View;
            GridViewColumn column = new GridViewColumn
            {
                Header = header,
                DisplayMemberBinding = new Binding(binding)
            };
            gridView.Columns.Add(column);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void CompanyAction_Click(object sender, RoutedEventArgs e)
        {
        }

        private void GroupAction_Click(object sender, RoutedEventArgs e)
        {
        }

        private void BuildingAction_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}