using System;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using TasksApi.DbContexts;
using TasksApi.Entities;

namespace TasksApi.Services;

public class MojTasksRepository : IMojTasksRepository
{
    private readonly MojTasksContext _context;

    public MojTasksRepository(MojTasksContext context)
    {
        _context = context ??
            throw new ArgumentNullException(nameof(context));
    }

    public void CreateMojTask(MojTask mojTask)
    {
        _context.Add(mojTask);
    }

    public void DeleteMojTask(MojTask mojTask)
    {
        _context.Remove(mojTask);
    }

    public async Task<MojTask?> GetMojTaskAsync(int id)
    {
        return await _context.MojTasks.FirstOrDefaultAsync(m => m.TaskId == id);
    }

    public async Task<IEnumerable<MojTask>> GetMojTasksAsync()
    {
        return await _context.MojTasks.ToListAsync();
    }

    public async Task<bool> SaveMojTaskAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public void UpdateMojTask(MojTask mojTask)
    {
        _context.Update(mojTask);
    }
}

