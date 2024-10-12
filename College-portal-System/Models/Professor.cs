using System;
using System.Collections.Generic;

namespace College_portal_System.Models;

public partial class Professor
{
    public string ProfessorId { get; set; } = null!;

    public string PhDat { get; set; } = null!;

    public int EnterYear { get; set; }

    public string? OfficeLocation { get; set; }

    public string DocUni { get; set; } = null!;

    public string Title { get; set; } = null!;

    public int? DepartmentId { get; set; }

    public virtual ICollection<CourseTeaching> CourseTeachings { get; set; } = new List<CourseTeaching>();

    public virtual Department? Department { get; set; }

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    public virtual ApplicationUser ProfessorNavigation { get; set; } = null!;

    public virtual ICollection<Timetable> Timetables { get; set; } = new List<Timetable>();
}
