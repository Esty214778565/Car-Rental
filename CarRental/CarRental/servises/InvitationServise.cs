using CarRental.Entity;

namespace CarRental.servises
{
    public class InvitationServise
    {
       
  
        public List<Invitation> getInvitations()
        {
            if(DataContextManager.DataContext.Invitations ==null)
                DataContextManager.DataContext.Invitations = new List<Invitation>();
            return DataContextManager.DataContext.Invitations;
        }

        public Invitation GetInvitationById(int id)
        {
            return DataContextManager.DataContext.Invitations.Find(invitation => invitation.Id == id);
        }

        public bool Update(int id, Invitation invitation)
        {
            Invitation inv = DataContextManager.DataContext.Invitations.Find(i => i.Id == id);
            if (inv == null)
                return false;
            DataContextManager.DataContext.Invitations.Remove(inv);
           DataContextManager.DataContext.Invitations.Add(invitation);
            return true;
        }
        public bool Add(Invitation invitation)
        {
            if (DataContextManager.DataContext.Invitations == null)
                DataContextManager.DataContext.Invitations = new List<Invitation>();
            DataContextManager.DataContext.Invitations.Add(invitation);
            return true;
        }
        public bool DeleteInvitation(int id)
        {
            Invitation invitation = DataContextManager.DataContext.Invitations.Find(i => i.Id == id);
            if (invitation == null)
                return false;
            DataContextManager.DataContext.Invitations.Remove(invitation);
            return true;
        }

    }
}
