namespace Keepr.Repositories;

public class VaultKeepsRepository
{
  private readonly IDbConnection _db;

  public VaultKeepsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal VaultKeeps Create(VaultKeeps vaultKeepsData)
  {
    string sql = @"
    INSERT INTO vaultkeeps
      (creatorId, vaultId, keepId)
    VALUES
      (@creatorId, @vaultId, @keepId);
      SELECT LAST_INSERT_ID();
    ";
    int id = _db.ExecuteScalar<int>(sql, vaultKeepsData);
    vaultKeepsData.Id = id;
    return vaultKeepsData;
  }

  internal List<KeepsInVault> GetKeepsbyVaultId(int id)
  {
    string sql = @"
    SELECT
    vk.*,
    k.*,
    a.*
    FROM vaultkeeps vk
    JOIN keeps k ON vk.keepId = k.id
    JOIN accounts a ON k.creatorId = a.id
    WHERE vaultId = @id;
    ";
    List<KeepsInVault> keeps = _db.Query<VaultKeeps, KeepsInVault, Account, KeepsInVault>(sql, (vk, keep, a) =>
    {
      keep.VaultKeepId = vk.Id;
      keep.Creator = a;
      return keep;
    }, new { id }).ToList();
    return keeps;
  }

  internal VaultKeeps GetOne(int id)
  {
    string sql = @"
    SELECT
    *
    FROM vaultkeeps
    WHERE id = @id;
    ";
    VaultKeeps vaultkeeps = _db.Query<VaultKeeps>(sql, new { id }).FirstOrDefault();
    return vaultkeeps;
  }

  internal bool Remove(int id)
  {
    string sql = @"
    DELETE FROM vaultkeeps
    WHERE id = @id;
    ";
    int rows = _db.Execute(sql, new { id });
    return rows > 0;
  }
}
