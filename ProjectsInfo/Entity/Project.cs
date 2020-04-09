using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using ProjectsInfo.Enums;

namespace ProjectsInfo.Entity
{
    [Table("Projects")]
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int CustomerCompanyId { get; set; }
        public int ExecutorCompanyId { get; set; }
        public int Supervisor { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Comment { get; set; }
        public ProjectStatus ProjectStatus { get; set; }

    }
}