using CarRental.Core.Entities;
using CarRental.Core.IService;
using Microsoft.AspNetCore.Mvc;
using CarRental.Service;
using CarRental.Data.Repository;
using CarRental.Core.IRepository;
using CarRental.api.Controllers;
using CarRental.Core.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRental.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionPointController : ControllerBase
    {
        readonly ICollectionPointService _collectionPointService;

        public CollectionPointController(ICollectionPointService collectionPointService)
        {
            _collectionPointService = collectionPointService;
        }

        // GET: api/<CollectionPointController>
        [HttpGet]
        public ActionResult<List<CollectionPointDto>> Get()
        {
            return _collectionPointService.GetCollectionPointList();
        }

        // GET api/<CollectionPointController>/5
        [HttpGet("{id}")]
        public ActionResult<CollectionPointDto> GetById(int id)
        {
            if (id < 0)
                return BadRequest();
            var result = _collectionPointService.GetCollectionPointById(id);
            return result == null ? NotFound() : result;
        }

        // POST api/<CollectionPointController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] CollectionPointEntity CollectionPoint)
        {
            return _collectionPointService.Add(CollectionPoint);
        }

        // PUT api/<CollectionPointController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put([FromBody] CollectionPointEntity CollectionPoint)
        {
            return !_collectionPointService.Update(CollectionPoint) ? NotFound() : true;
        }

        // DELETE api/<CollectionPointController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return !_collectionPointService.Delete(id) ? NotFound() : true;
        }
    }
}
