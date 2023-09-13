using TaskSystem.Data;
using TaskSystem.Models;

namespace TaskSystem.Repository
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(TaskDbContext taskDbContext) : base(taskDbContext)
        {
        }
    }
}
