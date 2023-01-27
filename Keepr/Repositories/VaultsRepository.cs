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

  internal Vault GetOne(int id)
  {
    string sql = @"
    SELECT
    *
    FROM vaults
    WHERE id = @id;
    ";

    Vault vault = _db.Query<Vault>(sql, new { id }).FirstOrDefault();
    return vault;
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
