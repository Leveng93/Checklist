using Checklist.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Checklist.Infrastructure.Services
{
    class ChecklistContext : DbContext
    {
        public ChecklistContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<AnswerType> AnswerTypes { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Error> Errors { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionBlock> QuestionBlocks { get; set; }
        public DbSet<QuestionSection> QuestionSections { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.Relational().TableName = entity.DisplayName();
            }

            // Answer
            modelBuilder.Entity<Answer>().Property(p => p.Value).IsRequired().HasMaxLength(5000);
            modelBuilder.Entity<Answer>().Property(p => p.DocumentId).IsRequired();
            modelBuilder.Entity<Answer>().Property(p => p.QuestionId).IsRequired();

            // AnswerType
            modelBuilder.Entity<AnswerType>().Property(p => p.Name).IsRequired().HasMaxLength(50);

            // Division
            modelBuilder.Entity<Division>().Property(p => p.Name).IsRequired().HasMaxLength(200);

            // Document
            modelBuilder.Entity<Document>().Property(p => p.Approved).IsRequired().HasDefaultValue("false");
        }
    }
}