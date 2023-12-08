using Microsoft.AspNetCore.Http.HttpResults;

namespace keepr.Controllers;

[ApiController]
[Route("api/[controller]")]

public class VaultsController : ControllerBase
{
    private readonly VaultsService _vaultsService;
    private readonly Auth0Provider _auth0;

    public VaultsController(VaultsService vaultsService, Auth0Provider auth0)
    {
        _vaultsService = vaultsService;
        _auth0 = auth0;
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
    public ActionResult<Vault> GetVaultById(int vaultId)
    {
        try
        {
            Vault vault = _vaultsService.GetVaultById(vaultId);
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
            Vault vault = _vaultsService.EditVault(vaultId, userInfo, vaultData);
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
}