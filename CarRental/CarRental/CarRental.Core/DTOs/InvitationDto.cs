using CarRental.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.DTOs
{
    public class InvitationDto
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
