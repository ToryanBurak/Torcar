using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torcar.CORE.Enums;

namespace Torcar.CORE.Entity
{
    
    public class Car:BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Description { get; set; }

        public int? CarSerialId { get; set; }

        [Required]
        [MaxLength(4)]
        public string Year { get; set; }

        [Required]
        public Fuel Fuel { get; set; }
        [Required]
        public Gear Gear { get; set; }
        [Required]
        [MinLength(0)]
        public string KM { get; set; }
        [Required]
        public CaseType Case { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int HP { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public double CC { get; set; }
        [Required]
        public Color Color { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }
        
        public string? ImageUrl { get; set; }
        public ActivityState ActiveState { get; set; } = ActivityState.Active;
        public RentState RentState { get; set; }


        //Relational Properties

        public virtual CarSerial CarSerial { get; set; }
        public virtual Advert Advert { get; set; }
    }
}
