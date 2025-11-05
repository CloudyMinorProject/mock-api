//using System.Reflection.PortableExecutable;
using Microsoft.AspNetCore.Mvc;
using MockApi.Models;
using MockApi.Services;

namespace MockApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MachinesController : ControllerBase {
  private readonly DataService _dataService;

  public MachinesController(DataService dataService) {
    _dataService = dataService;
  }

  // GET: api/Machines
  [HttpGet("GetAll")]
  public ActionResult<IEnumerable<Machine>> GetAllMachines() {
    return Ok(_dataService.Machines);
  }
}
