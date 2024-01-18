using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WPF_стройка.Windows;

namespace WPF_стройка.Pages
{
    /// <summary>
    /// Логика взаимодействия для RemoveBuildPage.xaml
    /// </summary>
    public partial class RemoveBuildingPage : Page
    {
        public RemoveBuildingPage()
        {
            InitializeComponent();
        }

        private void ChooseAction_Click(object sender, RoutedEventArgs e)
        {
            var name = Name.Text;
            var BuildData = SqlConnect.BuildingsData();
            if (BuildData.Any(item => item.Name == name))
            {
                SqlConnect.RemoveBuilding(name);
                Error.Text = "Строение удалено";
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
    }
}
