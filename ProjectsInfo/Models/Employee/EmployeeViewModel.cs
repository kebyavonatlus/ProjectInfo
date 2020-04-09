using System.ComponentModel.DataAnnotations;
using ProjectsInfo.Enums;

namespace ProjectsInfo.Models.Employee
{
    public class EmployeeViewModel
    {
        [Key]
        public int EmployeeId { get; set; }
        [Display(Name = "Имя")]
        public string EmployeeName { get; set; }

        [Display(Name = "Фамилия")]
        public string EmployeeSureName { get; set; }

        [Display(Name = "Отчество")]
        public string EmployeePatronymic { get; set; }

        [Display(Name = "Email")]
        public string EmployeeEmail { get; set; }

        [Display(Name = "Тип сотрудника")]
        public string EmployeeStatus { get; set; }

        public bool Checked { get; set; }
    }
}