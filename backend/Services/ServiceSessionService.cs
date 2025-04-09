
public class ServiceSessionService : IServiceSessionService {
    private readonly ServiceSessionRepository _serviceSessionRepository;

    public ServiceSessionService(ServiceSessionRepository serviceSessionRepository) {
        _serviceSessionRepository = serviceSessionRepository;
    }
    public async Task<ServiceSessionModel> Add(ServiceSessionModel serviceSession) {
        ServiceSessionModel findedServiceSession = await _serviceSessionRepository.FindById(serviceSession.Id);

        if (findedServiceSession != null) {
            throw new InvalidOperationException("Serviço para essa sessão já existe");
        }

        ServiceSessionModel addedServiceSession = await _serviceSessionRepository.Add(serviceSession);
        return addedServiceSession;
    }

    public async Task<ServiceSessionModel> FindById(int id) {
        ServiceSessionModel serviceSession = await _serviceSessionRepository.FindById(id);
        if (serviceSession == null) {
            throw new KeyNotFoundException("Serviço para essa consulta não foi encontrado");
        }
        return serviceSession;
    }

    public async Task<List<ServiceSessionModel>> FindAll() {
        List<ServiceSessionModel> serviceSession = await _serviceSessionRepository.FindAll();
        return serviceSession;
    }

    public async Task<ServiceSessionModel> Update(int id, ServiceSessionModel sessionServiceToUpdate) {
        ServiceSessionModel findedServiceSession = await _serviceSessionRepository.FindById(id);
        if (findedServiceSession == null) {
            throw new KeyNotFoundException("Serviço para essa consulta não foi encontrado");
        }

        ServiceSessionModel updatedServiceSession = await _serviceSessionRepository.Update(sessionServiceToUpdate, findedServiceSession);
        if (updatedServiceSession == null) {
            throw new InvalidOperationException("Erro ao atualizar serviço para sessão");
        }
        return updatedServiceSession;
    }

    public async Task<ServiceSessionModel> Delete(int id) {
        ServiceSessionModel findedServiceSession = await _serviceSessionRepository.FindById(id);
        if (findedServiceSession == null) {
            throw new KeyNotFoundException("Serviço para essa consulta não foi encontrado");
        }

        ServiceSessionModel deletedServiceSession = await _serviceSessionRepository.Delete(findedServiceSession);
        if (deletedServiceSession == null) {
            throw new InvalidOperationException("Erro ao deletar serviço para sessão");
        }
        return deletedServiceSession;
    }
}