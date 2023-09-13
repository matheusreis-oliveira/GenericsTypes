using TaskSystem.Enums;
using TaskSystem.Models.Interfaces;

namespace TaskSystem.Models
{
    public class Tasks : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
    }
}
