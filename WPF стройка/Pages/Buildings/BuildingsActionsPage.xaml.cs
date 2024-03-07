using System.Windows;
using System.Windows.Controls;
using WPF_стройка.Pages;

namespace WPF_стройка.Windows
{
    /// <summary>
    /// Логика взаимодействия для BuildingsActions.xaml
    /// </summary>
    public partial class BuildingsActionsPage : Page
    {
        public BuildingsActionsPage()
        {
            InitializeComponent();
        }

        private void ChooseAction_Click(object sender, RoutedEventArgs e)
        {
            if (AddBuilding.IsChecked == true)
            {
                Window.GetWindow(this).Content = new AddBuildingPage();
            }
            if (RemoveBuilding.IsChecked == true)
            {
                Window.GetWindow(this).Content = new RemoveBuildingPage();
            }
            if (UpdateBuilding.IsChecked == true)
            {
                Window.GetWindow(this).Content = new UpdateBuildingPage();
            }
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Content = new MainPage();
        }
    }
}
