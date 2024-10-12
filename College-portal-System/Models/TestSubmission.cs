﻿using System;
using System.Collections.Generic;

namespace College_portal_System.Models;

public partial class TestSubmission
{
    public int TestSubmissionId { get; set; }

    public int? TestId { get; set; }

    public string? StudentId { get; set; }

    public DateTime SubmissionDate { get; set; }

    public virtual Student? Student { get; set; }

    public virtual Test? Test { get; set; }
}