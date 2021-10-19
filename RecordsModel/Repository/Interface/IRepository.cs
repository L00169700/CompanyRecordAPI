using System;
using System.Linq;
using System.Linq.Expressions;

namespace RecordsModel.Repository.Interface
{
    public interface IRepository<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        T FindByID(int id);
    }
}
