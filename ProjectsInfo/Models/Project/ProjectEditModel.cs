using System;
using System.ComponentModel.DataAnnotations;
using ProjectsInfo.Enums;

namespace ProjectsInfo.Models.Project
{
    public class ProjectEditModel
    {
        [Key]
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Наименование проекта")]
        public string ProjectName { get; set; }

        [Required(ErrorMessage = "Выберите компанию клиент")]
        [Display(Name = "Компания клиент")]
        public int CustomerCompanyId { get; set; }

        [Required(ErrorMessage = "Выберите компанию исполнитель")]
        [Display(Name = "Компания исполнитель")]
        public int ExecutorCompanyId { get; set; }

        [Required(ErrorMessage = "Выберите руководителя проекта")]
        [Display(Name = "Руководитель проекта")]
        public int ProjectSupervisorId { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Дата начала проекта")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Дата завершения проекта")]
        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Статус проекта")]
        public ProjectStatus ProjectStatus { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Комментарий")]
        public string Comment { get; set; }
    }
}