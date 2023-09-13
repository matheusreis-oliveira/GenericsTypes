namespace TaskSystem.Repository.Interfaces
{
    public interface ICrudRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<T> Create(T entity);
        Task<T> Update(T entity, Guid id);
        Task Delete(Guid id);
    }
}
