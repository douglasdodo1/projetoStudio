public interface IAddressUserRepository {
    Task<AddressUserModel> Add(AddressUserModel addressUser);
    Task<AddressUserModel> FindById(int id);
    Task<List<AddressUserModel>> FindAll();
    Task<AddressUserModel> Update(AddressUserModel addressUserToUpdate, AddressUserModel addressUserFinded);
    Task<AddressUserModel> Remove(AddressUserModel addressUserToRemove);
}