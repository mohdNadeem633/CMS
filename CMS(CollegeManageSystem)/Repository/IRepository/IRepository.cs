using System.Linq.Expressions;

namespace CMS_CollegeManageSystem_.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {

        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        //_db.Categories.FirstOrDefault(u=>u.Id==Id); it's like the expression below
        T Get(Expression<Func<T, bool>>? filter, string? includeProperties = null, bool tracked = false);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(T entity);
    }
}
