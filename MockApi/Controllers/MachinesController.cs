//using System.Reflection.PortableExecutable;
using Microsoft.AspNetCore.Mvc;
using MockApi.Models;

namespace MockApi.Controllers;

[ApiController]
[Route("[controller]")]
[ProducesResponseType(typeof(List<Machine>), StatusCodes.Status200OK)] 
public class MachinesController : ControllerBase
{
    private List<Machine> machinesList = new List<Machine>();



    [HttpGet(Name = "GetMachines")]
    public List<Machine> GetMachines()
    {
        Machine machineTest = new Machine();
        machineTest.MachineID = 1;
        machineTest.MachineName = "test machine";

        machinesList.Add(machineTest);
        

        //Add info from database
        return machinesList;

    }
}
