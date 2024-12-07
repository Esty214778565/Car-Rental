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

        public InvitationController(IInvitationService invitationService)
        {
            _invitationService = invitationService;
        }


        // GET: api/<InvitationController>
        [HttpGet]
        public ActionResult<List<InvitationEntity>> Get()
        {
            return _invitationService.GetInvitationList();
        }

        // GET api/<InvitationController>/5
        [HttpGet("{id}")]
        public ActionResult<InvitationEntity> GetById(int id)
        {
            if (id < 0)
                return BadRequest();
            InvitationEntity result = _invitationService.GetInvitationById(id);
            return result == null ? NotFound() : result;
        }

        // POST api/<InvitationController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] InvitationEntity Invitation)
        {
            return _invitationService.Add(Invitation);
        }

        // PUT api/<InvitationController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put([FromBody] InvitationEntity Invitation)
        {
            return !_invitationService.Update(Invitation) ? NotFound() : true;
        }

        // DELETE api/<InvitationController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return !_invitationService.Delete(id) ? NotFound() : true;
        }
    }
}
