using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MockApi.Models;
using MockApi.Services;

namespace MockApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomersController : ControllerBase
{
    private readonly CustomerService _service;

    public CustomersController(CustomerService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Customer>> GetAll()
    {
        return Ok(_service.GetAll());
    }

    [HttpGet("{id:int}")]
    public ActionResult<Customer> GetById(int id)
    {
        var customer = _service.GetById(id);
        if (customer == null) return NotFound();
        return Ok(customer);
    }

    [HttpPost]
    public ActionResult<Customer> Create([FromBody] Customer input)
    {
        if (input == null) return BadRequest();

        var created = _service.Create(input);
        return CreatedAtAction(nameof(GetById), new { id = created.CustomerID }, created);
    }

    [HttpPut("{id:int}")]
    public ActionResult Update(int id, [FromBody] Customer input)
    {
        if (input == null || id != input.CustomerID) return BadRequest();

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
