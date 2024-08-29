using DatingApp.WebAPI.Data;
using DatingApp.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")] 
public class UsersController(DataContext context) : ControllerBase
{

[HttpGet]
public async Task<ActionResult<IEnumerable<User>>>GetUsers()
{
    var users=await context.Users.ToListAsync();
    return users;
}
[HttpGet("{id}")]
public async Task <ActionResult<User>>GetUsers(int id)
{
    var user=await context.Users.FindAsync(id);
    if(user==null) return NotFound();
    return user;
}
}
