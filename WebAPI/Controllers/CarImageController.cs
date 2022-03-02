using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImageController : ControllerBase
    {
        ICarImageService carImageService;

        public CarImageController(ICarImageService carImageService)
        {
            this.carImageService = carImageService;
        }
        [HttpPost("addImage")]
        public IActionResult Add([FromForm(Name ="Images")]IFormFile file, [FromForm] CarImage carImage)
        {
            var result = carImageService.Add(file,carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
