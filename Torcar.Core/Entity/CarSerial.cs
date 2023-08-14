using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torcar.CORE.Entity
{
    
    public class CarSerial:BaseEntity
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        
        public int? CarModelId { get; set; }

        //Relational Properties

        public virtual CarModel CarModel { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
