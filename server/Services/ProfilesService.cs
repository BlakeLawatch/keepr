
namespace keepr.Services;

public class ProfilesService
{
    private readonly ProfilesRepository _repo;

    public ProfilesService(ProfilesRepository repo)
    {
        _repo = repo;
    }

    internal Profile GetUsersProfile(string profileId)
    {
        Profile profile = _repo.GetusersProfile(profileId);
        return profile;
    }
}