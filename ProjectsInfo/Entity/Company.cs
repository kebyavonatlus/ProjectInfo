using System.ComponentModel.DataAnnotations;
using ProjectsInfo.Enums;

namespace ProjectsInfo.Entity
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyEmail { get; set; }
        public CompanyStatus CompanyStatus { get; set; }
    }
}