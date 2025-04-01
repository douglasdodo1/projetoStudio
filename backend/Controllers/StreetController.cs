using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("Street")]
public class StreetController : ControllerBase{

    private readonly StreetService _streetService;

    public StreetController(StreetService streetService){
        _streetService = streetService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] StreetModel street){
        if (street == null){
            return BadRequest("Rua não fornecida");
        }

        StreetModel streetReturned = await _streetService.Add(street);
        return Ok(streetReturned);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id){
        if (id <= 0){
            return BadRequest("ID inválido");
        }
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
        if (id <= 0) {
            return BadRequest("ID inválido");
        }
        else if (streetToUpdate == null){
            return BadRequest("Rua não fornecida");
        }


        StreetModel updatedStreet = await _streetService.Update(id, streetToUpdate);
        return Ok(updatedStreet);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id){
        if (id <= 0) {
            return BadRequest("ID inválido");
        }

        StreetModel deletedStreet = await _streetService.Delete(id);
        return Ok(deletedStreet);
    }
}