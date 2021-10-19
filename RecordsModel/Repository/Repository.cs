using RecordsModel.Repository.Interface;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace RecordsModel.Repository
{
    /// <summary>
    /// Repository of Create and Read methods.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected ApplicationDBContext ApplicationDBContext { get; set; }

        public Repository(ApplicationDBContext applicationDBContext)
        {
            this.ApplicationDBContext = applicationDBContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.ApplicationDBContext.Set<T>();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.ApplicationDBContext.Set<T>().Where(expression);

        }

        public void Create(T entity)
        {
            this.ApplicationDBContext.Set<T>().Add(entity);
        }

        public T FindByID(int id)
        {
            return this.ApplicationDBContext.Set<T>().Find(id);
        }


    }
    }
