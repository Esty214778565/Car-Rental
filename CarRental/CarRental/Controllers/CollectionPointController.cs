using CarRental.Entity;
using CarRental.servises;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionPointController : ControllerBase
    {
         readonly CollectionPointServise collectionPointServise = new CollectionPointServise();
        // GET: api/<CollectionPointController>
        [HttpGet]
        public ActionResult<List<CollectionPoint>> Get()
        {
            return collectionPointServise.getCollectionPoints();
        }

        // GET api/<CollectionPointController>/5
        [HttpGet("{id}")]
        public ActionResult<CollectionPoint> GetById(int id)
        {
            if (id < 0)
                return BadRequest();
            CollectionPoint result = collectionPointServise.GetCollectionPointById(id);
            return result == null ? NotFound() : result;
        }

        // POST api/<CollectionPointController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] CollectionPoint collectionPoint)
        {
            return collectionPointServise.Add(collectionPoint);
        }

        // PUT api/<CollectionPointController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] CollectionPoint collectionPoint)
        {
            return !collectionPointServise.Update(id, collectionPoint) ? NotFound() : true;
        }

        // DELETE api/<CollectionPointController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return !collectionPointServise.DeleteCollectionPoint(id) ? NotFound() : true;
        }
    }
}
