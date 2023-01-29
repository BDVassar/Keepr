namespace Keepr.Services;

public class KeepsService
{
  private readonly KeepsRepository _repo;

  public KeepsService(KeepsRepository keepsRepository)
  {
    _repo = keepsRepository;
  }

  internal Keep Create(Keep keepData)
  {
    keepData.views = 0;
    keepData.kept = 0;
    Keep keep = _repo.Create(keepData);
    return keep;
  }


  internal List<Keep> GetAll()
  {
    List<Keep> keeps = _repo.GetAll();
    return keeps;
  }

  internal Keep GetOne(int id)
  {
    Keep keep = _repo.GetOne(id);
    if (keep == null)
    {
      throw new Exception("No Keep by that Id");
    }
    return keep;
  }
  internal Keep Edit(Keep keepData, string accountId)
  {
    Keep keep = this.GetOne(keepData.Id);
    if (keep.CreatorId != accountId)
    {
      throw new Exception("You do not have permission to edit this Keep.");
    }
    keepData.Name = keepData.Name ?? keep.Name;
    keepData.Description = keepData.Description ?? keep.Description;
    keepData.img = keepData.img ?? keep.img;
    keepData.views = keepData.views ?? keep.views;
    keepData.kept = keepData.kept ?? keep.kept;
    keepData.CreatorId = keep.CreatorId;
    Boolean updated = _repo.Edit(keepData);
    if (updated == false)
    {
      throw new Exception($"{keepData.Name} was not updated");
    }
    return (keepData);
  }

  internal String Remove(string accountId, int keepId)
  {
    Keep keep = this.GetOne(keepId);
    if (keep.CreatorId != accountId)
    {
      throw new Exception("You do not have permission to delete this Keep.");
    }
    bool deleted = _repo.Remove(keepId);
    if (deleted == false) throw new Exception($"{keep.Name} was not deleted");
    return $"{keep.Name} was deleted";
  }

  internal List<Keep> GetKeepsByProfileId(string id)
  {
    List<Keep> keeps = _repo.GetKeepsByProfileId(id);
    return keeps;
  }
}
