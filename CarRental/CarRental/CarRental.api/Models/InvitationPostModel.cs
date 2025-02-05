using CarRental.Core.Entities;

namespace CarRental.api.Models
{
    public class InvitationPostModel
    {
        public int Id { get; set; }
        public int NumInvitation { get; set; }

        public int UserId { get; set; }


        public int CarId { get; set; }

        public DateTime CollectionDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int CollectionPointId { get; set; }
        public DateTime DateOfOrder { get; set; }
        public METHOD_OF_PAYMENT Method_payment { get; set; }
        public decimal TotalPayment { get; set; }
    }
}
