
public class SessionRepository : ISessionRepository
{
    public Task<SessionModel> Add(SessionModel session)
    {
        throw new NotImplementedException();
    }

    public Task<SessionModel> FindById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<SessionModel>> FindAll()
    {
        throw new NotImplementedException();
    }

    public Task<SessionModel> Update(SessionModel sessionToUpdate, SessionModel findedSession)
    {
        throw new NotImplementedException();
    }

    public Task<SessionModel> Delete(SessionModel sessionToDelete)
    {
        throw new NotImplementedException();
    }

}