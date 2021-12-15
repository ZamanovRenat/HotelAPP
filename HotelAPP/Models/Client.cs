using System.ComponentModel.DataAnnotations;

namespace HotelAPP.Models
{
    public class Client
    {
        public int Id { get; set; }
        [Display(Name = "Имя")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Длина имени должна быть от 2 до 200 символов")]
        [RegularExpression(@"([А-ЯЁ][а-яё]+)|([A-Z][a-z]+)", ErrorMessage = "Строка имела неверный формат (Либо русские, либо латинские символы начиная с заглавной буквы)")]
        public string FirstName { get; set; }
        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Не указана фамилия")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Длина фамилии должна быть от 2 до 200 символов")]
        [RegularExpression(@"([А-ЯЁ][а-яё]+)|([A-Z][a-z]+)", ErrorMessage = "Строка имела неверный формат (Либо русские, либо латинские символы начиная с заглавной буквы)")]
        public string LastName { get; set; }
        [Display(Name = "Отчество")]
        [StringLength(200, ErrorMessage = "Длина имени должна быть до 200 символов")]
        public string Patronymic { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }
        public string PassportData { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Notes { get; set; }
    }
}
