using FluentValidation;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("User")]
public class UsuarioController : ControllerBase {

    private readonly IValidator<UserModel> _validator;
    private  UserService _usuarioService;

    public UsuarioController (IValidator<UserModel> validador, UserService usuarioService){
        _validator = validador?? throw new ArgumentNullException(nameof(validador));
        _usuarioService = usuarioService?? throw new ArgumentNullException(nameof(usuarioService));
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] UserModel usuario){
        var resultadoValidacao = _validator.Validate(usuario);
        if(!resultadoValidacao.IsValid){
            return BadRequest(resultadoValidacao.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }));
        }
            UserModel result = await _usuarioService.Add(usuario);
            return Ok(result);
    }

    [HttpGet("{cpf}")]
    public IActionResult Get(string cpf){
        if(string.IsNullOrEmpty(cpf)){
            return BadRequest("CPF é obrigatório.");
        }
        else if(cpf.Length != 11){
            return BadRequest("CPF inválido.");
        }

        var usuario = _usuarioService.FindByCpf(cpf);
        return Ok(usuario);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(){
        List<UserModel> userList = await _usuarioService.FindAll(); 
        return Ok(userList);
    }

    [HttpPut("{cpf}")]
    public async Task<IActionResult> Update(string cpf, [FromBody] UserModel usuario){
        var resultadoValidacao = _validator.Validate(usuario);

        if (cpf != usuario.Cpf){
        return BadRequest("O CPF da URL deve ser o mesmo do corpo da requisição.");
        }
        if (!resultadoValidacao.IsValid){
            return BadRequest("informações inválidas");
        }

        UserModel updatedUser = await _usuarioService.Update(cpf, usuario);
        return Ok(updatedUser);
    }

    [HttpDelete("{cpf}")]
    public async Task<IActionResult> Delete(string cpf){
        if (cpf.Length != 11){
            return BadRequest("Cpf inválido");
        }

        UserModel deletedUser = await _usuarioService.Delete(cpf);
        return Ok(deletedUser);
    }
}