using System.Windows;
using System.Windows.Controls;

namespace WPF_стройка.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ChooseAction_Click(object sender, RoutedEventArgs e)
        {
            if (Buildings.IsChecked == true)
            {
                var window = Window.GetWindow(this);
                var page = new BuildingsActionsPage();
                window.Content = page;
            }
            if (GroupBuildings.IsChecked == true)
            {
                var window = Window.GetWindow(this);
                var page = new GroupBuildingsActionsPage();
                window.Content = page;
            }
            if (Companies.IsChecked == true)
            {
                var window = Window.GetWindow(this);
                var page = new CompaniesActionsPage();
                window.Content = page;
            }
            if (List.IsChecked == true)
            {
                var window = Window.GetWindow(this);
                var page = new ListPage();
                window.Content = page;
            }
        }

        private void ExitAction_Click(object sender, RoutedEventArgs e)
        {
            var LoginWindow = new LoginWindow();
            LoginWindow.Show();
            var window = Window.GetWindow(this);
            window.Close();
        }
    }
}
