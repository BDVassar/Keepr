namespace Keepr.Services;

public class VaultsService
{
  private readonly VaultsRepository _repo;

  public VaultsService(VaultsRepository repo)
  {
    _repo = repo;
  }

  internal Vault Create(Vault vaultData)
  {
    Vault vault = _repo.Create(vaultData);
    return vault;
  }

  internal Vault GetOne(string accountId, int id)
  {
    Vault vault = _repo.GetOne(id);
    if (vault == null) throw new Exception("No Vault by that id");
    if (vault.IsPrivate && vault.CreatorId != accountId) throw new Exception("You do not have permission to see this vault.");
    return vault;

  }
}
