using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torcar.CORE.Entity;
using Torcar.CORE.Enums;

namespace Torcar.CORE.DTOs
{
    public class RentDto
    {
        public int RentRequestId { get; set; }
        public RentDateState RentDateState { get; set; }
        public virtual RequestDto RentRequest { get; set; }
    }
}
