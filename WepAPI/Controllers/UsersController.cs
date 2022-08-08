using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAllUser();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("add")]
        public IActionResult Add(User user)
        {
            var result = _userService.AddUser(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("delete")]
        public IActionResult Delete(User user)
        {
            var result = _userService.DeleteUser(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("update")]
        public IActionResult Update(User user)
        {
            var result = _userService.UpdateUser(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("getclaimdetail")]
        public IActionResult Get(User user)
        {
            var result = _userService.GetClaims(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
