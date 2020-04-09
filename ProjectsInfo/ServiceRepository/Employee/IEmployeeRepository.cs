using System.Collections.Generic;
using ProjectsInfo.Enums;
using ProjectsInfo.Models.Employee;

namespace ProjectsInfo.ServiceRepository.Employee
{
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Добавление сотрудника
        /// </summary>
        /// <param name="employee"></param>
        void AddEmployee(Entity.Employee employee);

        /// <summary>
        /// Изменение сотрудника
        /// </summary>
        /// <param name="employee"></param>
        void EditEmployee(Entity.Employee employee);

        /// <summary>
        /// Получить всех сотрудников
        /// </summary>
        /// <param name="employeeStatus"></param>
        /// <returns></returns>
        List<Entity.Employee> GetAllEmployeesByStatus(EmployeeStatus employeeStatus);

        /// <summary>
        /// Получить весь список сотрудников
        /// </summary>
        /// <returns></returns>
        List<EmployeeViewModel> GetAllEmployee();

        Entity.Employee GetEmployeeById(int employeeId);
    }
}