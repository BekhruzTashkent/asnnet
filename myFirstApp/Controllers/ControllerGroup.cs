using Microsoft.AspNetCore.Mvc;
using myFirstApp.Data;
using myFirstApp.Models;

namespace myFirstApp.Controllers;
[Route("api/v1/groups/")]
[ApiController]


public class ControllerGroup : Controller
{
    
    private readonly ApplicationDbContext _context;
    
    public ControllerGroup(ApplicationDbContext context)
    {
        _context = context;  // _context is assigned the injected DbContext instance.
    }
    
    [HttpGet("all")]
    public IActionResult Index()
    {
        var groups = _context.Groups.ToList();
        return Ok(groups);
    }
    
    
    [HttpPost("add")]
    public IActionResult AddGroup([FromBody] Group group)
    {
        if (group == null)
        {
            return BadRequest("Group data is required and cannot be null.");
        }

        // Proceed with your database operations
        _context.Groups.Add(group);
        _context.SaveChanges();
        return CreatedAtAction(nameof(Index), new { id = group.Id }, group);
    }
    
}