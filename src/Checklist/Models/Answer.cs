namespace Checklist.Models
{
    public class Answer : IEntityBase
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int DocumentId { get; set; }
        public int QuestionId { get; set; }
        public virtual Document Document { get; set; }
        public virtual Question Question { get; set; }
    }
}