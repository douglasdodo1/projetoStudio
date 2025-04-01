
public class StreetService : IStreetService{

    private readonly StreetRepository _streetRepository;

    public StreetService(StreetRepository streetRepository){
        _streetRepository = streetRepository;
    }

    public async Task<StreetModel> Add(StreetModel street)
    {
        StreetModel streetFinded = await _streetRepository.FindById(street.Id);
        if (streetFinded != null){
            throw new Exception("Rua já cadastrada");
        }
        StreetModel streetModel = await _streetRepository.Add(street);
        return streetModel;
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
            throw new Exception("Rua não encontrada");
        }
        return street;
        
    }

    public async Task<StreetModel> Update(int id, StreetModel streetToUpdate)
    {
        StreetModel findedStreet = await _streetRepository.FindById(id);
        if (findedStreet == null) 
        {
            throw new Exception("rua não encontrada");
        }

        StreetModel UpdatedStreet = await _streetRepository.Update(streetToUpdate, findedStreet);
        return UpdatedStreet;        
    }

    public async Task<StreetModel> Delete(int id)
    {
        StreetModel findedStreet = await _streetRepository.FindById(id);
        if (findedStreet == null) 
        {
            throw new Exception("rua não encontrada");
        }

        StreetModel deletedStreet = await _streetRepository.Delete(findedStreet);
        return deletedStreet;
    }
}