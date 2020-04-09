using System.ComponentModel.DataAnnotations;
using ProjectsInfo.Enums;

namespace ProjectsInfo.Entity
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Обязательное поле")]
        public string EmployeeName { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Обязательное поле")]
        public string EmployeeSureName { get; set; }

        [Display(Name = "Отчество")]
        public string EmployeePatronymic { get; set; }

        [Display(Name = "Email")]
        public string EmployeeEmail { get; set; }

        [Display(Name = "Тип сотрудника")]
        [Required(ErrorMessage = "Выберите тип сотрудника")]
        public EmployeeStatus EmployeeStatus { get; set; }
    }
}