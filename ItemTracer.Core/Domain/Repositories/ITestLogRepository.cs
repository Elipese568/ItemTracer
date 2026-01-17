using ItemTracer.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItemTracer.Core.Domain.Repositories;

public interface ITestLogRepository
{
    Task AddAsync(TestLog log);
    Task<TestLog?> GetAsync(Guid id);
    Task<List<TestLog>> GetAllAsync();
    Task DeleteAsync(TestLog log);
}
