public interface IServiceSessionRepository {
    Task<ServiceSessionModel> Add(ServiceSessionModel serviceSession);
    Task<ServiceSessionModel> FindById(int id);
    Task<List<ServiceSessionModel>> FindAll();
    Task<ServiceSessionModel> Update(ServiceSessionModel serviceSessionToUpdate, ServiceSessionModel findedServiceSession);
    Task<ServiceSessionModel> Delete(ServiceSessionModel serviceSession);
}