using CarRental.servises;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionPointController : ControllerBase
    {
        static CollectionPointServise collectionPointServise = new CollectionPointServise();
        // GET: api/<CollectionPointController>
        [HttpGet]
        public ActionResult<List<CollectionPoint>> Get()
        {
            List<CollectionPoint> result = collectionPointServise.getCollectionPoints();
            return result == null ? NotFound() : result;
        }

        // GET api/<CollectionPointController>/5
        [HttpGet("{id}")]
        public ActionResult<CollectionPoint> Get(int id)
        {
            CollectionPoint result = collectionPointServise.GetCollectionPointById(id);
            return result == null ? NotFound() : result;
        }

        // POST api/<CollectionPointController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] CollectionPoint collectionPoint)
        {
            return !collectionPointServise.PostCollectionPoint(collectionPoint) ? NotFound() : Ok(true);
        }

        // PUT api/<CollectionPointController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] CollectionPoint collectionPoint)
        {
            return !collectionPointServise.PutCollectionPoint(id, collectionPoint) ? NotFound() : Ok(true);
        }

        // DELETE api/<CollectionPointController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return !collectionPointServise.DeleteCollectionPoint(id) ? NotFound() : Ok(true);
        }
    }
}
