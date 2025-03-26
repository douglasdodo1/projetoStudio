
public class StreetService : IStreetService{

    private readonly StreetRepository _streetRepository;

    public StreetService(StreetRepository streetRepository){
        _streetRepository = streetRepository;
    }

    public async Task<StreetModel> AddStreet(StreetModel street)
    {
        StreetModel streetFinded = await _streetRepository.FindStreetById(street.Id);
        if (streetFinded == null){
            throw new Exception("Rua não encontrada");
        }
        StreetModel streetModel = await _streetRepository.AddStreet(street);
        return streetModel;
    }

    public Task<List<StreetModel>> FindAllStreet()
    {
        throw new NotImplementedException();
    }

    public async Task<StreetModel> FindStreetById(int id)
    {
        StreetModel street = await _streetRepository.FindStreetById(id);
        if (street == null){
            throw new Exception("Rua não encontrada");
        }
        return street;
        
    }

    public async Task<StreetModel> UpdateStreet(int id, StreetModel streetToUpdate)
    {
        throw new NotImplementedException();
    }

    public async Task<StreetModel> DeleteStreet(int id)
    {
        throw new NotImplementedException();
    }
}