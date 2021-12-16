using System.ComponentModel.DataAnnotations.Schema;
using HotelAPP.Domain.Entities.Base;

namespace HotelAPP.Domain.Entities
{
    public class Room : NamedEntity
    {
        public int Capacity { get; set; }
        public string Comfort { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public byte[] Image { get; set; }
    }
}
