using CarRental.Entity;
using CarRental.servises;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
         readonly CarServise CarServise=new CarServise();
        // GET: api/<CarController>
        [HttpGet]
        public ActionResult<List<Car>> Get()
        {
          return CarServise.getCars();
            //List<Car> result = carServise.getCars();
            //return result == null ? NotFound() : result;
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public ActionResult<Car> GetById(int id)
        {
            if (id < 0)
                return BadRequest();
            Car result =CarServise.GetCarById(id);
            return result == null ? NotFound() : result;
        }

        // POST api/<CarController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Car car)
        {
            return CarServise.Add(car);
        }

        // PUT api/<CarController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Car car)
        {
            
            return !CarServise.Update(id, car) ? NotFound() : true;
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return !CarServise.DeleteCar(id) ? NotFound() : true;
        }


    }
}
