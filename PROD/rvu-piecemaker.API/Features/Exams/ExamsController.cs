using CAIU.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RvuPiecemaker.API.Features.Exams
{
  [Route("api/exams")]
  public class ExamsController : BaseController
  {
    private readonly IExamsService _service;
    public ExamsController(IExamsService service, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
      _service = service;
    }

    [HttpGet("user")]
    public IActionResult Get()
    {
      return Get(_service.GetUserExams, UserId);
    }

    [HttpGet("{date}")]
    public IActionResult GetDate(DateTime date)
    {
      var result = _service.GetExams(UserId, date);
      return Ok(result);
    }

    [HttpGet]
    public IActionResult GetDateRange([FromQuery]DateTime startDate, [FromQuery]DateTime endDate)
    {
      var result = _service.GetExamsBetweenDates(UserId, startDate, endDate);
      return Ok(result);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody]ExamModel model)
    {
      return Put(_service.UpdateExam, AuditExisting(model));
    }

    [HttpPost()]
    public IActionResult Post([FromBody]ExamModel model)
    {
      return Post(_service.InsertExam, AuditNew(model));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      return Delete(_service.DeleteExam, id);
    }

    [HttpGet("~/api/examtypes")]
    public IActionResult GetExamTypes()
    {
      //return Get(_service.GetUserExams, UserId);
      return Get(_service.GetAllExamTypes);
    }

    [HttpPut("~/api/examtypes/{id}")]
    public IActionResult PutExamType(int id, [FromBody]ExamTypeModel model)
    {
      return Put(_service.UpdateExamType, AuditExisting(model));
    }

    [HttpPost("~/api/examtypes")]
    public IActionResult PostExamType([FromBody]ExamTypeModel model)
    {
      return Post(_service.InsertExamType, AuditNew(model));
    }

    [HttpDelete("~/api/examtypes/{id}")]
    public IActionResult DeleteExamType(int id)
    {
      return Delete(_service.DeleteExamType, id);
    }
  }
}
