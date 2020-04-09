using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectsInfo.Entity
{
    [Table("ProjectEmployeeInfo")]
    public class ProjectEmployeeInfo
    {
        [Key, Column(Order = 1)]
        public int ProjectId { get; set; }

        [Key, Column(Order = 2)]
        public int EmployeeId { get; set; }
    }
}