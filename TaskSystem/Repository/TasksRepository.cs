using TaskSystem.Data;
using TaskSystem.Models;

namespace TaskSystem.Repository
{
    public class TasksRepository : Repository<Tasks>
    {
        public TasksRepository(TaskDbContext taskDbContext) : base(taskDbContext)
        {
        }
    }
}
