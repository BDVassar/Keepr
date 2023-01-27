using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keepr.Services;

public class VaultKeepsService
{
    private readonly VaultKeepsRepository _repo;

  public VaultKeepsService(VaultKeepsRepository repo)
  {
    _repo = repo;
  }
}
