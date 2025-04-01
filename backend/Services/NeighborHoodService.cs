

using Microsoft.AspNetCore.Mvc;

public class NeighborhoodService : IneighborhoodService{
    private readonly NeighborhoodRepository _neighborhoodRepository;

    public NeighborhoodService(NeighborhoodRepository neighborhoodRepository){
        _neighborhoodRepository = neighborhoodRepository;
    }
    public async Task<NeighborhoodModel> Add([FromBody] NeighborhoodModel neighborhood){
        int id = neighborhood.Id;
        NeighborhoodModel neighborhoodReturned = await _neighborhoodRepository.FindById(id);
        if (neighborhoodReturned != null){
             throw new Exception("Bairro já cadastrado");
        }

        NeighborhoodModel addedNeighborhood = await _neighborhoodRepository.Add(neighborhood);
        if (addedNeighborhood == null){
            throw new Exception("erro ao cadastrar serviço");
        }
        
        return addedNeighborhood;
    }
    public async Task<NeighborhoodModel> FindById(int id)
    {
        NeighborhoodModel neighborhood = await _neighborhoodRepository.FindById(id);
        if (neighborhood == null)
        {
            throw new Exception("Bairro não encontrado");
        }
        return neighborhood;
    }

    public async Task<List<NeighborhoodModel>> FindAll(){
        List<NeighborhoodModel> neighborhoods = await _neighborhoodRepository.FindAll();
        return neighborhoods;
    }

    public async Task<NeighborhoodModel> Update(int id, NeighborhoodModel neighborhoodToupdate)
    {
        NeighborhoodModel findedNeighborhood = await _neighborhoodRepository.FindById(id);
        if (findedNeighborhood == null){
            throw new Exception("Bairro não encontrado");
        }

        NeighborhoodModel updatedNeighborhood = await _neighborhoodRepository.Update(neighborhoodToupdate, findedNeighborhood);
        return updatedNeighborhood;
    }

    public async Task<NeighborhoodModel> Delete(int id)
    {
        NeighborhoodModel neighborhoodToDelete = await _neighborhoodRepository.FindById(id);
        if (neighborhoodToDelete == null)
        {
            throw new Exception("Bairro não encontrado");
        }

        NeighborhoodModel deletedNeighborhood = await _neighborhoodRepository.Delete(neighborhoodToDelete);
        return deletedNeighborhood;

    }


}