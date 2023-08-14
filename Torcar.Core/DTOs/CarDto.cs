using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torcar.CORE.Entity;
using Torcar.CORE.Enums;

namespace Torcar.CORE.DTOs
{
    public class CarDto
    {
        public int? Id { get; set; }
        public string Description { get; set; }
        public int? CarSerialId { get; set; }
        public string Year { get; set; }
        public Fuel Fuel { get; set; }
        public Gear Gear { get; set; }
        public string KM { get; set; }
        public CaseType Case { get; set; }
        public int HP { get; set; }
        public double CC { get; set; }
        public Color Color { get; set; }
        public IFormFile Image { get; set; }
        public string? ImageUrl { get; set; }
        public CarSerialDto CarSerial { get; set; }
        public AdvertDto Advert { get; set; }
        public ActivityState ActiveState { get; set; }
        public RentState RentState { get; set; } = RentState.Not_Rented;
    }
}
