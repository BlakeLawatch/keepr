
namespace keepr.Repositories;

public class KeepsRepository
{
    private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
        _db = db;
    }

    private Keep KeepsBuilder(Keep keep, Account account)
    {
        keep.Creator = account;
        return keep;
    }

    internal Keep CreateKeep(Keep keepData)
    {
        string sql = @"
        INSERT INTO 
        keeps (name, description, img, creatorId)
        VALUES (@Name, @Description, @Img, @CreatorId);

        SELECT *
        FROM keeps
        JOIN accounts ON keeps.creatorId = accounts.id
        WHERE keeps.id = LAST_INSERT_ID();";

        Keep keep = _db.Query<Keep, Account, Keep>(sql, KeepsBuilder, keepData).FirstOrDefault();
        return keep;
    }
}