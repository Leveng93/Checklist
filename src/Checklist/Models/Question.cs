namespace Checklist.Models
{
    public class Question : IEntityBase
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int DivisionId { get; set; }
        public int QuestionBlockId { get; set; }
        public int QuestionSectionId { get; set; }
        public virtual Division Division { get; set; }
        public virtual QuestionBlock QuestionBlock { get; set; }
        public virtual QuestionSection QuestionSection { get; set; }
    }
}