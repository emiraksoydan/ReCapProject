using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _icarservice;

        public CarImagesController(ICarImageService icarservice)
        {
            this._icarservice = icarservice;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _icarservice.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("getallimagesbycarid")]
        public IActionResult GetAllImagesByCarId(int id)
        {
            var result = _icarservice.GetByCarId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("getimagebyimageid")]
        public IActionResult GetImageByImageId(int id)
        {
            var result = _icarservice.GetByImageId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("Add")]
        public IActionResult Add(CarImage carimage)
        {
            var result = _icarservice.Add(carimage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("Delete")]
        public IActionResult Delete(CarImage carimage)
        {
            var result = _icarservice.Delete(carimage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("Update")]
        public IActionResult Update(CarImage carimage)
        {
            var result = _icarservice.Update(carimage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
