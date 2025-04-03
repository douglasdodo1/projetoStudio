
using System.ComponentModel;

public class StreetService : IStreetService{

    private readonly StreetRepository _streetRepository;

    public StreetService(StreetRepository streetRepository){
        _streetRepository = streetRepository;
    }

    public async Task<StreetModel> Add(StreetModel street)
    {
        StreetModel streetFinded = await _streetRepository.FindById(street.Id);
        if (streetFinded != null){
            throw new InvalidOperationException("Rua já cadastrada");
        }
        
        StreetModel addedStreet = await _streetRepository.Add(street);
        return addedStreet;
    }

    public async Task<List<StreetModel>> FindAll()
    {
        List<StreetModel> allStreets = await _streetRepository.FindAll();
        return allStreets;
    }

    public async Task<StreetModel> FindById(int id)
    {
        StreetModel street = await _streetRepository.FindById(id);
        if (street == null){
            throw new InvalidOperationException("Rua não encontrada");
        }
        return street;
        
    }

    public async Task<StreetModel> Update(int id, StreetModel streetToUpdate)
    {
        StreetModel findedStreet = await _streetRepository.FindById(id);
        if (findedStreet == null) 
        {
            throw new KeyNotFoundException("rua não encontrada");
        }

        StreetModel UpdatedStreet = await _streetRepository.Update(streetToUpdate, findedStreet);
        if (UpdatedStreet == null){
            throw new InvalidOperationException("erro ao atualizar rua");
        }
        return UpdatedStreet;
    }

    public async Task<StreetModel> Delete(int id)
    {
        StreetModel findedStreet = await _streetRepository.FindById(id);
        if (findedStreet == null) 
        {
            throw new KeyNotFoundException("rua não encontrada");
        }

        StreetModel deletedStreet = await _streetRepository.Delete(findedStreet);
        if(deletedStreet == null){
            throw new InvalidOperationException("erro ao deletar rua");
        }
        return deletedStreet;
    }
}