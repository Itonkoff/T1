using System;
using System.ComponentModel;
using Api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Api.Contexts {
    public partial class DatabaseContext : IdentityDbContext<User, Role, Guid> {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AcademicLevel> AcademicLevel { get; set; }
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<BookHasStudent> BookHasStudent { get; set; }
        public virtual DbSet<CanteenBalance> CanteenBalance { get; set; }
        public virtual DbSet<CanteenPriceList> CanteenPriceList { get; set; }
        public virtual DbSet<DaysAllowable> DaysAllowable { get; set; }
        public virtual DbSet<Module> Module { get; set; }
        public virtual DbSet<ModuleHasAcademicLevel> ModuleHasAcademicLevel { get; set; }
        public virtual DbSet<ModuleHasAcademicLevelHasWeekDay> ModuleHasAcademicLevelHasWeekDay { get; set; }
        public virtual DbSet<ModuleHasProgram> ModuleHasProgram { get; set; }
        public virtual DbSet<PenaltyRate> PenaltyRate { get; set; }
        public virtual DbSet<StudentProgram> Program { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<Student> Student { get; set; }

        public virtual DbSet<StudentHasModuleHasAcademicLevelHasWeekDay> StudentHasModuleHasAcademicLevelHasWeekDay
        {
            get;
            set;
        }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<WeekDay> WeekDay { get; set; }

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

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("book", "mtengure");

                entity.HasIndex(e => e.DaysAllowable)
                    .HasName("fk_book_days_allowable1_idx");

                entity.HasIndex(e => e.PenaltyRate)
                    .HasName("fk_book_penalty_rate1_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasColumnName("author")
                    .HasMaxLength(45);

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.DaysAllowable).HasColumnName("days_allowable");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.PenaltyRate).HasColumnName("penalty_rate");

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasMaxLength(45);

                entity.HasOne(d => d.DaysAllowableNavigation)
                    .WithMany(p => p.Book)
                    .HasForeignKey(d => d.DaysAllowable)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("book$fk_book_days_allowable1");

                entity.HasOne(d => d.PenaltyRateNavigation)
                    .WithMany(p => p.Book)
                    .HasForeignKey(d => d.PenaltyRate)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("book$fk_book_penalty_rate1");
            });

            modelBuilder.Entity<BookHasStudent>(entity =>
            {
                entity.HasKey(e => new {e.Book, e.Student, e.DateBorrowed})
                    .HasName("PK_book_has_student_book");

                entity.ToTable("book_has_student", "mtengure");

                entity.HasIndex(e => e.Book)
                    .HasName("fk_book_has_student_book1_idx");

                entity.HasIndex(e => e.Student)
                    .HasName("fk_book_has_student_student1_idx");


                entity.Property(e => e.Book).HasColumnName("book");

                entity.Property(e => e.Student).HasColumnName("student");

                entity.Property(e => e.DateBorrowed)
                    .HasColumnName("date_borrowed")
                    .HasColumnType("date");

                entity.Property(e => e.Paid).HasColumnName("paid");


                entity.HasOne(d => d.BookNavigation)
                    .WithMany(p => p.BookHasStudent)
                    .HasForeignKey(d => d.Book)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("book_has_student$fk_book_has_student_book1");

                entity.HasOne(d => d.StudentNavigation)
                    .WithMany(p => p.BookHasStudent)
                    .HasForeignKey(d => d.Student)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("book_has_student$fk_book_has_student_student1");
            });

            modelBuilder.Entity<CanteenBalance>(entity =>
            {
                entity.HasKey(e => e.Student)
                    .HasName("PK_canteen_balance_student");

                entity.ToTable("canteen_balance", "mtengure");

                entity.HasIndex(e => e.Student)
                    .HasName("fk_canteen_balance_student1_idx");


                entity.Property(e => e.Student)
                    .HasColumnName("student")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cr).HasColumnName("cr");

                entity.Property(e => e.Dr).HasColumnName("dr");


                entity.HasOne(d => d.StudentNavigation)
                    .WithOne(p => p.CanteenBalance)
                    .HasForeignKey<CanteenBalance>(d => d.Student)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("canteen_balance$fk_canteen_balance_student1");
            });

            modelBuilder.Entity<CanteenPriceList>(entity =>
            {
                entity.ToTable("canteen_price_list", "mtengure");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Meal)
                    .IsRequired()
                    .HasColumnName("meal")
                    .HasMaxLength(45);

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasColumnName("price")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<DaysAllowable>(entity =>
            {
                entity.ToTable("days_allowable", "mtengure");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.ToTable("module", "mtengure");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<ModuleHasAcademicLevel>(entity =>
            {
                entity.HasKey(e => new {e.Module, e.AcademicLevel})
                    .HasName("PK_module_has_academic_level_module");

                entity.ToTable("module_has_academic_level", "mtengure");

                entity.HasIndex(e => e.AcademicLevel)
                    .HasName("fk_module_has_academic_level_academic_level1_idx");

                entity.HasIndex(e => e.Module)
                    .HasName("fk_module_has_academic_level_module1_idx");

                entity.Property(e => e.Module).HasColumnName("module");

                entity.Property(e => e.AcademicLevel).HasColumnName("academic_level");

                entity.HasOne(d => d.AcademicLevelNavigation)
                    .WithMany(p => p.ModuleHasAcademicLevel)
                    .HasForeignKey(d => d.AcademicLevel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("module_has_academic_level$fk_module_has_academic_level_academic_level1");

                entity.HasOne(d => d.ModuleNavigation)
                    .WithMany(p => p.ModuleHasAcademicLevel)
                    .HasForeignKey(d => d.Module)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("module_has_academic_level$fk_module_has_academic_level_module1");
            });

            modelBuilder.Entity<ModuleHasAcademicLevelHasWeekDay>(entity =>
            {
                entity.HasKey(e => new {e.Module, e.AcademicLevel, e.WeekDay})
                    .HasName("PK_module_has_academic_level_has_week_day_module");

                entity.ToTable("module_has_academic_level_has_week_day", "mtengure");

                entity.HasIndex(e => e.WeekDay)
                    .HasName("fk_module_has_academic_level_has_week_day_week_day1_idx");

                entity.HasIndex(e => new {e.Module, e.AcademicLevel})
                    .HasName("fk_module_has_academic_level_has_week_day_module_has_academ_idx");

                entity.Property(e => e.Module).HasColumnName("module");

                entity.Property(e => e.AcademicLevel).HasColumnName("academic_level");

                entity.Property(e => e.WeekDay).HasColumnName("week_day");

                entity.Property(e => e.Timel).HasColumnName("timel");

                entity.HasOne(d => d.WeekDayNavigation)
                    .WithMany(p => p.ModuleHasAcademicLevelHasWeekDay)
                    .HasForeignKey(d => d.WeekDay)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName(
                        "module_has_academic_level_has_week_day$fk_module_has_academic_level_has_week_day_week_day1");

                entity.HasOne(d => d.ModuleHasAcademicLevel)
                    .WithMany(p => p.ModuleHasAcademicLevelHasWeekDay)
                    .HasForeignKey(d => new {d.Module, d.AcademicLevel})
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName(
                        "module_has_academic_level_has_week_day$fk_module_has_academic_level_has_week_day_module_has_academic1");
            });

            modelBuilder.Entity<ModuleHasProgram>(entity =>
            {
                entity.HasKey(e => new {e.Module, e.Program})
                    .HasName("PK_module_has_program_module");

                entity.ToTable("module_has_program", "mtengure");

                entity.HasIndex(e => e.Module)
                    .HasName("fk_module_has_program_module1_idx");

                entity.HasIndex(e => e.Program)
                    .HasName("fk_module_has_program_program1_idx");

                entity.Property(e => e.Module).HasColumnName("module");

                entity.Property(e => e.Program).HasColumnName("program");

                entity.HasOne(d => d.ModuleNavigation)
                    .WithMany(p => p.ModuleHasProgram)
                    .HasForeignKey(d => d.Module)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("module_has_program$fk_module_has_program_module1");

                entity.HasOne(d => d.StudentProgramNavigation)
                    .WithMany(p => p.ModuleHasProgram)
                    .HasForeignKey(d => d.Program)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("module_has_program$fk_module_has_program_program1");
            });

            modelBuilder.Entity<PenaltyRate>(entity =>
            {
                entity.ToTable("penalty_rate", "mtengure");

                entity.Property(e => e.Id).HasColumnName("id");

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
            
            modelBuilder.Entity<Staff>(entity =>
            {
                entity.ToTable("staff", "mtengure");                

                entity.HasIndex(e => e.UserId)
                    .HasName("fk_student_user1_idx");

                entity.Property(e => e.Id).HasColumnName("id");
                
                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Staff)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("staff$fk_student_user1");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("student", "mtengure");

                entity.HasIndex(e => e.AcademicLevel)
                    .HasName("fk_student_academic_level1_idx");

                entity.HasIndex(e => e.Program)
                    .HasName("fk_student_program1_idx");

                entity.HasIndex(e => e.UserId)
                    .HasName("fk_student_user1_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AcademicLevel).HasColumnName("academic_level");

                entity.Property(e => e.Program).HasColumnName("program");

                entity.Property(e => e.Registered).HasColumnName("registered");

                entity.Property(e => e.UserId).HasColumnName("user_id");

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

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("student$fk_student_user1");
            });

            modelBuilder.Entity<StudentHasModuleHasAcademicLevelHasWeekDay>(entity =>
            {
                entity.HasKey(e => new {e.Student, e.Module, e.AcademicLevel, e.WeekDay, e.Date})
                    .HasName("PK_student_has_module_has_academic_level_has_week_day_student");

                entity.ToTable("student_has_module_has_academic_level_has_week_day", "mtengure");

                entity.HasIndex(e => e.Student)
                    .HasName("fk_student_has_module_has_academic_level_has_week_day_stude_idx");

                entity.HasIndex(e => new {e.Module, e.AcademicLevel, e.WeekDay})
                    .HasName("fk_student_has_module_has_academic_level_has_week_day_modul_idx");

                entity.Property(e => e.Student).HasColumnName("student");

                entity.Property(e => e.Module).HasColumnName("module");

                entity.Property(e => e.AcademicLevel).HasColumnName("academic_level");

                entity.Property(e => e.WeekDay).HasColumnName("week_day");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.HasOne(d => d.StudentNavigation)
                    .WithMany(p => p.StudentHasModuleHasAcademicLevelHasWeekDay)
                    .HasForeignKey(d => d.Student)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName(
                        "student_has_module_has_academic_level_has_week_day$fk_student_has_module_has_academic_level_has_week_day_student1");

                entity.HasOne(d => d.ModuleHasAcademicLevelHasWeekDay)
                    .WithMany(p => p.StudentHasModuleHasAcademicLevelHasWeekDay)
                    .HasForeignKey(d => new {d.Module, d.AcademicLevel, d.WeekDay})
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName(
                        "student_has_module_has_academic_level_has_week_day$fk_student_has_module_has_academic_level_has_week_day_module_1");
            });

            modelBuilder.Entity<WeekDay>(entity =>
            {
                entity.ToTable("week_day", "mtengure");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasMaxLength(45);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}