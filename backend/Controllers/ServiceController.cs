using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
[Controller]
[Route("Service")]
public class ServiceController : ControllerBase {
    private readonly ServiceService _serviceService;

    public ServiceController(ServiceService service) {
        _serviceService = service;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] ServiceModel service) {
        if (service.Name == null) {
            return BadRequest("nome inválido");
        }
        if (service.Value == null) {
            return BadRequest("valor inválido");
        }

        ServiceModel serviceAdded = await _serviceService.Add(service);

        return Created(nameof(Add), serviceAdded);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) {
        ServiceModel service = await _serviceService.FindById(id);
        return Ok(service);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() {
        List<ServiceModel> serviceList = await _serviceService.FindAll();
        return Ok(serviceList);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ServiceModel serviceToUpdate) {
        if (serviceToUpdate == null) {
            return BadRequest("Serviço não fornecido");
        }

        ServiceModel updatedService = await _serviceService.Update(id, serviceToUpdate);
        return Ok(updatedService);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) {
        ServiceModel deletedService = await _serviceService.Delete(id);
        return Ok(deletedService);
    }

}