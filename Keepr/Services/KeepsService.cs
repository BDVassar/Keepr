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
}
