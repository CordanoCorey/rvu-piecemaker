using CAIU.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RvuPiecemaker.API.Features.Goals
{
  [Route("api/goals")]
  public class GoalsController : BaseController
  {
    private readonly IGoalsService _service;
    public GoalsController(IGoalsService service, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
      _service = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
      return Get(_service.GetGoals, UserId);
    }

    [HttpGet("current")]
    public IActionResult GetCurrent()
    {
      return Get(_service.GetUserGoal, UserId);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody]GoalModel model)
    {
      return Put(_service.UpdateGoal, AuditExisting(model));
    }

    [HttpPost()]
    public IActionResult Post([FromBody]GoalModel model)
    {
      return Post(_service.InsertGoal, AuditNew(model));
    }
  }
}
