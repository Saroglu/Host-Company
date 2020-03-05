using HostingFirmasıProje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HostingFirmasıProje.Interfaces
{
    public interface IRepository<T> where T : BaseModel
    {
        T GetById(int id);
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
