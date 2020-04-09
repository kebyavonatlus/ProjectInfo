using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using ProjectsInfo.DbContext;
using ProjectsInfo.Entity;
using ProjectsInfo.Enums;
using ProjectsInfo.Models.Employee;
using ProjectsInfo.Models.Project;

namespace ProjectsInfo.ServiceRepository.Project
{
    public class ProjectRepository : IProjectRepository
    {
        public void AddProject(ProjectSaveModel saveDataModel)
        {
            using (var db = new ProjectContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    var newProject = new Entity.Project
                    {
                        ProjectName = saveDataModel.ProjectName,
                        Comment = saveDataModel.Comment,
                        StartDate = DateTime.Now,
                        EndDate = saveDataModel.EndDate,
                        ProjectStatus = ProjectStatus.Created,
                        CustomerCompanyId = saveDataModel.CustomerCompanyId,
                        ExecutorCompanyId = saveDataModel.ExecutorCompanyId,
                        Supervisor = saveDataModel.ProjectSupervisorId
                    };
                    db.Projects.Add(newProject);

                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        throw new Exception(e.Message);
                    }

                    transaction.Commit();
                }
            }
        }

        public void RemoveProject(Entity.Project project)
        {
            throw new System.NotImplementedException();
        }

        public void EditProject(Entity.Project project)
        {
            using (var db = new ProjectContext())
            {
                db.Projects.AddOrUpdate(project);
                db.SaveChanges();
            }
        }

        public List<ProjectViewModel> GetAllProjects()
        {
            using (var db = new ProjectContext())
            {
                var result = from projects in db.Projects
                    join dbCompanyExec in db.Companies on projects.ExecutorCompanyId equals dbCompanyExec.CompanyId
                    join dbCompanyCust in db.Companies on projects.CustomerCompanyId equals dbCompanyCust.CompanyId
                    join dbEmployee in db.Employees on projects.Supervisor equals dbEmployee.EmployeeId
                    select new ProjectViewModel
                    {
                        ProjectStatus = projects.ProjectStatus == ProjectStatus.Created ? "Создан" :
                            projects.ProjectStatus == ProjectStatus.InProgress ? "В процессе" :
                            projects.ProjectStatus == ProjectStatus.Tested ? "Тестируется" : "Завершен",
                        EndDate = projects.EndDate,
                        ProjectName = projects.ProjectName,
                        StartDate = projects.StartDate,
                        CustomerCompany = dbCompanyCust.CompanyName,
                        ExecutorCompany = dbCompanyExec.CompanyName,
                        ProjectSupervisor = dbEmployee.EmployeeName,
                        Comment = projects.Comment,
                        ProjectId = projects.ProjectId
                    };
                return result.ToList();
            }
        }
        
        public ProjectEditModel GetProjectById(int projectId)
        {
            using (var db = new ProjectContext())
            {
                var result = from project in db.Projects
                             where project.ProjectId == projectId
                    select new ProjectEditModel()
                    {
                        Comment = project.Comment,
                        CustomerCompanyId = project.CustomerCompanyId,
                        ProjectSupervisorId = project.Supervisor,
                        ExecutorCompanyId = project.ExecutorCompanyId,
                        EndDate = project.EndDate,
                        ProjectId = project.ProjectId,
                        ProjectName = project.ProjectName,
                        ProjectStatus = project.ProjectStatus,
                        StartDate = project.StartDate
                    };
                return result.FirstOrDefault();
            }
        }

        public Entity.Project GetProjectByIdEntity(int projectId)
        {
            using (var db = new ProjectContext())
            {
                return db.Projects.FirstOrDefault(x => x.ProjectId == projectId);
            }
        }

        public List<EmployeeViewModel> GetEmployeeInProject(int projectId)
        {
            using (var db = new ProjectContext())
            {
                var result = from project in db.Projects
                    join projectEmployeeInfo in db.ProjectEmployeeInfo on project.ProjectId equals projectEmployeeInfo
                        .ProjectId
                    join dbEmployee in db.Employees on projectEmployeeInfo.EmployeeId equals dbEmployee.EmployeeId
                    where project.ProjectId == projectId
                    select new EmployeeViewModel()
                    {
                        EmployeeEmail = dbEmployee.EmployeeEmail,
                        EmployeeName = dbEmployee.EmployeeName,
                        EmployeePatronymic = dbEmployee.EmployeePatronymic,
                        EmployeeSureName = dbEmployee.EmployeeSureName,
                        EmployeeId = dbEmployee.EmployeeId,
                        EmployeeStatus = dbEmployee.EmployeeStatus == EmployeeStatus.Executor ? "Исполнитель" : "Руководитель"
                    };
                return result.ToList();
            }
        }

        public List<EmployeeViewModel> GetEmployeeNotInProject(int projectId)
        {
            using (var db = new ProjectContext())
            {
                var result = from dbEmployee in db.Employees
                    where !(from projectEmployeeInfo in db.ProjectEmployeeInfo select projectEmployeeInfo.EmployeeId)
                              .Contains(dbEmployee.EmployeeId) && dbEmployee.EmployeeStatus == EmployeeStatus.Executor
                    select new EmployeeViewModel()
                    {
                        EmployeeId = dbEmployee.EmployeeId,
                        EmployeeStatus = dbEmployee.EmployeeStatus == EmployeeStatus.Executor
                            ? "Исполнитель"
                            : "Руководитель",
                        EmployeeName = dbEmployee.EmployeeName,
                        EmployeeSureName = dbEmployee.EmployeeSureName,
                        EmployeePatronymic = dbEmployee.EmployeePatronymic,
                        EmployeeEmail = dbEmployee.EmployeeEmail
                    };
                return result.ToList();
            }
        }

        public void AddEmployeeToProject(int projectId, int employeeId)
        {
            using (var db = new ProjectContext())
            {
                var newEmployeeInProject = new ProjectEmployeeInfo()
                {
                    EmployeeId = employeeId,
                    ProjectId = projectId
                };
                db.ProjectEmployeeInfo.Add(newEmployeeInProject);
                db.SaveChanges();
            }
        }

        public void RemoveEmployeeFromProject(int projectId, int employeeId)
        {
            using (var db = new ProjectContext())
            {
                var removeEmployeeFromProject =
                    db.ProjectEmployeeInfo.FirstOrDefault(x => x.EmployeeId == employeeId && x.ProjectId == projectId);
                db.ProjectEmployeeInfo.Remove(removeEmployeeFromProject ?? throw new InvalidOperationException());
                db.SaveChanges();
            }
        }
    }
}