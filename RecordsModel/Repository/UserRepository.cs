using RecordsModel.Model;
using RecordsModel.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecordsModel.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDBContext applicationDBContext)
           : base(applicationDBContext)
        {
        }

    }
}
