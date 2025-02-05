using AutoMapper;
using CarRental.Core.DTOs;
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

        readonly IMapper _mapper;
        public InvitationService(IRepository<InvitationEntity> invitationRepository,IMapper mapper)
        {
            _InvitationRepository = invitationRepository;
            _mapper = mapper;
        }

        public List<InvitationDto> GetInvitationList()
        {
            var list= _InvitationRepository.GetAllDataAsync();
            var listDto=_mapper.Map<IEnumerable<InvitationDto>>(list);
            return listDto.ToList();
        }

        public InvitationDto GetInvitationById(int id)
        {
            var invitation= _InvitationRepository.GetById(id);
            return _mapper.Map<InvitationDto>(invitation);
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
