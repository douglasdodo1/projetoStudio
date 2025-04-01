
using System.Threading.Tasks;

public class AddressService : IAdressService{
    private readonly AddressRepository _addressRepository;

    public AddressService(AddressRepository addressRepository){
        _addressRepository = addressRepository;
    }

    public async Task<AddressModel> AddAddress(AddressModel address)
    {
        AddressModel findedAdress = await _addressRepository.FindById(address.Id);
        if (findedAdress != null){
            throw new Exception("endereço já cadastrado");
        }

        AddressModel newAddress = await _addressRepository.Add(address);
        return newAddress;
    }

    public async Task<AddressModel> FindAddressById(int id)
    {
        AddressModel address = await _addressRepository.FindById(id);
        if (address == null)
        {
            throw new Exception("endereço não encontrado");
        }

        return address;
    }

    public async Task<List<AddressModel>> FindAllAddress()
    {
        List<AddressModel> addressList = await _addressRepository.FindAll();
        return addressList;
    }

    public async Task<AddressModel> UpdateAddress(int id, AddressModel addressToUpdate)
    {
        AddressModel findedAddress = await _addressRepository.FindById(id);
        if (findedAddress == null){
            throw new Exception("endereço não encontrado");
        }

        AddressModel updatedAddress = await _addressRepository.Update(addressToUpdate, findedAddress);
        return updatedAddress;
    }

    public async Task<AddressModel> DeleteAddress(int id)
    {
        AddressModel addressToDelete = await _addressRepository.FindById(id);
        if(addressToDelete == null){
            throw new Exception("Endereço não encontrado");
        }

        AddressModel addressDeleted = await _addressRepository.Delete(addressToDelete);
        return addressDeleted;
    }
}