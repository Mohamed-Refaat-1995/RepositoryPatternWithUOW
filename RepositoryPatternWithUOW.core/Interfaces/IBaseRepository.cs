using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.core.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        IEnumerable<T> GetAll();
        T FindByExpression(Expression<Func<T, bool>> expression);
        T FindByExpression(Expression<Func<T, bool>> expression, string[] incudes = null);
        T Add(T entity);
        IEnumerable<T> AddRange(IEnumerable<T> entities);

    }
}
