namespace Keepr.Services;

public class ProfilesService
{
  private readonly ProfilesRepository _repo;

  public ProfilesService(ProfilesRepository repo)
  {
    _repo = repo;
  }

  internal Profile Get(string id)
  {
    Profile profile = _repo.Get(id);
    return profile;
  }
}
