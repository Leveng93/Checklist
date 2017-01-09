namespace Checklist.Models
{
    public class UserRole : IEntityBase
    {
        public int Id { get; set; }
        public virtual Role Role { get; set; }
    }
}