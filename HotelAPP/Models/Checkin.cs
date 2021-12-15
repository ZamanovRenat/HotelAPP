using System;

namespace HotelAPP.Models
{
    public class Checkin
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Client { get; set; }
        public string PhoneNumber { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string Notes { get; set; }
    }
}
