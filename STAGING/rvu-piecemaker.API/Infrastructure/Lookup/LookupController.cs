using CAIU.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RvuPiecemaker.API.Infrastructure.Lookup
{
  [Route("api/Lookup")]
  public class LookupController : BaseController
  {
    private readonly ILookupRepository _repo;
    public LookupController(ILookupRepository repo, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
      _repo = repo;
    }

    [HttpGet]
    public IEnumerable<LookupModel> Get()
    {
      var values = _repo.GetLookups();

      return values;
    }
  }
}
