
using Microsoft.EntityFrameworkCore;

public class NeighborhoodRepository : INeighborhoodRepository{

    private readonly Db _db;
    public Task<NeighborhoodModel> AddNeighborhood(NeighborhoodModel neighborhood)
    {
        throw new NotImplementedException();
    }

    public async Task<NeighborhoodModel> FindNeighborhoodById(int id)
    {
        NeighborhoodModel neighborhood = await _db.Neighborhood.FindAsync(id);
        return neighborhood;
    }

    public async Task<List<NeighborhoodModel>> FindAllNeighborhood()
    {
        return await _db.Neighborhood.ToListAsync();
    }

    public async Task<NeighborhoodModel> UpdateNeighborhoor(NeighborhoodModel neighborhoodToUpdate, NeighborhoodModel findedNeighborhood)
    {
        findedNeighborhood.Name = neighborhoodToUpdate.Name;
        await _db.SaveChangesAsync();
        return neighborhoodToUpdate;
    }

    public Task<NeighborhoodModel> DeleteNeighborhood(NeighborhoodModel neighborhood)
    {
        throw new NotImplementedException();
    }
}