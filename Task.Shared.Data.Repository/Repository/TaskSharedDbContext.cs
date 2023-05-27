using Microsoft.EntityFrameworkCore;
using Task.Domain.Entites;


namespace Task.Shared.Data.Repository
{
    public class TaskSharedDbContext : DbContext
    {
        public TaskSharedDbContext(DbContextOptions<TaskSharedDbContext> options) : base(options)
        {
        }
        protected TaskSharedDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Team> Team { get; set; }
        public DbSet<TeamMemeber> TeamMemeber { get; set; }
        public DbSet<TeamSchedule> TeamSchedule { get; set; }

        // Contracts
        //public DbSet<Contracts> Contracts { get; set; }
        //public DbSet<ContractPayment> ContractPayment { get; set; }
        //public DbSet<ContractDetails> ContractDetails { get; set; }
        //public DbSet<ContractAttachment> ContractAttachment { get; set; }
        //public DbSet<InitialReservationPaymentContract> InitialReservationPaymentContract { get; set; }


        //// Reservations
        //public DbSet<Reservations> Reservations { get; set; }
        //public DbSet<ReservationPayment> ReservationPayment { get; set; }
        //public DbSet<MarketersReservations> MarketersReservations { get; set; }
        //public DbSet<RevenueCollection> RevenueCollection { get; set; }
        //public DbSet<ContractsInspectionRequest> ContractsInspectionRequest { get; set; }



        ////lookups
        //public DbSet<City> City { get; set; }
        //public DbSet<Bank> Bank { get; set; }
        //public DbSet<Region> Region { get; set; }

    }
}