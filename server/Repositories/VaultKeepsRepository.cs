
namespace keepr.Repositories;

public class VaultKeepsRepository
{
    private readonly IDbConnection _db;

    public VaultKeepsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData)
    {
        string sql = @"
        INSERT INTO
        vaultKeeps (vaultId, keepId, creatorId)
        VALUES (@VaultId, @KeepId, @CreatorId);

        SELECT *
         FROM vaultKeeps
        WHERE vaultKeeps.id = LAST_INSERT_ID();";

        VaultKeep vaultKeep = _db.Query<VaultKeep>(sql, vaultKeepData).FirstOrDefault();
        return vaultKeep;

        // VaultKeep vaultKeep = _db.Query<VaultKeep, Account, VaultKeep>(sql, (vaultKeep, account) =>
        // {
        //     vaultKeep.Creator = account;
        //     return vaultKeep;
        // }, vaultKeepData).FirstOrDefault();
        // return vaultKeep;


    }
    // SELECT 
    // vaults.*,
    // keeps.*,
    // accounts.*
    // FROM vaultKeeps
    // JOIN keeps ON vaultKeeps.keepId = keeps.id
    // JOIN vaults ON vaultKeeps.vaultId = vaults.id
    // JOIN accounts ON vaultKeeps.creatorId = accounts.id
    // ;";
}