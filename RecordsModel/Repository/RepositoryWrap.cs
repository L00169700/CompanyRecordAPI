using RecordsModel.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecordsModel.Repository
{
    /// <summary>
    /// A wrapper aroud the list of repository classes
    /// </summary>
    public class RepositoryWrap : IRepositoryWrap
    {
        private ApplicationDBContext _applicationDBContext;
        private ICompanyRecordsRepository _company;
        private IUserRepository _user;

        public RepositoryWrap(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

        public ICompanyRecordsRepository CompanyRecord
        {
            get 
            {
                if (_company == null)
                {
                    _company = new CompanyRecordsRepository(_applicationDBContext);
                }
                return _company;
            }            
        }

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_applicationDBContext);
                }
                return _user;
            }
        }

        public void Save()
        {
            _applicationDBContext.SaveChanges();
        }
    }
}
