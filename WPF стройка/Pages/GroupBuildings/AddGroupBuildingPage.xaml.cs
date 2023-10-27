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
    public partial class AddGroupBuildingPage : Page
    {
        public AddGroupBuildingPage()
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
            var BuildData = SqlConnect.BuildingsGroupData();
            if (BuildData.Any(item => item.Name == name))
            {
                Error.Text = ("Такая группа строений уже существует!");
            }
            else
            {
                SqlConnect.AddGroupBuilding(name, int.Parse(buildings));
                Error.Text = "Группа строений добавлена";
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var Page = new GroupBuildingsActionsPage();
            var window = Window.GetWindow(this);
            window.Content = Page;
        }
    }
}
