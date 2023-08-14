using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torcar.CORE.Enums;

namespace Torcar.CORE.Entity
{
    
    public class Rent:BaseEntity
    {
        [Required]
        public int RentRequestId { get; set; }
        [Required]
        public RentDateState RentDateState { get; set; } = RentDateState.Not_Started;
        

        //Relational Properties

        public virtual RentRequest RentRequest { get; set; }
    }
}
