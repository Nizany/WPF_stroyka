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
                Window.GetWindow(this).Content = new BuildingsActionsPage();
            }
            if (GroupBuildings.IsChecked == true)
            {
                Window.GetWindow(this).Content = new GroupBuildingsActionsPage();
            }
            if (Companies.IsChecked == true)
            {
                Window.GetWindow(this).Content = new CompaniesActionsPage();
            }
            if (List.IsChecked == true)
            {
                Window.GetWindow(this).Content = new ListPage();
            }
        }

        private void ExitAction_Click(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
            Window.GetWindow(this).Close();
        }
    }
}
