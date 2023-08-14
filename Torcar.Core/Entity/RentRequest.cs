using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torcar.CORE.Enums;

namespace Torcar.CORE.Entity
{
    public class RentRequest:BaseEntity
    {
        [Required]
        public int AdvertId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int RentDay { get; set; }
        [Required]
        public DateTime RentStart { get; set; }
        [Required]
        public DateTime RentEnd { get; set; }
        [Required]
        public ConfirmState ConfirmState { get; set; }
        public int TotalPrice { get; set; }

        //Relational Properties

        public virtual User User { get; set; }
        public virtual Advert Advert { get; set; }
        public virtual Rent Rent { get; set; }
    }
}
