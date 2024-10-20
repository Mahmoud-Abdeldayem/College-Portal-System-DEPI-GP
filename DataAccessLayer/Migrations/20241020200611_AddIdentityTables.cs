using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentityTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    NationalID = table.Column<string>(type: "char(14)", unicode: false, fixedLength: true, maxLength: 14, nullable: false),
                    RecoveryEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Gender = table.Column<bool>(type: "bit", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Picture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Applicat__E9AA321B20B301FC", x => x.NationalID);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    FeedbackID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Feedback__6A4BEDF6151BB7B9", x => x.FeedbackID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "char(14)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "NationalID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "char(14)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "NationalID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "char(14)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                        principalColumn: "NationalID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "char(14)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "NationalID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    NotificationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SentBy = table.Column<string>(type: "char(14)", unicode: false, fixedLength: true, maxLength: 14, nullable: true),
                    SentTo = table.Column<string>(type: "char(14)", unicode: false, fixedLength: true, maxLength: 14, nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Notifica__20CF2E32989922FE", x => x.NotificationID);
                    table.ForeignKey(
                        name: "FK__Notificat__SentB__51300E55",
                        column: x => x.SentBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "NationalID");
                    table.ForeignKey(
                        name: "FK__Notificat__SentT__5224328E",
                        column: x => x.SentTo,
                        principalTable: "AspNetUsers",
                        principalColumn: "NationalID");
                });

            migrationBuilder.CreateTable(
                name: "CourseEnrollments",
                columns: table => new
                {
                    EnrollmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<string>(type: "char(14)", unicode: false, fixedLength: true, maxLength: 14, nullable: true),
                    CourseID = table.Column<int>(type: "int", nullable: true),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ClassWork = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    FinalGrade = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CourseEn__7F6877FB4D772154", x => x.EnrollmentID);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Hours = table.Column<int>(type: "int", nullable: false),
                    PrerequisiteCourseId = table.Column<int>(type: "int", nullable: true),
                    Semseter = table.Column<bool>(type: "bit", nullable: false),
                    CourseLevel = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: true, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Courses__C92D7187B969954B", x => x.CourseID);
                    table.ForeignKey(
                        name: "FK__Courses__Prerequ__3493CFA7",
                        column: x => x.PrerequisiteCourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseID");
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    TestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalGrade = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    MadeBy = table.Column<string>(type: "char(14)", unicode: false, fixedLength: true, maxLength: 14, nullable: true),
                    CourseID = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Time = table.Column<TimeOnly>(type: "time", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tests__8CC33100E061DD7A", x => x.TestID);
                    table.ForeignKey(
                        name: "FK__Tests__CourseID__42E1EEFE",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Tests__MadeBy__41EDCAC5",
                        column: x => x.MadeBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "NationalID");
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestID = table.Column<int>(type: "int", nullable: true),
                    QuestionNumber = table.Column<int>(type: "int", nullable: false),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grade = table.Column<decimal>(type: "decimal(4,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Question__0DC06F8CB985952F", x => x.QuestionID);
                    table.ForeignKey(
                        name: "FK__Questions__TestI__46B27FE2",
                        column: x => x.TestID,
                        principalTable: "Tests",
                        principalColumn: "TestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseTeaching",
                columns: table => new
                {
                    TeachingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseID = table.Column<int>(type: "int", nullable: true),
                    ProfessorID = table.Column<string>(type: "char(14)", unicode: false, fixedLength: true, maxLength: 14, nullable: true),
                    TAID = table.Column<string>(type: "char(14)", unicode: false, fixedLength: true, maxLength: 14, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CourseTe__69B6BA5EECE67C25", x => x.TeachingID);
                    table.ForeignKey(
                        name: "FK__CourseTea__Cours__625A9A57",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    HeadID = table.Column<string>(type: "char(14)", unicode: false, fixedLength: true, maxLength: 14, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Departme__B2079BCDD8AB6AAA", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "Professors",
                columns: table => new
                {
                    ProfessorID = table.Column<string>(type: "char(14)", unicode: false, fixedLength: true, maxLength: 14, nullable: false),
                    PhDAt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EnterYear = table.Column<int>(type: "int", nullable: false),
                    OfficeLocation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DocUni = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: true, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Professo__9003596931DA9444", x => x.ProfessorID);
                    table.ForeignKey(
                        name: "FK__Professor__Depar__2645B050",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID");
                    table.ForeignKey(
                        name: "FK__Professor__Profe__245D67DE",
                        column: x => x.ProfessorID,
                        principalTable: "AspNetUsers",
                        principalColumn: "NationalID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    NationalID = table.Column<string>(type: "char(14)", unicode: false, fixedLength: true, maxLength: 14, nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    EntryYear = table.Column<DateOnly>(type: "date", nullable: false),
                    GradYear = table.Column<DateOnly>(type: "date", nullable: true),
                    CurrentState = table.Column<bool>(type: "bit", nullable: true),
                    CollegeState = table.Column<bool>(type: "bit", nullable: true),
                    CurrentYear = table.Column<short>(type: "smallint", nullable: true),
                    TotalGPA = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    HoursTaken = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Students__E9AA321BAB929904", x => x.NationalID);
                    table.ForeignKey(
                        name: "FK__Students__Depart__2B0A656D",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK__Students__Nation__29221CFB",
                        column: x => x.NationalID,
                        principalTable: "AspNetUsers",
                        principalColumn: "NationalID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeachingAssistants",
                columns: table => new
                {
                    TAID = table.Column<string>(type: "char(14)", unicode: false, fixedLength: true, maxLength: 14, nullable: false),
                    AcademicDegree = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    University = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Faculty = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: true, defaultValue: 1),
                    AssistingProfessorID = table.Column<string>(type: "char(14)", unicode: false, fixedLength: true, maxLength: 14, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Teaching__B43FE34A3EE17177", x => x.TAID);
                    table.ForeignKey(
                        name: "FK__TeachingA__Assis__30C33EC3",
                        column: x => x.AssistingProfessorID,
                        principalTable: "AspNetUsers",
                        principalColumn: "NationalID");
                    table.ForeignKey(
                        name: "FK__TeachingA__Depar__2FCF1A8A",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID");
                    table.ForeignKey(
                        name: "FK__TeachingAs__TAID__2DE6D218",
                        column: x => x.TAID,
                        principalTable: "AspNetUsers",
                        principalColumn: "NationalID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Timetables",
                columns: table => new
                {
                    TimetableID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseID = table.Column<int>(type: "int", nullable: true),
                    ProfessorID = table.Column<string>(type: "char(14)", unicode: false, fixedLength: true, maxLength: 14, nullable: true),
                    Day = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Time = table.Column<TimeOnly>(type: "time", nullable: false),
                    Duration = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Timetabl__68413F4011C547EC", x => x.TimetableID);
                    table.ForeignKey(
                        name: "FK__Timetable__Cours__4D5F7D71",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Timetable__Profe__4E53A1AA",
                        column: x => x.ProfessorID,
                        principalTable: "Professors",
                        principalColumn: "ProfessorID");
                });

            migrationBuilder.CreateTable(
                name: "FeedbackResponses",
                columns: table => new
                {
                    ResponseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeedbackID = table.Column<int>(type: "int", nullable: true),
                    ResponseText = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SubmittedByStudentID = table.Column<string>(type: "char(14)", unicode: false, fixedLength: true, maxLength: 14, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Feedback__1AAA640C0178008C", x => x.ResponseID);
                    table.ForeignKey(
                        name: "FK__FeedbackR__Feedb__56E8E7AB",
                        column: x => x.FeedbackID,
                        principalTable: "Feedbacks",
                        principalColumn: "FeedbackID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__FeedbackR__Submi__57DD0BE4",
                        column: x => x.SubmittedByStudentID,
                        principalTable: "Students",
                        principalColumn: "NationalID");
                });

            migrationBuilder.CreateTable(
                name: "PasswordResetTickets",
                columns: table => new
                {
                    TicketID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<string>(type: "char(14)", unicode: false, fixedLength: true, maxLength: 14, nullable: true),
                    RequestDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ResetDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    AdminID = table.Column<string>(type: "char(14)", unicode: false, fixedLength: true, maxLength: 14, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Password__712CC627AFF1D053", x => x.TicketID);
                    table.ForeignKey(
                        name: "FK__PasswordR__Admin__5BAD9CC8",
                        column: x => x.AdminID,
                        principalTable: "AspNetUsers",
                        principalColumn: "NationalID");
                    table.ForeignKey(
                        name: "FK__PasswordR__Stude__5AB9788F",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "NationalID");
                });

            migrationBuilder.CreateTable(
                name: "TestSubmissions",
                columns: table => new
                {
                    TestSubmissionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestID = table.Column<int>(type: "int", nullable: true),
                    StudentID = table.Column<string>(type: "char(14)", unicode: false, fixedLength: true, maxLength: 14, nullable: true),
                    SubmissionDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TestSubm__BB934B8F6CF7B93B", x => x.TestSubmissionID);
                    table.ForeignKey(
                        name: "FK__TestSubmi__Stude__4A8310C6",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "NationalID");
                    table.ForeignKey(
                        name: "FK__TestSubmi__TestI__498EEC8D",
                        column: x => x.TestID,
                        principalTable: "Tests",
                        principalColumn: "TestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseID = table.Column<int>(type: "int", nullable: true),
                    Grade = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AssignedByTAID = table.Column<string>(type: "char(14)", unicode: false, fixedLength: true, maxLength: 14, nullable: true),
                    TaskLink = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tasks__7C6949D17FEFD15C", x => x.TaskID);
                    table.ForeignKey(
                        name: "FK__Tasks__AssignedB__3B40CD36",
                        column: x => x.AssignedByTAID,
                        principalTable: "TeachingAssistants",
                        principalColumn: "TAID");
                    table.ForeignKey(
                        name: "FK__Tasks__CourseID__395884C4",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Submissions",
                columns: table => new
                {
                    SubmissionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskID = table.Column<int>(type: "int", nullable: true),
                    StudentID = table.Column<string>(type: "char(14)", unicode: false, fixedLength: true, maxLength: 14, nullable: true),
                    SubmissionLink = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SubmissionDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Submissi__449EE1052A1041B0", x => x.SubmissionID);
                    table.ForeignKey(
                        name: "FK__Submissio__Stude__3F115E1A",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "NationalID");
                    table.ForeignKey(
                        name: "FK__Submissio__TaskI__3E1D39E1",
                        column: x => x.TaskID,
                        principalTable: "Tasks",
                        principalColumn: "TaskID",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserName",
                table: "AspNetUsers",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CourseEnrollments_CourseID",
                table: "CourseEnrollments",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseEnrollments_StudentID",
                table: "CourseEnrollments",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DepartmentID",
                table: "Courses",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_PrerequisiteCourseId",
                table: "Courses",
                column: "PrerequisiteCourseId");

            migrationBuilder.CreateIndex(
                name: "UQ__Courses__A25C5AA766F2798B",
                table: "Courses",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseTeaching_CourseID",
                table: "CourseTeaching",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTeaching_ProfessorID",
                table: "CourseTeaching",
                column: "ProfessorID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTeaching_TAID",
                table: "CourseTeaching",
                column: "TAID");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_HeadID",
                table: "Departments",
                column: "HeadID");

            migrationBuilder.CreateIndex(
                name: "UQ__Departme__737584F674071129",
                table: "Departments",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Departme__A25C5AA7E8C24511",
                table: "Departments",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FeedbackResponses_FeedbackID",
                table: "FeedbackResponses",
                column: "FeedbackID");

            migrationBuilder.CreateIndex(
                name: "IX_FeedbackResponses_SubmittedByStudentID",
                table: "FeedbackResponses",
                column: "SubmittedByStudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_SentBy",
                table: "Notifications",
                column: "SentBy");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_SentTo",
                table: "Notifications",
                column: "SentTo");

            migrationBuilder.CreateIndex(
                name: "IX_PasswordResetTickets_AdminID",
                table: "PasswordResetTickets",
                column: "AdminID");

            migrationBuilder.CreateIndex(
                name: "IX_PasswordResetTickets_StudentID",
                table: "PasswordResetTickets",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Professors_DepartmentID",
                table: "Professors",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TestID",
                table: "Questions",
                column: "TestID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_DepartmentID",
                table: "Students",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_StudentID",
                table: "Submissions",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_TaskID",
                table: "Submissions",
                column: "TaskID");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AssignedByTAID",
                table: "Tasks",
                column: "AssignedByTAID");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CourseID",
                table: "Tasks",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_TeachingAssistants_AssistingProfessorID",
                table: "TeachingAssistants",
                column: "AssistingProfessorID");

            migrationBuilder.CreateIndex(
                name: "IX_TeachingAssistants_DepartmentID",
                table: "TeachingAssistants",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_CourseID",
                table: "Tests",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_MadeBy",
                table: "Tests",
                column: "MadeBy");

            migrationBuilder.CreateIndex(
                name: "IX_TestSubmissions_StudentID",
                table: "TestSubmissions",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_TestSubmissions_TestID",
                table: "TestSubmissions",
                column: "TestID");

            migrationBuilder.CreateIndex(
                name: "IX_Timetables_CourseID",
                table: "Timetables",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Timetables_ProfessorID",
                table: "Timetables",
                column: "ProfessorID");

            migrationBuilder.AddForeignKey(
                name: "FK__CourseEnr__Cours__5F7E2DAC",
                table: "CourseEnrollments",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__CourseEnr__Stude__5E8A0973",
                table: "CourseEnrollments",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "NationalID");

            migrationBuilder.AddForeignKey(
                name: "FK__Courses__Departm__367C1819",
                table: "Courses",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK__CourseTea__Profe__634EBE90",
                table: "CourseTeaching",
                column: "ProfessorID",
                principalTable: "Professors",
                principalColumn: "ProfessorID");

            migrationBuilder.AddForeignKey(
                name: "FK__CourseTeac__TAID__6442E2C9",
                table: "CourseTeaching",
                column: "TAID",
                principalTable: "TeachingAssistants",
                principalColumn: "TAID");

            migrationBuilder.AddForeignKey(
                name: "FK_Dept_Head_Prof",
                table: "Departments",
                column: "HeadID",
                principalTable: "Professors",
                principalColumn: "ProfessorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Professor__Profe__245D67DE",
                table: "Professors");

            migrationBuilder.DropForeignKey(
                name: "FK__Professor__Depar__2645B050",
                table: "Professors");

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
                name: "CourseEnrollments");

            migrationBuilder.DropTable(
                name: "CourseTeaching");

            migrationBuilder.DropTable(
                name: "FeedbackResponses");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "PasswordResetTickets");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Submissions");

            migrationBuilder.DropTable(
                name: "TestSubmissions");

            migrationBuilder.DropTable(
                name: "Timetables");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "TeachingAssistants");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Professors");
        }
    }
}
