using WebApiA.Entities;

namespace WebApiA.Service;

public interface IMatchService
{
    Task<Profile> CreateProfile(Profile profile);
    Task<IEnumerable<Profile>> GetProfiles();
    Task<Profile> GetProfileById(int profileId);
    Task<Profile> UpdateProfile(int profileId, Profile profile);
    Task DeleteProfile(int profileId);
    Task<IEnumerable<Profile>> GetMatches(int profileId);
    Task<Like> LikeProfile(int profileId, int likedProfileId);
    
}