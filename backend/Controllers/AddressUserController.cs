using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

[Controller]
[Route("AddressUser")]
public class AddressUserController : ControllerBase{
    private readonly AddressUserService _addressUserService;

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddressUserModel addressUser){
        if (addressUser == null){
            return BadRequest("endereço de usuario invalido");
        }
        
        AddressUserModel newAddressUser = await _addressUserService.Add(addressUser);
        return Ok(newAddressUser);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id){
        if (id <= 0){
            return BadRequest("Id inválido");
        }

        AddressUserModel addressUser = await _addressUserService.FindById(id);
        return Ok(addressUser);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(){
        List<AddressUserModel> addressUserList = await _addressUserService.FindAll();
        return Ok(addressUserList);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] AddressUserModel addressUser){
        if (id <= 0){
            return BadRequest($"Id:{id} inválido");
        } else if (addressUser.AdressId <= 0){
            return BadRequest($"O id do endereço: '{addressUser.AdressId}' é inválido");
        }else if(string.IsNullOrWhiteSpace(addressUser.Cpf) ){
            return BadRequest($"cpf:'{addressUser.Cpf}' é inválido");
        }

        AddressUserModel newAddressUser = await _addressUserService.Updated(id, addressUser);
        return Ok(newAddressUser);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id){
        if(id <= 0){
            return BadRequest($"ID:{id} inválido");
        }
        AddressUserModel addressUserDeleted = await _addressUserService.Remove(id);
        return Ok(addressUserDeleted);
    }
}