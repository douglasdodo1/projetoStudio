public interface IAddressUserService {
    Task<AddressUserModel> Add(AddressUserModel addressUser);
    Task<AddressUserModel> FindById(int id);
    Task<List<AddressUserModel>> FindAll();
    Task<AddressUserModel> Updated(int id, AddressUserModel addressUserToUpdate);
    Task<AddressUserModel> Remove(int it);
}