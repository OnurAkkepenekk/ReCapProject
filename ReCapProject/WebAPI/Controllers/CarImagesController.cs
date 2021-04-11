using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageService.Add(file, carImage);
            carImage.Date = DateTime.Now;
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete([FromForm(Name = "Id")] int Id)
        {
            var carImage = _carImageService.Get(Id).Data;

            var result = _carImageService.Delete(carImage);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromForm(Name = ("Image"))] IFormFile file, [FromForm(Name = ("CarId"))] int CarId)
        {
            var result = _carImageService.Update(file, _carImageService.GetById(CarId).Data);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
        [HttpGet("GetImagesByCarId")]
        public IActionResult GetImagesByCarId( int carId)
        {
            var result = _carImageService.GetImagesByCarId(carId);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
