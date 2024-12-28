using WebApiA.Entities;

namespace WebApiA.Service;

public class InMemoryMatchService : IMatchService
{
    private readonly List<Profile> _profiles = new();

    //dommy data

    public InMemoryMatchService()
    {
        _profiles.Add(new Profile
        {
            ProfileId = 1,
            Name = "John",
            Age = 30,
            Gender = "Male",
            LikedProfiles = new List<Like>
            {
                new Like
                {
                    LikedProfileId = 2
                }
            }
        });

        _profiles.Add(new Profile
            {
                ProfileId = 2,
                Name = "Jane",
                Age = 25,
                Gender = "Female",
                LikedProfiles = new List<Like>
                {
                    new Like
                    {
                        LikedProfileId = 1
                    }
                }
            });
    }


    public Task<Profile> CreateProfile(Profile profile)
    {
        Console.WriteLine(_profiles.Count);
        profile.ProfileId = _profiles.Any()
            ? _profiles.Max(p => p.ProfileId) + 1
            : 1;
        _profiles.Add(profile);
        Console.WriteLine(_profiles.Count);
        return Task.FromResult(profile);
    }

    public Task<IEnumerable<Profile>> GetProfiles()
    {
        return Task.FromResult<IEnumerable<Profile>>(_profiles);
    }

    public Task<Profile> GetProfileById(int profileId)
    {
        throw new NotImplementedException();
    }

    public Task<Profile> UpdateProfile(int profileId, Profile profile)
    {
        throw new NotImplementedException();
    }

    public Task DeleteProfile(int profileId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Profile>> GetMatches(int profileId)
    {
        throw new NotImplementedException();
    }

    public Task<Like> LikeProfile(int profileId, int likedProfileId)
    {
        try
        {
            var profile = _profiles.FirstOrDefault(p => p.ProfileId == profileId);
            if (profile is null)
            {
                throw new Exception($"Profile with ID '{profileId}' not found");
            }

            var likedProfile = _profiles.FirstOrDefault(p => p.ProfileId == likedProfileId);
            if (likedProfile is null)
            {
                throw new Exception($"Profile with ID '{likedProfileId}' not found");
            }

            profile.LikedProfiles.Add(new Like
            {
                LikedProfileId = likedProfileId
            });

            return Task.FromResult(profile.LikedProfiles.Last());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}