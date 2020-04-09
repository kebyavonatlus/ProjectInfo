
using System.ComponentModel.DataAnnotations;

namespace ProjectsInfo.Models.Company
{
    public class CompanyViewModel
    {
        [Key]
        public int CompanyId { get; set; }

        [Display(Name = "Название компании")]
        public string CompanyName { get; set; }

        [Display(Name = "Email")]
        public string CompanyEmail { get; set; }

        [Display(Name = "Тип компании")]
        public string CompanyStatus { get; set; }
    }
}