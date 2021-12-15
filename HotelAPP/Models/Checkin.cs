using System;
using System.ComponentModel.DataAnnotations;

namespace HotelAPP.Models
{
    public class Checkin
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Client { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }
        public int RoomId { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата заезда")]
        public DateTime CheckIn { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата выезда")]
        public DateTime CheckOut { get; set; }
        public string Notes { get; set; }
    }
}
