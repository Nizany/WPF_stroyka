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
                Window.GetWindow(this).Content = new AddCompanyPage();
            }
            if (RemoveCompany.IsChecked == true)
            {
                Window.GetWindow(this).Content = new RemoveCompanyPage();
            }
            if (UpdateCompany.IsChecked == true)
            {
                Window.GetWindow(this).Content = new UpdateCompanyPage();
            }
            if (Back.IsChecked == true)
            {
                Window.GetWindow(this).Content = new MainPage();
            }
        }
    }
}