using System.ComponentModel.DataAnnotations;

namespace ProjectsInfo.Enums
{
    public enum ProjectStatus
    {
        [Display(Name = "Создан")]
        Created = 1,
        [Display(Name = "В процессе")]
        InProgress = 2,
        [Display(Name = "Тестируется")]
        Tested = 3,
        [Display(Name = "Завершен")]
        Completed = 4
    }
}