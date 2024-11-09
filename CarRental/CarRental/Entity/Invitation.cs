namespace CarRental.Entity
{
    public enum METHOD_OF_PAYMENT { credit, cash, check }
    public class Invitation
    {
        public Invitation()
        {
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public DateTime CollectionDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int CollectionPointId { get; set; }
        public DateTime DateOfOrder { get; set; }
        public METHOD_OF_PAYMENT Method_payment { get; set; }
        public double TotalPayment { get; set; }

        public Invitation(int id, int userId, int carId, DateTime collectionDate, DateTime returnDate, int collectionPointId, DateTime dateOfOrder, METHOD_OF_PAYMENT method_payment, double totalPayment)
        {
            Id = id;
            UserId = userId;
            CarId = carId;
            CollectionDate = collectionDate;
            ReturnDate = returnDate;
            CollectionPointId = collectionPointId;
            DateOfOrder = dateOfOrder;
            Method_payment = method_payment;
            TotalPayment = totalPayment;
        }
    }
}
