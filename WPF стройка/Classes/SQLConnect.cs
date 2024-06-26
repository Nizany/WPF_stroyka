﻿using System.Collections.Generic;
using System.Data.SqlClient;

namespace WPF_стройка
{
    public abstract class DataAccess
    {
        protected static SqlConnection CreateConnection()
        {
            var connection = new SqlConnection(Data.Connect_Data);
            connection.Open();
            return connection;
        }
        protected static int GetTableCount(string tableName, SqlConnection connection)
        {
            var sqlQuery = $"SELECT COUNT(ID) FROM {tableName}";
            var countCommand = new SqlCommand(sqlQuery, connection);
            return (int)countCommand.ExecuteScalar();
        }
        protected static void ExecuteNonQuery(string query, SqlConnection connection, params SqlParameter[] parameters)
        {
            var command = new SqlCommand(query, connection);
            command.Parameters.AddRange(parameters);
            command.ExecuteNonQuery();
        }
    }
    public class UserActions : DataAccess
    {
        public static void RegisterUser(string Login, string Password)
        {
            using (var connection = CreateConnection())
            {
                var count = GetTableCount("Авторизация", connection);

                ExecuteNonQuery("INSERT INTO Авторизация (ID, Login, Password) VALUES (@ID, @Login, @Password)",
                    connection,
                    new SqlParameter("@ID", count + 1),
                    new SqlParameter("@Login", Login),
                    new SqlParameter("@Password", Password));
            }
        }
    }
    public class BuildingActions : DataAccess
    {
        public static void AddBuilding(string Name, int Floors, float Height, int isResidential)
        {
            using (var connection = CreateConnection())
            {
                var tableName = "Строения";
                var count = GetTableCount(tableName, connection);

                ExecuteNonQuery($"INSERT INTO {tableName} (ID, Название, [Кол-во этажей], Высота, Жилой)" +
                    $" VALUES (@ID, @Название, @Кол_во_этажей, @Высота, @Жилой)",
                                connection,
                                new SqlParameter("@ID", count + 1),
                                new SqlParameter("@Название", Name),
                                new SqlParameter("@Кол_во_этажей", Floors),
                                new SqlParameter("@Высота", Height),
                                new SqlParameter("@Жилой", isResidential));
            }
        }
        public static void RemoveBuilding(string Name)
        {
            using (var connection = CreateConnection())
            {
                ExecuteNonQuery("DELETE FROM Строения WHERE Название = @Название",
                    connection,
                    new SqlParameter("@Название", Name));
            }
        }
        public static void UpdateBuilding(string Name, int Floors, float Height, int isResidential)
        {
            using (var connection = CreateConnection())
            {
                ExecuteNonQuery("UPDATE Строения SET [Кол-во этажей]=@Кол_во_этажей, Высота=@Высота, Жилой=@Жилой WHERE Название=@Название",
                                connection,
                                new SqlParameter("@Название", Name),
                                new SqlParameter("@Кол_во_этажей", Floors),
                                new SqlParameter("@Высота", Height),
                                new SqlParameter("@Жилой", isResidential));
            }
        }
    }
    public class GroupBuildingActions : DataAccess {
        public static void AddGroupBuilding(string Name, int buildings)
        {
            using (var connection = CreateConnection())
            {
                var count = GetTableCount("[Группы строений]", connection);

                ExecuteNonQuery("INSERT INTO Строения (ID_группы_строений, Название, [Кол-во этажей], Высота, Жилой) VALUES (@ID_группы_строения, @Название, @Кол_во_этажей, @Высота, @Жилой)",
                                connection,
                                new SqlParameter("@ID_строения", count + 1),
                                new SqlParameter("@Название", Name),
                                new SqlParameter("@Кол_во_строений", buildings));
            }
        }
        public static void RemoveGroupBuildings(string Name)
        {
            using (var connection = CreateConnection())
            {
                ExecuteNonQuery("DELETE FROM [Группы Строений] WHERE Название = @Название",
                    connection,
                    new SqlParameter("@Название", Name));
            }
        }
        public static void UpdateGroupBuildings(string Name, int buildings)
        {
            using (var connection = CreateConnection())
            {
                ExecuteNonQuery("UPDATE [Группы строений] SET [Кол-во строений]=@Кол_во_строений WHERE Название=@Название",
                    connection,
                    new SqlParameter("@Название", Name),
                    new SqlParameter("@Кол_во_строений", buildings));
            }
        }
    }
    public class CompaniesActions : DataAccess
    {
        public static void AddCompany(string Name, string location)
        {
            using (var connection = CreateConnection())
            {
                var count = GetTableCount("Компании", connection);

                InsertCompanyData(connection, count, Name, location);
            }
        }
        private static void InsertCompanyData(SqlConnection connection, int count, string Name, string location)
        {
            ExecuteNonQuery("INSERT INTO Компании (ID, Название, Местоположение) VALUES (@ID, @Название, @Местоположение",
                            connection,
                            new SqlParameter("@ID", count + 1),
                            new SqlParameter("@Название", Name),
                            new SqlParameter("@Местоположение", location));
        }
        public static void RemoveCompany(string Name)
        {
            using (var connection = CreateConnection())
            {
                var sqlQuery = "DELETE FROM Компании WHERE Название = @Название";
                var insertCommand = new SqlCommand(sqlQuery, connection);

                insertCommand.Parameters.AddWithValue("@Название", Name);

                ExecuteNonQuery("DELETE FROM Компании WHERE Название = @Название",
                                    connection,
                                    new SqlParameter("@Название", Name));
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

                ExecuteNonQuery("UPDATE Компании SET Местоположение=@Местоположение WHERE Название=@Название",
                                connection,
                                new SqlParameter("@Название", Name),
                                new SqlParameter("@Местоположение", location));
            }
        }
    }
    public class ListActions : DataAccess
    {
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
                            Id = reader["ID"].ToString(),
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
                        (
                            reader["ID"].ToString(),
                            reader["Название"].ToString(),
                            reader["Местоположение"].ToString()
                        );
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
    public class UserData
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}