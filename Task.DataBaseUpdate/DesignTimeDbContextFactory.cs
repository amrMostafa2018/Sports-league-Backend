using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using Task.DatabaseMigration;

namespace Nafes.DatabaseUpdate
{

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TaskDbContext>
    {
        public TaskDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<TaskDbContext>();

            var connectionString = configuration.GetConnectionString("ConnectionString");

            Console.WriteLine(connectionString);

            builder.UseSqlServer(connectionString);

            return new TaskDbContext(builder.Options);
        }
    }
}
