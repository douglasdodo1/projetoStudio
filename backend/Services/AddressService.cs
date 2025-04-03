
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class AddressService : IAdressService{
    private readonly AddressRepository _addressRepository;

    public AddressService(AddressRepository addressRepository){
        _addressRepository = addressRepository;
    }

    public async Task<AddressModel> AddAddress(AddressModel newAddress)
    {
        AddressModel findedAdress = await _addressRepository.FindById(newAddress.Id);
        if (findedAdress != null){
            throw new KeyNotFoundException("endereço já cadastrado");
        }

        AddressModel addedAddress = await _addressRepository.Add(newAddress);
        return addedAddress;
    }

    public async Task<AddressModel> FindAddressById(int id)
    {
        AddressModel address = await _addressRepository.FindById(id);
        if (address == null){
            throw new KeyNotFoundException("endereço não encontrado");
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
            throw new KeyNotFoundException("endereço não encontrado");
        }

        AddressModel updatedAddress = await _addressRepository.Update(addressToUpdate, findedAddress);
        if (updatedAddress == null){
            throw new InvalidOperationException("Erro ao atualizar serviço");
        }
        return updatedAddress;
    }

    public async Task<AddressModel> DeleteAddress(int id)
    {
        AddressModel addressToDelete = await _addressRepository.FindById(id);
        if(addressToDelete == null){
            throw new KeyNotFoundException("Endereço não encontrado");
        }

        AddressModel addressDeleted = await _addressRepository.Delete(addressToDelete);
        return addressDeleted;
    }
}