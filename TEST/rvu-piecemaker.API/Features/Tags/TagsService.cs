using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RvuPiecemaker.API.Features.Tags
{
  public interface ITagsService
  {
    IEnumerable<TagModel> GetTags();
    TagModel GetTag(int id);
    TagModel InsertTag(TagModel model);
    TagModel UpdateTag(TagModel model);
    void DeleteTag(int id);
  }

  public class TagsService : ITagsService
  {
    private readonly ITagsRepository _repo;

    public TagsService(ITagsRepository repo)
    {
      _repo = repo;
    }

    public void DeleteTag(int id)
    {
      _repo.Delete(id);
    }

    public TagModel GetTag(int id)
    {
      return _repo.FindByKey(id);
    }

    public IEnumerable<TagModel> GetTags()
    {
      return _repo.All();
    }

    public TagModel InsertTag(TagModel model)
    {
      var inserted = _repo.Insert(model);
      return GetTag(inserted.Id);
    }

    public TagModel UpdateTag(TagModel model)
    {
      var updated = _repo.Update(model);
      return GetTag(updated.Id);
    }
  }
}
