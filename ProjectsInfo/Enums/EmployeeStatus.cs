using System.ComponentModel.DataAnnotations;

namespace ProjectsInfo.Enums
{
    public enum EmployeeStatus
    {
        [Display(Name = "Руководитель")]
        Supervisor = 1,
        [Display(Name = "Исполнитель")]
        Executor = 2
    }
}