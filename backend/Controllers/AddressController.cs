using FluentValidation;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("Adress")]
public class AddressController :ControllerBase{

    private AdressService _adressService;
    private readonly IValidator<AddressModel> _validator;
    public  AddressController(AdressService adressService, IValidator<AddressModel> validator){
        _adressService = adressService;
        _validator = validator;
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] AddressModel adress){
        var validationResult =  _validator.Validate(adress);
        if (!validationResult.IsValid){
            return BadRequest(validationResult.Errors.Select(e => new {e.PropertyName, e.ErrorMessage}));
        }
        
        return Ok(validationResult.Errors);
    }
}