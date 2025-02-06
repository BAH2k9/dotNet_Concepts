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

            DapperTest.WriteBatch(1000, 1000);

            //DapperTest.ReadSingle(100);

            //DapperTest.WriteBatch(100, 50);

            //DapperTest.ReadBatch(100, 50);

            //EFTest.WriteSingle(100);

            //EFTest.ReadSingle(100);

            //EFTest.WriteBatch(100, 50);

            //EFTest.ReadBatch(100, 50);

        }



    }
}