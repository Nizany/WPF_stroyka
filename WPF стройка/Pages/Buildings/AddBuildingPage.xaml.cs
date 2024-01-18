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
    public partial class AddBuildingPage : Page
    {
        public AddBuildingPage()
        {
            InitializeComponent();
        }

        private void ChooseAction_Click(object sender, RoutedEventArgs e)
        {
            string name = Name.Text;
            if (!Regex.IsMatch(name, @"^[a-zA-Z0-9\s]+$"))
            {
                Error.Text = ("Название строения должно состоять только из букв, цифр и пробелов.");
                return;
            }

            var floors = Floors.Text;
            if (!Regex.IsMatch(floors, @"^\d+$"))
            {
                Error.Text = ("Количество этажей должно быть положительным целым числом.");
                return;
            }

            var height = Height.Text;
            if (!Regex.IsMatch(height, @"^\d+(\.\d+)?$"))
            {
                Error.Text = ("Высота строения должна быть числом.");
                return;
            }
            int isResidential = 1;
            switch (IsResidental.SelectedItem)
            {
                case "Да":
                    isResidential = 1;
                    break;
                case "Нет":
                    isResidential = 0;
                    break;
            }
            if (SqlConnect.BuildingsData().Any(item => item.Name == name))
            {
                Error.Text = ("Такое строение уже существует!");
            }
            else
            {
                SqlConnect.AddBuilding(name, int.Parse(floors), float.Parse(height), isResidential);
                Error.Text = "Строение добавлено";
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Content = new BuildingsActionsPage();
        }
    }
}
