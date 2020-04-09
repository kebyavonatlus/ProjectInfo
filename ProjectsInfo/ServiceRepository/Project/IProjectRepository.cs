using System.Collections.Generic;
using ProjectsInfo.Models.Employee;
using ProjectsInfo.Models.Project;

namespace ProjectsInfo.ServiceRepository.Project
{
    public interface IProjectRepository
    {
        /// <summary>
        /// Добавить новый проект
        /// </summary>
        /// <param name="saveDataModel"></param>
        void AddProject(ProjectSaveModel saveDataModel);

        /// <summary>
        /// Удалить проект
        /// </summary>
        /// <param name="project"></param>
        void RemoveProject(Entity.Project project);

        /// <summary>
        /// Изменить проект
        /// </summary>
        /// <param name="project"></param>
        void EditProject(Entity.Project project);

        /// <summary>
        /// Получить все проекты
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        List<ProjectViewModel> GetAllProjects();

        /// <summary>
        /// Получить проект по ID
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        ProjectEditModel GetProjectById(int projectId);

        /// <summary>
        /// Получить проект по ID entity
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Entity.Project GetProjectByIdEntity(int projectId);


        /// <summary>
        /// Получить список сотрудников в проекте
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        List<EmployeeViewModel> GetEmployeeInProject(int projectId);


        /// <summary>
        /// Получить список сотрудников не входящих в список исполнителей
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        List<EmployeeViewModel> GetEmployeeNotInProject(int projectId);


        /// <summary>
        /// Добавление сотрудника в проект
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="employeeId"></param>
        void AddEmployeeToProject(int projectId, int employeeId);

        /// <summary>
        /// Удаление сорудника с проекта
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="employeeId"></param>
        void RemoveEmployeeFromProject(int projectId, int employeeId);
    }
}