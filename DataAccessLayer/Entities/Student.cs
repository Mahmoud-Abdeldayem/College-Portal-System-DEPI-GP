using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities;

public partial class Student
{
    public string NationalId { get; set; } = null!;
    public string StudentId { get; set; } = null!;
    public DateTime EntryYear { get; set; } = new DateTime(DateTime.Now.Year, 1, 1);

    public DateTime? GradYear { get; set; }

    public bool? CurrentState { get; set; }

    public bool? CollegeState { get; set; }

    public short? CurrentYear { get; set; } = 1;

    public decimal? TotalGpa { get; set; } = 0;

    public int HoursTaken { get; set; } = 0;

    public virtual ICollection<CourseEnrollment> CourseEnrollments { get; set; } = new List<CourseEnrollment>();

    public virtual Department? Department { get; set; }
    public int? DepartmentId { get; set; }

    public virtual ICollection<FeedbackResponse> FeedbackResponses { get; set; } = new List<FeedbackResponse>();

    public virtual ApplicationUser? National { get; set; }

    public virtual ICollection<PasswordResetTicket> PasswordResetTickets { get; set; } = new List<PasswordResetTicket>();

    public virtual ICollection<Submission> Submissions { get; set; } = new List<Submission>();

    public virtual ICollection<TestSubmission> TestSubmissions { get; set; } = new List<TestSubmission>();
}
