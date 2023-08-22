using MediCareLibrary.Data;
using MediCareLibrary.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MediCareAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IDatabaseData _db;
        private readonly ILogger<UserController> _log;

        public UserController(IDatabaseData db,ILogger<UserController> log)
        {
            _db = db;
            _log = log;
        }

        [HttpGet]
        public List<FullUserModel> GetAllUsers()
        {
            return _db.GetUsers();
        }

        [HttpGet("{id}")]
        public FullUserModel GetUser(int id)
        {
            return _db.GetUserById(id);
        }



        [HttpPost]
        [Route("Register")]
        public IActionResult RegisterUser([FromBody] FullUserModel user)
        {
            if (user == null)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                _db.CreateUser(user);
                _log.LogInformation("User Added Successfully");
                return Ok(new { message = "User registered successfully." });
            }
            catch (Exception ex)
            {
                _log.LogError($"Error while registering user: {ex.Message}");
                return StatusCode(500, new { message = "An error occurred while registering the user." });
            }
        }

        [HttpPost]
        [Route("LogIn")]
        public IActionResult LoginUser([FromBody] FullUserModel user)
        {
            if (user.Email == null || user.Password == null)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                _db.LoginUser(user);
                _log.LogInformation($"{user.Email} Login Successfully");
                return Ok(new { message = $"{user.Email} Login successfully." });
            }
            catch (Exception ex)
            {
                _log.LogError($"Error while logging in user: {ex.Message}");
                return StatusCode(500, new { message = $"An error occurred while logging in the user.{ex.Message}" });
            }
        }



    }
}
