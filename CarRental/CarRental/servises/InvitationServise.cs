namespace CarRental.servises
{
    public class InvitationServise
    {
        public List<Invitation> Invitations { get; set; }
        public InvitationServise()
        {
            Invitations = new List<Invitation>();
           
        }
        public List<Invitation> getInvitations()
        {
            return Invitations;
        }

        public Invitation GetInvitationById(int id)
        {
            return Invitations.Find(invitation => invitation.Id == id);
        }

        public bool PutInvitation(int id, Invitation invitation)
        {
            Invitation inv = Invitations.Find(i => i.Id == id);
            if (inv == null)
                return false;
            Invitations.Remove(inv);
           Invitations.Add(invitation);
            return true;
        }
        public bool PostInvitation(Invitation invitation)
        {
           Invitations.Add(invitation);
            return true;
        }
        public bool DeleteInvitation(int id)
        {
            Invitation invitation = Invitations.Find(i => i.Id == id);
            if (invitation == null)
                return false;
            Invitations.Remove(invitation);
            return true;
        }

    }
}
