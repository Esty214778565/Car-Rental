using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.Entities
{
    [Table("User")]
    public class UserEntity
    {
        [Key]
        public int Id { get; set;}
        //[Required,MaxLength(9)]
        public string Tz { get; set;}
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Zip_code { get; set; }
        [MaxLength(10)]
        public string Phone { get; set; }

       
    }
}
