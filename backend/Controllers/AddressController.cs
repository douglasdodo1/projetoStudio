using FluentValidation;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("Address")]
public class AddressController :ControllerBase{

    private AddressService _addressService;
    private readonly IValidator<AddressModel> _validator;
    public  AddressController(AddressService adressService, IValidator<AddressModel> validator){
        _addressService = adressService;
        _validator = validator;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddressModel newAdress){
        var validationResult =  _validator.Validate(newAdress);
        if (!validationResult.IsValid){
            return BadRequest(validationResult.Errors.Select(e => new {e.PropertyName, e.ErrorMessage}));
        }
        
        AddressModel createdAddress = await _addressService.AddAddress(newAdress);
        return Created(nameof(Add), createdAddress);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id){
        if (id <= 0){
            return BadRequest("Id inválido");
        }

        AddressModel address = await _addressService.FindAddressById(id);
        return Ok(address);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(){
        List<AddressModel> addressList = await _addressService.FindAllAddress();
        return Ok(addressList);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] AddressModel addressToUpdate){
        if (id <= 0){
            return BadRequest("id inválido");
        }else if (addressToUpdate == null){
            return BadRequest("alterações vazias");
        }

        AddressModel updatedAddress = await _addressService.UpdateAddress(id, addressToUpdate);
        return Ok(updatedAddress);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id){
        if (id <= 0){
            return BadRequest("id inválido");
        }

        AddressModel deletedAddress = await _addressService.DeleteAddress(id);
        return Ok(deletedAddress);
    }
}