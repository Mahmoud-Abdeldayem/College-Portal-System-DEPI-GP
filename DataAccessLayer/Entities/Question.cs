using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities;

public partial class Question
{
    public int QuestionId { get; set; }

    public int? TestId { get; set; }

    public int QuestionNumber { get; set; }

    public string QuestionText { get; set; } = null!;

    public decimal Grade { get; set; }
    public string Diffcuilty { get; set; } = string.Empty;

    public virtual Test? Test { get; set; }
}
