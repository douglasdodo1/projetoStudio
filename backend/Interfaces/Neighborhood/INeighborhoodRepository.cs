public interface INeighborhoodRepository {
    Task<NeighborhoodModel> AddNeighborhood(NeighborhoodModel neighborhood);
    Task<NeighborhoodModel> FindNeighborhoodById(int id);
    Task<List<NeighborhoodModel>> FindAllNeighborhood();
    Task<NeighborhoodModel> UpdateNeighborhoor(NeighborhoodModel neighborhoodToUpdate, NeighborhoodModel findedNeighborhood);
    Task<NeighborhoodModel> DeleteNeighborhood(NeighborhoodModel neighborhood);
    }