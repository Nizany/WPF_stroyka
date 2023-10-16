using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using Class_Stroenia;

namespace YourNamespace
{
    public class SQL_Connect
    {
        private string connectionString = "Server=46.34.144.102;Database=sessia;User Id=Nizany;Password=2288;";
        private TextBlock resultTextBlock;

        public SQL_Connect(TextBlock textBlock)
        {
            resultTextBlock = textBlock;
        }

        public void ConnectAndDoSomething()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Открытие подключения
                connection.Open();

                // Пример SQL-запроса
                string query = "SELECT * FROM КАДРОВЫЙ_СОСТАВ";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Получение данных из результата запроса
                            string columnName = reader.GetString(1); // Здесь 0 - это индекс столбца

                            // Добавление данных к TextBox
                            resultTextBlock.Text += columnName + Environment.NewLine;
                        }
                    }
                }

                // Закрытие подключения
                connection.Close();
            }
        }
    }


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
            if (Buildings.IsChecked == true)
            {
                Text.Text = "Выбрано: Строения";
            }
            else if (GroupBuildings.IsChecked == true)
            {
                Text.Text = "Выбрано: Группы строений";
            }
            else if (Companies.IsChecked == true)
            {
                Text.Text = "Выбрано: Компании";
            }
            else if (List.IsChecked == true)
            {
                Text.Text = "";
                SQL_Connect sqlConnect = new SQL_Connect(Text);
                sqlConnect.ConnectAndDoSomething();
                
            }
        }

        private void ExitAction_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
