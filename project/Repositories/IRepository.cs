using project.Exception;
using System.Linq.Expressions;


namespace project.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void GetById(int id);
        IQueryable<T> GetAll();

    }
}
