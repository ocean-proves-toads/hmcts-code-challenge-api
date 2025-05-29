using System;
using System.Diagnostics.Eventing.Reader;
using Microsoft.EntityFrameworkCore.Metadata;
using TasksApi.Entities;

namespace TasksApi.Services;

public interface IMojTasksRepository
{
    Task<IEnumerable<MojTask>> GetMojTasksAsync();
    Task<MojTask?> GetMojTaskAsync(int id);
    void CreateMojTask(MojTask mojTask);
    Task<bool> SaveMojTaskAsync();
    void DeleteMojTask(MojTask mojTask);
    void UpdateMojTask(MojTask mojTask);
}
