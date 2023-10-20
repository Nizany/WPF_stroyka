using System.Windows;

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
            if ((ListBuildings.IsChecked == true))
            {
                var data = SqlConnect.BuildingsData();
                MyListView.ItemsSource = data;
            }

            else if ((Back.IsChecked == true))
            {
                var window = new MainWindow();
                window.Show();
                Close();
            }
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