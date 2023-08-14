using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

using Torcar.CORE.Entity;
using Torcar.CORE.Enums;
using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;


namespace Torcar.CORE.DTOs
{
    public class UserRegisterDto
    {

        [Required(ErrorMessage = "Lütfen İsim Giriniz.")]
        [MinLength(5, ErrorMessage = "Bu alana en az 5 karakter girilmelidir.")]
        [MaxLength(20, ErrorMessage = "Bu alana en fazla 20 karakter girilebilir.")]
        public string PersonName { get; set; }

        [Required(ErrorMessage = "lütfen Soyisim Giriniz.")]
        [MinLength(5, ErrorMessage = "Bu alana en az 5 karakter girilmelidir.")]
        [MaxLength(20, ErrorMessage = "Bu alana en fazla 20 karakter girilebilir.")]
        public string PersonSurName { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adı Zorunludur.")]
        [MinLength(5, ErrorMessage = "Bu alana en az 5 karakter girilmelidir.")]
        [MaxLength(20, ErrorMessage = "Bu alana en fazla 20 karakter girilebilir.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Şifre Zorunludur.")]
        [MinLength(5, ErrorMessage = "Bu alana en az 5 karakter girilmelidir.")]
        [MaxLength(20, ErrorMessage = "Bu alana en fazla 20 karakter girilebilir.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifreyi Tekrar Girmeniz Gerekmektedir")]
        [MinLength(5, ErrorMessage = "Bu alana en az 5 karakter girilmelidir.")]
        [MaxLength(20, ErrorMessage = "Bu alana en fazla 20 karakter girilebilir.")]
        [Compare(nameof(Password), ErrorMessage = "Girdiğiniz şifreler aynı değildir.Lütfen Kontrol Edin.")]
        public string RePassword { get; set; }
        
        [Required(ErrorMessage = "Mail zorunludur")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Yaş Zorunludur.")]
        [Range(18, 90, ErrorMessage = "Yaş aralığı 18 ila 90 arasında olmalıdır.")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "Telefon Numarası Zorunludur.")]
        [StringLength(11, ErrorMessage = "Bu alan 11 karakterden oluşmalıdır.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Lütfen Cinsiyetinizi giriniz.")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "TC kimlik No Zorunludur.")]
        [MinLength(11, ErrorMessage = "TC Minimum 11 haneli olmalıdır")]
        [MaxLength(11, ErrorMessage = "TC Maximum 11 haneli olmalıdır")]
        public string TC { get; set; }
        
        [Required(ErrorMessage = "Adres zorunludur.")]
        public string Adress { get; set; }
        public IFormFile? Image { get; set; }
        public int ConfirmCode { get; set; }





    }
}
