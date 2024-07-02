using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ProvasEnem.Api.Data.Mappings;
using ProvasEnem.Core.Models;

namespace ProvasEnem.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions options)
    {
        
    }
    
    public DbSet<ExamModel> Exams { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
       => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}