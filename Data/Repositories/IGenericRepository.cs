using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planifiqator.Data
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetAll();
        List<T> GetAllActive();
        IQueryable<T> GetAllQuery();
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void CreateRange(List<T> entities);
        T FindById(int id);
        bool SaveChanges();

    }
}
