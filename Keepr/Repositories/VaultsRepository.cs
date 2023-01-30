namespace Keepr.Repositories;

public class VaultsRepository
{
  private readonly IDbConnection _db;

  public VaultsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Vault Create(Vault vaultData)
  {
    string sql = @"
    INSERT INTO vaults
      (creatorId, name, description, img, isPrivate)
    VALUES
      (@creatorId, @name, @description, @img, @isPrivate);
      SELECT LAST_INSERT_ID();
    ";
    int id = _db.ExecuteScalar<int>(sql, vaultData);
    vaultData.Id = id;
    return vaultData;
  }

  internal bool Edit(Vault vault)
  {
    string sql = @"
    UPDATE vaults
      SET
      name = @name,
      description = @description,
      img = @img,
      isPrivate = @isPrivate
      WHERE id = @id;
    ";
    int rows = _db.Execute(sql, vault);
    return rows > 0;
  }

  internal List<Vault> GetMyVaults(string accountId)
  {
    string sql = @"
    SELECT
    v.*,
    a.*
    FROM vaults v
    JOIN accounts a ON v.creatorId = a.id
    WHERE creatorId = @accountId;
    ";

    List<Vault> vaults = _db.Query<Vault, Account, Vault>(sql, (vault, account) =>
    {
      vault.creator = account;
      return vault;
    }, new { accountId }).ToList();
    return vaults;
  }

  internal Vault GetOne(int id)
  {
    string sql = @"
    SELECT
    v.*,
    a.*
    FROM vaults v
    JOIN accounts a ON v.creatorId = a.id
    WHERE v.id = @id;
    ";

    Vault vault = _db.Query<Vault, Account, Vault>(sql, (vault, account) =>
    {
      vault.creator = account;
      return vault;
    }, new { id }).FirstOrDefault();
    return vault;
  }

  internal List<Vault> GetVaultsByProfileId(string id)
  {
    string sql = @"
    SELECT
    *
    From vaults
    WHERE creatorId = @id AND isPrivate = 0;
    ";
    List<Vault> vaults = _db.Query<Vault>(sql, new { id }).ToList();
    return vaults;
  }

  internal bool Remove(int id)
  {
    string sql = @"
    DELETE FROM vaults
    WHERE id = @id;
    ";
    int rows = _db.Execute(sql, new { id });
    return rows > 0;
  }
}
