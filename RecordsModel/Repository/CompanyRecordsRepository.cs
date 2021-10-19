using Microsoft.EntityFrameworkCore;
using RecordsModel.Model;
using RecordsModel.Repository.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RecordsModel.Repository
{
    public class CompanyRecordsRepository : Repository<CompanyRecord>, ICompanyRecordsRepository
    {
        public CompanyRecordsRepository(ApplicationDBContext applicationDBContext)
           : base(applicationDBContext)
        {
        }    

        public List<string> ValidateCompanyISIN(CompanyRecord companyRecords)
        {
            List<string> errorCheckerISIN = new List<string>();
            List<string> charChecker = new List<string>();

            //The first two characters of an ISIN must be letters
            charChecker.Add(companyRecords.ISIN.Substring(0, 1).ToUpper());
            charChecker.Add(companyRecords.ISIN.Substring(1, 1).ToUpper());
            foreach (var item in charChecker)
            {
                if (Regex.IsMatch(item, @"^\d+$"))
                    errorCheckerISIN.Add("Given ISIN is numeric, the first two characters of an ISIN must be letters...");                    
                             
            }

            //not allowed to create two Companies with the same ISIN.
            CompanyRecord companies = FindByISIN(companyRecords.ISIN);
            if (companies != null)
                errorCheckerISIN.Add("Not allowed to create two Companies with the same ISIN. the given ISIN is already on the system...");

            return errorCheckerISIN;           
        }

        




        public new IQueryable<CompanyRecord> FindAll()
        {
            var listCompanies = ApplicationDBContext.Set<CompanyRecord>().AsNoTracking().ToList();
            return listCompanies.AsQueryable();
        }

        public new CompanyRecord FindByID(int id)
        {
            var listCompanies = ApplicationDBContext.Set<CompanyRecord>().AsNoTracking().Where(w => w.Id == id).FirstOrDefault();
            return listCompanies;
        }

        public new CompanyRecord FindByISIN(string iSIN)
        {
            var listCompanies = ApplicationDBContext.Set<CompanyRecord>().AsNoTracking().Where(w => w.ISIN == iSIN).FirstOrDefault();
            return listCompanies;
        }

        public new void Create(CompanyRecord entity)
        {
            var company = FindAll().Where(n => n.Name == entity.Name);
            if (company != null)
            {
                this.ApplicationDBContext.Set<CompanyRecord>().Update(entity);
            }
            else
            {
                this.ApplicationDBContext.Set<CompanyRecord>().Add(entity);
            }
        }
    }
}
