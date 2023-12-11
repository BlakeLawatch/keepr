using Microsoft.AspNetCore.Http.HttpResults;

namespace keepr.Controllers;

[ApiController]
[Route("api/[controller]")]

public class VaultsController : ControllerBase
{
    private readonly VaultsService _vaultsService;
    private readonly Auth0Provider _auth0;
    private readonly VaultKeepsService _vaultKeepsService;

    public VaultsController(VaultsService vaultsService, Auth0Provider auth0, VaultKeepsService vaultKeepsService)
    {
        _vaultsService = vaultsService;
        _auth0 = auth0;
        _vaultKeepsService = vaultKeepsService;
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Vault>> CreateVault([FromBody] Vault vaultData)
    {
        try
        {
            Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
            vaultData.CreatorId = userInfo.Id;
            Vault vault = _vaultsService.CreateVault(vaultData);
            return Ok(vault);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    [HttpGet("{vaultId}")]
    public async Task<ActionResult<Vault>> GetVaultById(int vaultId)
    {
        try
        {
            Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
            Vault vault = _vaultsService.GetVaultById(vaultId, userInfo?.Id);
            return Ok(vault);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    [Authorize]
    [HttpPut("{vaultId}")]
    public async Task<ActionResult<Vault>> EditVault(int vaultId, [FromBody] Vault vaultData)
    {
        try
        {
            Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
            string userId = userInfo.Id;
            Vault vault = _vaultsService.EditVault(vaultId, userInfo.Id, vaultData);
            return Ok(vault);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    [Authorize]
    [HttpDelete("{vaultId}")]
    public async Task<ActionResult<string>> DestroyVault(int vaultId)
    {
        try
        {
            Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
            string message = _vaultsService.DestroyVault(vaultId, userInfo.Id);
            return Ok(message);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }


    // [HttpGet("{vaultId}/keeps")]
    // public async Task<ActionResult<List<VaultKeep>>> GetKeepsInVault(int vaultId)
    // {
    //     try
    //     {
    //         Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
    //         List<VaultKeep> vaultKeeps = _vaultKeepsService.GetKeepsInVault(vaultId, userInfo?.Id);
    //         return Ok(vaultKeeps);

    //     }
    //     catch (Exception e)
    //     {

    //         return BadRequest(e.Message);
    //     }
    // }
}