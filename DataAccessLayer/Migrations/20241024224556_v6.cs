using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class v6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__CourseEnr__Cours__5F7E2DAC",
                table: "CourseEnrollments");

            migrationBuilder.DropForeignKey(
                name: "FK__CourseEnr__Stude__5E8A0973",
                table: "CourseEnrollments");

            migrationBuilder.DropForeignKey(
                name: "FK__Courses__Departm__367C1819",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK__Courses__Prerequ__3493CFA7",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK__CourseTea__Cours__625A9A57",
                table: "CourseTeaching");

            migrationBuilder.DropForeignKey(
                name: "FK__CourseTea__Profe__634EBE90",
                table: "CourseTeaching");

            migrationBuilder.DropForeignKey(
                name: "FK__CourseTeac__TAID__6442E2C9",
                table: "CourseTeaching");

            migrationBuilder.DropForeignKey(
                name: "FK__FeedbackR__Feedb__56E8E7AB",
                table: "FeedbackResponses");

            migrationBuilder.DropForeignKey(
                name: "FK__FeedbackR__Submi__57DD0BE4",
                table: "FeedbackResponses");

            migrationBuilder.DropForeignKey(
                name: "FK_Material_Courses_CourseId",
                table: "Material");

            migrationBuilder.DropForeignKey(
                name: "FK__Notificat__SentB__51300E55",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK__Notificat__SentT__5224328E",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK__PasswordR__Admin__5BAD9CC8",
                table: "PasswordResetTickets");

            migrationBuilder.DropForeignKey(
                name: "FK__PasswordR__Stude__5AB9788F",
                table: "PasswordResetTickets");

            migrationBuilder.DropForeignKey(
                name: "FK__Professor__Depar__2645B050",
                table: "Professors");

            migrationBuilder.DropForeignKey(
                name: "FK__Professor__Profe__245D67DE",
                table: "Professors");

            migrationBuilder.DropForeignKey(
                name: "FK__Questions__TestI__46B27FE2",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK__Students__Depart__2B0A656D",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK__Students__Nation__29221CFB",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK__Submissio__Stude__3F115E1A",
                table: "Submissions");

            migrationBuilder.DropForeignKey(
                name: "FK__Submissio__TaskI__3E1D39E1",
                table: "Submissions");

            migrationBuilder.DropForeignKey(
                name: "FK__Tasks__AssignedB__3B40CD36",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK__Tasks__CourseID__395884C4",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK__TeachingA__Assis__30C33EC3",
                table: "TeachingAssistants");

            migrationBuilder.DropForeignKey(
                name: "FK__TeachingA__Depar__2FCF1A8A",
                table: "TeachingAssistants");

            migrationBuilder.DropForeignKey(
                name: "FK__TeachingAs__TAID__2DE6D218",
                table: "TeachingAssistants");

            migrationBuilder.DropForeignKey(
                name: "FK__Tests__CourseID__42E1EEFE",
                table: "Tests");

            migrationBuilder.DropForeignKey(
                name: "FK__Tests__MadeBy__41EDCAC5",
                table: "Tests");

            migrationBuilder.DropForeignKey(
                name: "FK__TestSubmi__Stude__4A8310C6",
                table: "TestSubmissions");

            migrationBuilder.DropForeignKey(
                name: "FK__TestSubmi__TestI__498EEC8D",
                table: "TestSubmissions");

            migrationBuilder.DropForeignKey(
                name: "FK__Timetable__Cours__4D5F7D71",
                table: "Timetables");

            migrationBuilder.DropForeignKey(
                name: "FK__Timetable__Profe__4E53A1AA",
                table: "Timetables");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Timetabl__68413F4011C547EC",
                table: "Timetables");

            migrationBuilder.DropPrimaryKey(
                name: "PK__TestSubm__BB934B8F6CF7B93B",
                table: "TestSubmissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Tests__8CC33100E061DD7A",
                table: "Tests");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Teaching__B43FE34A3EE17177",
                table: "TeachingAssistants");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Tasks__7C6949D17FEFD15C",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Submissi__449EE1052A1041B0",
                table: "Submissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Students__E9AA321BAB929904",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Question__0DC06F8CB985952F",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Professo__9003596931DA9444",
                table: "Professors");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Password__712CC627AFF1D053",
                table: "PasswordResetTickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Notifica__20CF2E32989922FE",
                table: "Notifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Feedback__6A4BEDF6151BB7B9",
                table: "Feedbacks");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Feedback__1AAA640C0178008C",
                table: "FeedbackResponses");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Departme__B2079BCDD8AB6AAA",
                table: "Departments");

            migrationBuilder.DropPrimaryKey(
                name: "PK__CourseTe__69B6BA5EECE67C25",
                table: "CourseTeaching");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Courses__C92D7187B969954B",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK__CourseEn__7F6877FB4D772154",
                table: "CourseEnrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Applicat__E9AA321B20B301FC",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Material",
                table: "Material");

            migrationBuilder.RenameTable(
                name: "Material",
                newName: "Materials");

            migrationBuilder.RenameIndex(
                name: "UQ__Departme__A25C5AA7E8C24511",
                table: "Departments",
                newName: "UQ_Departme_A25C5AA7E8C24511");

            migrationBuilder.RenameIndex(
                name: "UQ__Departme__737584F674071129",
                table: "Departments",
                newName: "UQ_Departme_737584F674071129");

            migrationBuilder.RenameIndex(
                name: "UQ__Courses__A25C5AA766F2798B",
                table: "Courses",
                newName: "UQ_Courses_A25C5AA766F2798B");

            migrationBuilder.RenameIndex(
                name: "IX_Material_CourseId",
                table: "Materials",
                newName: "IX_Materials_CourseId");

            migrationBuilder.AlterColumn<string>(
                name: "TaskLink",
                table: "Tasks",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Timetabl_68413F4011C547EC",
                table: "Timetables",
                column: "TimetableID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestSubm_BB934B8F6CF7B93B",
                table: "TestSubmissions",
                column: "TestSubmissionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tests_8CC33100E061DD7A",
                table: "Tests",
                column: "TestID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teaching_B43FE34A3EE17177",
                table: "TeachingAssistants",
                column: "TAID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks_7C6949D17FEFD15C",
                table: "Tasks",
                column: "TaskID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Submissi_449EE1052A1041B0",
                table: "Submissions",
                column: "SubmissionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students_E9AA321BAB929904",
                table: "Students",
                column: "NationalID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Question_0DC06F8CB985952F",
                table: "Questions",
                column: "QuestionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Professo_9003596931DA9444",
                table: "Professors",
                column: "ProfessorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Password_712CC627AFF1D053",
                table: "PasswordResetTickets",
                column: "TicketID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notifica_20CF2E32989922FE",
                table: "Notifications",
                column: "NotificationID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feedback_6A4BEDF6151BB7B9",
                table: "Feedbacks",
                column: "FeedbackID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feedback_1AAA640C0178008C",
                table: "FeedbackResponses",
                column: "ResponseID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departme_B2079BCDD8AB6AAA",
                table: "Departments",
                column: "DepartmentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseTe_69B6BA5EECE67C25",
                table: "CourseTeaching",
                column: "TeachingID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses_C92D7187B969954B",
                table: "Courses",
                column: "CourseID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseEn_7F6877FB4D772154",
                table: "CourseEnrollments",
                column: "EnrollmentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Applicat_E9AA321B20B301FC",
                table: "AspNetUsers",
                column: "NationalID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Materials",
                table: "Materials",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseEnrCours_5F7E2DAC",
                table: "CourseEnrollments",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseEnrStude_5E8A0973",
                table: "CourseEnrollments",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "NationalID");

            migrationBuilder.AddForeignKey(
                name: "FK_CoursesDepartm_367C1819",
                table: "Courses",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_CoursesPrerequ_3493CFA7",
                table: "Courses",
                column: "PrerequisiteCourseId",
                principalTable: "Courses",
                principalColumn: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTeaCours_625A9A57",
                table: "CourseTeaching",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTeaProfe_634EBE90",
                table: "CourseTeaching",
                column: "ProfessorID",
                principalTable: "Professors",
                principalColumn: "ProfessorID");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTeacTAID_6442E2C9",
                table: "CourseTeaching",
                column: "TAID",
                principalTable: "TeachingAssistants",
                principalColumn: "TAID");

            migrationBuilder.AddForeignKey(
                name: "FK_FeedbackRFeedb_56E8E7AB",
                table: "FeedbackResponses",
                column: "FeedbackID",
                principalTable: "Feedbacks",
                principalColumn: "FeedbackID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FeedbackRSubmi_57DD0BE4",
                table: "FeedbackResponses",
                column: "SubmittedByStudentID",
                principalTable: "Students",
                principalColumn: "NationalID");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Courses_CourseId",
                table: "Materials",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NotificatSentB_51300E55",
                table: "Notifications",
                column: "SentBy",
                principalTable: "AspNetUsers",
                principalColumn: "NationalID");

            migrationBuilder.AddForeignKey(
                name: "FK_NotificatSentT_5224328E",
                table: "Notifications",
                column: "SentTo",
                principalTable: "AspNetUsers",
                principalColumn: "NationalID");

            migrationBuilder.AddForeignKey(
                name: "FK_PasswordRAdmin_5BAD9CC8",
                table: "PasswordResetTickets",
                column: "AdminID",
                principalTable: "AspNetUsers",
                principalColumn: "NationalID");

            migrationBuilder.AddForeignKey(
                name: "FK_PasswordRStude_5AB9788F",
                table: "PasswordResetTickets",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "NationalID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessorDepar_2645B050",
                table: "Professors",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessorProfe_245D67DE",
                table: "Professors",
                column: "ProfessorID",
                principalTable: "AspNetUsers",
                principalColumn: "NationalID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionsTestI_46B27FE2",
                table: "Questions",
                column: "TestID",
                principalTable: "Tests",
                principalColumn: "TestID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsDepart_2B0A656D",
                table: "Students",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsNation_29221CFB",
                table: "Students",
                column: "NationalID",
                principalTable: "AspNetUsers",
                principalColumn: "NationalID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubmissioStude_3F115E1A",
                table: "Submissions",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "NationalID");

            migrationBuilder.AddForeignKey(
                name: "FK_SubmissioTaskI_3E1D39E1",
                table: "Submissions",
                column: "TaskID",
                principalTable: "Tasks",
                principalColumn: "TaskID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TasksAssignedB_3B40CD36",
                table: "Tasks",
                column: "AssignedByTAID",
                principalTable: "TeachingAssistants",
                principalColumn: "TAID");

            migrationBuilder.AddForeignKey(
                name: "FK_TasksCourseID_395884C4",
                table: "Tasks",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeachingAAssis_30C33EC3",
                table: "TeachingAssistants",
                column: "AssistingProfessorID",
                principalTable: "AspNetUsers",
                principalColumn: "NationalID");

            migrationBuilder.AddForeignKey(
                name: "FK_TeachingADepar_2FCF1A8A",
                table: "TeachingAssistants",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_TeachingAsTAID_2DE6D218",
                table: "TeachingAssistants",
                column: "TAID",
                principalTable: "AspNetUsers",
                principalColumn: "NationalID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestsCourseID_42E1EEFE",
                table: "Tests",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestsMadeBy_41EDCAC5",
                table: "Tests",
                column: "MadeBy",
                principalTable: "AspNetUsers",
                principalColumn: "NationalID");

            migrationBuilder.AddForeignKey(
                name: "FK_TestSubmiStude_4A8310C6",
                table: "TestSubmissions",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "NationalID");

            migrationBuilder.AddForeignKey(
                name: "FK_TestSubmiTestI_498EEC8D",
                table: "TestSubmissions",
                column: "TestID",
                principalTable: "Tests",
                principalColumn: "TestID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimetableCours_4D5F7D71",
                table: "Timetables",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimetableProfe_4E53A1AA",
                table: "Timetables",
                column: "ProfessorID",
                principalTable: "Professors",
                principalColumn: "ProfessorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseEnrCours_5F7E2DAC",
                table: "CourseEnrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseEnrStude_5E8A0973",
                table: "CourseEnrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_CoursesDepartm_367C1819",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_CoursesPrerequ_3493CFA7",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseTeaCours_625A9A57",
                table: "CourseTeaching");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseTeaProfe_634EBE90",
                table: "CourseTeaching");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseTeacTAID_6442E2C9",
                table: "CourseTeaching");

            migrationBuilder.DropForeignKey(
                name: "FK_FeedbackRFeedb_56E8E7AB",
                table: "FeedbackResponses");

            migrationBuilder.DropForeignKey(
                name: "FK_FeedbackRSubmi_57DD0BE4",
                table: "FeedbackResponses");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Courses_CourseId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_NotificatSentB_51300E55",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_NotificatSentT_5224328E",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_PasswordRAdmin_5BAD9CC8",
                table: "PasswordResetTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_PasswordRStude_5AB9788F",
                table: "PasswordResetTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessorDepar_2645B050",
                table: "Professors");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessorProfe_245D67DE",
                table: "Professors");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionsTestI_46B27FE2",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsDepart_2B0A656D",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsNation_29221CFB",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_SubmissioStude_3F115E1A",
                table: "Submissions");

            migrationBuilder.DropForeignKey(
                name: "FK_SubmissioTaskI_3E1D39E1",
                table: "Submissions");

            migrationBuilder.DropForeignKey(
                name: "FK_TasksAssignedB_3B40CD36",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_TasksCourseID_395884C4",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_TeachingAAssis_30C33EC3",
                table: "TeachingAssistants");

            migrationBuilder.DropForeignKey(
                name: "FK_TeachingADepar_2FCF1A8A",
                table: "TeachingAssistants");

            migrationBuilder.DropForeignKey(
                name: "FK_TeachingAsTAID_2DE6D218",
                table: "TeachingAssistants");

            migrationBuilder.DropForeignKey(
                name: "FK_TestsCourseID_42E1EEFE",
                table: "Tests");

            migrationBuilder.DropForeignKey(
                name: "FK_TestsMadeBy_41EDCAC5",
                table: "Tests");

            migrationBuilder.DropForeignKey(
                name: "FK_TestSubmiStude_4A8310C6",
                table: "TestSubmissions");

            migrationBuilder.DropForeignKey(
                name: "FK_TestSubmiTestI_498EEC8D",
                table: "TestSubmissions");

            migrationBuilder.DropForeignKey(
                name: "FK_TimetableCours_4D5F7D71",
                table: "Timetables");

            migrationBuilder.DropForeignKey(
                name: "FK_TimetableProfe_4E53A1AA",
                table: "Timetables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Timetabl_68413F4011C547EC",
                table: "Timetables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestSubm_BB934B8F6CF7B93B",
                table: "TestSubmissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tests_8CC33100E061DD7A",
                table: "Tests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teaching_B43FE34A3EE17177",
                table: "TeachingAssistants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks_7C6949D17FEFD15C",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Submissi_449EE1052A1041B0",
                table: "Submissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students_E9AA321BAB929904",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Question_0DC06F8CB985952F",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Professo_9003596931DA9444",
                table: "Professors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Password_712CC627AFF1D053",
                table: "PasswordResetTickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notifica_20CF2E32989922FE",
                table: "Notifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Feedback_6A4BEDF6151BB7B9",
                table: "Feedbacks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Feedback_1AAA640C0178008C",
                table: "FeedbackResponses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departme_B2079BCDD8AB6AAA",
                table: "Departments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseTe_69B6BA5EECE67C25",
                table: "CourseTeaching");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses_C92D7187B969954B",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseEn_7F6877FB4D772154",
                table: "CourseEnrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Applicat_E9AA321B20B301FC",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Materials",
                table: "Materials");

            migrationBuilder.RenameTable(
                name: "Materials",
                newName: "Material");

            migrationBuilder.RenameIndex(
                name: "UQ_Departme_A25C5AA7E8C24511",
                table: "Departments",
                newName: "UQ__Departme__A25C5AA7E8C24511");

            migrationBuilder.RenameIndex(
                name: "UQ_Departme_737584F674071129",
                table: "Departments",
                newName: "UQ__Departme__737584F674071129");

            migrationBuilder.RenameIndex(
                name: "UQ_Courses_A25C5AA766F2798B",
                table: "Courses",
                newName: "UQ__Courses__A25C5AA766F2798B");

            migrationBuilder.RenameIndex(
                name: "IX_Materials_CourseId",
                table: "Material",
                newName: "IX_Material_CourseId");

            migrationBuilder.AlterColumn<string>(
                name: "TaskLink",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AddPrimaryKey(
                name: "PK__Timetabl__68413F4011C547EC",
                table: "Timetables",
                column: "TimetableID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__TestSubm__BB934B8F6CF7B93B",
                table: "TestSubmissions",
                column: "TestSubmissionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Tests__8CC33100E061DD7A",
                table: "Tests",
                column: "TestID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Teaching__B43FE34A3EE17177",
                table: "TeachingAssistants",
                column: "TAID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Tasks__7C6949D17FEFD15C",
                table: "Tasks",
                column: "TaskID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Submissi__449EE1052A1041B0",
                table: "Submissions",
                column: "SubmissionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Students__E9AA321BAB929904",
                table: "Students",
                column: "NationalID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Question__0DC06F8CB985952F",
                table: "Questions",
                column: "QuestionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Professo__9003596931DA9444",
                table: "Professors",
                column: "ProfessorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Password__712CC627AFF1D053",
                table: "PasswordResetTickets",
                column: "TicketID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Notifica__20CF2E32989922FE",
                table: "Notifications",
                column: "NotificationID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Feedback__6A4BEDF6151BB7B9",
                table: "Feedbacks",
                column: "FeedbackID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Feedback__1AAA640C0178008C",
                table: "FeedbackResponses",
                column: "ResponseID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Departme__B2079BCDD8AB6AAA",
                table: "Departments",
                column: "DepartmentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__CourseTe__69B6BA5EECE67C25",
                table: "CourseTeaching",
                column: "TeachingID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Courses__C92D7187B969954B",
                table: "Courses",
                column: "CourseID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__CourseEn__7F6877FB4D772154",
                table: "CourseEnrollments",
                column: "EnrollmentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Applicat__E9AA321B20B301FC",
                table: "AspNetUsers",
                column: "NationalID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Material",
                table: "Material",
                column: "Id");

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
                name: "FK__Courses__Prerequ__3493CFA7",
                table: "Courses",
                column: "PrerequisiteCourseId",
                principalTable: "Courses",
                principalColumn: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK__CourseTea__Cours__625A9A57",
                table: "CourseTeaching",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK__FeedbackR__Feedb__56E8E7AB",
                table: "FeedbackResponses",
                column: "FeedbackID",
                principalTable: "Feedbacks",
                principalColumn: "FeedbackID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__FeedbackR__Submi__57DD0BE4",
                table: "FeedbackResponses",
                column: "SubmittedByStudentID",
                principalTable: "Students",
                principalColumn: "NationalID");

            migrationBuilder.AddForeignKey(
                name: "FK_Material_Courses_CourseId",
                table: "Material",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Notificat__SentB__51300E55",
                table: "Notifications",
                column: "SentBy",
                principalTable: "AspNetUsers",
                principalColumn: "NationalID");

            migrationBuilder.AddForeignKey(
                name: "FK__Notificat__SentT__5224328E",
                table: "Notifications",
                column: "SentTo",
                principalTable: "AspNetUsers",
                principalColumn: "NationalID");

            migrationBuilder.AddForeignKey(
                name: "FK__PasswordR__Admin__5BAD9CC8",
                table: "PasswordResetTickets",
                column: "AdminID",
                principalTable: "AspNetUsers",
                principalColumn: "NationalID");

            migrationBuilder.AddForeignKey(
                name: "FK__PasswordR__Stude__5AB9788F",
                table: "PasswordResetTickets",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "NationalID");

            migrationBuilder.AddForeignKey(
                name: "FK__Professor__Depar__2645B050",
                table: "Professors",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK__Professor__Profe__245D67DE",
                table: "Professors",
                column: "ProfessorID",
                principalTable: "AspNetUsers",
                principalColumn: "NationalID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Questions__TestI__46B27FE2",
                table: "Questions",
                column: "TestID",
                principalTable: "Tests",
                principalColumn: "TestID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Students__Depart__2B0A656D",
                table: "Students",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK__Students__Nation__29221CFB",
                table: "Students",
                column: "NationalID",
                principalTable: "AspNetUsers",
                principalColumn: "NationalID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Submissio__Stude__3F115E1A",
                table: "Submissions",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "NationalID");

            migrationBuilder.AddForeignKey(
                name: "FK__Submissio__TaskI__3E1D39E1",
                table: "Submissions",
                column: "TaskID",
                principalTable: "Tasks",
                principalColumn: "TaskID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Tasks__AssignedB__3B40CD36",
                table: "Tasks",
                column: "AssignedByTAID",
                principalTable: "TeachingAssistants",
                principalColumn: "TAID");

            migrationBuilder.AddForeignKey(
                name: "FK__Tasks__CourseID__395884C4",
                table: "Tasks",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__TeachingA__Assis__30C33EC3",
                table: "TeachingAssistants",
                column: "AssistingProfessorID",
                principalTable: "AspNetUsers",
                principalColumn: "NationalID");

            migrationBuilder.AddForeignKey(
                name: "FK__TeachingA__Depar__2FCF1A8A",
                table: "TeachingAssistants",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK__TeachingAs__TAID__2DE6D218",
                table: "TeachingAssistants",
                column: "TAID",
                principalTable: "AspNetUsers",
                principalColumn: "NationalID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Tests__CourseID__42E1EEFE",
                table: "Tests",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Tests__MadeBy__41EDCAC5",
                table: "Tests",
                column: "MadeBy",
                principalTable: "AspNetUsers",
                principalColumn: "NationalID");

            migrationBuilder.AddForeignKey(
                name: "FK__TestSubmi__Stude__4A8310C6",
                table: "TestSubmissions",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "NationalID");

            migrationBuilder.AddForeignKey(
                name: "FK__TestSubmi__TestI__498EEC8D",
                table: "TestSubmissions",
                column: "TestID",
                principalTable: "Tests",
                principalColumn: "TestID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Timetable__Cours__4D5F7D71",
                table: "Timetables",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Timetable__Profe__4E53A1AA",
                table: "Timetables",
                column: "ProfessorID",
                principalTable: "Professors",
                principalColumn: "ProfessorID");
        }
    }
}
