namespace CarRental.servises
{
   public enum METHOD_OF_PAYMENT {credit,cash,check}
    public class Invitation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public DateOnly CollectionDate { get; set; }
        public DateOnly ReturnDate { get; set; }
        public int CollectionPointId { get; set; }
        public DateOnly DateOfOrder { get; set; }
        public METHOD_OF_PAYMENT Method_payment { get; set; }
        public double TotalPayment { get; set; }

    }
}
