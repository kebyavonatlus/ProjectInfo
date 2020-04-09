using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectsInfo.Entity;
using ProjectsInfo.Models.Employee;
using ProjectsInfo.ServiceRepository.Employee;

namespace ProjectsInfo.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        // GET: Employee
        public ActionResult Index()
        {
            var result = _employeeRepository.GetAllEmployee();
            return View(result);
        }

        [HttpGet]
        public ActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEmployee(EmployeeModel createModel)
        {
            var newEmployee = new Employee
            {
                EmployeeEmail = createModel.EmployeeEmail,
                EmployeeName = createModel.EmployeeName,
                EmployeePatronymic = createModel.EmployeePatronymic,
                EmployeeStatus = createModel.EmployeeStatus,
                EmployeeSureName = createModel.EmployeeSureName
            };
            _employeeRepository.AddEmployee(newEmployee);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditEmployee(int employeeId)
        {
            var employee = _employeeRepository.GetEmployeeById(employeeId);

            if (employee == null)
            {
                return View();
            }

            return View(employee);
        }

        [HttpPost]
        public ActionResult EditEmployee(int employeeId, Employee employee)
        {
            var emp = _employeeRepository.GetEmployeeById(employeeId);

            if (emp != null)
            {
                emp.EmployeeEmail = employee.EmployeeEmail;
                emp.EmployeeName = employee.EmployeeName;
                emp.EmployeePatronymic = employee.EmployeePatronymic;
                emp.EmployeeStatus = employee.EmployeeStatus;
                emp.EmployeeSureName = employee.EmployeeSureName;

                _employeeRepository.EditEmployee(emp);
                return RedirectToAction("Index");
            }
            return View(employee);
        }
    }
}