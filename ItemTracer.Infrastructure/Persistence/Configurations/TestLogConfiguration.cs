using ItemTracer.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItemTracer.Infrastructure.Persistence.Configurations;

public class TestLogConfiguration : IEntityTypeConfiguration<TestLog>
{
    public void Configure(EntityTypeBuilder<TestLog> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Message)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(x => x.CreatedAt);
    }
}