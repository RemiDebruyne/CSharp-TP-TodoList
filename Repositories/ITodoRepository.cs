using System.Linq.Expressions;

namespace ToDoList.Repositories
{
    public interface ITodoRepository<T>
    {
        public bool Add(T entity);
        public bool Update(T entity);
        public List<T> GetAll();
        public T? Get(Expression<Func<T, bool>> predicate);
        public List<T> GetAll(Expression<Func<T, bool>> predicate);

        public T? GetById(int id);

        public bool Delete(int id);

        public bool UpdateStatus(T entity);

    }
}