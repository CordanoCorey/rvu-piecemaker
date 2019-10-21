using CAIU.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RvuPiecemaker.API.Features.ExamGroups
{
  [Route("api/examgroups")]
  public class ExamGroupsController : BaseController
  {
    private readonly IExamGroupsService _service;
    public ExamGroupsController(IExamGroupsService service, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
      _service = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
      return Get(_service.GetExamGroups);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody]ExamGroupModel model)
    {
      return Put(_service.UpdateExamGroup, AuditExisting(model));
    }

    [HttpPost()]
    public IActionResult Post([FromBody]ExamGroupModel model)
    {
      return Post(_service.InsertExamGroup, AuditNew(model));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      return Delete(_service.DeleteExamGroup, id);
    }
  }
}
