using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torcar.CORE.DTOs
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "Kullanıcı Adı boş bırakılamaz ")]
        [MinLength(5, ErrorMessage = "Bu alana en az 5 karakter girilmelidir.")]
        [MaxLength(20, ErrorMessage = "Bu Alana en fazla 20 karakter girilmelidir.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifre boş bırakılamaz")]
        [MinLength(5, ErrorMessage = "Bu alana en az 5 karakter girilmelidir.")]
        [MaxLength(20, ErrorMessage = "Bu Alana en fazla 20 karakter girilmelidir.")]
        public string Password { get; set; }
    }
}
