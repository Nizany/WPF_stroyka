using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using WPF_стройка.Windows;

namespace WPF_стройка.Pages
{
    public partial class UpdateGroupBuildingPage : Page
    {
        public UpdateGroupBuildingPage()
        {
            InitializeComponent();
        }

        private void ChooseAction_Click(object sender, RoutedEventArgs e)
        {
            string name = Name.Text;
            if (!Regex.IsMatch(name, @"^[a-zA-Z0-9\s]+$"))
            {
                Error.Text = ("Название группы строений должно состоять только из букв, цифр и пробелов.");
                return;
            }
            var buildings = Buildings.Text;
            if (!Regex.IsMatch(buildings, @"^\d+$"))
            {
                Error.Text = ("Количество групп строений должно быть положительным целым числом.");
                return;
            }
            var BuildingGroupData = ListActions.BuildingsGroupData();
            if (BuildingGroupData.Any(item => item.Name == name))
            {
                Error.Text = ("Такая группа строений уже существует!");
            }
            else
            {
                GroupBuildingActions.AddGroupBuilding(name, int.Parse(buildings));
                Error.Text = "Группа строений добавлена";
            }
            if (BuildingGroupData.Any(item => item.Name == name))
            {
                GroupBuildingActions.UpdateGroupBuildings(name, int.Parse(buildings));
                Error.Text = "Группа строений обновлена";
            }
            else
            {
                Error.Text = ("Такой группы строений не существует!");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Content = new GroupBuildingsActionsPage();
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Name.Text))
            {
                Error.Text = "Заполните поле";
            }
            else
            {
                var buildingGroup = ListActions.BuildingsGroupData().FirstOrDefault(b => b.Name == Name.Text);
                if (buildingGroup != null)
                {
                    Error.Text = string.Empty;
                    Name.Text = buildingGroup.Name;
                    Buildings.Text = buildingGroup.NumberOfBuildings;
                }
                else { Error.Text = "Группы строений не найдено"; }
            }
        }
    }
}