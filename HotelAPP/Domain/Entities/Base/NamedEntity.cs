using System.ComponentModel.DataAnnotations;
using HotelAPP.Domain.Entities.Base.Interfaces;

namespace HotelAPP.Domain.Entities.Base
{
    public class NamedEntity : Entity, INamedEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
