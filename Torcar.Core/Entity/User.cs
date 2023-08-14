using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torcar.CORE.Enums;

namespace Torcar.CORE.Entity
{
    
    public class User:BaseEntity
    {
        [Required]
        [MaxLength(30)]
        public string PersonName { get; set; }
        [Required]
        [MaxLength(30)]
        public string PersonSurname { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        [Required]
        [MaxLength(40)]
        public string Email { get; set; }
        [Required]
        public VerifyState Verify { get; set; } = VerifyState.Unverified;
        [Required]
        public UserState State { get; set; } = UserState.User;
        [Required]
        [Range(18,90)]
        public int Age { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public string TC { get; set; }
        [Required]
        public string Adress { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }
        public string? ImageUrl { get; set; } 
        public bool rentrequestwarrant { get; set; } = true;
        public int ConfirmCode { get; set; }

        //Relational Properties

        public virtual RentRequest RentRequest { get; set; }

        public User()
        {
            Verify = VerifyState.Unverified;
            State = UserState.User;
            if (Image == null) {
                ImageUrl = "~/Images/cover/no-image.jpeg";
            }
            
        }
    }
}
