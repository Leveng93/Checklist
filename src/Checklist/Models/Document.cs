using System;
using System.Collections.Generic;

namespace Checklist.Models
{
    class Document : IEntityBase
    {        public Document()
        {
            Answers = new List<Answer>();
        }
        public int Id { get; set; }
        public DateTime DateUploaded { get; set; }
        public DateTime? DateChanged { get; set; }
        public int DivisionId { get; set; }
        public int UserId { get; set; }
        public int ShopId { get; set; }

        public virtual Division Division { get; set; }
        public virtual User User { get; set; }
        public virtual Shop Shop { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}