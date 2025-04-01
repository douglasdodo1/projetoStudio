public interface IStreetService {
    Task<StreetModel> Add(StreetModel street);
    Task<StreetModel> FindById(int id);
    Task<List<StreetModel>> FindAll();
    Task<StreetModel> Update(int id, StreetModel streetToUpdate);
    Task<StreetModel>Delete(int id);
}