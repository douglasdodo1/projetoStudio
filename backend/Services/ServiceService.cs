
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

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
        return addedService;
    }

    public async Task<ServiceModel> FindById(int id){
        ServiceModel FindedService = await _serviceRepository.FindById(id);
        if (FindedService == null){
            throw new KeyNotFoundException("Serviço não encontrado");
        }
        return FindedService;
    }

    public async Task<List<ServiceModel>> FindAll()
    {
        List<ServiceModel> serviceList = await _serviceRepository.FindAll();
        return serviceList;
    }

    public async Task<ServiceModel> Update(int id, ServiceModel serviceToUpdate)
    {
       ServiceModel findedService = await _serviceRepository.FindById(id);
       if (findedService == null){
        throw new KeyNotFoundException("serviço não encontrado");
       }

        ServiceModel updatedService = await _serviceRepository.Update(serviceToUpdate, findedService);
        if (updatedService == null){
            throw new DbUpdateException("erro ao atualizar serviço");
        }
        return updatedService;
    }

    public async Task<ServiceModel> Delete(int id)
    {
        ServiceModel serviceToDelete = await _serviceRepository.FindById(id);
        if (serviceToDelete == null){
            throw new KeyNotFoundException("serviço não encontrado");
        }

        ServiceModel deletedService = await _serviceRepository.Delete(serviceToDelete);
        if (deletedService == null){
            throw new InvalidOperationException("erro ao deletar serviço");
        }
        return deletedService;
    }
}