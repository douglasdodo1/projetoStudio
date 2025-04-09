public interface INeighborhoodRepository {
    Task<NeighborhoodModel> Add(NeighborhoodModel neighborhood);
    Task<NeighborhoodModel> FindById(int id);
    Task<List<NeighborhoodModel>> FindAll();
    Task<NeighborhoodModel> Update(NeighborhoodModel neighborhoodToUpdate, NeighborhoodModel findedNeighborhood);
    Task<NeighborhoodModel> Delete(NeighborhoodModel neighborhood);
}