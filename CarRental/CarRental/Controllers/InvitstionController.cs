﻿using CarRental.servises;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvitstionController : ControllerBase
    {
        static InvitationServise invitationServise = new InvitationServise();
        // GET: api/<InvitationController>
        [HttpGet]
        public ActionResult<List<Invitation>> Get()
        {
            List<Invitation> result = invitationServise.getInvitations();
            return result == null ? NotFound() : result;
        }

        // GET api/<InvitationController>/5
        [HttpGet("{id}")]
        public ActionResult<Invitation> Get(int id)
        {
            Invitation result = invitationServise.GetInvitationById(id);
            return result == null ? NotFound() : result;
        }

        // POST api/<InvitationController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Invitation invitation)
        {
            return !invitationServise.PostInvitation(invitation) ? NotFound() : Ok(true);
        }

        // PUT api/<InvitationController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Invitation invitation)
        {
            return !invitationServise.PutInvitation(id, invitation) ? NotFound() : Ok(true);
        }

        // DELETE api/<InvitationController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return !invitationServise.DeleteInvitation(id) ? NotFound() : Ok(true);
        }


       
    }
}
