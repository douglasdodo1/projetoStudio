
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

public class AddressUserService : IAddressUserService {
    private readonly AddressUserRepository _addressRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AddressUserService(AddressUserRepository addressUserModel, IHttpContextAccessor httpContextAccessor) {
        _addressRepository = addressUserModel;
        _httpContextAccessor = httpContextAccessor;
    }
    public async Task<AddressUserModel> Add(AddressUserModel addressUser) {
        AddressUserModel findedAddressUser = await _addressRepository.FindById(addressUser.Id);
        if (findedAddressUser != null) {
            throw new KeyNotFoundException("endereço já cadastrado há um usuario");
        }

        var cpf = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Name)?.Value;
        if (cpf != null) {
            addressUser.Cpf = cpf;
        }
        else {
            throw new InvalidOperationException("Usuário não autenticado");
        }

        AddressUserModel newAddressUser = await _addressRepository.Add(addressUser);
        return newAddressUser;

    }

    public async Task<AddressUserModel> FindById(int id) {
        AddressUserModel addressUser = await _addressRepository.FindById(id);
        if (addressUser == null) {
            throw new KeyNotFoundException("Endereço de usuario não encontrado");
        }

        return addressUser;
    }

    public async Task<List<AddressUserModel>> FindAll() {
        var cpf = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Name)?.Value;
        if (cpf == null) {
            throw new InvalidOperationException("Usuário não autenticado");
        }

        List<AddressUserModel> addressUserList = await _addressRepository.FindAll(cpf);
        return addressUserList;
    }

    public async Task<AddressUserModel> Updated(int id, AddressUserModel addressUserToUpdate) {
        AddressUserModel findedAddressUser = await _addressRepository.FindById(id);
        if (findedAddressUser == null) {
            throw new KeyNotFoundException("Endereço de usuario não encontrado");
        }

        AddressUserModel addressUserUpdated = await _addressRepository.Update(addressUserToUpdate, findedAddressUser);
        if (addressUserUpdated != null) {
            throw new InvalidOperationException("Erro ao atualizar endereço de usuario");
        }
        return addressUserUpdated;
    }

    public async Task<AddressUserModel> Remove(int id) {
        AddressUserModel findedAddressUser = await _addressRepository.FindById(id);
        if (findedAddressUser == null) {
            throw new KeyNotFoundException("Endereço de usuario não encontrado");
        }

        AddressUserModel addressUserRemoved = await _addressRepository.Remove(findedAddressUser);
        if (addressUserRemoved != null) {
            throw new InvalidOperationException("Erro ao deletar endereço de usuario");
        }
        return addressUserRemoved;
    }
}