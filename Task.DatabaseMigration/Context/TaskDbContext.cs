using Microsoft.EntityFrameworkCore;
using Task.Domain.Entites;
using Task.Domain.Lookups;
using Task.Shared.Data.Repository;

namespace Task.DatabaseMigration
{
    public class TaskDbContext : TaskSharedDbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {

        }

        protected TaskDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }

}

