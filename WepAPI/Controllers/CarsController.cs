using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carservice;

        public CarsController(ICarService carservice)
        {
            _carservice = carservice;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carservice.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carservice.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carservice.Delete(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carservice.Update(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("getbybrandıd")]
        public IActionResult GetByBrandId(int id)
        {
            var result = _carservice.GetCarsByBrandId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("getbycolorıd")]
        public IActionResult GetByColorId(int id)
        {
            var result = _carservice.GetCarsByColorId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("getcardetail")]
        public IActionResult GetCarDetail()
        {
            var result = _carservice.GetCarDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
