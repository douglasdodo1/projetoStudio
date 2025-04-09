
using Microsoft.EntityFrameworkCore;

public class ServiceSessionRepository : IServiceSessionRepository {
    private readonly Db _db;

    public ServiceSessionRepository(Db db) {
        _db = db;
    }

    public async Task<ServiceSessionModel> Add(ServiceSessionModel serviceSession) {
        await _db.SessionService.AddAsync(serviceSession);
        await _db.SaveChangesAsync();
        return serviceSession;
    }

    public async Task<ServiceSessionModel> FindById(int id) {
        ServiceSessionModel serviceSession = await _db.SessionService.FindAsync(id);
        return serviceSession;
    }

    public async Task<List<ServiceSessionModel>> FindAll() {
        List<ServiceSessionModel> serviceSessionList = await _db.SessionService.ToListAsync();
        return serviceSessionList;
    }

    public async Task<ServiceSessionModel> Update(ServiceSessionModel serviceSessionToUpdate, ServiceSessionModel findedServiceSession) {
        findedServiceSession.IdSession = serviceSessionToUpdate.IdSession;
        findedServiceSession.IdService = serviceSessionToUpdate.IdService;
        await _db.SaveChangesAsync();
        return findedServiceSession;
    }

    public async Task<ServiceSessionModel> Delete(ServiceSessionModel serviceSession) {
        _db.SessionService.Remove(serviceSession);
        await _db.SaveChangesAsync();
        return serviceSession;
    }
}