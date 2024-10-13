using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities;

public partial class Submission
{
    public int SubmissionId { get; set; }

    public int? TaskId { get; set; }

    public string? StudentId { get; set; }

    public string SubmissionLink { get; set; } = null!;

    public DateTime SubmissionDate { get; set; }

    public virtual Student? Student { get; set; }

    public virtual Task? Task { get; set; }
}
