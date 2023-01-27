namespace Keepr.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VaultsController : ControllerBase
{
  private readonly VaultsService _vaultsService;
  private readonly Auth0Provider _auth;

  public VaultsController(VaultsService vaultsService, Auth0Provider auth)
  {
    _vaultsService = vaultsService;
    _auth = auth;
  }

  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Vault>> Create([FromBody] Vault vaultData)
  {
    try
    {
      Account account = await _auth.GetUserInfoAsync<Account>(HttpContext);
      vaultData.CreatorId = account.Id;
      Vault vault = _vaultsService.Create(vaultData);
      vault.creator = account;
      return vault;
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<Vault>> GetOne(int id)
  {
    try
    {
      Account account = await _auth.GetUserInfoAsync<Account>(HttpContext);
      Vault vault = _vaultsService.GetOne(account.Id, id);
      vault.creator = account;
      return Ok(vault);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPut("{id}")]
  [Authorize]
  public async Task<ActionResult<Vault>> Edit([FromBody] Vault vaultData, int id)
  {
    try
    {
      Account account = await _auth.GetUserInfoAsync<Account>(HttpContext);
      vaultData.Id = id;
      Vault vault = _vaultsService.Edit(vaultData, account.Id);
      vault.creator = account;
      return vault;
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
      string message = _vaultsService.Remove(id, account.Id);
      return message;
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}
