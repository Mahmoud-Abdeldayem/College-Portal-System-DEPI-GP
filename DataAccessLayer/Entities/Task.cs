using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities;

public partial class Task
{
    public int TaskId { get; set; }

    public int? CourseId { get; set; }

    public decimal Grade { get; set; }

    public DateTime Deadline { get; set; }

    public string Content { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string? AssignedByTaid { get; set; }

    public virtual TeachingAssistant? AssignedByTa { get; set; }

    public virtual Course? Course { get; set; }

    public virtual ICollection<Submission> Submissions { get; set; } = new List<Submission>();
}
