public interface IServiceRepository{
    Task<ServiceModel> Add(ServiceModel service);
    Task<ServiceModel> FindById(int id);
    Task<List<ServiceModel>> FindAll();
    Task<ServiceModel> Update(ServiceModel seriveToUpdate, ServiceModel findedService);
    Task<ServiceModel> Delete(ServiceModel serviceToDelete);
}