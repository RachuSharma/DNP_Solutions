using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly IDataService _dataService;

    public ProjectsController(IDataService dataService)
    {
        _dataService = dataService;
    }

    [HttpGet]
    public IQueryable<Project> GetProjects()
    {
        return _dataService.GetManyProjects();
    }

    [HttpGet("{projectId}")]
    public Task<Project> GetProject(int projectId)
    {
        return _dataService.GetProjectByIdAsync(projectId);
    }

    [HttpPost]
    public async Task<IActionResult> AddProject([FromBody] Project? _project)
    {
        try
        {
          var  project = await _dataService.AddProjectAsync(_project);
            
            return Ok(project);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }
}

