using System.Collections.Generic;

namespace Checklist.Models
{
    public class Shop : IEntityBase
    {
        public Shop()
        {
            Questions = new List<Question>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}