using CarRental.Core.Entities;
using CarRental.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Data.Repository
{
    public class InvitationRepository : IRepository<InvitationEntity>
    {
        readonly DataContext _dataContext;
        public InvitationRepository(DataContext dataContext)
        { _dataContext = dataContext; }

        public List<InvitationEntity> GetAllData()
        {
            return _dataContext.Invitations.ToList();
        }

        public InvitationEntity GetById(int id)
        {
            return _dataContext.Invitations.ToList().Find(c => c.Id == id);
        }

        public bool Add(InvitationEntity Invitation)
        {
            try
            {
                _dataContext.Invitations.Add(Invitation);
                _dataContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(InvitationEntity Invitation)
        {
            int i = _dataContext.Invitations.ToList().FindIndex(c => c.Id == Invitation.Id);
            if (i < 0)
                return false;
            if (Invitation.ReturnDate != new DateTime())
                _dataContext.Invitations.ToList()[i].ReturnDate = Invitation.ReturnDate;
            if (Invitation.UserTz != "")
                _dataContext.Invitations.ToList()[i].UserTz = Invitation.UserTz;
            if (Invitation.CollectionDate != new DateTime())
                _dataContext.Invitations.ToList()[i].CollectionDate = Invitation.CollectionDate;
            if (Invitation.CarId > 0)
                _dataContext.Invitations.ToList()[i].CarId = Invitation.CarId;
            if (Invitation.CollectionPointId > 0)
                _dataContext.Invitations.ToList()[i].CollectionPointId = Invitation.CollectionPointId;
            if (Invitation.DateOfOrder != new DateTime())
                _dataContext.Invitations.ToList()[i].DateOfOrder = Invitation.DateOfOrder;
            if (Invitation.Method_payment != _dataContext.Invitations.ToList()[i].Method_payment)
                _dataContext.Invitations.ToList()[i].Method_payment = Invitation.Method_payment;
            if (Invitation.NumInvitation > 0)
                _dataContext.Invitations.ToList()[i].NumInvitation = Invitation.NumInvitation;
            if (Invitation.TotalPayment > 0)
                _dataContext.Invitations.ToList()[i].TotalPayment = Invitation.TotalPayment;



            try
            {
                _dataContext.SaveChanges();
                return true;
            }
            catch { return false; }

        }

        public bool Delete(int id)
        {
            try
            {
                InvitationEntity i = _dataContext.Invitations.ToList().Find(c => c.Id == id);

                _dataContext.Invitations.Remove(i);
                _dataContext.SaveChanges();
                return true;
            }
            catch
            { return false; }
        }
        public int GetIndexById(int id)
        {
            return _dataContext.Invitations.ToList().FindIndex(c => c.Id == id);
        }


    }

}
