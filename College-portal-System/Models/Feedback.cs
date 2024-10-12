using System;
using System.Collections.Generic;

namespace College_portal_System.Models;

public partial class Feedback
{
    public int FeedbackId { get; set; }

    public string Question { get; set; } = null!;

    public string? SubmittedByStudentId { get; set; }

    public virtual ICollection<FeedbackResponse> FeedbackResponses { get; set; } = new List<FeedbackResponse>();

    public virtual Student? SubmittedByStudent { get; set; }
}
