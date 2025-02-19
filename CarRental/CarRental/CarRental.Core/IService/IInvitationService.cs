﻿using CarRental.Core.DTOs;
using CarRental.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.IService
{
    public interface IInvitationService
    {
        List<InvitationDto> GetInvitationList();
        InvitationDto GetInvitationById(int id);
        bool Add(InvitationDto invitation);
        bool Update(InvitationDto invitation);
        bool Delete(int id);
    }
}
