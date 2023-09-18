using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TaskMediaExpert.Domain.Entity;

namespace TaskMediaExpert.Persistence
{
    public class TaskMediaExpertDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;

    public TaskMediaExpertDbContext(DbContextOptions<TaskMediaExpertDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskMediaExpertDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>().HasData(
      new Product()
      {
          Id = Guid.Parse("8BE3D024-9F31-41C4-9768-80E2AFD5CD0E"),
          Code = "1",
          Name = "Telephone",
          Price = 5555.52
      },
      new Product()
      {
          Id = Guid.Parse("60359A55-3C34-4230-A5B6-6C8AFA0F17E5"),
          Code = "2",
          Name = "Printer",
          Price = 505.52
      },
      new Product()
      {
          Id = Guid.Parse("C1310F5A-6187-4FC4-9DE1-450EBA8707BC"),
          Code = "3",
          Name = "TV",
          Price = 3000.52
      }); ;
    }
}
}
