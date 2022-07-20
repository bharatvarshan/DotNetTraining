using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPIApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserDBContext _context;


        public UserController(UserDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("[Action]")]
        public async Task<ActionResult<List<User>>> Index()
        {
            List<User> users = new List<User>();

            return Ok(_context.Users.ToList<User>().ToList<User>());
        }

        [HttpPost]
        [Route("[Action]")]
        public async Task<ActionResult<Object>> Create(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(user);
                    await _context.SaveChangesAsync();
                    return Ok(new { msg = "Success" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return BadRequest(new { msg = "Something went wrong" });
        }


        [HttpGet]
        [Route("[Action]/{id}")]
        public async Task<ActionResult<Object>> GetUser(int id)
        {
            if (id == null || _context?.Users == null)
                return BadRequest(new { msg = "Id should not be null" });

            var user = await _context.Users.FindAsync(id);

            if (user == null)
                return NotFound(new { msg = $"User not found with id {id}" });

            return Ok(user);
        }
    }



}