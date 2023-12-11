




namespace keepr.Repositories;

public class VaultKeepsRepository
{
    private readonly IDbConnection _db;

    public VaultKeepsRepository(IDbConnection db)
    {
        _db = db;
    }

    private VaultKeep VaultKeepBuilder(VaultKeep vaultKeep, Account account)
    {
        vaultKeep.Creator = account;
        return vaultKeep;
    }

    internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData)
    {
        string sql = @"
        INSERT INTO
        vaultKeeps (vaultId, keepId, creatorId)
        VALUES (@VaultId, @KeepId, @CreatorId);

        SELECT *
        FROM vaultKeeps
        JOIN accounts ON accounts.id = vaultKeeps.creatorId
        WHERE vaultKeeps.id = LAST_INSERT_ID();";

        // VaultKeep vaultKeep = _db.Query<VaultKeep>(sql, vaultKeepData).FirstOrDefault();
        // return vaultKeep;

        VaultKeep vaultKeep = _db.Query<VaultKeep, Account, VaultKeep>(sql, (vaultKeep, account) =>
        {
            vaultKeep.Creator = account;
            return vaultKeep;
        }, vaultKeepData).FirstOrDefault();
        return vaultKeep;


    }

    internal List<KeepInVault> GetKeepsInVault(int vaultId)
    {
        string sql = @"
        SELECT *
        FROM vaultKeeps
        JOIN keeps ON vaultKeeps.keepId = keeps.id
        JOIN accounts ON accounts.id = vaultKeeps.creatorId
        WHERE vaultKeeps.vaultId = @VaultId;";

        List<KeepInVault> keeps = _db.Query<VaultKeep, KeepInVault, Account, KeepInVault>(sql, (vaultKeep, keepInVault, account) =>
        {
            // keepInVault.KeepsInVaultId = vaultKeep.Id;
            keepInVault.VaultKeepId = vaultKeep.Id;
            keepInVault.AccountId = vaultKeep.CreatorId;
            keepInVault.Creator = account;
            return keepInVault;
        }, new { vaultId }).ToList();
        return keeps;


    }

    internal VaultKeep GetVaultKeepById(int vaultKeepId)
    {
        string sql = "SELECT * FROM vaultKeeps WHERE id = @VaultKeepId;";

        VaultKeep vaultKeep = _db.Query<VaultKeep>(sql, new { vaultKeepId }).FirstOrDefault();
        return vaultKeep;
    }

    internal void DestroyVaultKeep(int vaultKeepId)
    {
        string sql = "DELETE FROM vaultKeeps WHERE id = @VaultKeepId;";

        _db.Execute(sql, new { vaultKeepId });
    }

    // internal List<VaultKeep> GetKeepsInVault(int vaultId)
    // {
    //     string sql = @"
    // SELECT *
    // FROM vaultKeeps
    // JOIN accounts ON vaultKeeps.creatorId = accounts.id
    // WHERE vaultKeeps.vaultId = @VaultId;";

    //     List<VaultKeep> vaultKeeps = _db.Query<VaultKeep, Account, VaultKeep>(sql, VaultKeepBuilder, new { vaultId }).ToList();
    //     return vaultKeeps;

    // }


}