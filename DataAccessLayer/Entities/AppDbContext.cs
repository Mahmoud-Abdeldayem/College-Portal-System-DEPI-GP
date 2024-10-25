using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Entities;

public partial class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public AppDbContext(){}

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

    #region Tables Set
    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseEnrollment> CourseEnrollments { get; set; }

    public virtual DbSet<CourseTeaching> CourseTeachings { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<FeedbackResponse> FeedbackResponses { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<PasswordResetTicket> PasswordResetTickets { get; set; }

    public virtual DbSet<Professor> Professors { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Submission> Submissions { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<TeachingAssistant> TeachingAssistants { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    public virtual DbSet<TestSubmission> TestSubmissions { get; set; }

    public virtual DbSet<Timetable> Timetables { get; set; }    
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ApplicationUser>(entity =>
        {
            entity.HasKey(e => e.NationalId).HasName("PK_Applicat_E9AA321B20B301FC");

            entity.Property(e => e.NationalId)
                .HasMaxLength(14)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NationalID");
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(30);
            entity.Property(e => e.LastName).HasMaxLength(30);                        
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK_Courses_C92D7187B969954B");

            entity.HasIndex(e => e.Code, "UQ_Courses_A25C5AA766F2798B").IsUnique();

            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.DepartmentId)
                .HasDefaultValue(1)
                .HasColumnName("DepartmentID");
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Department).WithMany(p => p.Courses)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_CoursesDepartm_367C1819");

            entity.HasOne(d => d.PrerequisiteCourse).WithMany(p => p.InversePrerequisiteCourse)
                .HasForeignKey(d => d.PrerequisiteCourseId)
                .HasConstraintName("FK_CoursesPrerequ_3493CFA7");
        });

        modelBuilder.Entity<CourseEnrollment>(entity =>
        {
            entity.HasKey(e => e.EnrollmentId).HasName("PK_CourseEn_7F6877FB4D772154");

            entity.Property(e => e.EnrollmentId).HasColumnName("EnrollmentID");
            entity.Property(e => e.ClassWork).HasColumnType("decimal(4, 2)");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.EnrollmentDate).HasColumnType("datetime");
            entity.Property(e => e.FinalGrade).HasColumnType("decimal(4, 2)");
            entity.Property(e => e.StudentId)
                .HasMaxLength(14)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("StudentID");

            entity.HasOne(d => d.Course).WithMany(p => p.CourseEnrollments)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_CourseEnrCours_5F7E2DAC");

            entity.HasOne(d => d.Student).WithMany(p => p.CourseEnrollments)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_CourseEnrStude_5E8A0973");
        });

        modelBuilder.Entity<CourseTeaching>(entity =>
        {
            entity.HasKey(e => e.TeachingId).HasName("PK_CourseTe_69B6BA5EECE67C25");

            entity.ToTable("CourseTeaching");

            entity.Property(e => e.TeachingId).HasColumnName("TeachingID");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.ProfessorId)
                .HasMaxLength(14)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ProfessorID");
            entity.Property(e => e.Taid)
                .HasMaxLength(14)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TAID");

            entity.HasOne(d => d.Course).WithMany(p => p.CourseTeachings)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_CourseTeaCours_625A9A57");

            entity.HasOne(d => d.Professor).WithMany(p => p.CourseTeachings)
                .HasForeignKey(d => d.ProfessorId)
                .HasConstraintName("FK_CourseTeaProfe_634EBE90");

            entity.HasOne(d => d.Ta).WithMany(p => p.CourseTeachings)
                .HasForeignKey(d => d.Taid)
                .HasConstraintName("FK_CourseTeacTAID_6442E2C9");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK_Departme_B2079BCDD8AB6AAA");

            entity.HasIndex(e => e.Name, "UQ_Departme_737584F674071129").IsUnique();

            entity.HasIndex(e => e.Code, "UQ_Departme_A25C5AA7E8C24511").IsUnique();

            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.HeadId)
                .HasMaxLength(14)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("HeadID");
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Head).WithMany(p => p.Departments)
                .HasForeignKey(d => d.HeadId)
                .HasConstraintName("FK_Dept_Head_Prof");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK_Feedback_6A4BEDF6151BB7B9");

            entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");
            entity.Property(e => e.Question).HasMaxLength(50);
        });

        modelBuilder.Entity<FeedbackResponse>(entity =>
        {
            entity.HasKey(e => e.ResponseId).HasName("PK_Feedback_1AAA640C0178008C");

            entity.Property(e => e.ResponseId).HasColumnName("ResponseID");
            entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");
            entity.Property(e => e.ResponseText).HasMaxLength(50);
            entity.Property(e => e.SubmittedByStudentId)
                .HasMaxLength(14)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SubmittedByStudentID");

            entity.HasOne(d => d.Feedback).WithMany(p => p.FeedbackResponses)
                .HasForeignKey(d => d.FeedbackId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_FeedbackRFeedb_56E8E7AB");

            entity.HasOne(d => d.SubmittedByStudent).WithMany(p => p.FeedbackResponses)
                .HasForeignKey(d => d.SubmittedByStudentId)
                .HasConstraintName("FK_FeedbackRSubmi_57DD0BE4");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK_Notifica_20CF2E32989922FE");

            entity.Property(e => e.NotificationId).HasColumnName("NotificationID");
            entity.Property(e => e.Message).HasMaxLength(50);
            entity.Property(e => e.SentBy)
                .HasMaxLength(14)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SentTo)
                .HasMaxLength(14)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.SentByNavigation).WithMany(p => p.NotificationSentByNavigations)
                .HasForeignKey(d => d.SentBy)
                .HasConstraintName("FK_NotificatSentB_51300E55");

            entity.HasOne(d => d.SentToNavigation).WithMany(p => p.NotificationSentToNavigations)
                .HasForeignKey(d => d.SentTo)
                .HasConstraintName("FK_NotificatSentT_5224328E");
        });

        modelBuilder.Entity<PasswordResetTicket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("PK_Password_712CC627AFF1D053");

            entity.Property(e => e.TicketId).HasColumnName("TicketID");
            entity.Property(e => e.AdminId)
                .HasMaxLength(14)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AdminID");
            entity.Property(e => e.RequestDate).HasColumnType("datetime");
            entity.Property(e => e.ResetDate).HasColumnType("datetime");
            entity.Property(e => e.StudentId)
                .HasMaxLength(14)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("StudentID");

            entity.HasOne(d => d.Admin).WithMany(p => p.PasswordResetTickets)
                .HasForeignKey(d => d.AdminId)
                .HasConstraintName("FK_PasswordRAdmin_5BAD9CC8");

            entity.HasOne(d => d.Student).WithMany(p => p.PasswordResetTickets)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_PasswordRStude_5AB9788F");
        });

        modelBuilder.Entity<Professor>(entity =>
        {
            entity.HasKey(e => e.ProfessorId).HasName("PK_Professo_9003596931DA9444");

            entity.Property(e => e.ProfessorId)
                .HasMaxLength(14)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ProfessorID");
            entity.Property(e => e.DepartmentId)
                .HasDefaultValue(1)
                .HasColumnName("DepartmentID");
            entity.Property(e => e.DocUni).HasMaxLength(50);
            entity.Property(e => e.OfficeLocation).HasMaxLength(50);
            entity.Property(e => e.PhDat)
                .HasMaxLength(50)
                .HasColumnName("PhDAt");
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.Department).WithMany(p => p.Professors)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_ProfessorDepar_2645B050");

            entity.HasOne(d => d.ProfessorNavigation).WithOne(p => p.Professor)
                .HasForeignKey<Professor>(d => d.ProfessorId)
                .HasConstraintName("FK_ProfessorProfe_245D67DE");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("PK_Question_0DC06F8CB985952F");

            entity.Property(e => e.QuestionId).HasColumnName("QuestionID");
            entity.Property(e => e.Grade).HasColumnType("decimal(4, 2)");
            entity.Property(e => e.TestId).HasColumnName("TestID");

            entity.HasOne(d => d.Test).WithMany(p => p.Questions)
                .HasForeignKey(d => d.TestId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_QuestionsTestI_46B27FE2");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.NationalId).HasName("PK_Students_E9AA321BAB929904");

            entity.Property(e => e.NationalId)
                .HasMaxLength(14)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NationalID");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.StudentId).HasMaxLength(15);
            entity.Property(e => e.TotalGpa)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("TotalGPA");

            entity.HasOne(d => d.Department).WithMany(p => p.Students)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_StudentsDepart_2B0A656D");

            entity.HasOne(d => d.National).WithOne(p => p.Student)
                .HasForeignKey<Student>(d => d.NationalId)
                .HasConstraintName("FK_StudentsNation_29221CFB");
        });

        modelBuilder.Entity<Submission>(entity =>
        {
            entity.HasKey(e => e.SubmissionId).HasName("PK_Submissi_449EE1052A1041B0");

            entity.Property(e => e.SubmissionId).HasColumnName("SubmissionID");
            entity.Property(e => e.StudentId)
                .HasMaxLength(14)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("StudentID");
            entity.Property(e => e.SubmissionDate).HasColumnType("datetime");
            entity.Property(e => e.SubmissionLink).HasMaxLength(50);
            entity.Property(e => e.TaskId).HasColumnName("TaskID");

            entity.HasOne(d => d.Student).WithMany(p => p.Submissions)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_SubmissioStude_3F115E1A");

            entity.HasOne(d => d.Task).WithMany(p => p.Submissions)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_SubmissioTaskI_3E1D39E1");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PK_Tasks_7C6949D17FEFD15C");

            entity.Property(e => e.TaskId).HasColumnName("TaskID");
            entity.Property(e => e.AssignedByTaid)
                .HasMaxLength(14)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AssignedByTAID");
            entity.Property(e => e.Content).HasMaxLength(50);
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.Deadline).HasColumnType("datetime");
            entity.Property(e => e.Grade).HasColumnType("decimal(4, 2)");
            entity.Property(e => e.TaskLink).HasMaxLength(150);
            entity.Property(e => e.Type).HasMaxLength(50);

            entity.HasOne(d => d.AssignedByTa).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.AssignedByTaid)
                .HasConstraintName("FK_TasksAssignedB_3B40CD36");

            entity.HasOne(d => d.Course).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TasksCourseID_395884C4");
        });

        modelBuilder.Entity<TeachingAssistant>(entity =>
        {
            entity.HasKey(e => e.Taid).HasName("PK_Teaching_B43FE34A3EE17177");

            entity.Property(e => e.Taid)
                .HasMaxLength(14)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TAID");
            entity.Property(e => e.AcademicDegree).HasMaxLength(50);
            entity.Property(e => e.AssistingProfessorId)
                .HasMaxLength(14)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AssistingProfessorID");
            entity.Property(e => e.DepartmentId)
                .HasDefaultValue(1)
                .HasColumnName("DepartmentID");
            entity.Property(e => e.Faculty).HasMaxLength(50);
            entity.Property(e => e.University).HasMaxLength(50);

            entity.HasOne(d => d.AssistingProfessor).WithMany(p => p.TeachingAssistantAssistingProfessors)
                .HasForeignKey(d => d.AssistingProfessorId)
                .HasConstraintName("FK_TeachingAAssis_30C33EC3");

            entity.HasOne(d => d.Department).WithMany(p => p.TeachingAssistants)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_TeachingADepar_2FCF1A8A");

            entity.HasOne(d => d.Ta).WithOne(p => p.TeachingAssistantTa)
                .HasForeignKey<TeachingAssistant>(d => d.Taid)
                .HasConstraintName("FK_TeachingAsTAID_2DE6D218");
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity.HasKey(e => e.TestId).HasName("PK_Tests_8CC33100E061DD7A");

            entity.Property(e => e.TestId).HasColumnName("TestID");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.MadeBy)
                .HasMaxLength(14)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TotalGrade).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Type).HasMaxLength(50);

            entity.HasOne(d => d.Course).WithMany(p => p.Tests)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TestsCourseID_42E1EEFE");

            entity.HasOne(d => d.MadeByNavigation).WithMany(p => p.Tests)
                .HasForeignKey(d => d.MadeBy)
                .HasConstraintName("FK_TestsMadeBy_41EDCAC5");
        });

        modelBuilder.Entity<TestSubmission>(entity =>
        {
            entity.HasKey(e => e.TestSubmissionId).HasName("PK_TestSubm_BB934B8F6CF7B93B");

            entity.Property(e => e.TestSubmissionId).HasColumnName("TestSubmissionID");
            entity.Property(e => e.StudentId)
                .HasMaxLength(14)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("StudentID");
            entity.Property(e => e.SubmissionDate).HasColumnType("datetime");
            entity.Property(e => e.TestId).HasColumnName("TestID");

            entity.HasOne(d => d.Student).WithMany(p => p.TestSubmissions)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_TestSubmiStude_4A8310C6");

            entity.HasOne(d => d.Test).WithMany(p => p.TestSubmissions)
                .HasForeignKey(d => d.TestId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TestSubmiTestI_498EEC8D");
        });

        modelBuilder.Entity<Timetable>(entity =>
        {
            entity.HasKey(e => e.TimetableId).HasName("PK_Timetabl_68413F4011C547EC");

            entity.Property(e => e.TimetableId).HasColumnName("TimetableID");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.Day).HasMaxLength(20);
            entity.Property(e => e.ProfessorId)
                .HasMaxLength(14)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ProfessorID");

            entity.HasOne(d => d.Course).WithMany(p => p.Timetables)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TimetableCours_4D5F7D71");

            entity.HasOne(d => d.Professor).WithMany(p => p.Timetables)
                .HasForeignKey(d => d.ProfessorId)
                .HasConstraintName("FK_TimetableProfe_4E53A1AA");
        });     
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
