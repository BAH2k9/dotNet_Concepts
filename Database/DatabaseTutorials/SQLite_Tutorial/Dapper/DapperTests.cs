using SQLite_Tutorial.Models;
using System.Diagnostics;

namespace SQLite_Tutorial.Dapper
{
    public class DapperTests
    {
        string _ConnectionString;
        public DapperTests(string connectionString)
        {
            _ConnectionString = connectionString;
        }
        public void WriteSingle(int n)
        {
            Console.WriteLine($"Running Dapper Test WriteSingle");

            ISqliteAPI dapper = new DataAccess_Dapper(_ConnectionString);

            dapper.CreateDb();

            List<PersonModel> people = new List<PersonModel>();
            List<double> times = new List<double>();


            for (int i = 0; i < n; i++)
            {
                Stopwatch stopwatch = new Stopwatch();
                var newPerson = new PersonModel($"{i}", $"{i}");
                people.Add(newPerson);

                stopwatch.Start();
                dapper.SavePerson(newPerson);
                stopwatch.Stop();


                times.Add(stopwatch.ElapsedMilliseconds);

            }


            var avgWriteTime = times.Average();

            Console.WriteLine($"Average insert Write time of: {avgWriteTime}ms\twith a sample size of: {n} ");

            dapper.DeleteDb();
        }

        public void WriteBatch(int batchSize, int numberOfBatches)
        {

            Console.WriteLine($"Running Dapper Test WriteBatch");

            ISqliteAPI dapper = new DataAccess_Dapper(_ConnectionString);

            dapper.CreateDb();
            List<double> times = new List<double>();

            for (int j = 0; j < numberOfBatches; j++)
            {
                Stopwatch stopwatch = new Stopwatch();
                List<PersonModel> people = new List<PersonModel>();

                for (int i = 0; i < batchSize; i++)
                {
                    var newPerson = new PersonModel($"{i}", $"{i}");
                    people.Add(newPerson);
                }

                stopwatch.Start();
                dapper.BatchInsert(people);
                stopwatch.Stop();

                times.Add(stopwatch.ElapsedMilliseconds);
            }


            var avgWriteTimePerBatch = times.Average();

            Console.WriteLine($"Average insert Write time of Batch: {avgWriteTimePerBatch}ms\twitha batch size of: {batchSize} and {numberOfBatches} Batches");

            dapper.DeleteDb();

        }

        public void ReadSingle(int n)
        {
            Console.WriteLine($"Running Dapper Test ReadSingle");

            ISqliteAPI dapper = new DataAccess_Dapper(_ConnectionString);

            dapper.CreateDb();

            List<double> times = new List<double>();


            for (int i = 0; i < n; i++)
            {
                Stopwatch stopwatch = new Stopwatch();
                var newPerson = new PersonModel($"{i}", $"{i}");
                dapper.SavePerson(newPerson);


                stopwatch.Start();
                dapper.LoadMostRecentPerson();
                stopwatch.Stop();


                times.Add(stopwatch.ElapsedMilliseconds);

            }


            var avgWriteTime = times.Average();

            Console.WriteLine($"Average insert Write time of: {avgWriteTime}ms\twith a sample size of: {n} ");

            dapper.DeleteDb();
        }

        public void ReadBatch(int batchSize, int numberOfBatches)
        {
            Console.WriteLine($"Running Dapper Test WriteBatch");

            ISqliteAPI dapper = new DataAccess_Dapper(_ConnectionString);

            dapper.CreateDb();
            List<double> times = new List<double>();

            for (int j = 0; j < numberOfBatches; j++)
            {
                Stopwatch stopwatch = new Stopwatch();
                List<PersonModel> people = new List<PersonModel>();

                for (int i = 0; i < batchSize; i++)
                {
                    var newPerson = new PersonModel($"{i}", $"{i}");
                    people.Add(newPerson);
                }


                dapper.BatchInsert(people);

                stopwatch.Start();
                dapper.LoadBatch(batchSize);
                stopwatch.Stop();

                times.Add(stopwatch.ElapsedMilliseconds);
            }


            var avgWriteTimePerBatch = times.Average();

            Console.WriteLine($"Average insert Write time of Batch: {avgWriteTimePerBatch}ms\twitha batch size of: {batchSize} and {numberOfBatches} Batches");

            dapper.DeleteDb();
        }
    }
}
