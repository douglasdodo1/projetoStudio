using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("User")]
public class UsuarioController : ControllerBase {

    
    private  UserService _userService;

    public UsuarioController (UserService usuarioService){
        _userService = usuarioService?? throw new ArgumentNullException(nameof(usuarioService));
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] UserModel newUser){
        if (newUser == null){
            return BadRequest("usúario vazio");
        }

        UserModel createdUser = await _userService.Add(newUser);
        return Created(nameof(Add),createdUser);
    }

    [HttpGet("{cpf}")]
    public async Task<IActionResult> Get(string cpf){
        

        var usuario = await _userService.FindByCpf(cpf);
        return Ok(usuario);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(){
        List<UserModel> userList = await _userService.FindAll();
        return Ok(userList);
    }

    [HttpPut("{cpf}")]
    public async Task<IActionResult> Update(string cpf, [FromBody] UserModel usuario){
        if (cpf != usuario.Cpf){
        return BadRequest("O CPF da URL deve ser o mesmo do corpo da requisição.");
        }
        

        UserModel updatedUser = await _userService.Update(cpf, usuario);
        return Ok(updatedUser);
    }

    [HttpDelete("{cpf}")]
    public async Task<IActionResult> Delete(string cpf){
        if (cpf.Length != 11){
            return BadRequest("Cpf inválido");
        }

        UserModel deletedUser = await _userService.Delete(cpf);
        return Ok(deletedUser);
    }
}