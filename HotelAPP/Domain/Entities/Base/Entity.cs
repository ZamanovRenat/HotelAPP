using System.ComponentModel.DataAnnotations;
using HotelAPP.Domain.Entities.Base.Interfaces;

namespace HotelAPP.Domain.Entities.Base
{
    public class Entity : IEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
