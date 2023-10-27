using System;
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

        public static void RegisterUser(string Login, string Password)
        {
            using (var connection = CreateConnection())
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
        }

        public static void AddBuilding(string Name, int Floors, float Height, int isResedental)
        {
            using (var connection = CreateConnection())
            {
                // Получить количество записей в таблице Авторизация
                var sqlQuery1 = "SELECT COUNT(ID_Строения) FROM Строения";
                var countCommand = new SqlCommand(sqlQuery1, connection);
                int count = (int)countCommand.ExecuteScalar();

                // Вставить новую запись
                var sqlQuery2 = "INSERT INTO Строения (ID_строения, Название, [Кол-во этажей], Высота, Жилой) VALUES (@ID_строения, @Название, @Кол_во_этажей, @Высота, @Жилой)";
                var insertCommand = new SqlCommand(sqlQuery2, connection);

                // Используйте параметры, чтобы избежать SQL-инъекции
                insertCommand.Parameters.AddWithValue("@ID_строения", count + 1);
                insertCommand.Parameters.AddWithValue("@Название", Name);
                insertCommand.Parameters.AddWithValue("@Кол_во_этажей", Floors);
                insertCommand.Parameters.AddWithValue("@Высота", Height);
                insertCommand.Parameters.AddWithValue("@Жилой", isResedental);

                insertCommand.ExecuteNonQuery();
            }
        }
        public static void RemoveBuilding(string Name)
        {
            using (var connection = CreateConnection())
            {
                var sqlQuery = "DELETE FROM Строения WHERE Название = @Название";
                var insertCommand = new SqlCommand(sqlQuery, connection);

                // Используйте параметры, чтобы избежать SQL-инъекции
                insertCommand.Parameters.AddWithValue("@Название", Name);

                insertCommand.ExecuteNonQuery();
            }
        }
        public static void UpdateBuilding(string Name, int Floors, float Height, int isResedental)
        {
            using (var connection = CreateConnection())
            {
                var sqlQuery2 = "UPDATE Строения SET [Кол-во этажей]=@Кол_во_этажей, Высота=@Высота, Жилой=@Жилой WHERE Название=@Название";
                var insertCommand = new SqlCommand(sqlQuery2, connection);

                insertCommand.Parameters.AddWithValue("@Название", Name);
                insertCommand.Parameters.AddWithValue("@Кол_во_этажей", Floors);
                insertCommand.Parameters.AddWithValue("@Высота", Height);
                insertCommand.Parameters.AddWithValue("@Жилой", isResedental);

                insertCommand.ExecuteNonQuery();
            }
        }

        public static void AddGroupBuilding(string Name, int buildings)
        {
            using (var connection = CreateConnection())
            {
                var sqlQuery1 = "SELECT COUNT(ID) FROM [Группы Строений]";
                var countCommand = new SqlCommand(sqlQuery1, connection);
                int count = (int)countCommand.ExecuteScalar();

                var sqlQuery2 = "INSERT INTO [Группы строений] (ID, Название, [Кол-во строений]) VALUES (@ID, @Название, @Кол_во_строений)";
                var insertCommand = new SqlCommand(sqlQuery2, connection);

                insertCommand.Parameters.AddWithValue("@ID", count + 1);
                insertCommand.Parameters.AddWithValue("@Название", Name);
                insertCommand.Parameters.AddWithValue("@Кол_во_строений", buildings);

                insertCommand.ExecuteNonQuery();
            }
        }
        public static void RemoveGroupBuildings(string Name)
        {
            using (var connection = CreateConnection())
            {
                var sqlQuery = "DELETE FROM [Группы Строений] WHERE Название = @Название";
                var insertCommand = new SqlCommand(sqlQuery, connection);

                // Используйте параметры, чтобы избежать SQL-инъекции
                insertCommand.Parameters.AddWithValue("@Название", Name);

                insertCommand.ExecuteNonQuery();
            }
        }
        public static void UpdateGroupBuildings(string Name, int buildings)
        {
            using (var connection = CreateConnection())
            {
                var sqlQuery2 = "UPDATE [Группы строений] SET [Кол-во строений]=@Кол_во_строений WHERE Название=@Название";
                var insertCommand = new SqlCommand(sqlQuery2, connection);

                insertCommand.Parameters.AddWithValue("@Название", Name);
                insertCommand.Parameters.AddWithValue("@Кол_во_строений", buildings);

                insertCommand.ExecuteNonQuery();
            }
        }

        public static void AddCompany(string Name, string location)
        {
            using (var connection = CreateConnection())
            {
                var sqlQuery1 = "SELECT COUNT(ID) FROM Компании";
                var countCommand = new SqlCommand(sqlQuery1, connection);
                int count = (int)countCommand.ExecuteScalar();

                var sqlQuery2 = "INSERT INTO Компании (ID, Название, Местоположение) VALUES (@ID, @Название, @Местоположение)";
                var insertCommand = new SqlCommand(sqlQuery2, connection);

                insertCommand.Parameters.AddWithValue("@ID", count + 1);
                insertCommand.Parameters.AddWithValue("@Название", Name);
                insertCommand.Parameters.AddWithValue("@Местоположение", location);

                insertCommand.ExecuteNonQuery();
            }
        }
        public static void RemoveCompany(string Name)
        {
            using (var connection = CreateConnection())
            {
                var sqlQuery = "DELETE FROM Компании WHERE Название = @Название";
                var insertCommand = new SqlCommand(sqlQuery, connection);

                // Используйте параметры, чтобы избежать SQL-инъекции
                insertCommand.Parameters.AddWithValue("@Название", Name);

                insertCommand.ExecuteNonQuery();
            }
        }
        public static void UpdateCompany(string Name, string location)
        {
            using (var connection = CreateConnection())
            {
                var sqlQuery2 = "UPDATE Компании SET Местоположение=@Местоположение WHERE Название=@Название";
                var insertCommand = new SqlCommand(sqlQuery2, connection);

                insertCommand.Parameters.AddWithValue("@Название", Name);
                insertCommand.Parameters.AddWithValue("@Местоположение", location);

                insertCommand.ExecuteNonQuery();
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
        public static List<BuildingsGroup> BuildingsGroupData()
        {
            var connection = CreateConnection();
            var result = new List<BuildingsGroup>();
            const string query = "SELECT * FROM [Группы строений]";
            using (var command = new SqlCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var data = new BuildingsGroup
                        {
                            Id = reader["ID"].ToString(),
                            Name = reader["Название"].ToString(),
                            NumberOfBuildings = reader["Кол-во строений"].ToString(),
                        };
                        result.Add(data);
                    }
                }
            }
            connection.Close();
            return result;
        }
        public static List<Companies> CompaniesData()
        {
            var connection = CreateConnection();
            var result = new List<Companies>();
            const string query = "SELECT * FROM Компании";
            using (var command = new SqlCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var data = new Companies
                        {
                            Id = reader["ID"].ToString(),
                            Name = reader["Название"].ToString(),
                            Location = reader["Местоположение"].ToString(),
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
    public class BuildingsGroup
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string NumberOfBuildings { get; set; }
    }
    public class Companies
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
    public class UserData
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
