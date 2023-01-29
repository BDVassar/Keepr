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

  internal Vault Edit(Vault vaultData, string accountId)
  {
    Vault vault = this.GetOne(accountId, vaultData.Id);
    if (vault.CreatorId != accountId) throw new Exception("You do not have permission to edit this vault.");
    vault.Name = vaultData.Name ?? vault.Name;
    vault.Description = vaultData.Description ?? vault.Description;
    vault.Img = vaultData.Img ?? vault.Img;
    vault.IsPrivate = vaultData.IsPrivate ?? vault.IsPrivate;
    bool updated = _repo.Edit(vault);
    if (updated == false) throw new Exception($"{vault.Name} was not updated");
    return vault;
  }

  internal List<Vault> GetMyVaults(string accountId)
  {
    List<Vault> vaults = _repo.GetMyVaults(accountId);
    return vaults;
  }

  internal Vault GetOne(string accountId, int id)
  {
    Vault vault = _repo.GetOne(id);
    if (vault == null) throw new Exception("No Vault by that id");
    if (vault.IsPrivate == true && vault.CreatorId != accountId) throw new Exception("You do not have permission to see this vault.");
    return vault;

  }

  internal List<Vault> GetVaultsByProfileId(string id)
  {
    List<Vault> vaults = _repo.GetVaultsByProfileId(id);
    return vaults;
  }

  internal string Remove(int id, string accountId)
  {
    Vault vault = this.GetOne(accountId, id);
    if (vault.CreatorId != accountId) throw new Exception("You do not have permission to delete this vault.");
    bool deleted = _repo.Remove(id);
    if (deleted == false) throw new Exception($"{vault.Name} was not deleted");
    return $"{vault.Name} was deleted";
  }
}
