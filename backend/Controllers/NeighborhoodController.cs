using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("neighborhood")]
public class NeighborhoodController : ControllerBase{
    private readonly NeighborhoodService _neighborHoodService;

    public NeighborhoodController(NeighborhoodService neighborhoodService){
        _neighborHoodService = neighborhoodService;
    }

    [HttpPost("add")]
    public async Task<IActionResult> Post([FromBody] NeighborhoodModel neighborhood){
        if (neighborhood == null){
            return BadRequest("neighborhood não fornecida");
        }

        NeighborhoodModel neighborhoodReturned = await _neighborHoodService.AddNeighborhood(neighborhood);
        return Ok(neighborhoodReturned);
    }

    [HttpGet("get/{id}")]
    public async Task<IActionResult> Get(int id){
        if (id <= 0){
            return BadRequest("id inválido");
        }

        NeighborhoodModel neighborhood = await _neighborHoodService.GetNeighborhoodById(id);
        return Ok(neighborhood);
    }

    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll(){
        List<NeighborhoodModel> neighborhoods = await _neighborHoodService.GetAllNeighborhood();
        return Ok(neighborhoods);
    }

    [HttpPut("put/{id}")]
    public async Task<IActionResult> put(int id, [FromBody] NeighborhoodModel neighborhood){
        if (id  <= 0 ){
            return BadRequest("id inválido ou não fornecido");
        }
        else if (neighborhood == null){
            return BadRequest("neighborhood não fornecida");
        }

        NeighborhoodModel updatedNeighborhood = await _neighborHoodService.UpdateNeighborhood(id, neighborhood);
        return Ok(updatedNeighborhood);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> delete(int id){
        if (id  <= 0 ){
            return BadRequest("id inválido ou não fornecido");
        }

        NeighborhoodModel deletedNeighborhood = await _neighborHoodService.DeleteNeighborhood(id);
        return Ok(deletedNeighborhood);
    }
}