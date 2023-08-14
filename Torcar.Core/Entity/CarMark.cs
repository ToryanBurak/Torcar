using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torcar.CORE.Entity
{
    
    public class CarMark:BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        //Relational Properties

        public virtual ICollection<CarModel> CarModels { get; set; }
        
    }
}
