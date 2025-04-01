public interface IAdressRepository{
    Task<AddressModel> Add (AddressModel address);
    Task<AddressModel> FindById(int id);
    Task<List<AddressModel>> FindAll();
    Task<AddressModel> Update (AddressModel addressToUpdate, AddressModel addressFinded);
    Task<AddressModel> Delete(AddressModel addressToDelete);
}