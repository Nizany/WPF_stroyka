using System.Collections.Generic;
using System.Data.SqlClient;

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



        public static List<Buildings> BuildingsData()
        {
            var result = new List<Buildings>();
            var connection = CreateConnection();
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
