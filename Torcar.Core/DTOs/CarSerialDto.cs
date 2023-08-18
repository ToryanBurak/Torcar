using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torcar.CORE.DTOs
{
    public class CarSerialDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public CarModelDto CarModel { get; set; }
        public int CarModelId { get; set; }
    }
}
