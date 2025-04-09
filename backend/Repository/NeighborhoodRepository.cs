
using Microsoft.EntityFrameworkCore;

public class NeighborhoodRepository : INeighborhoodRepository {

    private readonly Db _db;

    public NeighborhoodRepository(Db db) {
        _db = db;
    }
    public async Task<NeighborhoodModel> Add(NeighborhoodModel neighborhood) {
        await _db.AddAsync(neighborhood);
        await _db.SaveChangesAsync();
        return neighborhood;
    }

    public async Task<NeighborhoodModel> FindById(int id) {
        NeighborhoodModel neighborhood = await _db.Neighborhood.FindAsync(id);
        return neighborhood;
    }

    public async Task<List<NeighborhoodModel>> FindAll() {
        return await _db.Neighborhood.ToListAsync();
    }

    public async Task<NeighborhoodModel> Update(NeighborhoodModel neighborhoodToUpdate, NeighborhoodModel findedNeighborhood) {
        findedNeighborhood.Name = neighborhoodToUpdate.Name;
        await _db.SaveChangesAsync();
        return neighborhoodToUpdate;
    }

    public async Task<NeighborhoodModel> Delete(NeighborhoodModel neighborhood) {
        _db.Remove(neighborhood);
        await _db.SaveChangesAsync();
        return neighborhood;
    }
}