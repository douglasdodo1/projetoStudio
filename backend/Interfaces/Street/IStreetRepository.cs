public interface IStreetRepository{
    Task<StreetModel> AddStreet(StreetModel street);
    Task<StreetModel> FindStreetById(int id);
    Task<List<StreetModel>> FindAllStreet();
    Task<StreetModel> UpdateStreet(StreetModel streetToUpdate, StreetModel findedStreet);
    Task<StreetModel> deleteStreet(StreetModel street);
}