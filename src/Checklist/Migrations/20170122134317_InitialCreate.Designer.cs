using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Checklist.Infrastructure.Services;

namespace Checklist.Migrations
{
    [DbContext(typeof(ChecklistContext))]
    [Migration("20170122134317_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Checklist.Models.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DocumentId");

                    b.Property<int>("QuestionId");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(5000);

                    b.HasKey("Id");

                    b.HasIndex("DocumentId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("Checklist.Models.AnswerType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("AnswerType");
                });

            modelBuilder.Entity("Checklist.Models.Division", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Division");
                });

            modelBuilder.Entity("Checklist.Models.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Approved");

                    b.Property<DateTime?>("DateApproved");

                    b.Property<DateTime?>("DateChanged");

                    b.Property<DateTime>("DateUploaded")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2017, 1, 22, 13, 43, 17, 680, DateTimeKind.Utc));

                    b.Property<int>("ShopId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ShopId");

                    b.HasIndex("UserId");

                    b.ToTable("Document");
                });

            modelBuilder.Entity("Checklist.Models.Error", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Message");

                    b.Property<string>("StackTrace");

                    b.HasKey("Id");

                    b.ToTable("Error");
                });

            modelBuilder.Entity("Checklist.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<int>("DivisionId");

                    b.Property<int>("QuestionBlockId");

                    b.Property<int>("QuestionSectionId");

                    b.HasKey("Id");

                    b.HasIndex("DivisionId");

                    b.HasIndex("QuestionBlockId");

                    b.HasIndex("QuestionSectionId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("Checklist.Models.QuestionBlock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("QuestionBlock");
                });

            modelBuilder.Entity("Checklist.Models.QuestionSection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("QuestionSection");
                });

            modelBuilder.Entity("Checklist.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Checklist.Models.Shop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("Shop");
                });

            modelBuilder.Entity("Checklist.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2017, 1, 22, 13, 43, 17, 687, DateTimeKind.Utc));

                    b.Property<int>("DivisionId");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<bool>("IsLocked");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("DivisionId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Checklist.Models.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("RoleId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("Checklist.Models.Answer", b =>
                {
                    b.HasOne("Checklist.Models.Document", "Document")
                        .WithMany("Answers")
                        .HasForeignKey("DocumentId");

                    b.HasOne("Checklist.Models.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId");
                });

            modelBuilder.Entity("Checklist.Models.Document", b =>
                {
                    b.HasOne("Checklist.Models.Shop", "Shop")
                        .WithMany()
                        .HasForeignKey("ShopId");

                    b.HasOne("Checklist.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Checklist.Models.Question", b =>
                {
                    b.HasOne("Checklist.Models.Division", "Division")
                        .WithMany()
                        .HasForeignKey("DivisionId");

                    b.HasOne("Checklist.Models.QuestionBlock", "QuestionBlock")
                        .WithMany()
                        .HasForeignKey("QuestionBlockId");

                    b.HasOne("Checklist.Models.QuestionSection", "QuestionSection")
                        .WithMany()
                        .HasForeignKey("QuestionSectionId");
                });

            modelBuilder.Entity("Checklist.Models.User", b =>
                {
                    b.HasOne("Checklist.Models.Division", "Division")
                        .WithMany()
                        .HasForeignKey("DivisionId");
                });

            modelBuilder.Entity("Checklist.Models.UserRole", b =>
                {
                    b.HasOne("Checklist.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("Checklist.Models.User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId");
                });
        }
    }
}
