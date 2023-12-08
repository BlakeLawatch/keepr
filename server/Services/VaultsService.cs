

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
        Vault vault = GetVaultById(vaultId);
        if (vault.CreatorId != userId)
        {
            throw new Exception($"The Vault with the ID of {vaultId} is not your vault to delete");
        }
        _repo.DestroyVault(vaultId);
        return "Vault has been deleted";
    }

    internal Vault EditVault(int vaultId, Account userInfo, Vault vaultData)
    {
        Vault originalVault = GetVaultById(vaultId);
        if (userInfo.Id != originalVault.CreatorId)
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

    internal Vault GetVaultById(int vaultId)
    {
        Vault vault = _repo.GetVaultById(vaultId);
        if (vault == null)
        {
            throw new Exception("This Vault does not exist");
        }
        return vault;
    }
}