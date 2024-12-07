using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.Entities
{
    public enum Colors { red, green, blue,gray,black }
    public enum Raitings { a, b, c, d, e }
    public enum Kategories { family,van}
    [Table("Car")]
    public class CarEntity
    {

       
        [Key]
        public int Id { get; set; }
        public int License_plate { get; set;}
        public int Model { get; set;}
        public string Company { get; set;}
        public int Year_production { get; set; }
        public int Fuel_consumption_per_km { get; set; }
        public DateTime Test_validity { get; set; }
        public Kategories Kategory { get; set; }
        public bool IsAvailable { get; set; }
        public double Price { get; set; }
        public Colors Color { get; set; }
        public Raitings Raiting { get; set; }

       
    }
}
