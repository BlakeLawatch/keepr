





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

    internal List<Keep> GetKeeps()
    {
        string sql = @"
        
        SELECT *
        FROM keeps
        JOIN accounts ON keeps.creatorId = accounts.id;";

        List<Keep> keeps = _db.Query<Keep, Account, Keep>(sql, KeepsBuilder).ToList();
        return keeps;
    }

    internal Keep GetKeepById(int keepId)
    {
        string sql = @"
        
        SELECT *
        FROM keeps
        JOIN accounts ON keeps.creatorId = accounts.id
        WHERE keeps.id = @KeepId;";

        Keep keep = _db.Query<Keep, Account, Keep>(sql, KeepsBuilder, new { keepId }).FirstOrDefault();
        return keep;
    }

    internal Keep EditKeep(Keep originalKeep)
    {
        string sql = @"
       
       UPDATE keeps
       SET 
       name = @Name,
       description = @Description,
       img = @img;
       

       SELECT *
       FROM keeps
       JOIN accounts ON keeps.creatorId = accounts.id
       WHERE keeps.id = @Id ;";

        Keep keep = _db.Query<Keep, Account, Keep>(sql, KeepsBuilder, originalKeep).FirstOrDefault();
        return keep;
    }

    internal void DestroyKeep(int keepId)
    {
        string sql = "DELETE FROM keeps WHERE id = @keepId LIMIT 1;";

        _db.Execute(sql, new { keepId });
    }
}