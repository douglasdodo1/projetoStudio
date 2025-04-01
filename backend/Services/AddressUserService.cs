
public class AddressUserService : IAddressUserService
{
    private readonly AddressUserRepository _addressRepository;

    public AddressUserService(AddressUserRepository addressUserModel){
        _addressRepository = addressUserModel;
    }
    public async Task<AddressUserModel> Add(AddressUserModel addressUser)
    {
        AddressUserModel findedAddressUser = await _addressRepository.FindById(addressUser.Id);
        if (findedAddressUser != null){
            throw new Exception("endereço já cadastrado há um usuario");
        }

        AddressUserModel  newAddressUser = await _addressRepository.Add(addressUser);
        return newAddressUser;

    }

    public async Task<AddressUserModel> FindById(int id)
    {
        AddressUserModel addressUser = await _addressRepository.FindById(id);
        if (addressUser == null){
            throw new Exception("Endereço de usuario não encontrado");
        }

        return addressUser;
    }

    public async Task<List<AddressUserModel>> FindAll()
    {
        List<AddressUserModel> addressUserList = await  _addressRepository.FindAll();
        return addressUserList;
    }

    public async Task<AddressUserModel> Updated(int id, AddressUserModel addressUserToUpdate)
    {
        AddressUserModel findedAddressUser = await _addressRepository.FindById(id);
        if (findedAddressUser == null){
            throw new Exception("Endereço de usuario não encontrado");
        }

        AddressUserModel addressUserUpdated = await _addressRepository.Update(addressUserToUpdate, findedAddressUser);
        return addressUserUpdated;
    }

    public async Task<AddressUserModel> Remove(int id)
    {
       AddressUserModel findedAddressUser = await _addressRepository.FindById(id);
       if (findedAddressUser == null){
            throw new Exception("Endereço de usuario não encontrado");
       }

       AddressUserModel addressUserRemoved = await _addressRepository.Remove(findedAddressUser);
       return addressUserRemoved;
    }
}