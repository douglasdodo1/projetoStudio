using Microsoft.AspNetCore.Mvc;

[Controller]
[Route("Session")]
public class SessionController : ControllerBase{
    private readonly SessionService _sessionService;
    
}