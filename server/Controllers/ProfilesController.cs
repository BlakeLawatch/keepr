namespace keepr.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ProfilesController : ControllerBase
{
    private readonly Auth0Provider _auth;
    private readonly ProfilesService _profilesService;
    private readonly KeepsService _keepsService;
    private readonly VaultsService _vaultsService;

    public ProfilesController(Auth0Provider auth, ProfilesService profilesService, KeepsService keepsService, VaultsService vaultsService)
    {
        _auth = auth;
        _profilesService = profilesService;
        _keepsService = keepsService;
        _vaultsService = vaultsService;
    }

    [HttpGet("{profileId}")]
    public ActionResult<Profile> GetUsersProfile(string profileId)
    {
        try
        {
            Profile profile = _profilesService.GetUsersProfile(profileId);
            return Ok(profile);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    [HttpGet("{profileId}/keeps")]
    public ActionResult<List<Keep>> GetKeepsByProfileId(string profileId)
    {
        try
        {
            List<Keep> keeps = _keepsService.GetKeepsByProfileId(profileId);
            return Ok(keeps);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    [HttpGet("{profileId}/vaults")]
    public ActionResult<List<Vault>> GetVaultsByProfileId(string profileId)
    {
        try
        {
            List<Vault> vaults = _vaultsService.GetVaultsByProfileId(profileId);
            return Ok(vaults);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }
}