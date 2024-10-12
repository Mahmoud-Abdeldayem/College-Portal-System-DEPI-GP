using System;
using System.Collections.Generic;

namespace College_portal_System.Models;

public partial class Test
{
    public int TestId { get; set; }

    public decimal TotalGrade { get; set; }

    public string? MadeBy { get; set; }

    public int? CourseId { get; set; }

    public DateTime Date { get; set; }

    public TimeOnly Time { get; set; }

    public string Type { get; set; } = null!;

    public TimeOnly Duration { get; set; }

    public virtual Course? Course { get; set; }

    public virtual ApplicationUser? MadeByNavigation { get; set; }

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    public virtual ICollection<TestSubmission> TestSubmissions { get; set; } = new List<TestSubmission>();
}
