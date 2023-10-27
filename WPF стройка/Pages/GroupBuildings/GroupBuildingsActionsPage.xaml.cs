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
                var Page = new AddGroupBuildingPage();
                var window = Window.GetWindow(this);
                window.Content = Page;
            }
            if (RemoveBuilding.IsChecked == true)
            {
                var Page = new RemoveGroupBuildingPage();
                var window = Window.GetWindow(this);
                window.Content = Page;
            }
            if (UpdateBuilding.IsChecked == true)
            {
                var Page = new UpdateGroupBuildingPage();
                var window = Window.GetWindow(this);
                window.Content = Page;
            }
            if (Back.IsChecked == true)
            {
                var Page = new MainPage();
                var window = Window.GetWindow(this);
                window.Content = Page;
            }
        }
    }
}
