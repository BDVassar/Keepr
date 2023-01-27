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
}
