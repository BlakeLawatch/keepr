using Microsoft.AspNetCore.Http.HttpResults;

namespace keepr.Controllers;

[ApiController]
[Route("api/[controller]")]

public class KeepsController : ControllerBase
{


    private readonly KeepsService _keepsService;
    private readonly Auth0Provider _auth0;

    public KeepsController(KeepsService keepsService, Auth0Provider auth0)
    {
        _keepsService = keepsService;
        _auth0 = auth0;
    }


    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Keep>> CreateKeep([FromBody] Keep keepData)
    {
        try
        {
            Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
            keepData.CreatorId = userInfo.Id;
            Keep keep = _keepsService.CreateKeep(keepData);
            return Ok(keep);

        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public ActionResult<List<Keep>> GetKeeps()
    {
        try
        {
            List<Keep> keeps = _keepsService.GetKeeps();
            return Ok(keeps);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    [HttpGet("{keepId}")]
    public async Task<ActionResult<Keep>> GetKeepById(int keepId)
    {
        try
        {
            Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
            Keep keep = _keepsService.GetKeepByIdAndIncrementVisits(keepId, userInfo?.Id);
            return Ok(keep);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    [Authorize]
    [HttpPut("{keepId}")]
    public async Task<ActionResult<Keep>> EditKeep(int keepId, [FromBody] Keep keepData)
    {
        try
        {
            Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
            string userId = userInfo.Id;
            Keep keep = _keepsService.EditKeep(keepId, userInfo, keepData);
            return Ok(keep);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    [Authorize]
    [HttpDelete("{keepId}")]
    public async Task<ActionResult<string>> DestroyKeep(int keepId)
    {
        try
        {
            Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
            string message = _keepsService.DestroyKeep(keepId, userInfo.Id);
            return Ok(message);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

}