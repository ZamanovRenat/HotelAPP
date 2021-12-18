﻿namespace HotelAPP.Models
{
    public class RoomViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string Comfort { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public byte[] Image { get; set; }
    }
}
