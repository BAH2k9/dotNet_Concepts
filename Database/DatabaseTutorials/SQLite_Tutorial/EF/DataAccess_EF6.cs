using Dapper;
using Microsoft.EntityFrameworkCore;
using SQLite_Tutorial.Models;
using System;
using System.Data;
using System.Data.SQLite;

namespace SQLite_Tutorial.EF
{
    public class DataAccess_EF6 : ISqliteAPI
    {
        string _ConnectionString;

        public DataAccess_EF6(string connectionString)
        {
            _ConnectionString = connectionString;
        }

        public List<PersonModel> LoadPeople()
        {
            var people = new List<PersonModel>();

            using (var context = new MyDbContext(_ConnectionString))
            {

                people = context.People.ToList();

            }

            return people;
        }

        public void SavePerson(PersonModel person)
        {
            using (var context = new MyDbContext(_ConnectionString))
            {
                //context.Database.EnsureCreated();

                context.People.Add(person);

                context.SaveChanges();
            }

        }

        public void CreateDb()
        {
            using var context = new MyDbContext(_ConnectionString);
            {
                context.Database.EnsureCreated();

            }

            Console.WriteLine("Database created successfully!");
        }

        public void DeleteDb()
        {
            using var context = new MyDbContext(_ConnectionString);
            {
                context.Database.EnsureDeleted();

            }

            Console.WriteLine("Database Deleted successfully!\n");
        }

        public void BatchInsert(List<PersonModel> people)
        {
            using (var context = new MyDbContext(_ConnectionString))
            {

                using (var transaction = context.Database.BeginTransaction())
                {
                    // Add the batch to the context
                    context.People.AddRange(people);

                    // Commit the batch
                    context.SaveChanges();
                    transaction.Commit();
                }

            }


        }

        public List<PersonModel> LoadAllPeople()
        {
            throw new NotImplementedException();
        }

        public PersonModel LoadMostRecentPerson()
        {

            using (var context = new MyDbContext(_ConnectionString))
            {
                var mostRecentPerson = context.People
                                          .OrderByDescending(p => p.Id)
                                          .FirstOrDefault();

                if (mostRecentPerson == null)
                {
                    throw new Exception("No Records found");
                }

                return mostRecentPerson;
            }

        }

        public List<PersonModel> LoadBatch(int n)
        {
            using (var context = new MyDbContext(_ConnectionString))
            {
                var batch = context.People
                                   .OrderByDescending(p => p.Id) // Sort by most recent (descending order)
                                   .Take(n)             // Take only the specified batch size
                                   .ToList();

                return batch;

            }
        }
    }
}
