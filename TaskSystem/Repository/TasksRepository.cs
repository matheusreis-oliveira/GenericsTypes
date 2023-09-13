using TaskSystem.Data;
using TaskSystem.Models;
using TaskSystem.Repository.Interfaces;

namespace TaskSystem.Repository
{
    public class TasksRepository : CrudRepository<Tasks>, ITasksRepository
    {
        public TasksRepository(TaskDbContext taskDbContext) : base(taskDbContext)
        {
        }
    }
}
