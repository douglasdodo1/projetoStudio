using FluentValidation;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("Address")]
public class AddressController :ControllerBase{

    private AddressService _addressService;
    public  AddressController(AddressService adressService){
        _addressService = adressService;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddressModel newAdress){
        AddressModel createdAddress = await _addressService.AddAddress(newAdress);
        return Created(nameof(Add), createdAddress);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id){
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
        if (addressToUpdate == null){
            return BadRequest("alterações vazias");
        }

        AddressModel updatedAddress = await _addressService.UpdateAddress(id, addressToUpdate);
        return Ok(updatedAddress);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id){
        AddressModel deletedAddress = await _addressService.DeleteAddress(id);
        return Ok(deletedAddress);
    }
}