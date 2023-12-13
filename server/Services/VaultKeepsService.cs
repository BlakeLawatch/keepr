



namespace keepr.Services;

public class VaultKeepsService
{
    private readonly VaultKeepsRepository _repo;
    private readonly VaultsService _vaultsService;
    private readonly KeepsService _keepsService;

    public VaultKeepsService(VaultKeepsRepository repo, VaultsService vaultsService, KeepsService keepsService)
    {
        _repo = repo;
        _vaultsService = vaultsService;
        _keepsService = keepsService;
    }

    internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData, string userId)
    {
        _vaultsService.GetVaultById(vaultKeepData.VaultId, userId);
        // if (vaultKeepData.VaultId != vaultKeepData.Creator.)
        // {
        //     throw new Exception("Not your vault");
        // }
        VaultKeep vaultKeep = _repo.CreateVaultKeep(vaultKeepData);
        // if ()
        // {
        //     throw new Exception("not your vault");
        // }
        Keep keep = _keepsService.GetKeepById(vaultKeepData.KeepId, userId);
        keep.Kept++;
        _keepsService.updateKeptCount(keep);

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

    internal List<KeepInVault> GetKeepsInVault(int vaultId, string userId)
    {
        // List<KeepInVault> keeps = _repo.GetKeepsInVault(vaultId);
        _vaultsService.GetVaultById(vaultId, userId);
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