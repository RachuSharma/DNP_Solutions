using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;

namespace WebApi.Controller;

[ApiController]
[Route("ctx")]
public class ProjectController : ControllerBase
{
    private readonly IDataService _dataService;

    public ProjectController(IDataService dataService)
    {
        _dataService = dataService;
    }
}
// 1. create project
//[HttpPost]

