using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var usertologin = _authService.Login(userForLoginDto);
            if (!usertologin.Success)
            {
                return BadRequest(usertologin.Message);
            }
            var result = _authService.CreateAccesToken(usertologin.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userexists = _authService.userExists(userForRegisterDto.Email);
            if (!userexists.Success)
            {
                return BadRequest(userexists.Message);
            }
            var registeresult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccesToken(registeresult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}
