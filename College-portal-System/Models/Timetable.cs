using System;
using System.Collections.Generic;

namespace College_portal_System.Models;

public partial class Timetable
{
    public int TimetableId { get; set; }

    public int? CourseId { get; set; }

    public string? ProfessorId { get; set; }

    public string Day { get; set; } = null!;

    public TimeOnly Time { get; set; }

    public TimeOnly Duration { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Professor? Professor { get; set; }
}
