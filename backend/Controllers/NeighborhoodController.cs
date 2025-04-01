using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("Neighborhood")]
public class NeighborhoodController : ControllerBase{
    private readonly NeighborhoodService _neighborHoodService;

    public NeighborhoodController(NeighborhoodService neighborhoodService){
        _neighborHoodService = neighborhoodService;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] NeighborhoodModel neighborhood){
        if (neighborhood == null){
            return BadRequest("neighborhood não fornecida");
        }

        NeighborhoodModel neighborhoodReturned = await _neighborHoodService.Add(neighborhood);
        return Created(nameof(Add),neighborhoodReturned);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id){
        if (id <= 0){
            return BadRequest("id inválido");
        }

        NeighborhoodModel neighborhood = await _neighborHoodService.FindById(id);
        return Ok(neighborhood);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(){
        List<NeighborhoodModel> neighborhoods = await _neighborHoodService.FindAll();
        return Ok(neighborhoods);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> put(int id, [FromBody] NeighborhoodModel neighborhood){
        if (id  <= 0 ){
            return BadRequest("id inválido ou não fornecido");
        }
        else if (neighborhood == null){
            return BadRequest("neighborhood não fornecida");
        }

        NeighborhoodModel updatedNeighborhood = await _neighborHoodService.Update(id, neighborhood);
        return Ok(updatedNeighborhood);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> delete(int id){
        if (id  <= 0 ){
            return BadRequest("id inválido ou não fornecido");
        }

        NeighborhoodModel deletedNeighborhood = await _neighborHoodService.Delete(id);
        return Ok(deletedNeighborhood);
    }
}