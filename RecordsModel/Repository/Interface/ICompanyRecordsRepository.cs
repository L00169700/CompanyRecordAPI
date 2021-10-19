using RecordsModel.Model;
using System.Collections.Generic;

namespace RecordsModel.Repository.Interface
{
    public interface ICompanyRecordsRepository : IRepository<CompanyRecord>
    {
        List<string> ValidateCompanyISIN(CompanyRecord companyRecords);
        CompanyRecord FindByISIN(string iSIN);
    }
}
