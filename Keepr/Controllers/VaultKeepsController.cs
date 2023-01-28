namespace Keepr.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VaultKeepsController : ControllerBase
{
  private readonly VaultKeepsService _vaultKeepsService;
  private readonly Auth0Provider _auth;

  public VaultKeepsController(VaultKeepsService vaultKeepsService, Auth0Provider auth)
  {
    _vaultKeepsService = vaultKeepsService;
    _auth = auth;
  }

  [HttpPost]
  [Authorize]
  public async Task<ActionResult<VaultKeeps>> Create([FromBody] VaultKeeps vaultKeepsData)
  {
    try
    {
      Account account = await _auth.GetUserInfoAsync<Account>(HttpContext);
      vaultKeepsData.CreatorId = account.Id;
      VaultKeeps vaultKeeps = _vaultKeepsService.Create(vaultKeepsData);
      vaultKeeps.Creator = account;
      return vaultKeeps;
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  [HttpDelete("{id}")]
  [Authorize]
  public async Task<ActionResult<string>> Remove(int id)
  {
    try
    {
      Account account = await _auth.GetUserInfoAsync<Account>(HttpContext);
      String message = _vaultKeepsService.Remove(account.Id, id);
      return Ok(message);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}
