using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RvuPiecemaker.API.Features.Services
{
  public interface IServicesService
  {
    IEnumerable<ServiceModel> GetServices();
    ServiceModel GetService(int id);
    ServiceModel InsertService(ServiceModel model);
    ServiceModel UpdateService(ServiceModel model);
    void DeleteService(int id);
  }

  public class ServicesService : IServicesService
  {
    private readonly IServicesRepository _repo;

    public ServicesService(IServicesRepository repo)
    {
      _repo = repo;
    }

    public void DeleteService(int id)
    {
      _repo.Delete(id);
    }

    public ServiceModel GetService(int id)
    {
      return _repo.FindByKey(id);
    }

    public IEnumerable<ServiceModel> GetServices()
    {
      return _repo.All();
    }

    public ServiceModel InsertService(ServiceModel model)
    {
      var inserted = _repo.Insert(model);
      return GetService(inserted.Id);
    }

    public ServiceModel UpdateService(ServiceModel model)
    {
      var updated = _repo.Update(model);
      return GetService(updated.Id);
    }
  }
}
