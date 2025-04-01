public interface IneighborhoodService {
    Task<NeighborhoodModel> Add(NeighborhoodModel neighborhood);
    Task<NeighborhoodModel> FindById(int id);
    Task<List<NeighborhoodModel>> FindAll();
    Task<NeighborhoodModel> Update(int id, NeighborhoodModel updatedNeighborhod);
    Task<NeighborhoodModel> Delete(int id);
}