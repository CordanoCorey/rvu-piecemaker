using CAIU.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RvuPiecemaker.API.Features.Shifts
{
  [Route("api/shifts")]
  public class ShiftsController : BaseController
  {
    private readonly IShiftsService _service;
    public ShiftsController(IShiftsService service, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
      _service = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
      return Get(_service.GetShifts);
    }

    [HttpGet("user")]
    public IActionResult GetCurrentUserShifts()
    {
      return Get(_service.GetUserShifts, UserId);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
      return Get(_service.GetShift, id);
    }

    [HttpGet("~/api/users/{userId}/shifts")]
    public IActionResult GetUserShifts(int userId)
    {
      return Get(_service.GetUserShifts, userId);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody]ShiftModel model)
    {
      return Put(_service.UpdateShift, AuditExisting(model));
    }

    [HttpPost()]
    public IActionResult Post([FromBody]ShiftModel model)
    {
      return Post(_service.InsertShift, AuditNew(model));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      return Delete(_service.DeleteShift, id);
    }
  }
}
