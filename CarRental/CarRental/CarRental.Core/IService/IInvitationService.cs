﻿using CarRental.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.IService
{
    public interface IInvitationService
    {
        List<InvitationEntity> GetInvitationList();
        InvitationEntity GetInvitationById(int id);
        bool Add(InvitationEntity invitation);
        bool Update(InvitationEntity invitation);
        bool Delete(int id);
    }
}