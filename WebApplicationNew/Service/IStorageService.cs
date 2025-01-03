using WebApplicationNew.DTOs;
using WebApplicationSecound.Entities;

namespace WebApplicationSecound.Service;

public interface IStorageService
{
    Task<Box> AddBoxAsync(int storageRoomId,CreateBoxDto box);
    Task<Box> GetBoxByIdAsync(int storageRoomId,int boxId);
    Task DeleteBoxAsync(int storageRoomId, int boxId);
    Task<IEnumerable<StorageRoom>> GetAllStorageRoomsAsync(StorageRoom? storageRoom = null);
}