using CAIU.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RvuPiecemaker.API.Features.Tags
{
  [Route("api/tags")]
  public class TagsController : BaseController
  {
    private readonly ITagsService _service;
    public TagsController(ITagsService service, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
      _service = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
      return Get(_service.GetTags);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody]TagModel model)
    {
      return Put(_service.UpdateTag, AuditExisting(model));
    }

    [HttpPost()]
    public IActionResult Post([FromBody]TagModel model)
    {
      return Post(_service.InsertTag, AuditNew(model));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      return Delete(_service.DeleteTag, id);
    }
  }
}
