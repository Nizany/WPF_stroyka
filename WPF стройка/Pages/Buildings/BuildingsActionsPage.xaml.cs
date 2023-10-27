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
                var Page = new AddBuildingPage();
                var window = Window.GetWindow(this);
                window.Content = Page;
            }
            if (RemoveBuilding.IsChecked == true)
            {
                var Page = new RemoveBuildingPage();
                var window = Window.GetWindow(this);
                window.Content = Page;
            }
            if (UpdateBuilding.IsChecked == true)
            {
                var Page = new UpdateBuildingPage();
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
