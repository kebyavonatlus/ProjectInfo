using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using ProjectsInfo.DbContext;
using ProjectsInfo.Enums;
using ProjectsInfo.Models.Company;

namespace ProjectsInfo.ServiceRepository.Company
{
    public class CompanyRepository : ICompanyRepository
    {
        public void AddCompany(Entity.Company company)
        {
            using (var db = new ProjectContext())
            {
                db.Companies.Add(company);
                db.SaveChanges();
            }
        }

        public CompanyCreateModel EditCompany(int companyId)
        {
            using (var db = new ProjectContext())
            {
                var result = db.Companies.FirstOrDefault(x => x.CompanyId == companyId);
                var returnResult = new CompanyCreateModel()
                {
                    CompanyStatus = result.CompanyStatus,
                    CompanyEmail = result.CompanyEmail,
                    CompanyName = result.CompanyName
                };

                return returnResult;
            }
        }

        public void EditCompany(Entity.Company company)
        {
            using (var db = new ProjectContext())
            {
                db.Companies.AddOrUpdate(company);
                db.SaveChanges();
            }
        }

        public List<Entity.Company> GetAllCompaniesByStatus(CompanyStatus companyStatus)
        {
            using (var db = new ProjectContext())
            {
                return db.Companies.Where(type => type.CompanyStatus == companyStatus).ToList();
            }
        }

        public List<CompanyViewModel> GetAllCompanies()
        {
            using (var db = new ProjectContext())
            {
                var result = from company in db.Companies
                    select new CompanyViewModel
                    {
                        CompanyEmail = company.CompanyEmail,
                        CompanyName = company.CompanyName,
                        CompanyStatus = company.CompanyStatus == CompanyStatus.Customer
                            ? "Компания клиент"
                            : "Компания исполнитель",
                        CompanyId = company.CompanyId
                    };
                return result.ToList();
            }
        }

        public Entity.Company GetCompanyById(int companyId)
        {
            using (var db = new ProjectContext())
            {
                return db.Companies.FirstOrDefault(c => c.CompanyId == companyId);
            }
        }
    }
}