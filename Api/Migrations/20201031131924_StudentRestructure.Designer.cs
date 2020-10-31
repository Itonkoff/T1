﻿// <auto-generated />
using System;
using Api.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Api.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20201031131924_StudentRestructure")]
    partial class StudentRestructure
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Api.Models.AcademicLevel", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<double>("Value")
                        .HasColumnName("value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("academic_level","mtengure");
                });

            modelBuilder.Entity("Api.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnName("author")
                        .HasColumnType("nvarchar(45)")
                        .HasMaxLength(45);

                    b.Property<int>("Count")
                        .HasColumnName("count")
                        .HasColumnType("int");

                    b.Property<int>("DaysAllowable")
                        .HasColumnName("days_allowable")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<int>("PenaltyRate")
                        .HasColumnName("penalty_rate")
                        .HasColumnType("int");

                    b.Property<string>("Version")
                        .HasColumnName("version")
                        .HasColumnType("nvarchar(45)")
                        .HasMaxLength(45);

                    b.HasKey("Id");

                    b.HasIndex("DaysAllowable")
                        .HasName("fk_book_days_allowable1_idx");

                    b.HasIndex("PenaltyRate")
                        .HasName("fk_book_penalty_rate1_idx");

                    b.ToTable("book","mtengure");
                });

            modelBuilder.Entity("Api.Models.BookHasStudent", b =>
                {
                    b.Property<int>("Book")
                        .HasColumnName("book")
                        .HasColumnType("int");

                    b.Property<int>("Student")
                        .HasColumnName("student")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateBorrowed")
                        .HasColumnName("date_borrowed")
                        .HasColumnType("date");

                    b.Property<short?>("Paid")
                        .HasColumnName("paid")
                        .HasColumnType("smallint");

                    b.Property<Guid>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Book", "Student", "DateBorrowed")
                        .HasName("PK_book_has_student_book");

                    b.HasIndex("Book")
                        .HasName("fk_book_has_student_book1_idx");

                    b.HasIndex("Student")
                        .HasName("fk_book_has_student_student1_idx");

                    b.HasIndex("UserId")
                        .HasName("fk_book_has_student_user1_idx");

                    b.ToTable("book_has_student","mtengure");
                });

            modelBuilder.Entity("Api.Models.CanteenBalance", b =>
                {
                    b.Property<int>("Student")
                        .HasColumnName("student")
                        .HasColumnType("int");

                    b.Property<double?>("Cr")
                        .HasColumnName("cr")
                        .HasColumnType("float");

                    b.Property<double?>("Dr")
                        .HasColumnName("dr")
                        .HasColumnType("float");

                    b.Property<Guid?>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Student")
                        .HasName("PK_canteen_balance_student");

                    b.HasIndex("Student")
                        .HasName("fk_canteen_balance_student1_idx");

                    b.HasIndex("UserId")
                        .HasName("fk_canteen_balance_user1_idx");

                    b.ToTable("canteen_balance","mtengure");
                });

            modelBuilder.Entity("Api.Models.CanteenPriceList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Meal")
                        .IsRequired()
                        .HasColumnName("meal")
                        .HasColumnType("nvarchar(45)")
                        .HasMaxLength(45);

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnName("price")
                        .HasColumnType("nvarchar(45)")
                        .HasMaxLength(45);

                    b.HasKey("Id");

                    b.ToTable("canteen_price_list","mtengure");
                });

            modelBuilder.Entity("Api.Models.DaysAllowable", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnName("value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("days_allowable","mtengure");
                });

            modelBuilder.Entity("Api.Models.Module", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("module","mtengure");
                });

            modelBuilder.Entity("Api.Models.ModuleHasAcademicLevel", b =>
                {
                    b.Property<int>("Module")
                        .HasColumnName("module")
                        .HasColumnType("int");

                    b.Property<int>("AcademicLevel")
                        .HasColumnName("academic_level")
                        .HasColumnType("int");

                    b.HasKey("Module", "AcademicLevel")
                        .HasName("PK_module_has_academic_level_module");

                    b.HasIndex("AcademicLevel")
                        .HasName("fk_module_has_academic_level_academic_level1_idx");

                    b.HasIndex("Module")
                        .HasName("fk_module_has_academic_level_module1_idx");

                    b.ToTable("module_has_academic_level","mtengure");
                });

            modelBuilder.Entity("Api.Models.ModuleHasAcademicLevelHasWeekDay", b =>
                {
                    b.Property<int>("Module")
                        .HasColumnName("module")
                        .HasColumnType("int");

                    b.Property<int>("AcademicLevel")
                        .HasColumnName("academic_level")
                        .HasColumnType("int");

                    b.Property<int>("WeekDay")
                        .HasColumnName("week_day")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Timel")
                        .HasColumnName("timel")
                        .HasColumnType("time");

                    b.HasKey("Module", "AcademicLevel", "WeekDay")
                        .HasName("PK_module_has_academic_level_has_week_day_module");

                    b.HasIndex("WeekDay")
                        .HasName("fk_module_has_academic_level_has_week_day_week_day1_idx");

                    b.HasIndex("Module", "AcademicLevel")
                        .HasName("fk_module_has_academic_level_has_week_day_module_has_academ_idx");

                    b.ToTable("module_has_academic_level_has_week_day","mtengure");
                });

            modelBuilder.Entity("Api.Models.ModuleHasProgram", b =>
                {
                    b.Property<int>("Module")
                        .HasColumnName("module")
                        .HasColumnType("int");

                    b.Property<int>("Program")
                        .HasColumnName("program")
                        .HasColumnType("int");

                    b.HasKey("Module", "Program")
                        .HasName("PK_module_has_program_module");

                    b.HasIndex("Module")
                        .HasName("fk_module_has_program_module1_idx");

                    b.HasIndex("Program")
                        .HasName("fk_module_has_program_program1_idx");

                    b.ToTable("module_has_program","mtengure");
                });

            modelBuilder.Entity("Api.Models.PenaltyRate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Value")
                        .HasColumnName("value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("penalty_rate","mtengure");
                });

            modelBuilder.Entity("Api.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Api.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AcademicLevel")
                        .HasColumnName("academic_level")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhysicalAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Program")
                        .HasColumnName("program")
                        .HasColumnType("int");

                    b.Property<bool>("Registered")
                        .HasColumnName("registered")
                        .HasColumnType("bit");

                    b.Property<Guid?>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AcademicLevel")
                        .HasName("fk_student_academic_level1_idx");

                    b.HasIndex("Program")
                        .HasName("fk_student_program1_idx");

                    b.HasIndex("UserId")
                        .HasName("fk_student_user1_idx");

                    b.ToTable("student","mtengure");
                });

            modelBuilder.Entity("Api.Models.StudentHasModuleHasAcademicLevelHasWeekDay", b =>
                {
                    b.Property<int>("Student")
                        .HasColumnName("student")
                        .HasColumnType("int");

                    b.Property<int>("Module")
                        .HasColumnName("module")
                        .HasColumnType("int");

                    b.Property<int>("AcademicLevel")
                        .HasColumnName("academic_level")
                        .HasColumnType("int");

                    b.Property<int>("WeekDay")
                        .HasColumnName("week_day")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnName("date")
                        .HasColumnType("date");

                    b.HasKey("Student", "Module", "AcademicLevel", "WeekDay", "Date")
                        .HasName("PK_student_has_module_has_academic_level_has_week_day_student");

                    b.HasIndex("Student")
                        .HasName("fk_student_has_module_has_academic_level_has_week_day_stude_idx");

                    b.HasIndex("Module", "AcademicLevel", "WeekDay")
                        .HasName("fk_student_has_module_has_academic_level_has_week_day_modul_idx");

                    b.ToTable("student_has_module_has_academic_level_has_week_day","mtengure");
                });

            modelBuilder.Entity("Api.Models.StudentProgram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("nvarchar(45)")
                        .HasMaxLength(45);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("program","mtengure");
                });

            modelBuilder.Entity("Api.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Api.Models.WeekDay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnName("value")
                        .HasColumnType("nvarchar(45)")
                        .HasMaxLength(45);

                    b.HasKey("Id");

                    b.ToTable("week_day","mtengure");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Api.Models.Book", b =>
                {
                    b.HasOne("Api.Models.DaysAllowable", "DaysAllowableNavigation")
                        .WithMany("Book")
                        .HasForeignKey("DaysAllowable")
                        .HasConstraintName("book$fk_book_days_allowable1")
                        .IsRequired();

                    b.HasOne("Api.Models.PenaltyRate", "PenaltyRateNavigation")
                        .WithMany("Book")
                        .HasForeignKey("PenaltyRate")
                        .HasConstraintName("book$fk_book_penalty_rate1")
                        .IsRequired();
                });

            modelBuilder.Entity("Api.Models.BookHasStudent", b =>
                {
                    b.HasOne("Api.Models.Book", "BookNavigation")
                        .WithMany("BookHasStudent")
                        .HasForeignKey("Book")
                        .HasConstraintName("book_has_student$fk_book_has_student_book1")
                        .IsRequired();

                    b.HasOne("Api.Models.Student", "StudentNavigation")
                        .WithMany("BookHasStudent")
                        .HasForeignKey("Student")
                        .HasConstraintName("book_has_student$fk_book_has_student_student1")
                        .IsRequired();

                    b.HasOne("Api.Models.User", "User")
                        .WithMany("BookHasStudent")
                        .HasForeignKey("UserId")
                        .HasConstraintName("book_has_student$fk_book_has_student_user1")
                        .IsRequired();
                });

            modelBuilder.Entity("Api.Models.CanteenBalance", b =>
                {
                    b.HasOne("Api.Models.Student", "StudentNavigation")
                        .WithOne("CanteenBalance")
                        .HasForeignKey("Api.Models.CanteenBalance", "Student")
                        .HasConstraintName("canteen_balance$fk_canteen_balance_student1")
                        .IsRequired();

                    b.HasOne("Api.Models.User", "User")
                        .WithMany("CanteenBalance")
                        .HasForeignKey("UserId")
                        .HasConstraintName("canteen_balance$fk_canteen_balance_user1");
                });

            modelBuilder.Entity("Api.Models.ModuleHasAcademicLevel", b =>
                {
                    b.HasOne("Api.Models.AcademicLevel", "AcademicLevelNavigation")
                        .WithMany("ModuleHasAcademicLevel")
                        .HasForeignKey("AcademicLevel")
                        .HasConstraintName("module_has_academic_level$fk_module_has_academic_level_academic_level1")
                        .IsRequired();

                    b.HasOne("Api.Models.Module", "ModuleNavigation")
                        .WithMany("ModuleHasAcademicLevel")
                        .HasForeignKey("Module")
                        .HasConstraintName("module_has_academic_level$fk_module_has_academic_level_module1")
                        .IsRequired();
                });

            modelBuilder.Entity("Api.Models.ModuleHasAcademicLevelHasWeekDay", b =>
                {
                    b.HasOne("Api.Models.WeekDay", "WeekDayNavigation")
                        .WithMany("ModuleHasAcademicLevelHasWeekDay")
                        .HasForeignKey("WeekDay")
                        .HasConstraintName("module_has_academic_level_has_week_day$fk_module_has_academic_level_has_week_day_week_day1")
                        .IsRequired();

                    b.HasOne("Api.Models.ModuleHasAcademicLevel", "ModuleHasAcademicLevel")
                        .WithMany("ModuleHasAcademicLevelHasWeekDay")
                        .HasForeignKey("Module", "AcademicLevel")
                        .HasConstraintName("module_has_academic_level_has_week_day$fk_module_has_academic_level_has_week_day_module_has_academic1")
                        .IsRequired();
                });

            modelBuilder.Entity("Api.Models.ModuleHasProgram", b =>
                {
                    b.HasOne("Api.Models.Module", "ModuleNavigation")
                        .WithMany("ModuleHasProgram")
                        .HasForeignKey("Module")
                        .HasConstraintName("module_has_program$fk_module_has_program_module1")
                        .IsRequired();

                    b.HasOne("Api.Models.StudentProgram", "StudentProgramNavigation")
                        .WithMany("ModuleHasProgram")
                        .HasForeignKey("Program")
                        .HasConstraintName("module_has_program$fk_module_has_program_program1")
                        .IsRequired();
                });

            modelBuilder.Entity("Api.Models.Student", b =>
                {
                    b.HasOne("Api.Models.AcademicLevel", "AcademicLevelNavigation")
                        .WithMany("Student")
                        .HasForeignKey("AcademicLevel")
                        .HasConstraintName("student$fk_student_academic_level1")
                        .IsRequired();

                    b.HasOne("Api.Models.StudentProgram", "StudentProgramNavigation")
                        .WithMany("Student")
                        .HasForeignKey("Program")
                        .HasConstraintName("student$fk_student_program1")
                        .IsRequired();

                    b.HasOne("Api.Models.User", "User")
                        .WithMany("Student")
                        .HasForeignKey("UserId")
                        .HasConstraintName("student$fk_student_user1");
                });

            modelBuilder.Entity("Api.Models.StudentHasModuleHasAcademicLevelHasWeekDay", b =>
                {
                    b.HasOne("Api.Models.Student", "StudentNavigation")
                        .WithMany("StudentHasModuleHasAcademicLevelHasWeekDay")
                        .HasForeignKey("Student")
                        .HasConstraintName("student_has_module_has_academic_level_has_week_day$fk_student_has_module_has_academic_level_has_week_day_student1")
                        .IsRequired();

                    b.HasOne("Api.Models.ModuleHasAcademicLevelHasWeekDay", "ModuleHasAcademicLevelHasWeekDay")
                        .WithMany("StudentHasModuleHasAcademicLevelHasWeekDay")
                        .HasForeignKey("Module", "AcademicLevel", "WeekDay")
                        .HasConstraintName("student_has_module_has_academic_level_has_week_day$fk_student_has_module_has_academic_level_has_week_day_module_1")
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Api.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("Api.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Api.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Api.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("Api.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
