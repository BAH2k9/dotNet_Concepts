using SQLite_Tutorial.Models;
using System.Diagnostics;

namespace SQLite_Tutorial.EF
{
    internal class EFTests
    {
        string _ConnectionString;
        public EFTests(string connectionString)
        {
            _ConnectionString = connectionString;
        }

        public void WriteSingle(int n)
        {
            Console.WriteLine($"\n\nRunning EF Test");

            ISqliteAPI EF = new DataAccess_EF6(_ConnectionString);

            EF.CreateDb();

            List<PersonModel> people = new List<PersonModel>();
            List<double> times = new List<double>();


            for (int i = 0; i < n; i++)
            {
                Stopwatch stopwatch = new Stopwatch();
                var newPerson = new PersonModel($"{i}", $"{i}");
                people.Add(newPerson);

                stopwatch.Start();
                EF.SavePerson(newPerson);
                stopwatch.Stop();

                times.Add(stopwatch.ElapsedMilliseconds);

            }

            var avgWriteTime = times.Sum() / n;

            Console.WriteLine($"Average insert Write time of: {avgWriteTime}ms\twith a sample size of: {n} ");

            EF.DeleteDb();

        }

        public void WriteBatch(int batchSize, int numberOfBatches)
        {
            Console.WriteLine($"Running EF Test WriteBatch");

            ISqliteAPI EF = new DataAccess_EF6(_ConnectionString);

            EF.CreateDb();

            List<double> times = new List<double>();

            for (int j = 0; j < numberOfBatches; j++)
            {
                Stopwatch stopwatch = new Stopwatch();
                var people = new List<PersonModel>();
                for (int i = 0; i < batchSize; i++)
                {
                    people.Add(new PersonModel { FirstName = $"{i}", LastName = $"{i}" });
                }

                // Measure the time for batch insert
                stopwatch.Start();
                EF.BatchInsert(people);
                stopwatch.Stop();

                times.Add(stopwatch.ElapsedMilliseconds);
            }

            var avgWriteTimePerBatch = times.Average();

            Console.WriteLine($"Average insert Write time of Batch: {avgWriteTimePerBatch}ms\twith a bacth size of{batchSize} and {numberOfBatches} Batches");

            EF.DeleteDb();

        }
    }
}
