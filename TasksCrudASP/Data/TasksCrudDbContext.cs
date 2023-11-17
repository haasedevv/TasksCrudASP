using Microsoft.EntityFrameworkCore;
using TasksCrudASP.Data.Map;
using TasksCrudASP.Models;

namespace TasksCrudASP.Data;

public class TasksCrudDbContext: DbContext
{
    public TasksCrudDbContext(DbContextOptions<TasksCrudDbContext> options) : base(options)
    {

    }

    public DbSet<UserModel> Users { get; set; }
    public DbSet<TaskModel> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new TaskMap());
        base.OnModelCreating(modelBuilder);
    }
}
