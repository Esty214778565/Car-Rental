using CarRental.Core.Entities;
using CarRental.Core.IService;
using CarRental.Data.Repository;
using CarRental.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRental.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public ActionResult<List<UserEntity>> Get()
        {
            return _userService.GetUserList();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult<UserEntity> GetById(int id)
        {
            if (id < 0)
                return BadRequest();
            UserEntity result = _userService.GetUserById(id);     
            return result == null ? NotFound() : result;
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] UserEntity user)
        {
            var res=_userService.Add(user);
            if(!res)
                return BadRequest();
            return true;
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put([FromBody] UserEntity user)
        {
            return !_userService.Update(user) ? NotFound() : true;
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return !_userService.Delete(id) ? NotFound() : true;
        }
    }
}
