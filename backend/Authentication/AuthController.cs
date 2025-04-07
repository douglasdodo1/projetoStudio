using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("Authentication")]
public class AuthController : ControllerBase{
    private readonly AuthService _authService;
    public AuthController(AuthService authService){
        _authService = authService;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] AuthModel user){
        if(user == null){
            return Unauthorized("Usuário ou senha inválidos");
        }
        var token = await _authService.Login(user.Cpf, user.Password);
        return Ok(new { token });
    }
}