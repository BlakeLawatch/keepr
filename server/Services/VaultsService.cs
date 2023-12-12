


namespace keepr.Services;

public class VaultsService
{
    private readonly VaultsRepository _repo;

    public VaultsService(VaultsRepository repo)
    {
        _repo = repo;
    }

    internal Vault CreateVault(Vault vaultData)
    {
        Vault vault = _repo.CreateVault(vaultData);
        return vault;
    }

    internal string DestroyVault(int vaultId, string userId)
    {
        Vault vault = GetVaultById(vaultId, userId);
        if (vault.CreatorId != userId)
        {
            throw new Exception($"The Vault with the ID of {vaultId} is not your vault to delete");
        }
        _repo.DestroyVault(vaultId);
        return "Vault has been deleted";
    }

    internal Vault EditVault(int vaultId, string userId, Vault vaultData)
    {
        Vault originalVault = GetVaultById(vaultId, userId);
        if (originalVault.CreatorId != userId)
        {
            throw new Exception($"This vault with the ID of {vaultId} is not yours to edit");
        }

        originalVault.Name = vaultData.Name ?? originalVault.Name;
        originalVault.Description = vaultData.Description ?? originalVault.Description;
        originalVault.Img = vaultData.Img ?? originalVault.Img;
        originalVault.IsPrivate = vaultData.IsPrivate ?? originalVault.IsPrivate;

        Vault vault = _repo.EditVault(originalVault);
        return vault;
    }

    internal List<Vault> GetAccountVaults(string userId)
    {
        List<Vault> vault = _repo.GetAccountVaults(userId);
        return vault;

    }



    internal Vault GetVaultById(int vaultId, string userId)
    {
        Vault vault = _repo.GetVaultById(vaultId);
        if (vault == null)
        {
            throw new Exception("This Vault does not exist");
        }
        if (vault.IsPrivate == true && vault.CreatorId != userId)
        {
            throw new Exception("You can't go there...");
        }

        return vault;
    }

    internal List<Vault> GetVaultsByProfileId(string profileId)
    {

        List<Vault> vaults = _repo.GetVaultsByProfileId(profileId);
        vaults = vaults.FindAll(vault => vault.IsPrivate == false || vault.CreatorId != profileId);

        return vaults;
    }
}