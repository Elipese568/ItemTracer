using ItemTracer.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace ItemTracer.Infrastructure.Persistence;

public class ItemTracerDbContext : DbContext
{
    public DbSet<TestLog> TestLogs => Set<TestLog>();
    public ItemTracerDbContext(DbContextOptions<ItemTracerDbContext> options)
        : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(ItemTracerDbContext).Assembly
        );
    }
}