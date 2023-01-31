namespace Keepr.Repositories;

public class KeepsRepository
{
  private readonly IDbConnection _db;

  public KeepsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Keep Create(Keep keep)
  {
    string sql = @"
    INSERT INTO keeps
      (creatorId, name, description, img, views)
    VALUES
      (@creatorId, @name, @description, @img, @views);
      SELECT LAST_INSERT_ID();";
    int keepId = _db.ExecuteScalar<int>(sql, keep);
    keep.Id = keepId;
    return keep;
  }

  internal List<Keep> GetAll()
  {
    string sql = @"
    SELECT
    k.*,
    a.*
    FROM keeps k
    JOIN accounts a ON k.creatorId = a.id;
    ";
    List<Keep> keeps = _db.Query<Keep, Account, Keep>(sql, (keep, account) =>
    {
      keep.Creator = account;
      return keep;
    }).ToList();
    return keeps;
  }

  internal Keep GetOne(int id)
  {
    string sql = @"
    SELECT
    k.*,
    COUNT(vk.id) as Kept,
    a.*
    FROM keeps k
    JOIN accounts a ON k.creatorId = a.id
    JOIN vaultkeeps vk ON k.id = vk.keepId
    WHERE k.id = @id;
    ";
    Keep keep = _db.Query<Keep, Account, Keep>(sql, (keep, account) =>
    {
      keep.Creator = account;
      return keep;
    }, new { id }).FirstOrDefault();
    return keep;
  }

  internal bool Edit(Keep keepData)
  {
    string sql = @"
    UPDATE keeps
    SET
    name = @name,
    description = @description,
    img = @img,
    views = @views,
    kept = @kept
    WHERE id = @Id;
    ";
    int rows = _db.Execute(sql, keepData);
    return rows > 0;
  }

  internal bool Remove(int keepId)
  {
    string sql = @"
    DELETE FROM keeps
    WHERE id = @keepId;
    ";
    int rows = _db.Execute(sql, new { keepId });
    return rows > 0;
  }

  internal List<Keep> GetKeepsByProfileId(string id)
  {
    string sql = @"
    SELECT
    k.*,
    a.*
    FROM keeps k
    JOIN accounts a ON k.creatorId = a.id
    WHERE k.creatorId = @id;
    ";
    List<Keep> keeps = _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
    {
      keep.Creator = profile;
      return keep;
    }, new { id }).ToList();
    return keeps;
  }

}
