using System;
using Checklist.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;

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
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            // Answer
            modelBuilder.Entity<Answer>().Property(p => p.Value).IsRequired().HasMaxLength(5000);
            modelBuilder.Entity<Answer>().Property(p => p.QuestionId).IsRequired();
            modelBuilder.Entity<Answer>().Property(p => p.DocumentId).IsRequired();

            // AnswerType
            modelBuilder.Entity<AnswerType>().Property(p => p.Name).IsRequired().HasMaxLength(50);

            // Division
            modelBuilder.Entity<Division>().Property(p => p.Name).IsRequired().HasMaxLength(200);

            // Document
            modelBuilder.Entity<Document>().Property(p => p.UserId).IsRequired();
            modelBuilder.Entity<Document>().Property(p => p.ShopId).IsRequired();
            modelBuilder.Entity<Document>().Property(p => p.DateUploaded).IsRequired().HasDefaultValue(DateTime.UtcNow);

            // Question
            modelBuilder.Entity<Question>().Property(p => p.Description).IsRequired().HasMaxLength(1000);
            modelBuilder.Entity<Question>().Property(p => p.DivisionId).IsRequired();
            modelBuilder.Entity<Question>().Property(p => p.QuestionBlockId).IsRequired();
            modelBuilder.Entity<Question>().Property(p => p.QuestionSectionId).IsRequired();

            // QuestionBlock
            modelBuilder.Entity<QuestionBlock>().Property(p => p.Name).IsRequired().HasMaxLength(100);

            // QuestionSection
            modelBuilder.Entity<QuestionSection>().Property(p => p.Name).IsRequired().HasMaxLength(100);

            // Role
            modelBuilder.Entity<Role>().Property(p => p.Name).IsRequired().HasMaxLength(100);

            // Shop
            modelBuilder.Entity<Shop>().Property(p => p.Name).IsRequired().HasMaxLength(250);

            // User
            modelBuilder.Entity<User>().Property(u => u.Username).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<User>().Property(u => u.Email).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<User>().Property(u => u.PasswordHash).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<User>().Property(u => u.Salt).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<User>().Property(u => u.DateCreated).IsRequired().HasDefaultValue(DateTime.UtcNow);
            modelBuilder.Entity<User>().Property(u => u.DivisionId).IsRequired();

            // UserRole
            modelBuilder.Entity<UserRole>().Property(ur => ur.RoleId).IsRequired();
            modelBuilder.Entity<UserRole>().Property(ur => ur.UserId).IsRequired();
        }
    }
}