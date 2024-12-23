using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;

namespace WebApi.Controller;

[ApiController]
[Route("api/[controller]")]
public class ProjectController : ControllerBase
{
    private readonly IDataService _dataService;

    public ProjectController(IDataService dataService)
    {
        _dataService = dataService;
    }

    [HttpPost]
    public ActionResult AddProject([FromBody]Project project)
    {
        _dataService.AddProject(project);
        return Created($"/api/project/{project.Id}", project);

    }

    [HttpGet("{projectId}")]

    public ActionResult GetProject([FromRoute]int id)
    {
        var project = _dataService.GetProjectById(id);
        if (project == null) return NotFound();
        return Ok(project);    }



}



