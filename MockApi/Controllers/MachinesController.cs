using System.Reflection.PortableExecutable;
using Microsoft.AspNetCore.Mvc;

namespace MockApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MachinesController : ControllerBase
{
    private List<Machine> machinesArray = new List<Machine>();



    [HttpGet(Name = "GetMachines")]
    public List<Machine> GetMachines()
    {
        //Add info from database
        return machinesArray;

    }
}
