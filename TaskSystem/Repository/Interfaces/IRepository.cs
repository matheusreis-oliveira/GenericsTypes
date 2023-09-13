namespace TaskSystem.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<T> Create(T entity);
        Task<T> Update(T entity, Guid id);
        Task<T> Delete(Guid id);
    }
}
