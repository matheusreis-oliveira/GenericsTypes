using TaskSystem.Data;
using TaskSystem.Models;
using TaskSystem.Repository.Interfaces;

namespace TaskSystem.Repository
{
    public class UserRepository : CrudRepository<User>, IUserRepository
    {
        public UserRepository(TaskDbContext taskDbContext) : base(taskDbContext)
        {
        }
    }
}
