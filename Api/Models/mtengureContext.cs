using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Api.Models
{
    public partial class mtengureContext : DbContext
    {
        public mtengureContext()
        {
        }

        public mtengureContext(DbContextOptions<mtengureContext> options)
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
        public virtual DbSet<Program> Program { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentHasModuleHasAcademicLevelHasWeekDay> StudentHasModuleHasAcademicLevelHasWeekDay { get; set; }
        public virtual DbSet<WeekDay> WeekDay { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-RMM46MK;Database=mtengure;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcademicLevel>(entity =>
            {
                entity.HasKey(e => e.IdacademicLevel)
                    .HasName("PK_academic_level_idacademic_level");

                entity.ToTable("academic_level", "mtengure");

                entity.Property(e => e.IdacademicLevel)
                    .HasColumnName("idacademic_level")
                    .ValueGeneratedNever();

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.Idbook)
                    .HasName("PK_book_idbook");

                entity.ToTable("book", "mtengure");

                entity.HasIndex(e => e.DaysAllowable)
                    .HasName("fk_book_days_allowable1_idx");

                entity.HasIndex(e => e.PenaltyRate)
                    .HasName("fk_book_penalty_rate1_idx");

                entity.Property(e => e.Idbook).HasColumnName("idbook");

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
                entity.HasKey(e => new { e.Book, e.Student, e.Date })
                    .HasName("PK_book_has_student_book");

                entity.ToTable("book_has_student", "mtengure");

                entity.HasIndex(e => e.Book)
                    .HasName("fk_book_has_student_book1_idx");

                entity.HasIndex(e => e.Student)
                    .HasName("fk_book_has_student_student1_idx");

                entity.Property(e => e.Book).HasColumnName("book");

                entity.Property(e => e.Student).HasColumnName("student");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Paid).HasColumnName("paid");

                entity.Property(e => e.UserId).HasColumnName("user_id");

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

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.StudentNavigation)
                    .WithOne(p => p.CanteenBalance)
                    .HasForeignKey<CanteenBalance>(d => d.Student)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("canteen_balance$fk_canteen_balance_student1");
            });

            modelBuilder.Entity<CanteenPriceList>(entity =>
            {
                entity.HasKey(e => e.IdcanteenPriceList)
                    .HasName("PK_canteen_price_list_idcanteen_price_list");

                entity.ToTable("canteen_price_list", "mtengure");

                entity.Property(e => e.IdcanteenPriceList).HasColumnName("idcanteen_price_list");

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
                entity.HasKey(e => e.DaysAllowablecol)
                    .HasName("PK_days_allowable_days_allowablecol");

                entity.ToTable("days_allowable", "mtengure");

                entity.Property(e => e.DaysAllowablecol)
                    .HasColumnName("days_allowablecol")
                    .ValueGeneratedNever();

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.HasKey(e => e.Idmodule)
                    .HasName("PK_module_idmodule");

                entity.ToTable("module", "mtengure");

                entity.Property(e => e.Idmodule).HasColumnName("idmodule");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<ModuleHasAcademicLevel>(entity =>
            {
                entity.HasKey(e => new { e.Module, e.AcademicLevel })
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
                entity.HasKey(e => new { e.Module, e.AcademicLevel, e.WeekDay })
                    .HasName("PK_module_has_academic_level_has_week_day_module");

                entity.ToTable("module_has_academic_level_has_week_day", "mtengure");

                entity.HasIndex(e => e.WeekDay)
                    .HasName("fk_module_has_academic_level_has_week_day_week_day1_idx");

                entity.HasIndex(e => new { e.Module, e.AcademicLevel })
                    .HasName("fk_module_has_academic_level_has_week_day_module_has_academ_idx");

                entity.Property(e => e.Module).HasColumnName("module");

                entity.Property(e => e.AcademicLevel).HasColumnName("academic_level");

                entity.Property(e => e.WeekDay).HasColumnName("week_day");

                entity.Property(e => e.Timel).HasColumnName("timel");

                entity.HasOne(d => d.WeekDayNavigation)
                    .WithMany(p => p.ModuleHasAcademicLevelHasWeekDay)
                    .HasForeignKey(d => d.WeekDay)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("module_has_academic_level_has_week_day$fk_module_has_academic_level_has_week_day_week_day1");

                entity.HasOne(d => d.ModuleHasAcademicLevel)
                    .WithMany(p => p.ModuleHasAcademicLevelHasWeekDay)
                    .HasForeignKey(d => new { d.Module, d.AcademicLevel })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("module_has_academic_level_has_week_day$fk_module_has_academic_level_has_week_day_module_has_academic1");
            });

            modelBuilder.Entity<ModuleHasProgram>(entity =>
            {
                entity.HasKey(e => new { e.ModuleIdmodule, e.ProgramIdprogram })
                    .HasName("PK_module_has_program_module_idmodule");

                entity.ToTable("module_has_program", "mtengure");

                entity.HasIndex(e => e.ModuleIdmodule)
                    .HasName("fk_module_has_program_module1_idx");

                entity.HasIndex(e => e.ProgramIdprogram)
                    .HasName("fk_module_has_program_program1_idx");

                entity.Property(e => e.ModuleIdmodule).HasColumnName("module_idmodule");

                entity.Property(e => e.ProgramIdprogram).HasColumnName("program_idprogram");

                entity.HasOne(d => d.ModuleIdmoduleNavigation)
                    .WithMany(p => p.ModuleHasProgram)
                    .HasForeignKey(d => d.ModuleIdmodule)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("module_has_program$fk_module_has_program_module1");

                entity.HasOne(d => d.ProgramIdprogramNavigation)
                    .WithMany(p => p.ModuleHasProgram)
                    .HasForeignKey(d => d.ProgramIdprogram)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("module_has_program$fk_module_has_program_program1");
            });

            modelBuilder.Entity<PenaltyRate>(entity =>
            {
                entity.HasKey(e => e.IdpenaltyRate)
                    .HasName("PK_penalty_rate_idpenalty_rate");

                entity.ToTable("penalty_rate", "mtengure");

                entity.Property(e => e.IdpenaltyRate).HasColumnName("idpenalty_rate");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<Program>(entity =>
            {
                entity.HasKey(e => e.Idprogram)
                    .HasName("PK_program_idprogram");

                entity.ToTable("program", "mtengure");

                entity.Property(e => e.Idprogram).HasColumnName("idprogram");

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
                entity.HasKey(e => e.Idstudent)
                    .HasName("PK_student_idstudent");

                entity.ToTable("student", "mtengure");

                entity.HasIndex(e => e.AcademicLevel)
                    .HasName("fk_student_academic_level1_idx");

                entity.HasIndex(e => e.Program)
                    .HasName("fk_student_program1_idx");

                entity.Property(e => e.Idstudent).HasColumnName("idstudent");

                entity.Property(e => e.AcademicLevel).HasColumnName("academic_level");

                entity.Property(e => e.Program).HasColumnName("program");

                entity.Property(e => e.Registered).HasColumnName("registered");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.AcademicLevelNavigation)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.AcademicLevel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("student$fk_student_academic_level1");

                entity.HasOne(d => d.ProgramNavigation)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.Program)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("student$fk_student_program1");
            });

            modelBuilder.Entity<StudentHasModuleHasAcademicLevelHasWeekDay>(entity =>
            {
                entity.HasKey(e => new { e.StudentIdstudent, e.Module, e.AcademicLevel, e.WeekDay, e.Date })
                    .HasName("PK_student_has_module_has_academic_level_has_week_day_student_idstudent");

                entity.ToTable("student_has_module_has_academic_level_has_week_day", "mtengure");

                entity.HasIndex(e => e.StudentIdstudent)
                    .HasName("fk_student_has_module_has_academic_level_has_week_day_stude_idx");

                entity.HasIndex(e => new { e.Module, e.AcademicLevel, e.WeekDay })
                    .HasName("fk_student_has_module_has_academic_level_has_week_day_modul_idx");

                entity.Property(e => e.StudentIdstudent).HasColumnName("student_idstudent");

                entity.Property(e => e.Module).HasColumnName("module");

                entity.Property(e => e.AcademicLevel).HasColumnName("academic_level");

                entity.Property(e => e.WeekDay).HasColumnName("week_day");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.HasOne(d => d.StudentIdstudentNavigation)
                    .WithMany(p => p.StudentHasModuleHasAcademicLevelHasWeekDay)
                    .HasForeignKey(d => d.StudentIdstudent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("student_has_module_has_academic_level_has_week_day$fk_student_has_module_has_academic_level_has_week_day_student1");

                entity.HasOne(d => d.ModuleHasAcademicLevelHasWeekDay)
                    .WithMany(p => p.StudentHasModuleHasAcademicLevelHasWeekDay)
                    .HasForeignKey(d => new { d.Module, d.AcademicLevel, d.WeekDay })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("student_has_module_has_academic_level_has_week_day$fk_student_has_module_has_academic_level_has_week_day_module_1");
            });

            modelBuilder.Entity<WeekDay>(entity =>
            {
                entity.HasKey(e => e.IdweekDays)
                    .HasName("PK_week_day_idweek_days");

                entity.ToTable("week_day", "mtengure");

                entity.Property(e => e.IdweekDays).HasColumnName("idweek_days");

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
