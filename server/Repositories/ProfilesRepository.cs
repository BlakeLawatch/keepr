
namespace keepr.Repositories;

public class ProfilesRepository
{
    private readonly IDbConnection _db;

    public ProfilesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Profile GetusersProfile(string profileId)
    {
        string sql = @"SELECT * 
        FROM accounts
        ;";

        Profile profile = _db.Query<Profile>(sql, profileId).FirstOrDefault();
        return profile;
    }
}