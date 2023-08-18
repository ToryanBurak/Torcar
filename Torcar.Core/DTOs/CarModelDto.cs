using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torcar.CORE.DTOs
{
    public class CarModelDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public CarMarkDto CarMark { get; set; }
        public int CarMarkId { get; set; }
    }
}
