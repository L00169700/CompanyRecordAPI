using System;
using System.Collections.Generic;
using System.Text;

namespace RecordsModel.Repository.Interface
{
    public interface IRepositoryWrap
    {
        ICompanyRecordsRepository CompanyRecord { get; }
        IUserRepository User { get; }


        void Save();
    }
}
