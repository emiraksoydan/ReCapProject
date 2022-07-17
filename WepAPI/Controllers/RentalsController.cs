using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalservice;

        public RentalsController(IRentalService rentalservice)
        {
            _rentalservice = rentalservice;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _rentalservice.GetAllRental();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("add")]
        public IActionResult Add(Rental rental)
        {
            var result = _rentalservice.AddRental(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("delete")]
        public IActionResult Delete(Rental rental)
        {
            var result = _rentalservice.DeleteRental(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("update")]
        public IActionResult Update(Rental rental)
        {
            var result = _rentalservice.UpdateRental(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("getrentaldetail")]
        public IActionResult GetRentalDetail()
        {
            var result = _rentalservice.GetRentalDetail();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
