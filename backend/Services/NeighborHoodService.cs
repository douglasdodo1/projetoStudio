

using Microsoft.AspNetCore.Mvc;

public class NeighborhoodService : IneighborhoodService {
    private readonly NeighborhoodRepository _neighborhoodRepository;
    private readonly EmployeeValidator _employeeValidator;
    public NeighborhoodService(NeighborhoodRepository neighborhoodRepository, EmployeeValidator employeeValidator) {
        _employeeValidator = employeeValidator;
        _neighborhoodRepository = neighborhoodRepository;
    }

    public async Task<NeighborhoodModel> Add([FromBody] NeighborhoodModel neighborhood) {
        _employeeValidator.ValidateEmployee().Wait();

        NeighborhoodModel neighborhoodReturned = await _neighborhoodRepository.FindById(neighborhood.Id);
        if (neighborhoodReturned != null) {
            throw new KeyNotFoundException("Bairro já cadastrado");
        }

        NeighborhoodModel addedNeighborhood = await _neighborhoodRepository.Add(neighborhood);
        return addedNeighborhood;
    }

    public async Task<NeighborhoodModel> FindById(int id) {
        NeighborhoodModel neighborhood = await _neighborhoodRepository.FindById(id);
        if (neighborhood == null) {
            throw new KeyNotFoundException("Bairro não encontrado");
        }
        return neighborhood;
    }

    public async Task<List<NeighborhoodModel>> FindAll() {
        List<NeighborhoodModel> neighborhoods = await _neighborhoodRepository.FindAll();
        return neighborhoods;
    }

    public async Task<NeighborhoodModel> Update(int id, NeighborhoodModel neighborhoodToupdate) {
        _employeeValidator.ValidateEmployee().Wait();

        NeighborhoodModel findedNeighborhood = await _neighborhoodRepository.FindById(id);
        if (findedNeighborhood == null) {
            throw new KeyNotFoundException("Bairro não encontrado");
        }

        NeighborhoodModel updatedNeighborhood = await _neighborhoodRepository.Update(neighborhoodToupdate, findedNeighborhood);
        if (updatedNeighborhood == null) {
            throw new InvalidOperationException("erro ao atualizar bairro");
        }
        return updatedNeighborhood;
    }

    public async Task<NeighborhoodModel> Delete(int id) {
        _employeeValidator.ValidateEmployee().Wait();

        NeighborhoodModel neighborhoodToDelete = await _neighborhoodRepository.FindById(id);
        if (neighborhoodToDelete == null) {
            throw new KeyNotFoundException("Bairro não encontrado");
        }

        NeighborhoodModel deletedNeighborhood = await _neighborhoodRepository.Delete(neighborhoodToDelete);
        if (deletedNeighborhood == null) {
            throw new InvalidOperationException("Erro ao deletar bairro");
        }
        return deletedNeighborhood;
    }
}