using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torcar.CORE.DTOs
{
    public class ForgetPasswordDto
    {
        [Required(ErrorMessage ="Lütfen Bir Email Giriniz")]
        public string Email { get; set; }
    }
}
