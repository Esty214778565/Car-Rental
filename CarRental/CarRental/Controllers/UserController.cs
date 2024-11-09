using CarRental.Entity;
using CarRental.servises;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        static readonly UserServise userServise = new UserServise();
        // GET: api/<UserController>
        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            return userServise.getUsers();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult<User> GetById(int id)
        {
            if (id < 0)
                return BadRequest();
            User result = userServise.GetUserById(id);
            return result == null ? NotFound() : result;
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] User user)
        {
            
            return !userServise.Add(user)?BadRequest():true;
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] User user)
        {
            return !userServise.Update(id, user) ? NotFound() : true;
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return !userServise.DeleteUser(id) ? NotFound() :true;
        }


    }
}
