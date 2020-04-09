using System.ComponentModel.DataAnnotations;
using ProjectsInfo.Enums;

namespace ProjectsInfo.Models.Company
{
    public class CompanyCreateModel
    {
        [Display(Name = "Название компании")]
        [Required(ErrorMessage = "Обязательное поле")]
        public string CompanyName { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Введите корректный email")]
        public string CompanyEmail { get; set; }

        [Display(Name = "Тип компании")]
        [Required(ErrorMessage = "Выберите тип клиента")]
        public CompanyStatus CompanyStatus { get; set; }
    }
}