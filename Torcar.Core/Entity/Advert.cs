using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torcar.CORE.Enums;

namespace Torcar.CORE.Entity
{
    
    public class Advert:BaseEntity
    {
        [Required]
        public int CarId { get; set; }
        [Required]
        public int PriceOfDay { get; set; }
        [Required]
        public DateTime PublishDate { get; set; }= DateTime.Now;
        [Required]
        public ActivityState ActiveState { get; set; }=ActivityState.Active;

        //Relational Properties

        public virtual Car Car { get; set; }
        public virtual RentRequest RentRequest { get; set; }


    }
}
