using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithUOW.core.Interfaces;
using RepositoryPatternWithUOW.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.EF.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _Context;

        public BaseRepository(ApplicationDbContext context)
        {
            _Context = context;
        }

        public T Add(T entity)
        {
            _Context.Set<T>().Add(entity);
            _Context.SaveChanges();
            return entity;
        }

        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            _Context.Set<T>().AddRange(entities);
            _Context.SaveChanges();
            return entities;

        }

        public T FindByExpression(Expression<Func<T, bool>> expression) => _Context.Set<T>().FirstOrDefault(expression);

        public T FindByExpression(Expression<Func<T, bool>> expression, string[] incudes = null)
        {
            IQueryable<T> query = _Context.Set<T>();
            if (incudes != null)
            {
                foreach (string item in incudes)
                {
                    query = query.Include(item);
                }
            }
            return query.FirstOrDefault(expression);
        }

        public IEnumerable<T> GetAll()
        {
            return _Context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _Context.Set<T>().Find(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _Context.Set<T>().FindAsync(id);
        }
    }
}
