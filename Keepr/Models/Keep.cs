namespace Keepr.Models;

public class Keep
{
  public int Id { get; set; }
  public string CreatorId { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public string img { get; set; }
  public int? views { get; set; }
  public int? kept { get; set; }
  public Profile Creator { get; set; }
}

public class KeepsInVault : Keep
{
  public int VaultKeepId { get; set; }
}
