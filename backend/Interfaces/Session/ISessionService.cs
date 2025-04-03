public interface ISessionService{
    public Task<SessionModel> Add(SessionModel session);
    public Task<SessionModel> FindById(int id);
    public Task<List<SessionModel>> FindAll();
    public Task<SessionModel> Update(int id, SessionModel sessionModelToUpdate);
    public Task<SessionModel> Delete(int id);
}