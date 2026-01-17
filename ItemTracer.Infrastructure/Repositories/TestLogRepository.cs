using ItemTracer.Core.Domain.Entities;
using ItemTracer.Core.Domain.Repositories;
using ItemTracer.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItemTracer.Infrastructure.Repositories;

public class TestLogRepository : ITestLogRepository
{
    private readonly ItemTracerDbContext _db;

    public TestLogRepository(ItemTracerDbContext db)
    {
        _db = db;
    }

    public async Task AddAsync(TestLog log)
    {
        _db.TestLogs.Add(log);
        await _db.SaveChangesAsync();
    }

    public Task<TestLog?> GetAsync(Guid id)
        => _db.TestLogs.FindAsync(id).AsTask();

    public Task<List<TestLog>> GetAllAsync()
        => _db.TestLogs
              .OrderByDescending(x => x.CreatedAt)
              .ToListAsync();

    public async Task DeleteAsync(TestLog log)
    {
        _db.TestLogs.Remove(log);
        await _db.SaveChangesAsync();
    }
}
