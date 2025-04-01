public interface IServiceService{
    Task<ServiceModel> Add(ServiceModel service);
    Task<ServiceModel> FindById(int id);
    Task<List<ServiceModel>> FindAll();
    Task<ServiceModel> Update(int id, ServiceModel serviceToUpdate);
    Task<ServiceModel> Delete(int id);
}