using Dapper;
using SQLite_Tutorial.Models;
using System.Data;
using System.Data.SQLite;

namespace SQLite_Tutorial.Dapper
{
    public class DataAccess_Dapper : ISqliteAPI
    {
        private string _ConnectionString;
        public DataAccess_Dapper(string connectionString)
        {
            _ConnectionString = connectionString;
        }

        public void CreateDb()
        {
            using (var connection = new SQLiteConnection(_ConnectionString))
            {
                connection.Open();
                Console.WriteLine("Database created successfully!");

                string createTableQuery = "CREATE TABLE IF NOT EXISTS Person (Id INTEGER PRIMARY KEY, FirstName TEXT, LastName TEXT)";
                using (var command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Table created successfully!");
                }
            }
        }

        public void DeleteDb()
        {

            const string prefix = "Data Source=";
            const string suffix = ";";

            int startIndex = _ConnectionString.IndexOf(prefix) + prefix.Length;
            int endIndex = _ConnectionString.IndexOf(suffix, startIndex);

            if (startIndex < prefix.Length || endIndex < 0)
            {
                throw new ArgumentException("Invalid connection string format.");
            }

            string dbPath = _ConnectionString.Substring(startIndex, endIndex - startIndex);

            if (File.Exists(dbPath))
            {
                File.Delete(dbPath);
                Console.WriteLine("Database deleted successfully!\n");
            }
            else
            {
                Console.WriteLine("Database file does not exist.\n");
            }
        }

        public List<PersonModel> LoadPeople()
        {
            using (IDbConnection conn = new SQLiteConnection(_ConnectionString))
            {
                string sqlCommand = "select * from Person";

                var output = conn.Query<PersonModel>(sqlCommand, new DynamicParameters());

                return output.ToList();
            }
        }

        public void SavePerson(PersonModel person)
        {
            using (IDbConnection conn = new SQLiteConnection(_ConnectionString))
            {
                string sqlCommand = "insert into Person (FirstName, LastName) values (@FirstName, @LastName)";
                conn.Execute(sqlCommand, person);
            }
        }

        public void BatchInsert(List<PersonModel> people)
        {
            using (var connection = new SQLiteConnection(_ConnectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    string sqlCommand = "INSERT INTO Person (FirstName, LastName) VALUES (@FirstName, @LastName)";
                    connection.Execute(sqlCommand, people, transaction);
                    transaction.Commit();
                }
            }
        }


    }
}
