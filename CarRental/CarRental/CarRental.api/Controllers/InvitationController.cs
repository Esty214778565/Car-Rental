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
    public class InvitationController : ControllerBase
    {
        readonly IInvitationService _invitationService;
        readonly IMapper _mapper;

        public InvitationController(IInvitationService invitationService,IMapper mapper)
        {
            _invitationService = invitationService;
            _mapper = mapper;
        }


        // GET: api/<InvitationController>
        [HttpGet]
        public ActionResult<List<InvitationDto>> Get()
        {
            return _invitationService.GetInvitationList();
        }

        // GET api/<InvitationController>/5
        [HttpGet("{id}")]
        public ActionResult<InvitationDto> GetById(int id)
        {
            if (id < 0)
                return BadRequest();
            var result = _invitationService.GetInvitationById(id);
            return result == null ? NotFound() : result;
        }

        // POST api/<InvitationController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] InvitationPostModel Invitation)
        {
            return _invitationService.Add(_mapper.Map<InvitationDto>(Invitation));
        }

        // PUT api/<InvitationController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put([FromBody] InvitationPostModel Invitation)
        {
            return !_invitationService.Update(_mapper.Map<InvitationDto>(Invitation)) ? NotFound() : true;
        }

        // DELETE api/<InvitationController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return !_invitationService.Delete(id) ? NotFound() : true;
        }
    }
}
