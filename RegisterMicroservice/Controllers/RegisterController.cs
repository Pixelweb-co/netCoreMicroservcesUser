using Microsoft.AspNetCore.Mvc;
using RegisterMicroservice.Models;
using RegisterMicroservice.Services;

namespace RegisterMicroservice.Controllers
{
    [ApiController]
    [Route("api/registro")]
    public class RegisterController : ControllerBase
    {

        public UserRegisterMicroservice _RegisterService;

        public RegisterController(UserRegisterMicroservice RegisterService) => _RegisterService = RegisterService;

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            await _RegisterService.CreateUser(user);
            return Ok();
        }


    }
}
