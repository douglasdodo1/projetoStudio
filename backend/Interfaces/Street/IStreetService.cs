public interface IStreetService {
    Task<StreetModel> AddStreet(StreetModel street);
    Task<StreetModel> FindStreetById(int id);
    Task<List<StreetModel>> FindAllStreet();
    Task<StreetModel> UpdateStreet(int id, StreetModel streetToUpdate);
    Task<StreetModel>DeleteStreet(int id);
}