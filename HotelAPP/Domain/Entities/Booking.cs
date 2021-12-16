using System;
using System.ComponentModel.DataAnnotations;
using HotelAPP.Domain.Entities.Base;

namespace HotelAPP.Domain.Entities
{
    public class Booking : Entity
    {
        [Required]
        public Client Client { get; set; }
        public Room Room  { get; set; }
        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }
        public string Notes { get; set; }
    }
}
