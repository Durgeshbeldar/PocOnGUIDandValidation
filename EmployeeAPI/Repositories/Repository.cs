using EmployeeAPI.Data;
using EmployeeAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly EmployeeContext _context;
        private readonly DbSet<T> _table;
        public Repository(EmployeeContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public T Add(T entity)
        {
            _table.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public IQueryable<T> GetAll()
        {
            return _table.AsQueryable();
        }
        public T GetById(Guid id)
        {
            return _table.Find(id);
        }
    }
}
