using ItemTracer.Core.Domain.Entities;
using ItemTracer.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItemTracer.Core.Application.Services;

public class TestLogService
{
    private readonly ITestLogRepository _repository;

    public TestLogService(ITestLogRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> CreateAsync(string message)
    {
        var log = new TestLog(message);
        await _repository.AddAsync(log);
        return log.Id;
    }

    public Task<TestLog?> GetAsync(Guid id)
        => _repository.GetAsync(id);

    public Task<List<TestLog>> GetAllAsync()
        => _repository.GetAllAsync();

    public async Task DeleteAsync(Guid id)
    {
        var log = await _repository.GetAsync(id);
        if (log is null) return;

        await _repository.DeleteAsync(log);
    }
}

