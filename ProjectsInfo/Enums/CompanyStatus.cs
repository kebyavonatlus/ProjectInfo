using System.ComponentModel.DataAnnotations;

namespace ProjectsInfo.Enums
{
    public enum CompanyStatus
    {
        [Display(Name = "Компания клиент")]
        Customer = 1,
        [Display(Name = "Компания исполнитель")]
        Executor = 2
    }
}