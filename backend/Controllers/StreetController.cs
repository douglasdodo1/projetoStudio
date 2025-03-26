using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("street")]
public class StreetController : ControllerBase{

    private readonly StreetService _streetService;

    public StreetController(StreetService streetService){
        _streetService = streetService;
    }
    
    [HttpPost("add")]
    public async Task<IActionResult> add([FromBody] StreetModel street){
        if (street == null){
            return BadRequest("Rua não fornecida");
        }

        StreetModel streetReturned = await _streetService.AddStreet(street);
        return Ok(streetReturned);
    }

    [HttpPost("get/{id}")]
    public async Task<IActionResult> get(int id){
        if (id <= 0){
            return BadRequest("ID inválido");
        }
        StreetModel street = await _streetService.FindStreetById(id);
        return Ok(street);
    }

    [HttpPut("put/{id}")]
    public async Task<IActionResult> put(int id, [FromBody] StreetModel streetToUpdate){
        if (id <= 0) {
            return BadRequest("ID inválido");
        }
        else if (streetToUpdate == null){
            return BadRequest("Rua não fornecida");
        }


        StreetModel updatedStreet = await _streetService.UpdateStreet(id, streetToUpdate);
        return Ok(updatedStreet);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> delete(int id){
        if (id <= 0) {
            return BadRequest("ID inválido");
        }

        StreetModel deletedStreet = await _streetService.DeleteStreet(id);
        return Ok(deletedStreet);
    }
}