using ExcelReader.Models;
using Microsoft.EntityFrameworkCore;

namespace ExcelReader.Data;

public class ExcelDbContext : DbContext
{
    public string _connectionString;

    public ExcelDbContext(DbContextOptions<ExcelDbContext> options) : base(options)
    {
    }

    public DbSet<Inventory> Inventories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Inventory>().ToTable("Exercise");
        modelBuilder.Entity<Inventory>()
            .Property(e => e.Id)
            .ValueGeneratedNever(); 
    }
}