namespace Keepr.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KeepsController : ControllerBase
{
  private readonly KeepsService _keepsService;
  private readonly Auth0Provider _auth;

  public KeepsController(KeepsService keepsService, Auth0Provider auth = null)
  {
    _keepsService = keepsService;
    _auth = auth;
  }

  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Keep>> Create([FromBody] Keep keepData)
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      keepData.CreatorId = userInfo.Id;
      Keep keep = _keepsService.Create(keepData);
      keep.Creator = userInfo;
      return Ok(keep);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet]

  public ActionResult<List<Keep>> GetAll()
  {
    try
    {
      List<Keep> keeps = _keepsService.GetAll();
      return Ok(keeps);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{id}")]
  public ActionResult<Keep> GetOne(int id)
  {
    try
    {
      Keep keep = _keepsService.GetOne(id);
      return Ok(keep);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPut("{id}")]
  [Authorize]
  public async Task<ActionResult<Keep>> Edit([FromBody] Keep keepData, int id)
  {
    try
    {
      Account account = await _auth.GetUserInfoAsync<Account>(HttpContext);
      keepData.Id = id;
      Keep keep = _keepsService.Edit(keepData, account.Id);
      keep.Creator = account;
      return Ok(keep);
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
      string message = _keepsService.Remove(account.Id, id);
      return Ok(message);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}
