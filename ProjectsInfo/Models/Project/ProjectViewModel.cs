using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectsInfo.Models.Project
{
    public class ProjectViewModel
    {
        [Key]
        public int ProjectId { get; set; }

        [Display(Name = "Наименование проекта")]
        public string ProjectName { get; set; }

        [Display(Name = "Компания клиент")]
        public string CustomerCompany { get; set; }

        [Display(Name = "Компания исполнитель")]
        public string ExecutorCompany { get; set; }

        [Display(Name = "Руководитель проекта")]
        public string ProjectSupervisor { get; set; }

        [Display(Name = "Дата начала проекта")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Дата завершения проекта")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Статус проекта")]
        public string ProjectStatus { get; set; }

        [Display(Name = "Комментарий")]
        public string Comment { get; set; }
    }
}