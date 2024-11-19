namespace EmployeeAPI.Repositories
{
    public interface IRepository<T>
    {
        public T Add(T entity);
        public T GetById(Guid id);
        public IQueryable<T> GetAll();

    }
}
