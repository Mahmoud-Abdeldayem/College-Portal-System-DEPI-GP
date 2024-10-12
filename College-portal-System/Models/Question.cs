using System;
using System.Collections.Generic;

namespace College_portal_System.Models;

public partial class Question
{
    public int QuestionId { get; set; }

    public int? TestId { get; set; }

    public int QuestionNumber { get; set; }

    public string QuestionText { get; set; } = null!;

    public decimal Grade { get; set; }

    public virtual Test? Test { get; set; }
}
