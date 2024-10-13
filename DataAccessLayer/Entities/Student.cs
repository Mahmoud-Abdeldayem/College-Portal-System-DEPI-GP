using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities;

public partial class Student
{
    public string NationalId { get; set; } = null!;

    public string StudentId { get; set; } = null!;

    public DateOnly EntryYear { get; set; }

    public DateOnly? GradYear { get; set; }

    public bool? CurrentState { get; set; }

    public bool? CollegeState { get; set; }

    public short? CurrentYear { get; set; }

    public decimal? TotalGpa { get; set; }

    public int HoursTaken { get; set; }

    public int? DepartmentId { get; set; }

    public virtual ICollection<CourseEnrollment> CourseEnrollments { get; set; } = new List<CourseEnrollment>();

    public virtual Department? Department { get; set; }

    public virtual ICollection<FeedbackResponse> FeedbackResponses { get; set; } = new List<FeedbackResponse>();

    public virtual ApplicationUser National { get; set; } = null!;

    public virtual ICollection<PasswordResetTicket> PasswordResetTickets { get; set; } = new List<PasswordResetTicket>();

    public virtual ICollection<Submission> Submissions { get; set; } = new List<Submission>();

    public virtual ICollection<TestSubmission> TestSubmissions { get; set; } = new List<TestSubmission>();
}
