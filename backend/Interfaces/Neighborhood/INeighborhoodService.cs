public interface IneighborhoodService {
    Task<NeighborhoodModel> AddNeighborhood(NeighborhoodModel neighborhood);
    Task<NeighborhoodModel> GetNeighborhoodById(int id);
    Task<List<NeighborhoodModel>> GetAllNeighborhood();
    Task<NeighborhoodModel> UpdateNeighborhood(int id, NeighborhoodModel updatedNeighborhod);
    Task<NeighborhoodModel> DeleteNeighborhood(int id);
}