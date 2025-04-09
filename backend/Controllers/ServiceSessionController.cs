using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
[Controller]
[Route("ServiceSession")]
public class ServiceSessionController : ControllerBase {
    readonly ServiceSessionService _serviceSessionService;
    public ServiceSessionController(ServiceSessionService serviceSessionService) {
        _serviceSessionService = serviceSessionService;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] ServiceSessionModel serviceSession) {
        if (serviceSession == null) {
            return BadRequest("body está vázio");
        }

        ServiceSessionModel AddedServiceSession = await _serviceSessionService.Add(serviceSession);
        return Created(nameof(Add), AddedServiceSession);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) {
        ServiceSessionModel serviceSession = await _serviceSessionService.FindById(id);
        return Ok(serviceSession);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() {
        List<ServiceSessionModel> serviceSessionList = await _serviceSessionService.FindAll();
        return Ok(serviceSessionList);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ServiceSessionModel serviceSessionToUpdate) {
        if (serviceSessionToUpdate == null) {
            return BadRequest("body está vazio");
        }
        ServiceSessionModel updatedServiceSession = await _serviceSessionService.Update(id, serviceSessionToUpdate);
        return Ok(updatedServiceSession);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) {
        ServiceSessionModel serviceSessionDeleted = await _serviceSessionService.Delete(id);
        return Ok(serviceSessionDeleted);
    }
}