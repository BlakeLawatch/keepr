



namespace keepr.Services;

public class VaultKeepsService
{
    private readonly VaultKeepsRepository _repo;
    private readonly VaultsService _vaultsService;

    public VaultKeepsService(VaultKeepsRepository repo, VaultsService vaultsService)
    {
        _repo = repo;
        _vaultsService = vaultsService;
    }

    internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData)
    {
        _vaultsService.GetVaultById(vaultKeepData.VaultId, vaultKeepData.CreatorId);
        // if (vaultKeepData.CreatorId != userId)
        // {
        //     throw new Exception();
        // }
        VaultKeep vaultKeep = _repo.CreateVaultKeep(vaultKeepData);

        return vaultKeep;
    }

    internal VaultKeep GetVaultKeepById(int vaultKeepId)
    {
        VaultKeep vaultKeep = _repo.GetVaultKeepById(vaultKeepId);
        if (vaultKeep == null)
        {
            throw new Exception("This VaultKeep doesn't exist");
        }
        return vaultKeep;
    }

    internal string DestroyVaultKeep(int vaultKeepId, string userId)
    {
        VaultKeep vaultKeep = GetVaultKeepById(vaultKeepId);
        if (vaultKeep.CreatorId != userId)
        {
            throw new Exception("Not your VaultKeep to delete");
        }
        _repo.DestroyVaultKeep(vaultKeepId);
        return "This vault keep has been deleted";
    }

    internal List<KeepInVault> GetKeepsInVault(int vaultId)
    {
        List<KeepInVault> keeps = _repo.GetKeepsInVault(vaultId);
        return keeps;
    }

    // internal List<VaultKeep> GetKeepsInVault(int vaultId, string userId)
    // {
    //     _vaultsService.GetVaultById(vaultId, userId);
    //     List<VaultKeep> vaultKeeps = _repo.GetKeepsInVault(vaultId);
    //     return vaultKeeps;
    // }
}