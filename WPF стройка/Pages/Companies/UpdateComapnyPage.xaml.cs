using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using WPF_стройка.Windows;

namespace WPF_стройка.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddBuildingPage.xaml
    /// </summary>
    public partial class UpdateCompanyPage : Page
    {
        public UpdateCompanyPage()
        {
            InitializeComponent();
        }

        private void ChooseAction_Click(object sender, RoutedEventArgs e)
        {
            string name = Name.Text;
            if (!Regex.IsMatch(name, @"^[a-zA-Z0-9\s]+$"))
            {
                Error.Text = ("Название компании должно состоять только из букв, цифр и пробелов.");
                return;
            }

            var location = Location.Text;
            if (!Regex.IsMatch(location, @"^[a-zA-Z0-9\s]+$"))
            {
                Error.Text = ("Местоположение компнаии должно состоять только из букв, цифр и пробелов.");
                return;
            }
            var CompanyData = ListActions.CompaniesData();
            if (CompanyData.Any(item => item.Name == name))
            {
                CompaniesActions.UpdateCompany(name, location);
                Error.Text = "Компания обновлена";
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

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Name.Text))
            {
                Error.Text = "Заполните поле";
            }
            else
            {
                var Company = ListActions.CompaniesData().FirstOrDefault(b => b.Name == Name.Text);
                if (Company != null)
                {
                    Error.Text = string.Empty;
                    Name.Text = Company.Name;
                    Location.Text = Company.Location;
                }
                else { Error.Text = "Компании не найдено"; }
            }
        }
    }
}
