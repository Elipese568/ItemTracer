using ItemTracer.Core.Application.Services;
using ItemTracer.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ItemTracer.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestLogController : ControllerBase
{
    private readonly TestLogService _service;

    public TestLogController(TestLogService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<Guid> Create(string message)
        => await _service.CreateAsync(message);

    [HttpGet("{id}")]
    public async Task<TestLog?> Get(Guid id)
        => await _service.GetAsync(id);

    [HttpGet]
    public async Task<List<TestLog>> GetAll()
        => await _service.GetAllAsync();

    [HttpDelete("{id}")]
    public async Task Delete(Guid id)
        => await _service.DeleteAsync(id);
}
