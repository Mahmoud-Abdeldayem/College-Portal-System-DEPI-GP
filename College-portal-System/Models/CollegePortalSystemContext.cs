using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace College_portal_System.Models;

public partial class CollegePortalSystemContext : DbContext
{
    public CollegePortalSystemContext()
    {
    }

    public CollegePortalSystemContext(DbContextOptions<CollegePortalSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }

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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-NKNL1D9;Initial Catalog=college_portal_system;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApplicationUser>(entity =>
        {
            entity.HasKey(e => e.NationalId).HasName("PK__Applicat__E9AA321BE627747C");

            entity.ToTable("ApplicationUser");

            entity.Property(e => e.NationalId)
                .HasMaxLength(14)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NationalID");
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(30);
            entity.Property(e => e.LastName).HasMaxLength(30);
            entity.Property(e => e.MiddleName).HasMaxLength(30);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.RecoveryEmail).HasMaxLength(50);
            entity.Property(e => e.Role).HasMaxLength(50);
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__Course__C92D7187855F69AC");

            entity.ToTable("Course");

            entity.HasIndex(e => e.Code, "UQ__Course__A25C5AA7C10A2C6D").IsUnique();

            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Department).WithMany(p => p.Courses)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Course__Departme__4CA06362");

            entity.HasOne(d => d.PrerequisiteCourse).WithMany(p => p.InversePrerequisiteCourse)
                .HasForeignKey(d => d.PrerequisiteCourseId)
                .HasConstraintName("FK__Course__Prerequi__4BAC3F29");
        });

        modelBuilder.Entity<CourseEnrollment>(entity =>
        {
            entity.HasKey(e => e.EnrollmentId).HasName("PK__CourseEn__7F6877FBBDFEAB77");

            entity.ToTable("CourseEnrollment");

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
                .HasConstraintName("FK__CourseEnr__Cours__75A278F5");

            entity.HasOne(d => d.Student).WithMany(p => p.CourseEnrollments)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__CourseEnr__Stude__74AE54BC");
        });

        modelBuilder.Entity<CourseTeaching>(entity =>
        {
            entity.HasKey(e => e.TeachingId).HasName("PK__CourseTe__69B6BA5EF76A21F7");

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
                .HasConstraintName("FK__CourseTea__Cours__787EE5A0");

            entity.HasOne(d => d.Professor).WithMany(p => p.CourseTeachings)
                .HasForeignKey(d => d.ProfessorId)
                .HasConstraintName("FK__CourseTea__Profe__797309D9");

            entity.HasOne(d => d.Ta).WithMany(p => p.CourseTeachings)
                .HasForeignKey(d => d.Taid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__CourseTeac__TAID__7A672E12");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BCDFB0C332B");

            entity.ToTable("Department");

            entity.HasIndex(e => e.Name, "UQ__Departme__737584F6B9CE87B6").IsUnique();

            entity.HasIndex(e => e.Code, "UQ__Departme__A25C5AA7654C8C5C").IsUnique();

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
                .HasConstraintName("FK_HeadID_Professor");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__6A4BEDF65395306F");

            entity.ToTable("Feedback");

            entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");
            entity.Property(e => e.Question).HasMaxLength(50);
            entity.Property(e => e.SubmittedByStudentId)
                .HasMaxLength(14)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SubmittedByStudentID");

            entity.HasOne(d => d.SubmittedByStudent).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.SubmittedByStudentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Feedback__Submit__6A30C649");
        });

        modelBuilder.Entity<FeedbackResponse>(entity =>
        {
            entity.HasKey(e => e.ResponseId).HasName("PK__Feedback__1AAA640C1F97FED9");

            entity.ToTable("FeedbackResponse");

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
                .HasConstraintName("FK__FeedbackR__Feedb__6D0D32F4");

            entity.HasOne(d => d.SubmittedByStudent).WithMany(p => p.FeedbackResponses)
                .HasForeignKey(d => d.SubmittedByStudentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__FeedbackR__Submi__6E01572D");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__Notifica__20CF2E3270AA9CE8");

            entity.ToTable("Notification");

            entity.Property(e => e.NotificationId).HasColumnName("NotificationID");
            entity.Property(e => e.Message).HasMaxLength(50);
            entity.Property(e => e.SentByAdminId)
                .HasMaxLength(14)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SentByAdminID");

            entity.HasOne(d => d.SentByAdmin).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.SentByAdminId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Notificat__SentB__6754599E");
        });

        modelBuilder.Entity<PasswordResetTicket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("PK__Password__712CC62733205D40");

            entity.ToTable("PasswordResetTicket");

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
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__PasswordR__Admin__71D1E811");

            entity.HasOne(d => d.Student).WithMany(p => p.PasswordResetTickets)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__PasswordR__Stude__70DDC3D8");
        });

        modelBuilder.Entity<Professor>(entity =>
        {
            entity.HasKey(e => e.ProfessorId).HasName("PK__Professo__90035969327A97DE");

            entity.ToTable("Professor");

            entity.Property(e => e.ProfessorId)
                .HasMaxLength(14)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ProfessorID");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.DocUni).HasMaxLength(50);
            entity.Property(e => e.OfficeLocation).HasMaxLength(50);
            entity.Property(e => e.PhDat)
                .HasMaxLength(50)
                .HasColumnName("PhDAt");
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.Department).WithMany(p => p.Professors)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Professor__Depar__47DBAE45");

            entity.HasOne(d => d.ProfessorNavigation).WithOne(p => p.Professor)
                .HasForeignKey<Professor>(d => d.ProfessorId)
                .HasConstraintName("FK__Professor__Profe__46E78A0C");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("PK__Question__0DC06F8C3A2184E2");

            entity.ToTable("Question");

            entity.Property(e => e.QuestionId).HasColumnName("QuestionID");
            entity.Property(e => e.Grade).HasColumnType("decimal(4, 2)");
            entity.Property(e => e.TestId).HasColumnName("TestID");

            entity.HasOne(d => d.Test).WithMany(p => p.Questions)
                .HasForeignKey(d => d.TestId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Question__TestID__5CD6CB2B");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.NationalId).HasName("PK__Student__E9AA321B2B4A566F");

            entity.ToTable("Student");

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
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Student__Departm__3F466844");

            entity.HasOne(d => d.National).WithOne(p => p.Student)
                .HasForeignKey<Student>(d => d.NationalId)
                .HasConstraintName("FK__Student__Nationa__3D5E1FD2");
        });

        modelBuilder.Entity<Submission>(entity =>
        {
            entity.HasKey(e => e.SubmissionId).HasName("PK__Submissi__449EE105C248818A");

            entity.ToTable("Submission");

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
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Submissio__Stude__5535A963");

            entity.HasOne(d => d.Task).WithMany(p => p.Submissions)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Submissio__TaskI__5441852A");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PK__Task__7C6949D17ABE73E7");

            entity.ToTable("Task");

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
            entity.Property(e => e.Type).HasMaxLength(50);

            entity.HasOne(d => d.AssignedByTa).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.AssignedByTaid)
                .HasConstraintName("FK__Task__AssignedBy__5165187F");

            entity.HasOne(d => d.Course).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Task__CourseID__4F7CD00D");
        });

        modelBuilder.Entity<TeachingAssistant>(entity =>
        {
            entity.HasKey(e => e.Taid).HasName("PK__Teaching__B43FE34A7A4E7D04");

            entity.ToTable("TeachingAssistant");

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
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Faculty).HasMaxLength(50);
            entity.Property(e => e.University).HasMaxLength(50);

            entity.HasOne(d => d.AssistingProfessor).WithMany(p => p.TeachingAssistantAssistingProfessors)
                .HasForeignKey(d => d.AssistingProfessorId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__TeachingA__Assis__440B1D61");

            entity.HasOne(d => d.Department).WithMany(p => p.TeachingAssistants)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__TeachingA__Depar__4316F928");

            entity.HasOne(d => d.Ta).WithOne(p => p.TeachingAssistantTa)
                .HasForeignKey<TeachingAssistant>(d => d.Taid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TeachingAs__TAID__4222D4EF");
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity.HasKey(e => e.TestId).HasName("PK__Test__8CC33100D07E6E88");

            entity.ToTable("Test");

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
                .HasConstraintName("FK__Test__CourseID__59063A47");

            entity.HasOne(d => d.MadeByNavigation).WithMany(p => p.Tests)
                .HasForeignKey(d => d.MadeBy)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Test__MadeBy__5812160E");
        });

        modelBuilder.Entity<TestSubmission>(entity =>
        {
            entity.HasKey(e => e.TestSubmissionId).HasName("PK__TestSubm__BB934B8F5942FAE9");

            entity.ToTable("TestSubmission");

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
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__TestSubmi__Stude__60A75C0F");

            entity.HasOne(d => d.Test).WithMany(p => p.TestSubmissions)
                .HasForeignKey(d => d.TestId)
                .HasConstraintName("FK__TestSubmi__TestI__5FB337D6");
        });

        modelBuilder.Entity<Timetable>(entity =>
        {
            entity.HasKey(e => e.TimetableId).HasName("PK__Timetabl__68413F40B3D210D7");

            entity.ToTable("Timetable");

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
                .HasConstraintName("FK__Timetable__Cours__6383C8BA");

            entity.HasOne(d => d.Professor).WithMany(p => p.Timetables)
                .HasForeignKey(d => d.ProfessorId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Timetable__Profe__6477ECF3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
