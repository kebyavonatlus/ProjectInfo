using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectsInfo.Entity;
using ProjectsInfo.Enums;
using ProjectsInfo.Models.Employee;
using ProjectsInfo.Models.Project;
using ProjectsInfo.ServiceRepository.Company;
using ProjectsInfo.ServiceRepository.Employee;
using ProjectsInfo.ServiceRepository.Project;

namespace ProjectsInfo.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IEmployeeRepository _employeeRepository;
        public ProjectController(IProjectRepository projectRepository, ICompanyRepository companyRepository, IEmployeeRepository employeeRepository)
        {
            _projectRepository = projectRepository;
            _companyRepository = companyRepository;
            _employeeRepository = employeeRepository;
        }
        // GET: Project
        public ActionResult Index()
        {
            var result = _projectRepository.GetAllProjects();
            return View(result);
        }

        [HttpGet]
        public ActionResult CreateProject()
        {
            ViewBag.CustomerCompanies = _companyRepository.GetAllCompaniesByStatus(CompanyStatus.Customer);
            ViewBag.ExecutorCompanies = _companyRepository.GetAllCompaniesByStatus(CompanyStatus.Executor);
            ViewBag.Supervisors = _employeeRepository.GetAllEmployeesByStatus(EmployeeStatus.Supervisor);
            return View();
        }

        [HttpPost]
        public ActionResult CreateProject(ProjectSaveModel saveDataModel)
        {
            _projectRepository.AddProject(saveDataModel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditProject(int projectId)
        {
            ViewBag.CustomerCompanies = _companyRepository.GetAllCompaniesByStatus(CompanyStatus.Customer);
            ViewBag.ExecutorCompanies = _companyRepository.GetAllCompaniesByStatus(CompanyStatus.Executor);
            ViewBag.Supervisors = _employeeRepository.GetAllEmployeesByStatus(EmployeeStatus.Supervisor);
            var result = _projectRepository.GetProjectById(projectId);
            return View(result);
        }

        [HttpPost]
        public ActionResult EditProject(int projectId, ProjectEditModel editModel)
        {
            var update = _projectRepository.GetProjectByIdEntity(projectId);
            update.Comment = editModel.Comment;
            update.CustomerCompanyId = editModel.CustomerCompanyId;
            update.EndDate = editModel.EndDate;
            update.ExecutorCompanyId = editModel.ExecutorCompanyId;
            update.ProjectName = editModel.ProjectName;
            update.ProjectStatus = editModel.ProjectStatus;
            update.Supervisor = editModel.ProjectSupervisorId;
            _projectRepository.EditProject(update);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ShowEmployeesInProject(int projectId)
        {
            var project = _projectRepository.GetProjectByIdEntity(projectId);
            ViewBag.ProjectName = project.ProjectName;
            var employeeListToReturn = new EmployeeList();
            employeeListToReturn.EmployeeViewModel = _projectRepository.GetEmployeeInProject(projectId);
            return View(employeeListToReturn);
        }

        [HttpPost]
        public ActionResult ShowEmployeesInProject(int projectId, EmployeeList employee)
        {
            if (employee.EmployeeViewModel != null)
            {
                foreach (var employeeViewModel in employee.EmployeeViewModel)
                {
                    if (employeeViewModel.Checked == true)
                    {
                        _projectRepository.RemoveEmployeeFromProject(projectId, employeeViewModel.EmployeeId);
                    }
                }
                return RedirectToAction("ShowEmployeesInProject", new { @projectId = projectId });
            }
            return RedirectToAction("ShowEmployeesInProject", new { @projectId = projectId });
        }



        [HttpGet]
        public ActionResult AddEmployeeToProject(int projectId)
        {
            var project = _projectRepository.GetProjectByIdEntity(projectId);
            if (project == null)
            {
                return RedirectToAction("Index");
            }

            var newEmployeeListToReturn = new EmployeeList();
            newEmployeeListToReturn.EmployeeViewModel = _projectRepository.GetEmployeeNotInProject(projectId);
            return View(newEmployeeListToReturn);
        }

        [HttpPost]
        public ActionResult AddEmployeeToProject(int projectId, EmployeeList employee)
        {
            if (employee.EmployeeViewModel != null)
            {
                foreach (var employeeViewModel in employee.EmployeeViewModel)
                {
                    if (employeeViewModel.Checked == true)
                    {
                        _projectRepository.AddEmployeeToProject(projectId, employeeViewModel.EmployeeId);
                    }
                }
                return RedirectToAction("AddEmployeeToProject", new { @projectId = projectId });
            }

            return RedirectToAction("AddEmployeeToProject", new { @projectId = projectId });
        }
    }
}