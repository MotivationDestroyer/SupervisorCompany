using Microsoft.EntityFrameworkCore;
using SupervisorCompany.App.Context.Models;

namespace SupervisorCompany.App.Context;

public class SupervisorCompanyDbContext : DbContext
{
    public SupervisorCompanyDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Address> Addresses { get; set; } = null!;
    public DbSet<Contract> Contracts { get; set; } = null!;
    public DbSet<House> Houses { get; set; } = null!;
    public DbSet<Person> Persons { get; set; } = null!;
    public DbSet<Service> Services { get; set; } = null!;

    public DbSet<ServiceType> ServiceTypes { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ServiceType>()
            .HasIndex(s => s.Name)
            .IsUnique();
        modelBuilder.Entity<ServiceType>()
            .Property(s => s.Name)
            .HasMaxLength(200);

        modelBuilder.Entity<Contract>()
            .Property(c => c.Id)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<Contract>()
            .HasMany(c => c.Services)
            .WithOne(s => s.Contract);
        modelBuilder.Entity<Contract>()
            .HasOne(c => c.Person)
            .WithMany(p => p.Contracts);

        modelBuilder.Entity<Person>()
            .HasMany(p => p.Addresses)
            .WithOne(s => s.Person);

        modelBuilder.Entity<Address>()
            .HasOne(a => a.House)
            .WithMany()
            .IsRequired();
        modelBuilder.Entity<Address>()
            .HasOne(a => a.Person)
            .WithMany(p => p.Addresses)
            .IsRequired();

        modelBuilder.Entity<Service>()
            .HasOne(s => s.Contract)
            .WithMany(c => c.Services);
        modelBuilder.Entity<Service>()
            .HasOne(s => s.ServiceType)
            .WithMany(c => c.Services);
    }
}