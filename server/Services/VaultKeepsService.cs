

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

    // internal List<VaultKeep> GetKeepsInVault(int vaultId, string userId)
    // {
    //     _vaultsService.GetVaultById(vaultId, userId);
    //     List<VaultKeep> vaultKeeps = _repo.GetKeepsInVault(vaultId);
    //     return vaultKeeps;
    // }
}