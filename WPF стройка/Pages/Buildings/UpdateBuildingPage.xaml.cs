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
    public partial class UpdateBuildingPage : Page
    {
        public UpdateBuildingPage()
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
            var BuildData = SqlConnect.BuildingsData();
            if (BuildData.Any(item => item.Name == name))
            {
                SqlConnect.UpdateBuilding(name, int.Parse(floors), float.Parse(height), isResidential);
                Error.Text = "Строение обновлено";
            }
            else
            {
                Error.Text = ("Такого строения не существует!");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Content = new BuildingsActionsPage();
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Name.Text))
            {
                Error.Text = "Заполните поле";
            }
            else
            {
                var building = SqlConnect.BuildingsData().FirstOrDefault(b => b.Name == Name.Text);
                if (building != null)
                {
                    Error.Text = string.Empty;
                    Name.Text = building.Name;
                    Floors.Text = building.Floors;
                    Height.Text = building.Height;
                    if (building.IsResidential == "True") { IsResidental.SelectedIndex = 0; }
                    else { IsResidental.SelectedIndex = 1; }
                }
                else { Error.Text = "Строение не найдено"; }
            }
        }
    }
}
