using Microsoft.EntityFrameworkCore;
using SQLite_Tutorial.Models;

namespace SQLite_Tutorial.EF
{
    public class MyDbContext : DbContext
    {
        string _ConnectionString;
        public DbSet<PersonModel> People { get; set; }
        public MyDbContext(string connectionString)
        {
            _ConnectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_ConnectionString);
        }
    }
}
