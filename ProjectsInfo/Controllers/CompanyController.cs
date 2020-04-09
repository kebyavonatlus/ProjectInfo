using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectsInfo.Entity;
using ProjectsInfo.Enums;
using ProjectsInfo.Models.Company;
using ProjectsInfo.ServiceRepository.Company;

namespace ProjectsInfo.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        // GET: Company
        public ActionResult Index()
        {
            var result = _companyRepository.GetAllCompanies();
            return View(result);
        }

        [HttpGet]
        public ActionResult CreateCompany()
        {
            IEnumerable<SelectListItem> values = from CompanyStatus company in Enum.GetValues(typeof(CompanyStatus))
                select new SelectListItem
                {
                    Text = company.ToString(),
                    Value = Convert.ToInt32(company).ToString()
                };

            ViewBag.CompanyStatus = values;
            return View();
        }

        [HttpPost]
        public ActionResult CreateCompany(CompanyCreateModel createModel)
        {
            if (ModelState.IsValid)
            {
                var newCompany = new Company
                {
                    CompanyStatus = createModel.CompanyStatus,
                    CompanyEmail = createModel.CompanyEmail,
                    CompanyName = createModel.CompanyName
                };
                _companyRepository.AddCompany(newCompany);
                return RedirectToAction("Index");
            } 
            return View();
        }

        [HttpGet]
        public ActionResult EditCompany(int companyId)
        {
            var company = _companyRepository.EditCompany(companyId);
            return View(company);
        }

        [HttpPost]
        public ActionResult EditCompany(int companyId, CompanyCreateModel createModel)
        {
            var update = _companyRepository.GetCompanyById(companyId);
            update.CompanyEmail = createModel.CompanyEmail;
            update.CompanyName = createModel.CompanyName;
            update.CompanyStatus = createModel.CompanyStatus;

            _companyRepository.EditCompany(update);

            return RedirectToAction("Index");
        }
    }
}