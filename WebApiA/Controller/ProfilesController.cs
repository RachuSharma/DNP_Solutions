using Microsoft.AspNetCore.Mvc;
using WebApiA.Entities;
using WebApiA.Service;

namespace WebApiA.Controller;

[ApiController] 
[Route("api/[controller]")]

public class ProfilesController : ControllerBase
{
    private readonly IMatchService _matchService;
    
    public ProfilesController(IMatchService matchService)
    {
        _matchService = matchService;
    }
    
    [HttpPost]
    
    public async Task<IActionResult> CreateProfile([FromBody] Profile profile)
    {
        try
        {
            var newProfile = await _matchService.CreateProfile(profile);
            return Ok(newProfile);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> GetProfiles()
    {
        try
        {
            var profiles = await _matchService.GetProfiles();
            return Ok(profiles);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpPost("/api/[controller]/like")]
    public async Task<IActionResult> LikeProfile([FromQuery] int profileId, [FromQuery] int likedProfileId)
    {
        try
        {
            var like = await _matchService.LikeProfile(profileId, likedProfileId);
            return Ok(like);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

}