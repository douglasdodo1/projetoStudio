public interface IStreetRepository{
    Task<StreetModel> Add(StreetModel street);
    Task<StreetModel> FindById(int id);
    Task<List<StreetModel>> FindAll();
    Task<StreetModel> Update(StreetModel streetToUpdate, StreetModel findedStreet);
    Task<StreetModel> Delete(StreetModel street);
}