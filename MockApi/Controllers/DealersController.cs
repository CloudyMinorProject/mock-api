using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MockApi.Models;
using MockApi.Services;

namespace MockApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DealersController : ControllerBase
{
    private readonly DealerService _service;

    public DealersController(DealerService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Dealer>> GetAll()
    {
        return Ok(_service.GetAll());
    }

    [HttpGet("{id:int}")]
    public ActionResult<Dealer> GetById(int id)
    {
        var dealer = _service.GetById(id);
        if (dealer == null) return NotFound();
        return Ok(dealer);
    }

    [HttpPost]
    public ActionResult<Dealer> Create([FromBody] Dealer input)
    {
        if (input == null) return BadRequest();

        var created = _service.Create(input);
        return CreatedAtAction(nameof(GetById), new { id = created.DealerID }, created);
    }

    [HttpPut("{id:int}")]
    public ActionResult Update(int id, [FromBody] Dealer input)
    {
        if (input == null || id != input.DealerID) return BadRequest();

        var ok = _service.Update(id, input);
        if (!ok) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var ok = _service.Delete(id);
        if (!ok) return NotFound();
        return NoContent();
    }
}
