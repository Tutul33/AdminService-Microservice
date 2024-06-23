using System.Linq.Expressions;
namespace DataFactory.BaseFactory
{
    public interface IGenericFactoryEF<T> : IDisposable where T : class
    {
        Task<T> GetById(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindBy(Expression<Func<T, bool>> predicate);
        void InsertAsync(T entity);
        void InsertListAsync(IEnumerable<T> entity);
        void UpdateAsync(T entity);
        void DeleteAsync(T entity);
        void DeleteListAsync(IEnumerable<T> entity);
        void DeleteAsync(Expression<Func<T, bool>> predicate);
        Task SaveAsync();
    }
}
