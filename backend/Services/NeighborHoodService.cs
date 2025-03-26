

using Microsoft.AspNetCore.Mvc;

public class NeighborhoodService : IneighborhoodService{
    private readonly NeighborhoodRepository _neighborhoodRepository;

    public NeighborhoodService(NeighborhoodRepository neighborhoodRepository){
        _neighborhoodRepository = neighborhoodRepository;
    }
    public async Task<NeighborhoodModel> AddNeighborhood([FromBody] NeighborhoodModel neighborhood){
        int id = neighborhood.Id;
        NeighborhoodModel neighborhoodReturned = await _neighborhoodRepository.FindNeighborhoodById(id);
        if (neighborhoodReturned != null){
             throw new Exception("Bairro já cadastrado");
        }

        NeighborhoodModel addedNeighborhood = await _neighborhoodRepository.AddNeighborhood(neighborhood);
        return addedNeighborhood;
    }
    public async Task<NeighborhoodModel> GetNeighborhoodById(int id)
    {
        NeighborhoodModel neighborhood = await _neighborhoodRepository.FindNeighborhoodById(id);
        if (neighborhood == null)
        {
            throw new Exception("Bairro não encontrado");
        }
        return neighborhood;
    }

    public async Task<List<NeighborhoodModel>> GetAllNeighborhood(){
        List<NeighborhoodModel> neighborhoods = await _neighborhoodRepository.FindAllNeighborhood();
        return neighborhoods;
    }

    public async Task<NeighborhoodModel> UpdateNeighborhood(int id, NeighborhoodModel neighborhoodToupdate)
    {
        NeighborhoodModel findedNeighborhood = await _neighborhoodRepository.FindNeighborhoodById(id);
        if (findedNeighborhood == null){
            throw new Exception("Bairro não encontrado");
        }

        NeighborhoodModel updatedNeighborhood = await _neighborhoodRepository.UpdateNeighborhoor(neighborhoodToupdate, findedNeighborhood);
        return updatedNeighborhood;
    }

    public async Task<NeighborhoodModel> DeleteNeighborhood(int id)
    {
        NeighborhoodModel neighborhoodToDelete = await _neighborhoodRepository.FindNeighborhoodById(id);
        if (neighborhoodToDelete == null)
        {
            throw new Exception("Bairro não encontrado");
        }

        NeighborhoodModel deletedNeighborhood = await _neighborhoodRepository.DeleteNeighborhood(neighborhoodToDelete);
        return deletedNeighborhood;

    }


}