using System.Windows;
using System.Windows.Controls;
using WPF_стройка.Pages;

namespace WPF_стройка.Windows
{
    /// <summary>
    /// Логика взаимодействия для BuildingsActions.xaml
    /// </summary>
    public partial class GroupBuildingsActionsPage : Page
    {
        public GroupBuildingsActionsPage()
        {
            InitializeComponent();
        }

        private void ChooseAction_Click(object sender, RoutedEventArgs e)
        {
            if (AddBuilding.IsChecked == true)
            {
                Window.GetWindow(this).Content = new AddGroupBuildingPage();
            }
            if (RemoveBuilding.IsChecked == true)
            {
                Window.GetWindow(this).Content = new RemoveGroupBuildingPage();
            }
            if (UpdateBuilding.IsChecked == true)
            {
                Window.GetWindow(this).Content = new UpdateGroupBuildingPage();
            }
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Content = new MainPage();
        }
    }
}
