using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torcar.CORE.DTOs
{
    public class UpdatePasswordDto
    {
        [Required(ErrorMessage = "Şifre Zorunludur.")]
        [MinLength(5, ErrorMessage = "Bu alana en az 5 karakter girilmelidir.")]
        [MaxLength(20, ErrorMessage = "Bu alana en fazla 20 karakter girilebilir.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifreyi Tekrar Girmeniz Gerekmektedir")]
        [MinLength(5, ErrorMessage = "Bu alana en az 5 karakter girilmelidir.")]
        [MaxLength(20, ErrorMessage = "Bu alana en fazla 20 karakter girilebilir.")]
        [Compare(nameof(Password), ErrorMessage = "Girdiğiniz şifreler aynı değildir.Lütfen Kontrol Edin.")]
        public string RePassword { get; set; }
    }
}
