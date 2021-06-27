using Microsoft.EntityFrameworkCore;
using Planifiqator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planifiqator.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DatabaseContext _context;
        protected readonly DbSet<T> _table;

        public GenericRepository(DatabaseContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }
        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        public void CreateRange(List<T> entities)
        {
            _table.AddRange(entities);
        }
        public void Delete(T entity)
        {
            _table.Remove(entity);
        }
        public T FindById(int id)
        {
            return _table.Find(id);
        }
        public List<T> GetAll()
        {
            return _table.ToList();
        }

        public List<T> GetAllActive()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAllQuery()
        {
            return _context.Set<T>();
        }
        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
        public void Update(T entity)
        {
            _table.Update(entity);
        }
    }
}
