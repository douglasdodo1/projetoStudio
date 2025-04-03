
public class ServiceRepository : IServiceRepository
{
    public Task<ServiceModel> Add(ServiceModel service)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceModel> FindById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<ServiceModel>> FindAll()
    {
        throw new NotImplementedException();
    }

    public Task<ServiceModel> Update(ServiceModel seriveToUpdate, ServiceModel findedService)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceModel> Delete(ServiceModel serviceToDelete)
    {
        throw new NotImplementedException();
    }
}