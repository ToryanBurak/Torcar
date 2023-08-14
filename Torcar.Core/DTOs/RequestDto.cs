using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torcar.CORE.Entity;
using Torcar.CORE.Enums;

namespace Torcar.CORE.DTOs
{
    public class RequestDto
    {
        public int Id { get; set; }
        public int AdvertId { get; set; }
        public int UserId { get; set; }
        public int RentDay { get; set; }
        [Required(ErrorMessage ="Kira Başlangıç Tarihini Girmelisiniz")]
        public DateTime RentStart { get; set; }
        public DateTime RentEnd { get; set; }
        public ConfirmState ConfirmState { get; set; }
        public int RentMonth { get; set; }
        public int TotalPrice { get; set; }
        public virtual UserDto User { get; set; }
        public virtual AdvertDto Advert { get; set; }
        public virtual RentDto Rent { get; set; }
        
    }
}
