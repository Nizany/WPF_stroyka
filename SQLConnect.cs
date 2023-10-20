using System;
using Login_Data;

namespace SQLConnect
{

    public class SqlConnect
    {
        private readonly string _connectionString = Data.Connect_Data;

        public SqlConnect()
        {
        }

        public List<MyData> ConnectAndDoSomething()
        {
            List<MyData> result = new List<MyData>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var query = "SELECT * FROM Строения";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MyData data = new MyData
                            {
                                Column1 = reader["ID_Строения"].ToString(),
                                Column2 = reader["Название"].ToString(),
                                Column3 = reader["Высота"].ToString(),
                                Column4 = reader["Кол-во этажей"].ToString(),
                                Column5 = reader["Жилой"].ToString(),
                            };
                            result.Add(data);
                        }
                    }
                }
                connection.Close();
            }

            return result;
        }
    }
}