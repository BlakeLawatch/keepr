
using System.Runtime.CompilerServices;

namespace keepr.Repositories;

public class VaultsRepository
{
    private readonly IDbConnection _db;

    public VaultsRepository(IDbConnection db)
    {
        _db = db;
    }

    private Vault VaultBuilder(Vault vault, Account account)
    {
        vault.Creator = account;
        return vault;
    }

    internal Vault CreateVault(Vault vaultData)
    {
        string sql = @"
        INSERT INTO 
        vaults(name, description, img, isPrivate, creatorId)
        VALUES(@Name, @Description, @Img, @IsPrivate, @CreatorId);

        SELECT *
        FROM vaults
        JOIN accounts ON vaults.creatorId = accounts.id
        where vaults.id = Last_INSERT_ID();";

        Vault vault = _db.Query<Vault, Account, Vault>(sql, VaultBuilder, vaultData).FirstOrDefault();
        return vault;
    }

    internal Vault GetVaultById(int vaultId)
    {
        string sql = @"
        SELECT *
        FROM vaults
        JOIN accounts on vaults.creatorId = accounts.id
        WHERE vaults.id = @vaultId;";

        Vault vault = _db.Query<Vault, Account, Vault>(sql, VaultBuilder, new { vaultId }).FirstOrDefault();
        return vault;
    }

    internal Vault EditVault(Vault originalVault)
    {
        string sql = @"
        UPDATE vaults
        SET
        name = @Name,
        description = @Description,
        img = @Img,
        isPrivate = @IsPrivate;

        SELECT *
        FROM vaults
        JOIN accounts ON vaults.creatorId = accounts.id
        WHERE vaults.id = @Id;";

        Vault vault = _db.Query<Vault, Account, Vault>(sql, VaultBuilder, originalVault).FirstOrDefault();
        return vault;
    }

    internal void DestroyVault(int vaultId)
    {
        string sql = "DELETE FROM vaults WHERE id = @vaultId LIMIT 1;";

        _db.Execute(sql, new { vaultId });
    }
}