using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;

namespace WPF_стройка
{

    public class SqlConnect
    {
        public SqlConnect()
        {
        }
        private static SqlConnection CreateConnection()
        {
            var connectionString = Data.Connect_Data;
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public static void RegisterUser(string Login, string Password)
        {
            using (var connection = CreateConnection())
            {
                try
                {
                    // Получить количество записей в таблице Авторизация
                    var sqlQuery1 = "SELECT COUNT(ID) FROM Авторизация";
                    var countCommand = new SqlCommand(sqlQuery1, connection);
                    int count = (int)countCommand.ExecuteScalar();

                    // Вставить новую запись
                    var sqlQuery2 = "INSERT INTO Авторизация (ID, Login, Password) VALUES (@ID, @Login, @Password)";
                    var insertCommand = new SqlCommand(sqlQuery2, connection);

                    // Используйте параметры, чтобы избежать SQL-инъекции
                    insertCommand.Parameters.AddWithValue("@ID", count + 1);
                    insertCommand.Parameters.AddWithValue("@Login", Login);
                    insertCommand.Parameters.AddWithValue("@Password", Password);

                    insertCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                    // Обработка ошибки, если что-то пошло не так
                }
            }
        }


        public static List<Buildings> BuildingsData()
        {
            var connection = CreateConnection();
            var result = new List<Buildings>();
            const string query = "SELECT * FROM Строения";
            using (var command = new SqlCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var data = new Buildings
                        {
                            Id = reader["ID_Строения"].ToString(),
                            Name = reader["Название"].ToString(),
                            Floors = reader["Высота"].ToString(),
                            Height = reader["Кол-во этажей"].ToString(),
                            IsResidential = reader["Жилой"].ToString(),
                        };
                        result.Add(data);
                    }
                }
            }
            connection.Close();
            return result;
        }
        public static List<UserData> UserDatas(string tableName, string columnName, string valueToFind)
        {
            var connection = CreateConnection();
            var result = new List<UserData>();
            var sqlQuery = $"SELECT * FROM {tableName} WHERE {columnName} = @valueToFind";

            using (var command = new SqlCommand(sqlQuery, connection))
            {
                command.Parameters.AddWithValue("@valueToFind", valueToFind);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var Login = (string)reader["Login"];
                    var Password = (string)reader["Password"];
                    result.Add(new UserData { Login = Login, Password = Password });
                }

                connection.Close();
            }

            return result;
        }
    }

    public class Buildings
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Floors { get; set; }
        public string Height { get; set; }
        public string IsResidential { get; set; }
    }
    public class UserData
    {
        public string Login{ get; set; }
        public string Password { get; set; }
    }
}
