using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torcar.CORE.Enums;

namespace Torcar.CORE.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string PersonName { get; set; }
        public string PersonSurname { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public VerifyState Verify { get; set; } 
        public UserState State { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string TC { get; set; }
        public string Adress { get; set; }
        public string? ImageUrl { get; set; }
        public bool rentrequestwarrant { get; set; }
        public int ConfirmCode { get; set; }
        public ObjectState ObjectState { get; set; }
        [Required(ErrorMessage ="Resim Girmediniz!!!")]
        public IFormFile Image { get; set; }
        public Gender Gender { get; set; }
    }
}
