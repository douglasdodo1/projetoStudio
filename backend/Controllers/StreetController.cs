using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("Street")]
public class StreetController : ControllerBase{

    private readonly StreetService _streetService;

    public StreetController(StreetService streetService){
        _streetService = streetService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] StreetModel newStreet){
        if (newStreet == null){
            return BadRequest("Rua não fornecida");
        }

        StreetModel createdStreet = await _streetService.Add(newStreet);
        return Created(nameof(Add),createdStreet);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id){
        StreetModel street = await _streetService.FindById(id);
        return Ok(street);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(){
        List<StreetModel> addressList = await _streetService.FindAll();
        return Ok(addressList);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] StreetModel streetToUpdate){
        if (streetToUpdate == null){
            return BadRequest("Rua não fornecida");
        }
        StreetModel updatedStreet = await _streetService.Update(id, streetToUpdate);
        return Ok(updatedStreet);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id){
        StreetModel deletedStreet = await _streetService.Delete(id);
        return Ok(deletedStreet);
    }
}