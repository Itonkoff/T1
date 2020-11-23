using System;
using System.ComponentModel;
using System.IO;
using RegistrationModule.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace RegistrationModule.Contexts
{
    public partial class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            var confuguration = builder.Build();
            optionsBuilder.UseSqlServer(confuguration["ConnectionStrings:DefaultConnection"]);
        }

        public virtual DbSet<AcademicLevel> AcademicLevel { get; set; }
        public virtual DbSet<StudentProgram> Program { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AcademicLevel>(entity =>
            {
                entity.ToTable("academic_level", "mtengure");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<StudentProgram>(entity =>
            {
                entity.ToTable("program", "mtengure");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(45);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("student", "mtengure");

                entity.HasIndex(e => e.AcademicLevel)
                    .HasName("fk_student_academic_level1_idx");

                entity.HasIndex(e => e.Program)
                    .HasName("fk_student_program1_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AcademicLevel).HasColumnName("academic_level");

                entity.Property(e => e.Program).HasColumnName("program");

                entity.Property(e => e.Registered).HasColumnName("registered");

                entity.HasOne(d => d.AcademicLevelNavigation)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.AcademicLevel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("student$fk_student_academic_level1");

                entity.HasOne(d => d.StudentProgramNavigation)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.Program)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("student$fk_student_program1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
