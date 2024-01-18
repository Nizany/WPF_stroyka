using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WPF_стройка.Windows;

namespace WPF_стройка.Pages
{
    /// <summary>
    /// Логика взаимодействия для RemoveBuildPage.xaml
    /// </summary>
    public partial class RemoveGroupBuildingPage : Page
    {
        public RemoveGroupBuildingPage()
        {
            InitializeComponent();
        }

        private void ChooseAction_Click(object sender, RoutedEventArgs e)
        {
            var name = Name.Text;
            if (SqlConnect.BuildingsGroupData().Any(item => item.Name == name))
            {
                SqlConnect.RemoveGroupBuildings(name);
                Error.Text = "Группа строений удалена";
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
    }
}
