
using Microsoft.EntityFrameworkCore;

public class AddressRepository : IAdressRepository{

    private readonly Db _db;

    public async Task<AddressModel> Add(AddressModel address)
    {
        await _db.AddAsync(address);
        await _db.SaveChangesAsync();
        return address;
    }

    
    public async Task<AddressModel> FindById(int id)
    {
        AddressModel address = await _db.Address.FindAsync(id);
        return address;
    }

    public async Task<List<AddressModel>> FindAll()
    {
        List<AddressModel> addressList = await _db.Address.ToListAsync();
        return addressList;
    }

    public async Task<AddressModel> Update(AddressModel addressToUpdate, AddressModel addressFinded)
    {
        addressFinded.Number = addressToUpdate.Number;
        addressFinded.NeighborHoodId = addressToUpdate.NeighborHoodId;
        addressFinded.StreetId = addressToUpdate.StreetId;
        await _db.SaveChangesAsync();
        return addressToUpdate;
    }

    public async Task<AddressModel> Delete(AddressModel addressToDelete)
    {
        _db.Remove(addressToDelete);
        await _db.SaveChangesAsync();
        return addressToDelete;
    }

}