public interface IServiceSessionService {
    Task<ServiceSessionModel> Add(ServiceSessionModel serviceSession);
    Task<ServiceSessionModel> FindById(int id);
    Task<List<ServiceSessionModel>> FindAll();
    Task<ServiceSessionModel>  Update(int id,  ServiceSessionModel ServiceSessionToUpdate);
    Task<ServiceSessionModel>  Delete(int id);
}