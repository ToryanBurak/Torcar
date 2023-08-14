using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torcar.CORE.Entity
{
   
    public class CarModel:BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        public int? CarMarkId { get; set; }

        //Relational Properties
        public virtual ICollection<CarSerial> CarSerials { get; set; }
        public virtual CarMark CarMark { get; set; }

    }
}
