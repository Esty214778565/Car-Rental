using AutoMapper;
using CarRental.api.Models;
using CarRental.Core.DTOs;
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
        readonly IMapper _mapper;
        public UserController(IUserService userService,IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        // GET: api/<UserController>
        [HttpGet]
        public ActionResult<List<UserDto>> Get()
        {
            return _userService.GetUserList();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult<UserDto> GetById(int id)
        {
            if (id < 0)
                return BadRequest();
            var result = _userService.GetUserById(id);     
            return result == null ? NotFound() : result;
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] UserPostModel user)
        {
            ;
            var res=_userService.Add(_mapper.Map<UserDto>(user));
            if(!res)
                return BadRequest();
            return true;
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put([FromBody] UserPostModel user)
        {
            return !_userService.Update(_mapper.Map<UserDto>(user)) ? NotFound() : true;
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return !_userService.Delete(id) ? NotFound() : true;
        }
    }
}
