public interface ISessionRepository{
    Task<SessionModel> Add(SessionModel session);
    Task<SessionModel> FindById(int id);
    Task<List<SessionModel>> FindAll();

    Task<SessionModel> Update(SessionModel sessionToUpdate, SessionModel findedSession);
    Task<SessionModel> Delete(SessionModel sessionToDelete);
}