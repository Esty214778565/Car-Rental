﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.Entities
{
    public enum Colors { red=0, green=1, blue=2,gray=3,black=4}
    public enum Raitings { a=0, b=1, c=2, d=3, e =4}
    public enum Kategories { family=0,van=1}
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
        public bool? IsAvailable { get; set; }
        public double Price { get; set; }
        public Colors Color { get; set; }
        public Raitings? Raiting { get; set; }

       
    }
}
