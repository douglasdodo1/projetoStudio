
using Microsoft.EntityFrameworkCore;

public class StreetRepository : IStreetRepository {

    private readonly Db _db;

    public StreetRepository(Db Db) {
        _db = Db;
    }
    public async Task<StreetModel> Add(StreetModel street) {
        await _db.AddAsync(street);
        await _db.SaveChangesAsync();
        return street;
    }

    public async Task<StreetModel> FindById(int id) {
        StreetModel street = await _db.Street.FindAsync(id);
        return street;
    }

    public async Task<List<StreetModel>> FindAll() {
        List<StreetModel> streetList = await _db.Street.ToListAsync();
        return streetList;
    }

    public async Task<StreetModel> Update(StreetModel streetToUpdate, StreetModel findedStreet) {
        findedStreet.Name = streetToUpdate.Name;
        await _db.SaveChangesAsync();
        return streetToUpdate;
    }

    public async Task<StreetModel> Delete(StreetModel street) {
        _db.Remove(street);
        await _db.SaveChangesAsync();
        return street;
    }
}