using System;
using Microsoft.EntityFrameworkCore;
using TasksApi.Entities;

namespace TasksApi.DbContexts;

public class MojTasksContext : DbContext
{
    public DbSet<MojTask> MojTasks => Set<MojTask>();//{ get; set; } = null!;

    public MojTasksContext(DbContextOptions<MojTasksContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<MojTask>().HasData(
            new MojTask()
            {
                TaskId = 1,
                TaskDescription = "First Task",
                TaskStatus = "Started",
                TaskDueDate = new DateOnly(2025, 5, 9)
            },
            new MojTask()
            {
                TaskId = 2,
                TaskDescription = "Second Task",
                TaskStatus = "Waiting",
                TaskDueDate = new DateOnly(2025, 4, 10)
            },
            new MojTask()
            {
                TaskId = 3,
                TaskDescription = "Third Task",
                TaskStatus = "Blocked",
                TaskDueDate = new DateOnly(2025, 3, 11)
            },
            new MojTask()
            {
                TaskId = 4,
                TaskDescription = "Fourth Task",
                TaskStatus = "Finished",
                TaskDueDate = new DateOnly(2025, 2, 12)
            }
        );


    }
}
