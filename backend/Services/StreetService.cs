
using System.ComponentModel;

public class StreetService : IStreetService {

    private readonly StreetRepository _streetRepository;
    private readonly EmployeeValidator _employeeValidator;
    public StreetService(StreetRepository streetRepository, EmployeeValidator employeeValidator) {
        _streetRepository = streetRepository;

        _employeeValidator = employeeValidator;
    }

    public async Task<StreetModel> Add(StreetModel street) {
        _employeeValidator.ValidateEmployee().Wait();

        StreetModel streetFinded = await _streetRepository.FindById(street.Id);
        if (streetFinded != null) {
            throw new InvalidOperationException("Rua já cadastrada");
        }

        StreetModel addedStreet = await _streetRepository.Add(street);
        return addedStreet;
    }

    public async Task<List<StreetModel>> FindAll() {
        List<StreetModel> allStreets = await _streetRepository.FindAll();
        return allStreets;
    }

    public async Task<StreetModel> FindById(int id) {
        StreetModel street = await _streetRepository.FindById(id);
        if (street == null) {
            throw new InvalidOperationException("Rua não encontrada");
        }
        return street;

    }

    public async Task<StreetModel> Update(int id, StreetModel streetToUpdate) {
        _employeeValidator.ValidateEmployee().Wait();

        StreetModel findedStreet = await _streetRepository.FindById(id);
        if (findedStreet == null) {
            throw new KeyNotFoundException("rua não encontrada");
        }

        StreetModel UpdatedStreet = await _streetRepository.Update(streetToUpdate, findedStreet);
        if (UpdatedStreet == null) {
            throw new InvalidOperationException("erro ao atualizar rua");
        }
        return UpdatedStreet;
    }

    public async Task<StreetModel> Delete(int id) {
        _employeeValidator.ValidateEmployee().Wait();

        StreetModel findedStreet = await _streetRepository.FindById(id);

        if (findedStreet == null) {
            throw new KeyNotFoundException("rua não encontrada");
        }

        StreetModel deletedStreet = await _streetRepository.Delete(findedStreet);
        if (deletedStreet == null) {
            throw new InvalidOperationException("erro ao deletar rua");
        }
        return deletedStreet;
    }
}