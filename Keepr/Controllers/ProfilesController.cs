namespace Keepr.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfilesController : ControllerBase
{
  private readonly ProfilesService _profilesService;
  private readonly Auth0Provider _auth;
  private readonly KeepsService _keepsService;
  private readonly VaultsService _vaultsService;

  public ProfilesController(ProfilesService profilesService, Auth0Provider auth, KeepsService keepsService, VaultsService vaultsService)
  {
    _profilesService = profilesService;
    _auth = auth;
    _keepsService = keepsService;
    _vaultsService = vaultsService;
  }

  [HttpGet("{id}")]
  public ActionResult<Profile> Get(string id)
  {
    try
    {
      Profile profile = _profilesService.Get(id);
      return Ok(profile);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{id}/keeps")]
  public ActionResult<List<Keep>> GetKeepsByProfileId(string Id)
  {
    try
    {
      List<Keep> keeps = _keepsService.GetKeepsByProfileId(Id);
      return Ok(keeps);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{id}/vaults")]
  public ActionResult<List<Vault>> GetVaultsByProfileId(string id)
  {
    try
    {
      List<Vault> vaults = _vaultsService.GetVaultsByProfileId(id);
      return Ok(vaults);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}
