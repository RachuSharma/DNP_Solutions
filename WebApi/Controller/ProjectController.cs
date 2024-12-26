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
    
    [HttpPost]
    public async Task<IActionResult> AddProject([FromBody] Project _project)
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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Project>>> GetManyProjects([FromQuery] string? status = null, [FromQuery] string? responsible = null)
    {
        try
        {
            var projects = await _dataService.GetManyProjects(status, responsible);
            return Ok(projects);
        }
        catch (Exception e)
        {
            return BadRequest(new { Message = e.Message });
        }
    }

    [HttpGet("{projectId}")]
    public async Task<IActionResult> GetsingleProject( [FromQuery]int projectId)
    {
        try
        {
            var project = await _dataService.GetProjectByIdAsync(projectId);
            return Ok(project);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

    

    [HttpPut("{projectId}")]
    public async Task<IActionResult> UpdateProject([FromRoute] int projectId, [FromBody] Project project)
    {
        try
        {
            await _dataService.UpdateProjectAsync(projectId, project);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

    [HttpDelete("{projectId}")]
    public async Task<IActionResult> DeleteProject([FromRoute]int projectId)
    {
        try
        {
            await _dataService.DeleteProjectAsync(projectId);
            return Ok();
                    
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

    [HttpPost("{projectId}/userstory")]
    public async Task<IActionResult> AddUserStory([FromRoute]int projectId, [FromBody] UserStory userStory)
    {
        try
        {
            var userStoryAdded = await _dataService.AddUserStoryAsync(projectId, userStory);
            return Ok(userStoryAdded);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

}

