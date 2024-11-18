using SQLite_Tutorial.Dapper;
using SQLite_Tutorial.EF;

namespace HelloWorldSample
{
    class Program
    {
        static void Main(string[] args)
        {
            string dbPath = "MyDatabase.db";
            string connectionString = $"Data Source={dbPath};";

            var DapperTest = new DapperTests(connectionString);
            var EFTest = new EFTests(connectionString);

            DapperTest.WriteSingle(1000);

            DapperTest.WriteBatch(1000, 50);

            EFTest.WriteSingle(1000);

            EFTest.WriteBatch(1000, 50);

        }



    }
}