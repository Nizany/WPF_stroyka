using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace WPF_стройка.Windows
{
    /// <summary>
    /// Логика взаимодействия для ListPage.xaml
    /// </summary>
    public partial class ListPage : Page
    {
        public ListPage()
        {
            InitializeComponent();
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
            Window.GetWindow(this).Content = new MainPage();
        }

        private void CompanyAction_Click(object sender, RoutedEventArgs e)
        {
            MyListView.View = new GridView();
            MyListView.ItemsSource = SqlConnect.CompaniesData();

            AddColumn("ID", "Id");
            AddColumn("Название", "Name");
            AddColumn("Местоположение", "Location");
        }

        private void GroupAction_Click(object sender, RoutedEventArgs e)
        {
            MyListView.View = new GridView();
            MyListView.ItemsSource = SqlConnect.BuildingsGroupData();

            AddColumn("ID", "Id");
            AddColumn("Название", "Name");
            AddColumn("Кол-во строений", "NumberOfBuildings");
        }

        private void BuildingAction_Click(object sender, RoutedEventArgs e)
        {
            MyListView.View = new GridView();
            MyListView.ItemsSource = SqlConnect.BuildingsData();

            AddColumn("ID", "Id");
            AddColumn("Название", "Name");
            AddColumn("Кол-во этажей", "Floors");
            AddColumn("Высота", "Height");
            AddColumn("Жилой", "IsResidential");
        }
    }
}
