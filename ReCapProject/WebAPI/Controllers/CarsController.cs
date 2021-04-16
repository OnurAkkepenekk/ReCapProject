using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        //Get
        [HttpGet("GetAll")]
        public IActionResult GetAll()
         {
            var result = _carService.GetAll();
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet("GetByBrandId")]
        public IActionResult GetByBrandId(int brandId)
        {
            var result = _carService.GetAllByBrandId(brandId);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
        [HttpGet("GetByColorId")]
        public IActionResult GetByColorId(int colorId)
        {
            var result = _carService.GetAllByColorId(colorId);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet("GetCarDetail")]
        public IActionResult GetCarDetail()
        {
            var result = _carService.GetCarDetailDtos();
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
        [HttpGet("GetCarDetailsByColorAndBrand")]
        public IActionResult GetCarDetailsByColorAndBrand(int brandId,int colorId)
        {
            var result = _carService.GetCarDetailsByColorAndBrand(brandId,colorId);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet("GetCarDetailsByCarId")]
        public IActionResult GetCarDetailsByCarId(int carId)
        {
            var result = _carService.GetCarDetailsByCarId(carId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getAllWithDetail")]
        public IActionResult GetAllWithDetail()
        {
            var result = _carService.GetAllWithDetail();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        //Post
        [HttpPost("Add")]
        public IActionResult Add(Car car)
        {

            var result = _carService.Add(car);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Car car)
        {

            var result = _carService.Delete(car);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(Car car)
        {

            var result = _carService.Update(car);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
