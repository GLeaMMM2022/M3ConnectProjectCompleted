using System;
using System.ComponentModel.DataAnnotations;

namespace M3ConnectProject.Models
{
    public class ContractViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [RegularExpression(@"^[А-ЯЁ][а-яё]+\s[А-ЯЁ][а-яё]+\s[А-ЯЁ][а-яё]+$",
            ErrorMessage = "Введите корректное ФИО (три слова, каждое с большой буквы).")]
        public string FullName { get; set; }

        [Required]
        [RegularExpression(@"^(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[1-9]?[0-9])(\.(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[1-9]?[0-9])){3}$",
            ErrorMessage = "Введите корректный IP-адрес.")]
        public string IpAddress { get; set; }

        [Required]
        public ServiceType ServiceType { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Дата заключения")]
        public DateTime ContractDate { get; set; }

        public bool IsActive { get; set; }
    }
}
