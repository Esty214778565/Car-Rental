using CarRental.Core.Entities;
using CarRental.Core.IRepository;
using CarRental.Core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Service
{
    public class InvitationService : IInvitationService
    {

       
        readonly IRepository<InvitationEntity> _InvitationRepository;


        public InvitationService(IRepository<InvitationEntity> invitationRepository)
        {
            _InvitationRepository = invitationRepository;
        }

        public List<InvitationEntity> GetInvitationList()
        {
            return _InvitationRepository.GetAllData();
        }

        public InvitationEntity GetInvitationById(int id)
        {
            return _InvitationRepository.GetById(id);
        }

        public bool Add(InvitationEntity Invitation)
        {
            if (_InvitationRepository.GetIndexById(Invitation.Id) >-1)
                return false;
            return _InvitationRepository.Add(Invitation);
        }

        public bool Update(InvitationEntity Invitation)
        {

            if (_InvitationRepository.GetIndexById(Invitation.Id) < 0)
                return false;
            return _InvitationRepository.Update(Invitation);
        }

        public bool Delete(int id)
        {
            if (_InvitationRepository.GetIndexById(id) < 0)
                return false;
            return _InvitationRepository.Delete(id);
        }

    }

}
