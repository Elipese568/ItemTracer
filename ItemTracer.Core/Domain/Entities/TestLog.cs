using System;
using System.Collections.Generic;
using System.Text;

namespace ItemTracer.Core.Domain.Entities;

public class TestLog
{
    public Guid Id { get; private set; }
    public string Message { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private TestLog() { } // EF 用

    public TestLog(string message)
    {
        Id = Guid.NewGuid();
        Message = message;
        CreatedAt = DateTime.UtcNow;
    }
}
