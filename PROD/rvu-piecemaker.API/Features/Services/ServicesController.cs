using CAIU.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RvuPiecemaker.API.Features.Services
{
  [Route("api/services")]
  public class ServicesController : BaseController
  {
    private readonly IServicesService _service;
    public ServicesController(IServicesService service, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
      _service = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
      var result = _service.GetUserServices(UserId);
      return Ok(result);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody]ServiceModel model)
    {
      return Put(_service.UpdateService, AuditExisting(model));
    }

    [HttpPost()]
    public IActionResult Post([FromBody]ServiceModel model)
    {
      return Post(_service.InsertService, AuditNew(model));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      return Delete(_service.DeleteService, id);
    }
  }
}
