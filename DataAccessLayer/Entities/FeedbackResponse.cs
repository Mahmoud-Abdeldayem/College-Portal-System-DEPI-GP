using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities;

public partial class FeedbackResponse
{
    public int ResponseId { get; set; }

    public int? FeedbackId { get; set; }

    public string ResponseText { get; set; } = null!;

    public string? SubmittedByStudentId { get; set; }

    public virtual Feedback? Feedback { get; set; }

    public virtual Student? SubmittedByStudent { get; set; }
}
