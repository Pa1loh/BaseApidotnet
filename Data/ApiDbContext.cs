using _net.Models;
using Microsoft.EntityFrameworkCore;

namespace _net.Data;
public class ApiDbContext : DbContext{

public DbSet<Todo>? Todos { get;set; }

 protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
 optionsBuilder.UseSqlite("DataSource=api.db;Cache=Shared");

}

