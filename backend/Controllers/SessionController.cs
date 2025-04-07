using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
[Controller]
[Route("Session")]
public class SessionController : ControllerBase{
    private readonly SessionService _sessionService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public SessionController(SessionService sessionService, IHttpContextAccessor httpContextAccessor){
        _sessionService = sessionService;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] SessionModel newSession){
        if (newSession == null){
            return BadRequest("sessão não fornecida");
        }

        SessionModel createdSession = await _sessionService.Add(newSession);
        return Created(nameof(Add), createdSession);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id){
        SessionModel session = await _sessionService.FindById(id);
        return Ok(session);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll(){
        List<SessionModel> sessionList = await _sessionService.FindAll();
        return Ok(sessionList);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] SessionModel session){
        if (session == null){
            return BadRequest("sessão não fornecida");
        }

        SessionModel updatedSession = await _sessionService.Update(id, session);
        return Ok(updatedSession);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id){
        SessionModel deletedSession = await _sessionService.Delete(id);
        return Ok(deletedSession);
    }
}