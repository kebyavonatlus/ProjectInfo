using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc.Html;
using ProjectsInfo.DbContext;
using ProjectsInfo.Enums;
using ProjectsInfo.Models.Employee;

namespace ProjectsInfo.ServiceRepository.Employee
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public void AddEmployee(Entity.Employee employee)
        {
            using (var db = new ProjectContext())
            {
                db.Employees.Add(employee);
                db.SaveChanges();
            }
        }

        public void EditEmployee(Entity.Employee employee)
        {
            using (var db = new ProjectContext())
            {
                db.Employees.AddOrUpdate(employee);
                db.SaveChanges();
            }
        }


        public List<Entity.Employee> GetAllEmployeesByStatus(EmployeeStatus employeeStatus)
        {
            using (var db = new ProjectContext())
            {
                return db.Employees.Where(status => status.EmployeeStatus == employeeStatus).ToList();
            }
        }

        public List<EmployeeViewModel> GetAllEmployee()
        {
            using (var db = new ProjectContext())
            {
                var result = from emp in db.Employees
                    select new EmployeeViewModel()
                    {
                        EmployeeStatus = emp.EmployeeStatus == EmployeeStatus.Executor ? "Исполнитель" : "Руководитель",
                        EmployeePatronymic = emp.EmployeePatronymic,
                        EmployeeSureName = emp.EmployeeSureName,
                        EmployeeName = emp.EmployeeName,
                        EmployeeEmail = emp.EmployeeEmail,
                        EmployeeId =  emp.EmployeeId
                    };
                return result.ToList();
            }
        }

        public Entity.Employee GetEmployeeById(int employeeId)
        {
            using (var db = new ProjectContext())
            {
                return db.Employees.FirstOrDefault(x => x.EmployeeId == employeeId);
            }
        }
    }
}