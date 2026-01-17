using ItemTracer.Core.Application.Services;
using ItemTracer.Core.Domain.Repositories;
using ItemTracer.Infrastructure.Persistence;
using ItemTracer.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItemTracer.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ItemTracerDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("Postgres")));

        services.AddScoped<ITestLogRepository, TestLogRepository>();
        services.AddScoped<TestLogService>();
        return services;
    }
}

