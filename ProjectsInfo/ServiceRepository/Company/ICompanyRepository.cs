using System;
using System.Collections.Generic;
using System.Linq;
using ProjectsInfo.Enums;
using ProjectsInfo.Models.Company;

namespace ProjectsInfo.ServiceRepository.Company
{
    public interface ICompanyRepository
    {
        /// <summary>
        /// Добавить компанию
        /// </summary>
        /// <param name="company"></param>
        void AddCompany(Entity.Company company);

        /// <summary>
        /// Изменить компанию
        /// </summary>
        /// <param name="companyId"></param>
        CompanyCreateModel EditCompany(int companyId);

        /// <summary>
        /// Изменить существующую компанию
        /// </summary>
        /// <param name="company"></param>
        void EditCompany(Entity.Company company);

        /// <summary>
        /// Получить все компании по статусу
        /// </summary>
        /// <param name="companyStatus"></param>
        /// <returns></returns>
        List<Entity.Company> GetAllCompaniesByStatus(CompanyStatus companyStatus);

        /// <summary>
        /// Получить все компании
        /// </summary>
        /// <returns></returns>
        List<CompanyViewModel> GetAllCompanies();

        /// <summary>
        /// Получить компанию по Id
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        Entity.Company GetCompanyById(int companyId);

    }
}