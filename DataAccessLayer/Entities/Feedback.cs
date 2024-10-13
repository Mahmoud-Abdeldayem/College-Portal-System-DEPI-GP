using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities;

public partial class Feedback
{
    public int FeedbackId { get; set; }

    public string Question { get; set; } = null!;

    public virtual ICollection<FeedbackResponse> FeedbackResponses { get; set; } = new List<FeedbackResponse>();
}
