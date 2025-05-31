using System.Linq.Expressions;

namespace Contracts
{
    public interface IRepositoryBase<T>
    {
        // trackChanges is used to improve read-only query performance
        IQueryable<T> FindAll(bool trackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
