using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Torcar.CORE.Enums;

namespace Torcar.CORE.Entity
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        
        public DateTime? ModifiedDate { get; set; }
        
        public DateTime? DeletedDate { get; set; }
        public ObjectState ObjectState { get; set; } = ObjectState.Created;

        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
            ObjectState = ObjectState.Created;
        }
    }
}
