using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Models;

namespace Supermarket.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Battery> Batteries { get; set; }
        public DbSet<Column> Columns { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<Battery>().ToTable("batteries");
            builder.Entity<Battery>().HasKey(p => p.id);
            builder.Entity<Battery>().Property(p => p.status).IsRequired().HasMaxLength(32);
            builder.Entity<Battery>().HasMany(p => p.Column).WithOne(p => p.Battery);
            // .HasForeignKey(p => p.BatteryId);
            // builder.Entity<Battery>().HasMany(p => p.Elevator).WithOne(p => p.Column).HasForeignKey(p => p.BatteryId);


            builder.Entity<Column>().ToTable("columns");
            builder.Entity<Column>().HasKey(p => p.id);
            builder.Entity<Column>().Property(p => p.id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Column>().Property(p => p.status).IsRequired().HasMaxLength(32);










        }
    }
}

            // builder.Entity<Battery>().Property(p => p.building_id).IsRequired().ValueGeneratedOnAdd();
