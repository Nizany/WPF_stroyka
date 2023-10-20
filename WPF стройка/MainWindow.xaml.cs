using System.Windows;

namespace WPF_стройка
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BuildingAction_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GroupAction_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CompanyAction_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DisplayAction_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ChooseAction_Click(object sender, RoutedEventArgs e)
        {
            Window2 window = new Window2();
            window.Show();
            Close();
        }

        private void ExitAction_Click(object sender, RoutedEventArgs e)
        {
            var window = new Login_Window();
            window.Show();
            Close();
        }
    }
}
