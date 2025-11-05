using Microsoft.AspNetCore.Mvc;
using MockApi.Models;
using MockApi.Services;

namespace MockApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MachinesController : ControllerBase {
  private readonly MachineService _machineService;

  public MachinesController(MachineService machineService) {
    _machineService = machineService;
  }

  // GET: api/machines
  [HttpGet]
  public ActionResult<IEnumerable<Machine>> GetAllMachines() {
    return Ok(_machineService.GetAllMachines());
  }

  // GET: api/machines/{id}
  [HttpGet("{id}")]
  public ActionResult<Machine> GetMachine(int id) {
    var machine = _machineService.GetMachineById(id);
    if (machine == null) {
      return NotFound();
    }
    return Ok(machine);
  }

  // POST: api/machines
  [HttpPost]
  public ActionResult<Machine> CreateMachine(Machine machine) {
    var createdMachine = _machineService.CreateMachine(machine);
    return CreatedAtAction(nameof(GetMachine), new { id = createdMachine.MachineID }, createdMachine);
  }

  // PUT: api/machines/{id}
  [HttpPut("{id}")]
  public ActionResult<Machine> UpdateMachine(int id, Machine machine) {
    var updatedMachine = _machineService.UpdateMachine(id, machine);
    if (updatedMachine == null) {
      return NotFound();
    }
    return Ok(updatedMachine);
  }

  // DELETE: api/machines/{id}
  [HttpDelete("{id}")]
  public ActionResult DeleteMachine(int id) {
    var result = _machineService.DeleteMachine(id);
    if (!result) {
      return NotFound();
    }
    return NoContent();
  }

  // GET: api/machines/active
  [HttpGet("active")]
  public ActionResult<IEnumerable<Machine>> GetActiveMachines() {
    return Ok(_machineService.GetActiveMachines());
  }

  // GET: api/machines/accesspoint/{accessPointId}
  [HttpGet("accesspoint/{accessPointId}")]
  public ActionResult<IEnumerable<Machine>> GetMachinesByAccessPoint(int accessPointId) {
    return Ok(_machineService.GetMachinesByAccessPoint(accessPointId));
  }
}
