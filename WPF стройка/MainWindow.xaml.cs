using System.Windows;

namespace YourNamespace
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BuildingAction_Click(object sender, RoutedEventArgs e)
        {
            // Обработка действия "Работа со строениями"
            // Добавьте код для работы с данными о строениях
        }

        private void GroupAction_Click(object sender, RoutedEventArgs e)
        {
            // Обработка действия "Работа с группами строений"
            // Добавьте код для работы с данными о группах строений
        }

        private void CompanyAction_Click(object sender, RoutedEventArgs e)
        {
            // Обработка действия "Работа с компаниями"
            // Добавьте код для работы с данными о компаниях
        }

        private void DisplayAction_Click(object sender, RoutedEventArgs e)
        {
            // Обработка действия "Вывести список"
            // Добавьте код для отображения списков строений, компаний и групп строений
        }

        private void ExitAction_Click(object sender, RoutedEventArgs e)
        {
            // Обработка действия "Выйти из программы"
            Close();
        }
    }
}
