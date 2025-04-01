
using Microsoft.AspNetCore.Http.HttpResults;

public class ServiceService : IServiceService
{
    private readonly ServiceRepository _serviceRepository;

    public ServiceService(ServiceRepository serviceRepository){
        _serviceRepository = serviceRepository;
    }

    public async Task<ServiceModel> Add(ServiceModel service)
    {
        ServiceModel findedService = await FindById(service.Id);

        if (findedService != null){
            throw new InvalidOperationException("Serviço já existe");
        }

        ServiceModel addedService = await _serviceRepository.Add(service);
        if (addedService == null){
            throw new InvalidOperationException("erro ao adicionar serviço");
        }
        return addedService;
    }

    public async Task<ServiceModel> FindById(int id){
        if (id <= 0){
            throw new ArgumentOutOfRangeException(nameof(id), "O ID fornecido é inválido.");
        }

        ServiceModel FindedService = await _serviceRepository.FindById(id);
        if (FindedService == null){
            throw new KeyNotFoundException("Serviço não encontrado");
        }
        return FindedService;
    }

    public Task<List<ServiceModel>> FindAll()
    {
        throw new NotImplementedException();
    }

    public Task<ServiceModel> Update(int id, ServiceModel serviceToUpdate)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceModel> Delete(int id)
    {
        throw new NotImplementedException();
    }
}