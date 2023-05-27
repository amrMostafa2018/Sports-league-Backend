
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasel.Domain.Entites;

namespace Tasel.Infrastructure.Context
{
    public class TaselDbContext : DbContext
    {
        public TaselDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyAttachment> PropertyAttachments { get; set; }
        public DbSet<PropertyUser> PropertyUsers { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PropertyAttachment>()
                  .HasKey(m => new { m.PropertyId, m.AttachmentId });
        }
    }
}
