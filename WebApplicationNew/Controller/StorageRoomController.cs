using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplicationSecound.Entities;
using WebApplicationSecound.Service;

namespace WebApplicationSecound.Controller;

[Route("api/[controller]")]
public class StorageRoomController : ControllerBase
{
    private readonly IStorageService _storageService;

    public StorageRoomController(IStorageService storageService)
    {
        _storageService = storageService;
    }

    [HttpPost]
    public async Task<IActionResult> AddBoxAsync([FromQuery] int storageRoomId, [FromBody] Box _box)
    {
        var storageRoom = new StorageRoom { StorageRoomId = storageRoomId };
        try
        {
            var box = await _storageService.AddBoxAsync(storageRoomId, _box);
            return Ok(box);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }
    /*

    [HttpGet]
    public async Task<IActionResult> GetSingleBoxAsync([FromQuery] int storageRoomId,[FromQuery] int boxId)
    {
        var storageRoom = new StorageRoom { StorageRoomId = storageRoomId };

        try
        {
            var box = await _storageService.GetBoxByIdAsync(storageRoomId, boxId);
            return Ok(box);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

    [HttpDelete]

    public async Task<IActionResult> DeleteBoxAsync( [FromQuery] int storageRoomId,[FromQuery] int boxId)
    {
        var storageRoom = new StorageRoom { StorageRoomId = storageRoomId };

        try
        {
            await _storageService.DeleteBoxAsync(storageRoomId, boxId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }

    }

    [HttpGet]
    public async Task<IActionResult> GetStorageRoomsAsync()
    {
        try
        {
            var storageRooms = await _storageService.GetAllStorageRoomsAsync();
            return Ok(storageRooms);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });}
        }*/
}