using Interface.Common;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Models.Models;
using Services.IServices;
using Services.Services;

namespace Interface.Controllers
{
    [Route("interface/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService service, ILogger<UserController> logger)
        {
            _service = service;
            _logger = logger;
        }


        [HttpGet("GetUsers")]
        public ActionResult<List<UserDTO>> GetUsers()
        {
            try
            {
                var response = _service.GetUsers();
                if(response.Count == 0)
                {
                    NotFound("Usuario inexistente");
                }

                return Ok(response);
            }
            catch (Exception ex)
            {

                _logger.LogCustomError("GetUsers", ex);
                return BadRequest($"{ex.Message}");
            }
        }
    }
}
