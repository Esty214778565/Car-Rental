using CarRental.servises;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        static CarServise carServise = new CarServise();
        // GET: api/<CarController>
        [HttpGet]
        public ActionResult<List<Car>> Get()
        {
            List<Car> result = carServise.getCars();
            return result == null ? NotFound() : result;
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public ActionResult<Car> Get(int id)
        {
            Car result = carServise.GetCarById(id);
            return result == null ? NotFound() : result;
        }

        // POST api/<CarController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Car car)
        {
            return !carServise.PostCar(car) ? NotFound() : Ok(true);
        }

        // PUT api/<CarController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Car car)
        {
            return !carServise.PutCar(id, car) ? NotFound() : Ok(true);
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return !carServise.DeleteCar(id) ? NotFound() : Ok(true);
        }


    }
}
