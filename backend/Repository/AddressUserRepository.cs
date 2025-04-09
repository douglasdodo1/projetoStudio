
using Microsoft.EntityFrameworkCore;

public class AddressUserRepository : IAddressUserRepository
{
    private readonly Db _db;

    public AddressUserRepository(Db db){
        _db = db;
    }
    public async Task<AddressUserModel> Add(AddressUserModel addressUser)
    {
        AddressUserModel addressUserAdded = await _db.AdressUser.AddAsync(addressUser);
        return addressUserAdded;
    }

    public async Task<AddressUserModel> FindById(int id)
    {
        AddressUserModel addressUser = await _db.AdressUser.FindAsync(id);
        return addressUser;
    }

    public async Task<List<AddressUserModel>> FindAll(string cpf)
    {
        List<AddressUserModel> addressUserList = await _db.AdressUser.Where(au => au.Cpf == cpf).ToListAsync();
        return addressUserList;
    }

    public async Task<AddressUserModel> Update(AddressUserModel addressUserToUpdate, AddressUserModel addressUserFinded)
    {
        addressUserFinded.AdressId = addressUserToUpdate.AdressId;
        addressUserFinded.Cpf = addressUserToUpdate.Cpf;
        await _db.SaveChangesAsync();
        return addressUserToUpdate;
    }

    public async Task<AddressUserModel> Remove(AddressUserModel addressUserToRemove)
    {
        _db.AdressUser.Remove(addressUserToRemove);
        await _db.SaveChangesAsync();
        return addressUserToRemove;
    }
}