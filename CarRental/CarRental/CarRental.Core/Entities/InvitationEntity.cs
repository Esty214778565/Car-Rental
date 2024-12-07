using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.Entities
{
    public enum METHOD_OF_PAYMENT { credit, cash, check }
    [Table("Invitation")]
    public class InvitationEntity
    {
       
        [Key]
        public int Id { get; set; }
        public int NumInvitation { get; set; }
        [Required,MaxLength(9)]
        public string UserTz { get; set; }
        public int CarId { get; set; }
        public DateTime CollectionDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int CollectionPointId { get; set; }
        public DateTime DateOfOrder { get; set; }
        public METHOD_OF_PAYMENT Method_payment { get; set; }
        [Column(TypeName ="decimal(18,3)")]
        public decimal TotalPayment { get; set; }
        



    }
}
