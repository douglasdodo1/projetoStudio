
using Microsoft.EntityFrameworkCore;

public class SessionRepository : ISessionRepository {
    private readonly Db _db;

    public SessionRepository(Db db) {
        _db = db;
    }

    public async Task<SessionModel> Add(SessionModel session) {
        SessionModel addedSession = await _db.Session.AddAsync(session);
        await _db.SaveChangesAsync();
        return addedSession;
    }

    public async Task<SessionModel> FindById(int id) {
        SessionModel? session = await _db.Session.FindAsync(id);
        if (session == null) {
            throw new KeyNotFoundException($"Session with ID {id} was not found.");
        }
        return session;
    }

    public async Task<List<SessionModel>> FindAll(string cpf) {
        List<SessionModel> sessionList = await _db.Session.Where(session => session.Cpf == cpf).ToListAsync();
        return sessionList;
    }

    public async Task<SessionModel> Update(SessionModel sessionToUpdate, SessionModel findedSession) {
        findedSession.Cpf = sessionToUpdate.Cpf;
        findedSession.State = sessionToUpdate.State;
        findedSession.Value = sessionToUpdate.Value;
        findedSession.Date = sessionToUpdate.Date;
        findedSession.Time = sessionToUpdate.Time;

        await _db.SaveChangesAsync();
        return sessionToUpdate;
    }

    public async Task<SessionModel> Delete(SessionModel sessionToDelete) {
        _db.Session.Remove(sessionToDelete);
        await _db.SaveChangesAsync();
        return sessionToDelete;
    }

}