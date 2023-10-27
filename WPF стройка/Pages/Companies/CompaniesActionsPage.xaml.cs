using System.Windows;
using System.Windows.Controls;
using WPF_стройка.Pages;

namespace WPF_стройка.Windows
{
    /// <summary>
    /// Логика взаимодействия для BuildingsActions.xaml
    /// </summary>
    public partial class CompaniesActionsPage : Page
    {
        public CompaniesActionsPage()
        {
            InitializeComponent();
        }

        private void ChooseAction_Click(object sender, RoutedEventArgs e)
        {
            if (AddCompany.IsChecked == true)
            {
                var Page = new AddCompanyPage();
                var window = Window.GetWindow(this);
                window.Content = Page;
            }
            if (RemoveCompany.IsChecked == true)
            {
                var Page = new RemoveCompanyPage();
                var window = Window.GetWindow(this);
                window.Content = Page;
            }
            if (UpdateCompany.IsChecked == true)
            {
                var Page = new UpdateCompanyPage();
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
