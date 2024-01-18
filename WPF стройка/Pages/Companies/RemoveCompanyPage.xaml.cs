using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WPF_стройка.Windows;

namespace WPF_стройка.Pages
{
    /// <summary>
    /// Логика взаимодействия для RemoveBuildPage.xaml
    /// </summary>
    public partial class RemoveCompanyPage : Page
    {
        public RemoveCompanyPage()
        {
            InitializeComponent();
        }

        private void ChooseAction_Click(object sender, RoutedEventArgs e)
        {
            var name = Name.Text;
            var CompanyData = SqlConnect.CompaniesData();
            if (CompanyData.Any(item => item.Name == name))
            {
                SqlConnect.RemoveCompany(name);
                Error.Text = "Компания удалена";
            }
            else
            {
                Error.Text = ("Такой компании не существует!");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Content = new CompaniesActionsPage();
        }
    }
}
