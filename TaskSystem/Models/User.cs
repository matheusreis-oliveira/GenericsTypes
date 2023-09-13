using TaskSystem.Models.Interfaces;

namespace TaskSystem.Models
{
    public class User : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email{ get; set; }
    }
}
