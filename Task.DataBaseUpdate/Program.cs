﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Task.DatabaseMigration;
using Task.Shared.Security;

namespace Task.Database
{
    [SuppressMessage("ReSharper", "LocalizableElement")]
    // ReSharper disable once ClassNeverInstantiated.Global
    class Program
    {
        private static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                     .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile("appsettings.json")
                     .Build();

            var optionsBuilder = new DbContextOptionsBuilder<TaskDbContext>();
            var connectionStr = config.GetConnectionString("ConnectionString");
            optionsBuilder.UseSqlServer(connectionStr);

            using (var context = new TaskDbContext(optionsBuilder.Options))
            {
                Console.WriteLine("Ensuring database is created...");
                Console.WriteLine(connectionStr);

                //bool exist = context.Database.EnsureCreated();

                Console.WriteLine("Migrating the database to the latest version...");
                var pendingMigrations = (context.Database.GetPendingMigrations());
                if (pendingMigrations.Any())
                    context.Database.Migrate();
            }

            //Console.WriteLine("Now, creating the database for identity...");

            var identityOptionsBuilder = new DbContextOptionsBuilder<ApplicationIdentityDbContext>();
            identityOptionsBuilder.UseSqlServer(config.GetConnectionString("ConnectionString"));
            using (ApplicationIdentityDbContext identityContext = new ApplicationIdentityDbContext(identityOptionsBuilder.Options))
            {
                identityContext.Database.Migrate();
                Console.WriteLine("Identity DB is now created");
            }
            Console.WriteLine("Database has been updated successfully, Now seeding the database with initial data.");
            Console.WriteLine("done!");
        }
    }
}
