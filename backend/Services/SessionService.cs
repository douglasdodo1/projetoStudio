
public class SessionService : ISessionService{

    private readonly SessionValidator _validator;
    private readonly SessionRepository _sessionRepository;
    public SessionService(SessionValidator validator, SessionRepository sessionRepository){
        _validator = validator;
        _sessionRepository = sessionRepository;
    }

    public async Task<SessionModel> Add(SessionModel session)
    {
        var validationResult = _validator.Validate(session);
        var erros = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
        if (!validationResult.IsValid){
            throw new ArgumentException(erros);
        }

        SessionModel findedSessionModel = await _sessionRepository.FindById(session.Id);
        if(findedSessionModel != null){
            throw new InvalidOperationException("Sessão já existe");
        }

        SessionModel addedSession = await _sessionRepository.Add(session);
        return addedSession;
    }

    public Task<SessionModel> FindById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<SessionModel>> FindAll()
    {
        throw new NotImplementedException();
    }
    
    public Task<SessionModel> Update(int id, SessionModel sessionModelToUpdate)
    {
        throw new NotImplementedException();
    }

    public Task<SessionModel> Delete(int id)
    {
        throw new NotImplementedException();
    }
}