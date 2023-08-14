using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torcar.CORE.Entity;
using Torcar.CORE.Enums;

namespace Torcar.CORE.DTOs
{
    public class AdvertDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int PriceOfDay { get; set; }
        public DateTime PublishDate { get; set; }=DateTime.Now;
        public ActivityState ActiveState { get; set; }
        public CarDto Car { get; set; }
        public RequestDto RentRequest { get; set; }
    }
}
