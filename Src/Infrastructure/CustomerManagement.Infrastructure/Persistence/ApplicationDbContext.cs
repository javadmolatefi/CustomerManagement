using CustomerManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<City> Cities => Set<City>();
    public DbSet<LogEntry> Logs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsRequired();

            entity.Property(e => e.Address)
                .HasMaxLength(200);

            entity.Property(e => e.Phone)
                .HasMaxLength(20);

            entity.Property(e => e.Fax)
                .HasMaxLength(20);
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.Property(e => e.Title)
                .HasMaxLength(30)
                .IsRequired();
        });
    }
}
