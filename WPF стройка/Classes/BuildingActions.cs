using System.Data.SqlClient;

namespace WPF_стройка
{
    internal static class BuildingActions
    {

        public static void AddBuilding(string Name, int Floors, float Height, int isResidential)
        {
            using (var connection = CreateConnection())
            {
                var count = SqlConnect.GetTableCount("Строения", connection);

                ExecuteNonQuery("INSERT INTO Строения (ID, Название, [Кол-во этажей], Высота, Жилой) VALUES (@ID, @Название, @Кол_во_этажей, @Высота, @Жилой)",
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
}