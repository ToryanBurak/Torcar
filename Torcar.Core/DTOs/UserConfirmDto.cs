using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torcar.CORE.Entity;

namespace Torcar.CORE.DTOs
{
    public class UserConfirmDto
    {
        public UserDto? User { get; set; }
        public int? ConfirmCode { get; set; }
    }
}
