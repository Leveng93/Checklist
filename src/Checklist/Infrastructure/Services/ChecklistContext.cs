using System;
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
            modelBuilder.Entity<Document>().Property(p => p.UserId).IsRequired();
            modelBuilder.Entity<Document>().Property(p => p.ShopId).IsRequired();
            modelBuilder.Entity<Document>().Property(p => p.DateUploaded).IsRequired().HasDefaultValue(DateTime.UtcNow);
            modelBuilder.Entity<Document>().HasMany(d => d.Answers).WithOne(d => d.Document);

            // Question
            modelBuilder.Entity<Question>().Property(p => p.Description).IsRequired().HasMaxLength(1000);
            modelBuilder.Entity<Question>().Property(p => p.DivisionId).IsRequired();
            modelBuilder.Entity<Question>().Property(p => p.QuestionBlockId).IsRequired();
            modelBuilder.Entity<Question>().Property(p => p.QuestionSectionId).IsRequired();
            modelBuilder.Entity<Question>().Property(p => p.ShopId).IsRequired();

            // QuestionBlock
            modelBuilder.Entity<QuestionBlock>().Property(p => p.Name).IsRequired().HasMaxLength(100);

            // QuestionSection
            modelBuilder.Entity<QuestionSection>().Property(p => p.Name).IsRequired().HasMaxLength(100);

            // Role
            modelBuilder.Entity<Role>().Property(p => p.Name).IsRequired().HasMaxLength(100);

            // Shop
            modelBuilder.Entity<Shop>().Property(p => p.Name).IsRequired().HasMaxLength(250);
            modelBuilder.Entity<Shop>().HasMany(s => s.Questions).WithOne(s => s.Shop);

            // User
            modelBuilder.Entity<User>().Property(u => u.Username).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<User>().Property(u => u.Email).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<User>().Property(u => u.PasswordHash).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<User>().Property(u => u.Salt).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<User>().Property(u => u.DivisionId).IsRequired();

            // UserRole
            modelBuilder.Entity<UserRole>().Property(ur => ur.RoleId).IsRequired();
            modelBuilder.Entity<UserRole>().Property(ur => ur.UserId).IsRequired();
        }
    }
}