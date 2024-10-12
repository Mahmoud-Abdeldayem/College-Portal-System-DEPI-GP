using System;
using System.Collections.Generic;

namespace College_portal_System.Models;

public partial class CourseTeaching
{
    public int TeachingId { get; set; }

    public int? CourseId { get; set; }

    public string? ProfessorId { get; set; }

    public string? Taid { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Professor? Professor { get; set; }

    public virtual TeachingAssistant? Ta { get; set; }
}
