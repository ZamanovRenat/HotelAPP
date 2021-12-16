using HotelAPP.Domain.Entities.Base;

namespace HotelAPP.Domain.Entities
{
    public class Client : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public string PassportData { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Notes { get; set; }
    }
}
