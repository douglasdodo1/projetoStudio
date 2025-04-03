
public class ServiceRepository : IServiceRepository
{
    private readonly Db _db;

    public ServiceRepository(Db db){
        _db = db;
    }
    public async Task<ServiceModel> Add(ServiceModel service)
    {
        ServiceModel serviceAdded = await _db.Service.AddAsync(service);
        return serviceAdded;
    }

    public async Task<ServiceModel> FindById(int id)
    {
        ServiceModel serviceModel = await _db.Service.FindAsync(id);
        return serviceModel;
    }

    public async Task<List<ServiceModel>> FindAll()
    {
        List<ServiceModel> serviceModel = _db.Service.ToList();
        return serviceModel;
    }

    public async Task<ServiceModel> Update(ServiceModel seriveToUpdate, ServiceModel findedService)
    {
        findedService.Name = seriveToUpdate.Name;
        findedService.Value = seriveToUpdate.Value;
        await _db.SaveChangesAsync();
        return seriveToUpdate;
    }

    public async Task<ServiceModel> Delete(ServiceModel serviceToDelete)
    {
        _db.Service.Remove(serviceToDelete);
        await _db.SaveChangesAsync();
        return serviceToDelete;
    }
}