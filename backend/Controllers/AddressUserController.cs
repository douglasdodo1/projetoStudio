using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

[Authorize]
[Controller]
[Route("AddressUser")]
public class AddressUserController : ControllerBase {
    private readonly AddressUserService _addressUserService;

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddressUserModel newAddressUser) {
        if (newAddressUser == null) {
            return BadRequest("endereço de usuario invalido");
        }

        AddressUserModel createdAddressUser = await _addressUserService.Add(newAddressUser);
        return Created(nameof(Add), createdAddressUser);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) {
        AddressUserModel addressUser = await _addressUserService.FindById(id);
        return Ok(addressUser);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() {
        List<AddressUserModel> addressUserList = await _addressUserService.FindAll();
        return Ok(addressUserList);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] AddressUserModel addressUser) {
        if (string.IsNullOrWhiteSpace(addressUser.Cpf)) {
            return BadRequest($"cpf:'{addressUser.Cpf}' é inválido");
        }
        AddressUserModel newAddressUser = await _addressUserService.Updated(id, addressUser);
        return Ok(newAddressUser);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) {
        AddressUserModel addressUserDeleted = await _addressUserService.Remove(id);
        return Ok(addressUserDeleted);
    }
}