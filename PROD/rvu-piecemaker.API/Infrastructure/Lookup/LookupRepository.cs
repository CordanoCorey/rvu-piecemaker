using Microsoft.EntityFrameworkCore;
using RvuPiecemaker.Entities.Context;
using RvuPiecemaker.Entities.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RvuPiecemaker.API.Infrastructure.Lookup
{

  public interface ILookupRepository
  {
    IEnumerable<LookupModel> GetLookups();
  }
  public class LookupRepository : ILookupRepository
  {
    private RvuPiecemakerContext _context;

    public LookupRepository(RvuPiecemakerContext context)
    {
      _context = context;
    }

    public IEnumerable<LookupModel> GetLookups()
    {
      var lookups = new List<LookupModel>();


      foreach (var entity in _context.Model.GetEntityTypes())
      {
        var name = entity.Name;
        var type = entity.ClrType;


        var schema = _context.Model.FindEntityType(type).Relational().Schema;

        if (schema == "Lookup")
        {

          var dbObject = (IEnumerable<ILookup>)
             typeof(DbContext).GetMethod("Set", Type.EmptyTypes)
             .MakeGenericMethod(type)
             .Invoke(_context, null);

          lookups.Add(new LookupModel()
          {
            Name = name.Split('.').Last(),
            Values = dbObject
          });
        }
      }

      return lookups;
    }
  }
}
