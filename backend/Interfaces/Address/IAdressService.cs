public interface IAdressService {
    Task<AddressModel> AddAddress(AddressModel address);
    Task<AddressModel> FindAddressById(int id);
    Task<List<AddressModel>> FindAllAddress();
    Task<AddressModel> UpdateAddress(int id, AddressModel addressToUpdate);
    Task<AddressModel> DeleteAddress(int id);
}