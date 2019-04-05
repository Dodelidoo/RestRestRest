using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Models;

namespace Supermarket.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Battery> Batteries { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<Battery>().ToTable("batteries");
            builder.Entity<Battery>().HasKey(p => p.id);
            builder.Entity<Battery>().Property(p => p.building_id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Battery>().Property(p => p.status).IsRequired().HasMaxLength(32);
        //    builder.Entity<Battery>().HasMany(p => p.Products).WithOne(p => p.Battery).HasForeignKey(p => p.BatteryId);

            // builder.Entity<Battery>().HasData
            // (
            //     new Battery { Id = 100, Name = "Fruits and Vegetables" }, // Id set manually due to in-memory provider
            //     new Battery { Id = 101, Name = "Dairy" }
            // );
        }
    }
}