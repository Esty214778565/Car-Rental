using AutoMapper;
using CarRental.api.Models;
using CarRental.Core.DTOs;
using CarRental.Core.Entities;
using CarRental.Core.IService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRental.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        readonly ICarService _carService;
        readonly IMapper _mapper;


        public CarController(ICarService carService,IMapper mapper)
        {
            _carService = carService;
            _mapper = mapper;
        }

        // GET: api/<CarController>
        [HttpGet]
        public ActionResult<List<CarDto>> Get()
        {
            return _carService.GetCarList();
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public ActionResult<CarDto> GetById(int id)
        {
            if (id < 0)
                return BadRequest();
            var result = _carService.GetCarById(id);
            return result == null ? NotFound() : result;
        }

        // POST api/<CarController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] CarPostModel Car)
        {
            return _carService.Add(_mapper.Map<CarDto>(Car));
        }

        // PUT api/<CarController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put([FromBody] CarPostModel Car)
        {
            return !_carService.Update(_mapper.Map<CarDto>(Car)) ? NotFound() : true;
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return !_carService.Delete(id) ? NotFound() : true;
        }
    }
}
