using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "mtengure");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    NationalId = table.Column<string>(nullable: true),
                    PhysicalAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "academic_level",
                schema: "mtengure",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    value = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_academic_level", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "canteen_price_list",
                schema: "mtengure",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    meal = table.Column<string>(maxLength: 45, nullable: false),
                    price = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_canteen_price_list", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "days_allowable",
                schema: "mtengure",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_days_allowable", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "module",
                schema: "mtengure",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_module", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "penalty_rate",
                schema: "mtengure",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_penalty_rate", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "program",
                schema: "mtengure",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(maxLength: 200, nullable: false),
                    description = table.Column<string>(maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_program", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "week_day",
                schema: "mtengure",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    value = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_week_day", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "module_has_academic_level",
                schema: "mtengure",
                columns: table => new
                {
                    module = table.Column<int>(nullable: false),
                    academic_level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_module_has_academic_level_module", x => new { x.module, x.academic_level });
                    table.ForeignKey(
                        name: "module_has_academic_level$fk_module_has_academic_level_academic_level1",
                        column: x => x.academic_level,
                        principalSchema: "mtengure",
                        principalTable: "academic_level",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "module_has_academic_level$fk_module_has_academic_level_module1",
                        column: x => x.module,
                        principalSchema: "mtengure",
                        principalTable: "module",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "book",
                schema: "mtengure",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    version = table.Column<string>(maxLength: 45, nullable: true),
                    author = table.Column<string>(maxLength: 45, nullable: false),
                    count = table.Column<int>(nullable: false),
                    days_allowable = table.Column<int>(nullable: false),
                    penalty_rate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book", x => x.id);
                    table.ForeignKey(
                        name: "book$fk_book_days_allowable1",
                        column: x => x.days_allowable,
                        principalSchema: "mtengure",
                        principalTable: "days_allowable",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "book$fk_book_penalty_rate1",
                        column: x => x.penalty_rate,
                        principalSchema: "mtengure",
                        principalTable: "penalty_rate",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "module_has_program",
                schema: "mtengure",
                columns: table => new
                {
                    module = table.Column<int>(nullable: false),
                    program = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_module_has_program_module", x => new { x.module, x.program });
                    table.ForeignKey(
                        name: "module_has_program$fk_module_has_program_module1",
                        column: x => x.module,
                        principalSchema: "mtengure",
                        principalTable: "module",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "module_has_program$fk_module_has_program_program1",
                        column: x => x.program,
                        principalSchema: "mtengure",
                        principalTable: "program",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "student",
                schema: "mtengure",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    academic_level = table.Column<int>(nullable: false),
                    program = table.Column<int>(nullable: false),
                    registered = table.Column<short>(nullable: false),
                    user_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student", x => x.id);
                    table.ForeignKey(
                        name: "student$fk_student_academic_level1",
                        column: x => x.academic_level,
                        principalSchema: "mtengure",
                        principalTable: "academic_level",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "student$fk_student_program1",
                        column: x => x.program,
                        principalSchema: "mtengure",
                        principalTable: "program",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "student$fk_student_user1",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "module_has_academic_level_has_week_day",
                schema: "mtengure",
                columns: table => new
                {
                    module = table.Column<int>(nullable: false),
                    academic_level = table.Column<int>(nullable: false),
                    week_day = table.Column<int>(nullable: false),
                    timel = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_module_has_academic_level_has_week_day_module", x => new { x.module, x.academic_level, x.week_day });
                    table.ForeignKey(
                        name: "module_has_academic_level_has_week_day$fk_module_has_academic_level_has_week_day_week_day1",
                        column: x => x.week_day,
                        principalSchema: "mtengure",
                        principalTable: "week_day",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "module_has_academic_level_has_week_day$fk_module_has_academic_level_has_week_day_module_has_academic1",
                        columns: x => new { x.module, x.academic_level },
                        principalSchema: "mtengure",
                        principalTable: "module_has_academic_level",
                        principalColumns: new[] { "module", "academic_level" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "book_has_student",
                schema: "mtengure",
                columns: table => new
                {
                    book = table.Column<int>(nullable: false),
                    student = table.Column<int>(nullable: false),
                    date_borrowed = table.Column<DateTime>(type: "date", nullable: false),
                    paid = table.Column<short>(nullable: true),
                    user_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book_has_student_book", x => new { x.book, x.student, x.date_borrowed });
                    table.ForeignKey(
                        name: "book_has_student$fk_book_has_student_book1",
                        column: x => x.book,
                        principalSchema: "mtengure",
                        principalTable: "book",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "book_has_student$fk_book_has_student_student1",
                        column: x => x.student,
                        principalSchema: "mtengure",
                        principalTable: "student",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "book_has_student$fk_book_has_student_user1",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "canteen_balance",
                schema: "mtengure",
                columns: table => new
                {
                    student = table.Column<int>(nullable: false),
                    cr = table.Column<double>(nullable: true),
                    dr = table.Column<double>(nullable: true),
                    user_id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_canteen_balance_student", x => x.student);
                    table.ForeignKey(
                        name: "canteen_balance$fk_canteen_balance_student1",
                        column: x => x.student,
                        principalSchema: "mtengure",
                        principalTable: "student",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "canteen_balance$fk_canteen_balance_user1",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "student_has_module_has_academic_level_has_week_day",
                schema: "mtengure",
                columns: table => new
                {
                    student = table.Column<int>(nullable: false),
                    module = table.Column<int>(nullable: false),
                    academic_level = table.Column<int>(nullable: false),
                    week_day = table.Column<int>(nullable: false),
                    date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student_has_module_has_academic_level_has_week_day_student", x => new { x.student, x.module, x.academic_level, x.week_day, x.date });
                    table.ForeignKey(
                        name: "student_has_module_has_academic_level_has_week_day$fk_student_has_module_has_academic_level_has_week_day_student1",
                        column: x => x.student,
                        principalSchema: "mtengure",
                        principalTable: "student",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "student_has_module_has_academic_level_has_week_day$fk_student_has_module_has_academic_level_has_week_day_module_1",
                        columns: x => new { x.module, x.academic_level, x.week_day },
                        principalSchema: "mtengure",
                        principalTable: "module_has_academic_level_has_week_day",
                        principalColumns: new[] { "module", "academic_level", "week_day" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "fk_book_days_allowable1_idx",
                schema: "mtengure",
                table: "book",
                column: "days_allowable");

            migrationBuilder.CreateIndex(
                name: "fk_book_penalty_rate1_idx",
                schema: "mtengure",
                table: "book",
                column: "penalty_rate");

            migrationBuilder.CreateIndex(
                name: "fk_book_has_student_book1_idx",
                schema: "mtengure",
                table: "book_has_student",
                column: "book");

            migrationBuilder.CreateIndex(
                name: "fk_book_has_student_student1_idx",
                schema: "mtengure",
                table: "book_has_student",
                column: "student");

            migrationBuilder.CreateIndex(
                name: "fk_book_has_student_user1_idx",
                schema: "mtengure",
                table: "book_has_student",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "fk_canteen_balance_student1_idx",
                schema: "mtengure",
                table: "canteen_balance",
                column: "student");

            migrationBuilder.CreateIndex(
                name: "fk_canteen_balance_user1_idx",
                schema: "mtengure",
                table: "canteen_balance",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "fk_module_has_academic_level_academic_level1_idx",
                schema: "mtengure",
                table: "module_has_academic_level",
                column: "academic_level");

            migrationBuilder.CreateIndex(
                name: "fk_module_has_academic_level_module1_idx",
                schema: "mtengure",
                table: "module_has_academic_level",
                column: "module");

            migrationBuilder.CreateIndex(
                name: "fk_module_has_academic_level_has_week_day_week_day1_idx",
                schema: "mtengure",
                table: "module_has_academic_level_has_week_day",
                column: "week_day");

            migrationBuilder.CreateIndex(
                name: "fk_module_has_academic_level_has_week_day_module_has_academ_idx",
                schema: "mtengure",
                table: "module_has_academic_level_has_week_day",
                columns: new[] { "module", "academic_level" });

            migrationBuilder.CreateIndex(
                name: "fk_module_has_program_module1_idx",
                schema: "mtengure",
                table: "module_has_program",
                column: "module");

            migrationBuilder.CreateIndex(
                name: "fk_module_has_program_program1_idx",
                schema: "mtengure",
                table: "module_has_program",
                column: "program");

            migrationBuilder.CreateIndex(
                name: "fk_student_academic_level1_idx",
                schema: "mtengure",
                table: "student",
                column: "academic_level");

            migrationBuilder.CreateIndex(
                name: "fk_student_program1_idx",
                schema: "mtengure",
                table: "student",
                column: "program");

            migrationBuilder.CreateIndex(
                name: "fk_student_user1_idx",
                schema: "mtengure",
                table: "student",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "fk_student_has_module_has_academic_level_has_week_day_stude_idx",
                schema: "mtengure",
                table: "student_has_module_has_academic_level_has_week_day",
                column: "student");

            migrationBuilder.CreateIndex(
                name: "fk_student_has_module_has_academic_level_has_week_day_modul_idx",
                schema: "mtengure",
                table: "student_has_module_has_academic_level_has_week_day",
                columns: new[] { "module", "academic_level", "week_day" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "book_has_student",
                schema: "mtengure");

            migrationBuilder.DropTable(
                name: "canteen_balance",
                schema: "mtengure");

            migrationBuilder.DropTable(
                name: "canteen_price_list",
                schema: "mtengure");

            migrationBuilder.DropTable(
                name: "module_has_program",
                schema: "mtengure");

            migrationBuilder.DropTable(
                name: "student_has_module_has_academic_level_has_week_day",
                schema: "mtengure");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "book",
                schema: "mtengure");

            migrationBuilder.DropTable(
                name: "student",
                schema: "mtengure");

            migrationBuilder.DropTable(
                name: "module_has_academic_level_has_week_day",
                schema: "mtengure");

            migrationBuilder.DropTable(
                name: "days_allowable",
                schema: "mtengure");

            migrationBuilder.DropTable(
                name: "penalty_rate",
                schema: "mtengure");

            migrationBuilder.DropTable(
                name: "program",
                schema: "mtengure");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "week_day",
                schema: "mtengure");

            migrationBuilder.DropTable(
                name: "module_has_academic_level",
                schema: "mtengure");

            migrationBuilder.DropTable(
                name: "academic_level",
                schema: "mtengure");

            migrationBuilder.DropTable(
                name: "module",
                schema: "mtengure");
        }
    }
}
