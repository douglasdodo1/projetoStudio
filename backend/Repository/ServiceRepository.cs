
using Microsoft.EntityFrameworkCore;

public class ServiceRepository : IServiceRepository {

    private readonly Db _db;
    public ServiceRepository(Db db) {
        _db = db;
    }

    public async Task<ServiceModel> Add(ServiceModel service) {
        await _db.Service.AddAsync(service);
        await _db.SaveChangesAsync();
        return service;
    }

    public async Task<ServiceModel> FindById(int id) {
        ServiceModel service = await _db.Service.FindAsync(id);
        return service;
    }

    public async Task<List<ServiceModel>> FindAll() {
        List<ServiceModel> serviceList = await _db.Service.ToListAsync();
        return serviceList;
    }

    public async Task<ServiceModel> Update(ServiceModel seriveToUpdate, ServiceModel findedService) {
        findedService.Name = seriveToUpdate.Name;
        findedService.Value = seriveToUpdate.Value;

        await _db.SaveChangesAsync();
        return seriveToUpdate;
    }

    public async Task<ServiceModel> Delete(ServiceModel serviceToDelete) {
        _db.Service.Remove(serviceToDelete);
        await _db.SaveChangesAsync();
        return serviceToDelete;
    }
}