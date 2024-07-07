using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ProvasEnem.Core.Models;

namespace ProvasEnem.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext()
    {
        
    }
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<ExamModel> Exams { get; set; } = null!;
    public DbSet<PostModel> Posts { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .AddUserSecrets<AppDbContext>()
            .Build();

        var cnn = configuration.GetConnectionString("DefaultConnection");

        optionsBuilder.UseSqlServer(cnn);
    }
}