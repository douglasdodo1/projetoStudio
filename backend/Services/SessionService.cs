using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;


public class SessionService : ISessionService {

    private readonly SessionValidator _validator;
    private readonly SessionRepository _sessionRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public SessionService(SessionValidator validator, SessionRepository sessionRepository, IHttpContextAccessor httpContextAccessor) {
        _validator = validator;
        _sessionRepository = sessionRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<SessionModel> Add(SessionModel session) {


        var cpf = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Name)?.Value;
        if (cpf != null) {
            session.Cpf = cpf;
        }
        else {
            throw new InvalidOperationException("Usuário não autenticado");
        }

        var validationResult = _validator.Validate(session);
        var erros = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));

        if (!validationResult.IsValid) {
            throw new ArgumentException(erros);
        }

        SessionModel findedSessionModel = await _sessionRepository.FindById(session.Id);
        if (findedSessionModel != null) {
            throw new InvalidOperationException("Sessão já existe");
        }
        SessionModel addedSession = await _sessionRepository.Add(session);
        return addedSession;
    }

    public async Task<SessionModel> FindById(int id) {
        SessionModel session = await _sessionRepository.FindById(id);
        if (session == null) {
            throw new InvalidOperationException("sessão não encontrada");
        }
        return session;
    }

    public async Task<List<SessionModel>> FindAll() {
        var cpf = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Name)?.Value;
        if (cpf == null) {
            throw new InvalidOperationException("Usuário não autenticado");
        }

        List<SessionModel> sessionList = await _sessionRepository.FindAll(cpf);
        return sessionList;
    }

    public async Task<SessionModel> Update(int id, SessionModel sessionModelToUpdate) {
        SessionModel findedSession = await _sessionRepository.FindById(id);
        if (findedSession == null) {
            throw new InvalidOperationException("sessão não encontrada");
        }
        SessionModel updatedSession = await _sessionRepository.Update(sessionModelToUpdate, findedSession);
        return updatedSession;
    }

    public async Task<SessionModel> Delete(int id) {
        SessionModel sessionToDelete = await _sessionRepository.FindById(id);
        if (sessionToDelete == null) {
            throw new InvalidOperationException("sessão não encontrada");
        }

        SessionModel deletedSession = await _sessionRepository.Delete(sessionToDelete);
        return deletedSession;
    }
}