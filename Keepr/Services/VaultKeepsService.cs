namespace Keepr.Services;

public class VaultKeepsService
{
  private readonly VaultKeepsRepository _repo;
  private readonly VaultsService _vaultsService;

  public VaultKeepsService(VaultKeepsRepository repo, VaultsService vaultsService)
  {
    _repo = repo;
    _vaultsService = vaultsService;
  }

  internal VaultKeeps Create(VaultKeeps vaultKeepsData)
  {
    VaultKeeps vaultKeeps = _repo.Create(vaultKeepsData);
    return vaultKeeps;
  }

  internal List<KeepsInVault> GetKeepsbyVaultId(string accountId, int id)
  {
    Vault vault = _vaultsService.GetOne(accountId, id);
    List<KeepsInVault> keeps = _repo.GetKeepsbyVaultId(id);
    return keeps;
  }

  internal string Remove(string accountId, int id)
  {
    VaultKeeps vaultKeeps = _repo.GetOne(id);
    if (vaultKeeps.CreatorId != accountId) throw new Exception("You are not authorized.");
    bool deleted = _repo.Remove(id);
    if (deleted == false) throw new Exception("Relationship not removed.");
    return "Relationship Removed.";
  }
}