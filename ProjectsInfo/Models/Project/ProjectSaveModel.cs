using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectsInfo.Models.Project
{
    public class ProjectSaveModel
    {
        [Display(Name = "Название проекта")]
        [Required(ErrorMessage = "Обязательное поле к заполнению")]
        public string ProjectName { get; set; }

        [Display(Name = "Компания заказчик")]
        [Required(ErrorMessage = "Обязательное поле к заполнению")]
        public int CustomerCompanyId { get; set; }

        [Display(Name = "Компания исполнитель")]
        [Required(ErrorMessage = "Обязательное поле к заполнению")]
        public int ExecutorCompanyId { get; set; }

        [Display(Name = "Руководитель проекта")]
        [Required(ErrorMessage = "Обязательное поле к заполнению")]
        public int ProjectSupervisorId { get; set; }

        [Display(Name = "Дата окончания проекта")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Комментарий к проекту")]
        [Required(ErrorMessage = "Обязательное поле к заполнению")]
        public string Comment { get; set; }
    }
}
