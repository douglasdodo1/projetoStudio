using FluentValidation;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("user")]
public class UsuarioController : ControllerBase {

    private readonly IValidator<UserModel> _validator;
    private  UserService _usuarioService;

    public UsuarioController (IValidator<UserModel> validador, UserService usuarioService){
        _validator = validador?? throw new ArgumentNullException(nameof(validador));
        _usuarioService = usuarioService?? throw new ArgumentNullException(nameof(usuarioService));
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] UserModel usuario){
        var resultadoValidacao = _validator.Validate(usuario);
        if(!resultadoValidacao.IsValid){
            return BadRequest(resultadoValidacao.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }));
        }
            UserModel result = await _usuarioService.addUser(usuario);
            return Ok(result);
    }

    [HttpGet("get/{cpf}")]
    public IActionResult Get(string cpf){
        if(string.IsNullOrEmpty(cpf)){
            return BadRequest("CPF é obrigatório.");
        }
        else if(cpf.Length != 11){
            return BadRequest("CPF inválido.");
        }

        var usuario = _usuarioService.findUserByCpf(cpf);
        return Ok(usuario);
    }

    [HttpPut("address/{cpf}")]
    public async Task<IActionResult> Update(string cpf, [FromBody] UserModel usuario){
        var resultadoValidacao = _validator.Validate(usuario);

        if (cpf != usuario.Cpf){
        return BadRequest("O CPF da URL deve ser o mesmo do corpo da requisição.");
        }
        if (!resultadoValidacao.IsValid){
            return BadRequest("informações inválidas");
        }

        UserModel updatedUser = await _usuarioService.updateUser(cpf, usuario);
        return Ok(updatedUser);
    }

    [HttpDelete("delete/{cpf}")]
    public async Task<IActionResult> Delete(string cpf){
        if (cpf.Length != 11){
            return BadRequest("Cpf inválido");
        }

        UserModel deletedUser = await _usuarioService.deleteUser(cpf);
        return Ok(deletedUser);
    }
}